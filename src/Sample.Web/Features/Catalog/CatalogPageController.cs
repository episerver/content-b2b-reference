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
        var model = new CatalogViewModel(currentPage);
        if (string.IsNullOrEmpty(currentPage.PreviewType))
        {
            model.PreviewType = "Listing";
        }
        else
        {
            model.PreviewType = currentPage.PreviewType;
        }
        if (model.PreviewType.Equals("Listing"))
        {
            model.ProductListViewModel = new ProductListViewModel
            {
                FilterOptionViewModel = new FilterOptionViewModel
                {
                    Page = 1,
                    PageSize = 8,
                },
                CatalogPage = new CommerceApiSDK.Models.CatalogPage
                {
                    BreadCrumbs = new List<BreadCrumb>
                    {
                        new BreadCrumb
                        {
                            CategoryId = "Home",
                            Text = "Home",
                            Url = "/"
                        }
                    }
                },
                ProductCollection = new CommerceApiSDK.Models.Results.GetProductCollectionResult
                {
                    Pagination = new Pagination
                    {
                        TotalItemCount = 1,
                        Page = 1,
                        PageSize = 8,
                        PageSizeOptions = new List<int>
                        {
                            1,
                            2
                        },
                        SortOptions = new List<CommerceApiSDK.Models.SortOption>
                        {
                            new CommerceApiSDK.Models.SortOption
                            {
                                DisplayName = "test",
                                SortType = "1"
                            }
                        }
                    },
                    Products = new List<Product>
                    {
                        new Product
                        {
                            ProductNumber = "Test",
                            ProductTitle = "ProductTitle",
                            Images = new List<ProductImage>()
                            {
                                new ProductImage
                                {
                                    SmallImagePath = "https://www.fillmurray.com/640/360",
                                    MediumImagePath = "https://www.fillmurray.com/640/360",
                                    LargeImagePath = "https://www.fillmurray.com/640/360"
                                }
                            }
                        }
                    }
                }
            };
        }
        else
        {
            model.ProductDetailViewModel = new ProductDetailViewModel
            {
                CatalogPage = new CommerceApiSDK.Models.CatalogPage
                {
                    BreadCrumbs = new List<BreadCrumb>
                    {
                        new BreadCrumb
                        {
                            CategoryId = "Home",
                            Text = "Home",
                            Url = "/"
                        }
                    }
                },
                ProductModel = new CommerceApiSDK.Models.Results.GetProductResult
                {
                    Product = new Product
                    {
                        ProductNumber = "Test",
                        ProductTitle = "ProductTitle",
                        Images = new List<ProductImage>()
                        {
                            new ProductImage
                            {
                                SmallImagePath = "https://www.fillmurray.com/640/360",
                                MediumImagePath = "https://www.fillmurray.com/640/360",
                                LargeImagePath = "https://www.fillmurray.com/640/360"
                            }
                        }
                    }
                }
            };
        }
        return View(model);
    }
}

public class CatalogPagePartialController : ActionControllerBase, IRenderTemplate<CatalogRoutedViewModel>
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
            "detail","specifications","content","images","documents","attributes","variantTraits"
        }, catalogPage.ProductId.ToString());

        return new ProductDetailViewModel(currentPage)
        {
            ProductModel = apiResult,
            CatalogPage = catalogPage,
            CommerceApiUrl = new Uri(_commerceApiSettings.baseUrl).ToString(),
            SiteCrossSells = await _productService.GetSiteCrossSells()
        };
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
            new List<string>() { "variantTraits", "attributes", "facets" },
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

public class VariantOptions
{
    public string ProductId { get; set; }

    public List<SelectListItem> Options { get; set; }
}
