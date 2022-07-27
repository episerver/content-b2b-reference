using CommerceApiSDK.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Sample.Services.Catalog;

public class ProductService : BaseService, IProductService
{
    private readonly CommerceApiSDK.Services.Interfaces.IProductService _productClient;
    private readonly IAutocompleteService _autocompleteService;
    private readonly ICatalogpagesService _catalogPagesClient;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IRealTimeInventoryService _realTimeInventoryService;
    private readonly IRealTimePricingService _realTimePricingService;

    public ProductService(
        CommerceApiSDK.Services.Interfaces.IProductService productClient,
        ICatalogpagesService catalogPagesClient,
        IAutocompleteService autocompleteService,
        IHttpContextAccessor httpContextAccessor,
        IRealTimeInventoryService realTimeInventoryService,
        IRealTimePricingService realTimePricingService)
    {
        _productClient = productClient;
        _catalogPagesClient = catalogPagesClient;
        _autocompleteService = autocompleteService;
        _httpContextAccessor = httpContextAccessor;
        _realTimeInventoryService = realTimeInventoryService;
        _realTimePricingService = realTimePricingService;
    }

    public virtual async Task<GetProductResult> GetProduct(string productId)
    {
        return await _productClient.GetProduct(Guid.Parse(productId), null);
    }

    public virtual async Task<CatalogPage> GetCatalogPage(string path)
    {
        return await _catalogPagesClient.GetProductCatalogInformation(path);
    }

    public virtual async Task<GetProductCollectionResult> GetProductCrossSells(string productId)
    {
        var paramters = new ProductQueryParameters() { Expand = "crosssells" };
        var result = await _productClient.GetProduct(Guid.Parse(productId), paramters);
        return new GetProductCollectionResult()
        {
            Products = result.Product?.CrossSells
        };
    }

    public virtual async Task<GetProductCollectionResult> GetProducts(
        string categoryId,
        List<string> expands,
        List<string> priceFilters,
        List<string> queries,
        string sortBy,
        int? pageIndex,
        int? pageSize,
        List<Guid?> attributeFilters,
        List<Guid?> brandIds,
        List<Guid?> productLineIds,
        string searchWithinQuery = null
    )
    {
        var str1 = string.Empty;
        if (queries != null)
        {
            str1 = "";
            str1 = queries
                .Where(str2 => !string.IsNullOrEmpty(str2))
                .Aggregate(str1, (current, str2) => current + str2 + '+');
            str1 = str1.TrimEnd('+');
        }
        var parameters = new ProductsQueryParameters()
        {
            CategoryId = string.IsNullOrEmpty(categoryId) ? null : Guid.Parse(categoryId),
            Expand = expands,
            PriceFilters = priceFilters,
            Query = str1,
            Sort = sortBy,
            Page = pageIndex,
            PageSize = pageSize,
            AttributeValueIds = attributeFilters,
            SearchWithin = searchWithinQuery
        };

        if (brandIds?.Any() ?? false)
        {
            parameters.BrandIds = brandIds;
        }

        if (productLineIds?.Any() ?? false)
        {
            parameters.ProductLineIds = productLineIds;
        }
        var products = await _productClient.GetProductsNoCache(parameters);
        if (products != null && products.Products.Any())
        {
            foreach (var product in products.Products)
            {
                product.Availability.Message = GetAvailabilityMessage(
                    Convert.ToInt32(product.QtyOnHand)
                );
            }
        }
        return products;
    }

    public virtual async Task<GetProductResult> GetProduct(IEnumerable<string> expands, string productId)
    {
        var str1 = string.Empty;
        if (expands != null)
        {
            str1 = "";
            str1 = expands
                .Where(str2 => !string.IsNullOrEmpty(str2))
                .Aggregate(str1, (current, str2) => current + str2 + ',');
            str1 = str1.TrimEnd(',');
        }
        var paramters = new ProductQueryParameters() { Expand = str1 };
        return await _productClient.GetProduct(Guid.Parse(productId), paramters);
    }

    public virtual async Task<AutocompleteResult> GetAutoCompleteProducts(string query)
    {
        var parameters = new AutocompleteQueryParameters()
        {
            Query = query,
            CategoryEnabled = true,
            BrandEnabled = true,
            ContentEnabled = true,
            ProductEnabled = true,
            PageSize = 25
        };
        return await _autocompleteService.GetAutocompleteResults(parameters);
    }

    public virtual async Task<IEnumerable<string>> GetAllProductIds()
    {
        var parameters = new ProductsQueryParameters()
        {
            PageSize = 32,
            Page = 1,
            Expand = new List<string> { "styledproducts" },
        };
        var pageSize = 32;
        var pageIndex = 1;
        var remainingCount = 1;
        var expands = new List<string> { "styledproducts" };
        IList<string> products = new List<string>();
        while (remainingCount > 0)
        {
            var productCollection = await _productClient.GetProducts(parameters);
            if (productCollection != null && productCollection.Products.Any())
            {
                foreach (var product in productCollection.Products)
                {
                    products.Add(product.Id.ToString());
                    if (product.StyledProducts.Count > 0)
                    {
                        foreach (var styleProduct in product.StyledProducts)
                        {
                            products.Add(styleProduct.ProductId.ToString());
                        }
                    }
                }
                pageIndex++;
                remainingCount =
                    productCollection.Pagination.TotalItemCount - (pageIndex - 1) * pageSize;
            }
            else
            {
                //In case of any error after first or any consecutive call remove all products and return empty object
                products.Clear();
                return products;
            }
        }
        return products;
    }

    public virtual async Task<ProductPrice> GetProductPrice(string productId, string uom, decimal qty, bool realtime)
    {
        if (realtime)
        {
            var result = await _realTimePricingService.GetProductRealTimePrices(new RealTimePricingParameters
            {
                ProductPriceParameters = new List<ProductPriceQueryParameters>
                {
                    new ProductPriceQueryParameters
                    {
                        ProductId = new Guid(productId),
                        UnitOfMeasure = uom,
                        QtyOrdered = qty
                    }
                }
            });
            return result?.RealTimePricingResults.FirstOrDefault();
        }

        return await _productClient.GetProductPrice(
            Guid.Parse(productId),
            new ProductPriceQueryParameters
            {
                QtyOrdered = qty,
                UnitOfMeasure = uom
            }
        );
    }

    public virtual async Task<ProductInventory> GetProductRealTimeInventory(string productId)
    {
        var result = await _realTimeInventoryService.GetProductRealTimeInventory(new RealTimeInventoryParameters
        {
            ProductIds = new List<Guid> {new Guid(productId) }
        });
        return result?.RealTimeInventoryResults.FirstOrDefault();
    }

    public virtual async Task<Product> GetProductByName(string productName, IEnumerable<string> expands)
    {
        var parameters = new ProductsQueryParameters()
        {
            ExtendedNames = new List<string>() { productName },
            Expand = expands.ToList()
        };
        var result = await _productClient.GetProducts(parameters);
        if (result.Products != null && result.Products.Any())
        {
            result.Products.FirstOrDefault().Availability.Message = GetAvailabilityMessage(
                Convert.ToInt32(result.Products.FirstOrDefault().QtyOnHand)
            );
            return result.Products.FirstOrDefault();
        }
        else
            return null;
    }

    public virtual string GetAvailabilityMessage(int qtyOnHand)
    {
        var lowStockSetting = "0";
        var lowStockQty = 0;
        var availabilityMessage = "Out of Stock";
        if (lowStockSetting != null && !string.IsNullOrEmpty(lowStockSetting))
            lowStockQty = Convert.ToInt32(lowStockSetting);
        if (qtyOnHand > 0 && qtyOnHand < lowStockQty)
            availabilityMessage = "Low Stock";
        else if (qtyOnHand > 0 && qtyOnHand > lowStockQty)
            availabilityMessage = "Available";
        else if (qtyOnHand < 1)
            availabilityMessage = "Out of Stock";

        return availabilityMessage;
    }

    public virtual async Task<GetProductCollectionResult> GetCompareProducts(List<string> expands)
    {
        var productsToCompare = _httpContextAccessor.HttpContext.Request.Cookies[
            "ProductsToCompare"
        ];
        if (productsToCompare != null)
        {
            var productIds = productsToCompare
                .Split('|')
                .Select(Guid.Parse)
                .Cast<Guid?>()
                .ToList();
            var parameters = new ProductsQueryParameters()
            {
                Expand = expands,
                ProductIds = productIds
            };

            return await _productClient.GetProductsNoCache(parameters);
        }
        return new GetProductCollectionResult();
    }

    public virtual async Task<GetProductCollectionResult> GetRecentlyViewedProducts()
    {
        var parameters = new ProductsQueryParameters()
        {
            Expand = new List<string>() { "pricing", "recentlyviewed", "brand" }
        };
        return await _productClient.GetProducts(parameters);
    }
}
