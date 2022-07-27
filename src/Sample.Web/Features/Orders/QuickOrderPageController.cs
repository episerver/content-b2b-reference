using EPiServer.Logging;
using static System.String;
using CommerceApiSettings = Sample.Web.Infrastructure.CommerceApiSettings;
using Sample.Services.Catalog;
using Sample.Services.Cart;

namespace Sample.Web.Features.Orders;

[LoginRequired]
public class QuickOrderPageController : PageControllerBase<QuickOrderPage>
{
    private IProductService _productService;
    private readonly ICartService _cartService;
    private readonly LocalizationService _localizationService;
    private readonly CommerceApiSettings _commerceApiSettings;

    public QuickOrderPageController(IProductService productService,
        ICartService cartService,
        IOptionsMonitor<CommerceApiSettings> commerceApiSettings,
        LocalizationService localizationService)
    {
        _productService = productService;
        _cartService = cartService;
        _commerceApiSettings = commerceApiSettings.CurrentValue;
        _localizationService = localizationService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(QuickOrderPage currentPage)
    {
        var model = new QuickOrderPageViewModel(currentPage)
        {
            EmptyErrorMessage = _localizationService.GetString("/QuickOrder/Form/Error/Empty"),
            InvalidQtyErrorMessage = _localizationService.GetString("/QuickOrder/Form/Error/InvalidQuantity"),
            EmptyProductErrorMessage = _localizationService.GetString("/QuickOrder/Form/Error/EmptyProduct")
        };
        return await Task.FromResult(View(model));
    }

    [HttpPost]
    public async Task<IActionResult> SelectProduct([FromBody] ProductDataModel productData)
    {
        if (IsNullOrEmpty(productData.Qty))
        {
            productData.Qty = "1";
        }
        var product = await _productService.GetProduct(new List<string> { "detail","variantTraits", "pricing", "inventory"}, productData.ProductId);
        product.Product.ProductDetailUrl = GetProductDetailsUrl(
            product.Product.ProductDetailUrl
        );
        return Json(product.Product);
    }

    [HttpPost]
    public async Task<IActionResult> AddToQuickOrder([FromBody] ProductDataModel productData)
    {
        if (IsNullOrEmpty(productData.Qty))
        {
            productData.Qty = "1";
        }

        var result = await _productService.GetProduct(new List<string> { "detail", "variantTraits", "pricing", "inventory" }, productData.ProductId);
        var model = new AddToQuickOrder
        {
            Product = result.Product
        };

        if (result.Product.Availability?.RequiresRealTimeInventory ?? false)
        {
            model.ProductInventory = await _productService.GetProductRealTimeInventory(productData.ProductId);
        }

        if(result.Product.Pricing?.RequiresRealTimePrice ?? false)
        {
            result.Product.Pricing = await _productService.GetProductPrice(productData.ProductId, productData.Uom, 
                decimal.Parse(productData.Qty), result.Product.Pricing?.RequiresRealTimePrice ?? false);
        }
        
        return Json(model);
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart([FromBody] List<AddToQuickOrder> productData)
    {
        try
        {
            var cartLineCollection = new List<AddCartLine>();
            foreach (var product in productData)
            {
                var cartLine = new AddCartLine()
                {
                    ProductId = product.Product.Id,
                    QtyOrdered = product.Product.QtyOrdered,
                    UnitOfMeasure = product.Product.UnitOfMeasure
                };
                cartLineCollection.Add(cartLine);
            }
            var result = await _cartService.AddAllToCart(cartLineCollection);
            var isSuccess = result.Any();
            return Json(new { isSuccess, url = GetPageReferenceUrl(x => x.CartPage) });
        }
        catch (Exception ex)
        {
            LogManager.GetLogger(GetType()).Error($"{ex.Message}");
            return Json(new { isSuccess = false });
        }
    }

    public async Task<Product> GetProductDetails(string productName, string uom, string qty)
    {
        var expands = new List<string>() { "pricing" };
        var result = await _productService.GetProductByName(productName, expands);
        if (result != null)
        {
            uom = !IsNullOrEmpty(uom) ? uom : result.UnitOfMeasureDisplay;
            if (!int.TryParse(qty, out var quantity))
                quantity = 1;
            else
                quantity = quantity > 0 ? quantity : 1;

            if (
                quantity > 1
                ||
                    !IsNullOrEmpty(uom)
                    && !result.UnitOfMeasureDisplay.Equals(
                        uom.Trim(),
                        StringComparison.OrdinalIgnoreCase
                    )

            )
            {
                var prices = await _productService.GetProductPrice(result.Id.ToString(), uom, decimal.Parse(qty), false);
                if (prices != null)
                {
                    if (
                        result.ProductUnitOfMeasures
                            .Where(
                                u =>
                                    u.UnitOfMeasure.Equals(
                                        uom,
                                        StringComparison.OrdinalIgnoreCase
                                    )
                            )
                            .FirstOrDefault() != null
                    )
                    {
                        result.UnitOfMeasureDisplay = uom;
                        result.UnitOfMeasure = uom;
                        foreach (var item in result.ProductUnitOfMeasures)
                        {
                            if (
                                item.UnitOfMeasure.Equals(
                                    uom,
                                    StringComparison.OrdinalIgnoreCase
                                )
                            )
                                item.IsDefault = true;
                            else
                                item.IsDefault = false;
                        }
                    }
                    result.QtyOrdered = quantity;
                    result.Pricing.UnitNetPrice = prices.UnitNetPrice;
                    result.Pricing.UnitNetPriceDisplay = prices.UnitNetPriceDisplay;
                    result.Pricing.ExtendedUnitNetPrice = prices.ExtendedUnitNetPrice;
                    result.Pricing.ExtendedUnitNetPriceDisplay =
                        prices.ExtendedUnitNetPriceDisplay;
                }
            }
            else
                result.QtyOrdered = Convert.ToInt32(qty);

            result.ProductDetailUrl = Empty;
        }
        return result;
    }

    private string GetProductDetailsUrl(string productUrlSegment)
    {
        return $"/{LanguageSelector.AutoDetect().Language.TwoLetterISOLanguageName}{productUrlSegment}";
    }

    [HttpGet]
    public async Task<IActionResult> AutoCompleteProducts(string term)
    {
        var result = await _productService.GetAutoCompleteProducts(term);
        if (result != null && result.Products != null && result.Products.Count > 0)
        {
            var lstProductJson = new List<AutocompleteProductsJsonViewModel>();
            foreach (var product in result.Products)
            {
                lstProductJson.Add(
                    new AutocompleteProductsJsonViewModel()
                    {
                        productId = product.Id,
                        label = product.Title,
                        value = product.Name == "" ? product.Title : product.Name,
                        url =
                            $"/{LanguageSelector.AutoDetect().Language.Name}{product.Url}",
                        Name = product.ErpNumber,
                        Image = product.Image,
                        productUrl = GetProductDetailsUrl(product.Url),
                        type = "0"
                    }
                );
            }

            return Json(lstProductJson);
        }
        return Json(null);
    }


    [HttpPost]
    public async Task<IActionResult> OrderUpload(List<string> items, string goalId)
    {
        var isSuccess = false;
        var validProducts = new List<Product>();
        var invalidProducts = new List<string>();
        var canNotAddToCartProducts = new List<Product>();
        var isNotActiveProducts = new List<Product>();
        var outOfStockProducts = new List<Product>();
        var invalidQtyProducts = new List<string>();
        var invalidUomProducts = new List<string>();
        var errorMessage = Empty;

        if (items != null && items.Count > 0)
        {
            foreach (var item in items)
            {
                if (!IsNullOrEmpty(item))
                {
                    var pDetails = item.Contains(",") ? item.Split(',') : new string[] { };
                    var productName = pDetails.Length > 0 ? pDetails[0].Trim() : item.Trim();
                    var quantity =
                        pDetails.Length > 1
                            ? !IsNullOrEmpty(pDetails[1].Trim()) ? pDetails[1].Trim() : "1"
                            : "1";
                    int checkQty;

                    if (int.TryParse(quantity, out checkQty))
                        quantity = Convert.ToInt32(checkQty) > 0 ? quantity : "1";
                    else
                    {
                        invalidQtyProducts.Add(quantity);
                        continue;
                    }
                    var uom =
                        pDetails.Length > 2
                            ? !IsNullOrEmpty(pDetails[2].Trim()) ? pDetails[2].Trim() : Empty
                            : Empty;

                    var product = !invalidProducts.Contains(productName)
                        ? await GetProductDetails(productName, uom, quantity)
                        : null;
                    if (product != null)
                    {
                        if (!product.IsActive)
                            isNotActiveProducts.Add(product);
                        else if (

                                !IsNullOrEmpty(uom)
                                && !product.UnitOfMeasureDisplay.Equals(
                                    uom.Trim(),
                                    StringComparison.OrdinalIgnoreCase
                                )

                        )
                            invalidUomProducts.Add(uom);
                        else if (
                            product.Availability.Message == "Out of Stock"
                            && !product.CanBackOrder
                        )
                            outOfStockProducts.Add(product);
                        else if (!product.CanAddToCart)
                            canNotAddToCartProducts.Add(product);
                        else
                            validProducts.Add(product);
                    }
                    else
                    {
                        if (!invalidProducts.Contains(productName))
                            invalidProducts.Add(productName);
                    }
                }
            }
            if (validProducts.Count == items.Count)
            {
                isSuccess = true;
                errorMessage = Empty;
            }
            else
            {
                isSuccess = false;
                errorMessage = invalidProducts.Aggregate(
                    errorMessage,
                    (current, name) => current + name + " is an invalid product.<br>"
                );
                errorMessage = invalidUomProducts.Aggregate(
                    errorMessage,
                    (current, name) => current + name + " is an invalid UOM.<br>"
                );
                errorMessage = invalidQtyProducts.Aggregate(
                    errorMessage,
                    (current, name) => current + name + " is an invalid quanitity.<br>"
                );
                errorMessage = canNotAddToCartProducts.Aggregate(
                    errorMessage,
                    (current, product) =>
                        current + product.Name + " can not be added to cart.<br>"
                );
                errorMessage = isNotActiveProducts.Aggregate(
                    errorMessage,
                    (current, product) =>
                        current + product.Name + " is not an active product.<br>"
                );
                errorMessage = outOfStockProducts.Aggregate(
                    errorMessage,
                    (current, product) => current + product.Name + " is out of stock.<br>"
                );
            }
        }
        if (!IsNullOrEmpty(goalId))
            isSuccess = true;
        return Json(
            new
            {
                IsSuccess = isSuccess,
                ErrorMessage = errorMessage,
                ValidProducts = validProducts,
                InValidProducts = invalidProducts
            }
        );
    }

    [HttpPost]
    public async Task<IActionResult> GetVariantProductDetails(
        [FromBody] ProductDataModel productDataModel
    )
    {
        var expands = new List<string>() { "pricing", "brand", "styledproducts" };
        var apiResult = await _productService.GetProduct(expands, productDataModel.ProductId);
        return Json(apiResult);
    }
}
