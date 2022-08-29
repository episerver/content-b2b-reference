using EPiServer.Logging;
using EPiServer.Web.Routing.Matching;
using Microsoft.Extensions.Primitives;
using Sample.Services.Catalog;
using CommerceApiSettings = Sample.Web.Infrastructure.CommerceApiSettings;

namespace Sample.Web.Features.Catalog;

public class CatalogPageController : PageController<Models.Pages.CatalogPage>
{
    public ActionResult Index(Models.Pages.CatalogPage currentPage)
    {
        return View(new CatalogViewModel(currentPage));
    }
}

public class CatalogPagePartialController : Controller, IRenderTemplate<CatalogRoutedViewModel>
{
    private readonly IProductService _productService;
    private readonly CommerceApiSettings _commerceApiSettings;
    private readonly ISettingsHelper _settingsHelper;

    public CatalogPagePartialController(
        IProductService productService,
        IOptionsMonitor<CommerceApiSettings> commerceApiSettings,
        ISettingsHelper settingsHelper)
    {
        _productService = productService;
        _commerceApiSettings = commerceApiSettings.CurrentValue;
        _settingsHelper = settingsHelper;
    }

    [HttpGet]
    public async Task<IActionResult> Index(Models.Pages.CatalogPage currentPage, FilterOptionViewModel filterOptionViewModel)
    {
        var catalogViewModel = new CatalogViewModel
        {
            Path = (HttpContext.Features.Get<IContentRouteFeature>().RoutedContentData.PartialRoutedObject as CatalogRoutedViewModel)?.Path
        };
        var path = catalogViewModel.Path;
        ViewData["path"] = path;
        if (string.IsNullOrWhiteSpace(path))
        {
            LogManager
                .GetLogger(GetType())
                .Error(
                    "path is Empty. This is required to get CatalogPage object, which provides product related information."
                );
            //TODO: This will be changed to global error handling.
            throw new Exception("CatalogPath cannot be empty.");
        }
        catalogViewModel.CurrentContent = currentPage;
        var catalogPage = await _productService.GetCatalogPage(path);
        if (!string.IsNullOrWhiteSpace(catalogPage.ProductId.ToString()))
        {
            catalogViewModel.ProductDetailViewModel = await GetProductDetailViewModel(currentPage, catalogPage);
            catalogViewModel.ProductDetailViewModel.MetaDescription = catalogPage.MetaDescription;
            
        }
        else
        {
            catalogViewModel.ProductListViewModel = await GetProductListViewModel(currentPage, filterOptionViewModel, path, catalogPage);
            catalogViewModel.ProductListViewModel.MetaDescription = catalogPage.MetaDescription;
        }

        ViewData["path"] = catalogViewModel.Path;
        return View("/Features/Catalog/CatalogPage.Index.cshtml", catalogViewModel);
    }

    private async Task<ProductDetailViewModel> GetProductDetailViewModel(Models.Pages.CatalogPage currentPage, CommerceApiSDK.Models.CatalogPage catalogPage)
    {
        //Handle ProductDetail Page
        var apiResult = await _productService.GetProduct(new List<string>()
        {
            "documents",
            "specifications",
            "styledproducts",
            "htmlcontent",
            "attributes",
            "crosssells",
            "pricing",
            "relatedproducts",
            "brand"
        }, catalogPage.ProductId.ToString());

        var productDetailViewModel = new ProductDetailViewModel(currentPage)
        {
            ProductModel = apiResult,
            CatalogPage = catalogPage,
            CommerceApiUrl = new Uri(_commerceApiSettings.baseUrl).ToString()
        };
        foreach (var productImage in productDetailViewModel.ProductModel.Product.ProductImages)
        {
            productImage.MediumImagePath = productImage.MediumImagePath;
            productImage.LargeImagePath = productImage.LargeImagePath;
            productImage.SmallImagePath = productImage.SmallImagePath;
        }
        return productDetailViewModel;
    }

    private async Task<ProductListViewModel> GetProductListViewModel(Models.Pages.CatalogPage currentPage, 
        FilterOptionViewModel filterOptionViewModel, 
        string path, 
        CommerceApiSDK.Models.CatalogPage catalogPage)
    {
        var productListSettings = _settingsHelper.GetProductListSettings();

        if (filterOptionViewModel.DefaultPageSize == 0)
        {
            filterOptionViewModel.DefaultPageSize = productListSettings.DefaultPageSize;
        }

        if (filterOptionViewModel.PageSize == 0)
        {
            filterOptionViewModel.PageSize = filterOptionViewModel.DefaultPageSize;
        }

        if (filterOptionViewModel.Page == 0)
        {
            filterOptionViewModel.Page = 1;
        }

        if (string.IsNullOrEmpty(filterOptionViewModel.ViewMode))
        {
            filterOptionViewModel.ViewMode = productListSettings.DefaultProductListViewMode;
        }

        if (string.IsNullOrEmpty(filterOptionViewModel.Sort))
        {
            filterOptionViewModel.Sort = "1";
        }

        //Handle ProductList Page
        var productListViewModel = new ProductListViewModel(currentPage)
        {
            ProductUrlBase = $"/{LanguageSelector.AutoDetect().Language.TwoLetterISOLanguageName}{path}",
            FilterOptionViewModel = filterOptionViewModel,
            DataViewStyle = filterOptionViewModel.ViewMode,
            MaxCompareProducts = productListSettings.MaxCompareProducts,
            CommerceApiUrl = new Uri(_commerceApiSettings.baseUrl).ToString(),
            CatalogPage = catalogPage
        };

        if (catalogPage.Category != null)
        {
            productListViewModel.Category = catalogPage.Category;
        }
        
        productListViewModel.ProductCollection = await _productService.GetProducts(
            catalogPage.Category?.Id.ToString(),
            new List<string>() { "pricing", "attributes", "facets", "brand", "styledproducts" },
            GetPriceFilters(),
            GetCriteria(),
            filterOptionViewModel.Sort,
            filterOptionViewModel.Page,
            filterOptionViewModel.PageSize,
            GetFilters(filterOptionViewModel, "attribute"),
            GetFilters(filterOptionViewModel, "brand"),
            GetFilters(filterOptionViewModel, "productLine"),
            filterOptionViewModel.Q
        );

        return productListViewModel;
    }

    private List<string> GetPriceFilters()
    {
        StringValues priceFiltersQs;
        Request.Query.TryGetValue("priceFilters", out priceFiltersQs);

        var priceFilters = new List<string>();
        if (!string.IsNullOrEmpty(priceFiltersQs))
        {
            foreach (var p in priceFiltersQs.ToString().Split(','))
            {
                priceFilters.Add(p);
            }
        }

        return priceFilters;
    }

    private List<Guid?> GetFilters(FilterOptionViewModel filterOptionViewModel, string facetType)
    {
        var filters = new List<Guid?>();
        if (string.IsNullOrEmpty(filterOptionViewModel.SelectedFacet))
        {
            return filters;
        }
        
        foreach (var facet in filterOptionViewModel.SelectedFacet.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            var data = facet.Split(':');
            if (data.Length != 2)
            {
                continue;
            }

            if (facetType.Equals("brand") && data[0].Equals("brand"))
            {
                filters.Add(Guid.Parse(data[1]));
            }
            else if (facetType.Equals("productLine") && data[0].Equals("productLine"))
            {
                filters.Add(Guid.Parse(data[1]));
            }
            else if (facetType.Equals("attribute") && data[0].Equals("attribute"))
            {
                filters.Add(Guid.Parse(data[1]));
            }
        }
        
        return filters;
    }

    private List<string> GetCriteria()
    {
        StringValues queryQs;
        Request.Query.TryGetValue("criteria", out queryQs);

        var query = new List<string>();
        if (!string.IsNullOrEmpty(queryQs))
        {
            foreach (var p in queryQs.ToString().Split(','))
            {
                query.Add(p);
            }
        }
        return query;
    }

    [HttpPost]
    public virtual async Task<IActionResult> getChildProductAvailability(
        [FromBody] ProductDetails productDetails
    )
    {
        var result = await _productService.GetProduct(productDetails.ProductId);
        return Json(result);
    }
}
