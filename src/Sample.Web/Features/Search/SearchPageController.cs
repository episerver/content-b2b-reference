using CommerceApiSDK.Models.Results;
using Microsoft.Extensions.Primitives;
using CommerceApiSettings = Sample.Web.Infrastructure.CommerceApiSettings;
using Sample.Services.Catalog;

namespace Sample.Web.Features.Search;

public class SearchPageController : PageControllerBase<SearchPage>
{
    private readonly IProductService _productService;
    private readonly IContentSearchService _contentSearchService;
    private readonly ISettingsHelper _settingsHelper;
    private readonly CommerceApiSettings _commerceApiSettings;

    public SearchPageController(
        IProductService productService,
        ISettingsHelper settingsHelper,
        IContentSearchService contentSearchService,
        IOptionsMonitor<CommerceApiSettings> commerceApiSettings
    )
    {
        _productService = productService;
        _settingsHelper = settingsHelper;
        _contentSearchService = contentSearchService;
        _commerceApiSettings = commerceApiSettings.CurrentValue;
    }

    [HttpGet]
    public async Task<IActionResult> Index(SearchPage currentPage, FilterOptionViewModel filterOptionViewModel)
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

        var searchPageViewModel = new SearchPageViewModel(currentPage)
        {
            ProductListViewModel = new ProductListViewModel(currentPage)
            {
                ProductUrlBase = _settingsHelper.GetProductPageLink(),
                FilterOptionViewModel = filterOptionViewModel,
                DataViewStyle = filterOptionViewModel.ViewMode,
                MaxCompareProducts = productListSettings.MaxCompareProducts,
                CommerceApiUrl = new Uri(_commerceApiSettings.baseUrl).ToString(),
            }
        };

        
        var categoryFilter = GetCategoryFilter();
        var request = Request;
        var sortBy = "1";
        if (request.Query.TryGetValue("sort", out var sort))
            sortBy = !StringValues.IsNullOrEmpty(sort) ? sort : "1";
        searchPageViewModel.ProductListViewModel.DataViewStyle =
            _settingsHelper.GetProductListSettings().DefaultProductListViewMode;
        searchPageViewModel.ProductListViewModel.MaxCompareProducts =
            _settingsHelper.GetProductListSettings().MaxCompareProducts;

        var expands = new List<string>() { "pricing", "attributes", "facets", "brand" };
        searchPageViewModel.ProductListViewModel.ProductCollection = await _productService.GetProducts(
            categoryFilter,
            expands,
            GetPriceFilters(),
            GetCriteria(),
            filterOptionViewModel.Sort,
            filterOptionViewModel.Page,
            filterOptionViewModel.PageSize,
            GetFilters(filterOptionViewModel, "attribute"),
            GetFilters(filterOptionViewModel, "brand"),
            GetFilters(filterOptionViewModel, "productLine")
        );
        return View(searchPageViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> AutoCompleteSearch(
        string term,
        bool enableProductSearch,
        bool enableCategorySearch,
        bool enableContentSearch,
        bool enableBrandSearch
    )
    {
        var autoCompleteModel = new AutocompleteSearchViewModel();

        var autocompleteViewModelList = new List<AutocompleteSearchJsonViewModel>();

        if (enableProductSearch)
        {
            var autocompleteResult = await _productService.GetAutoCompleteProducts(term);
            if (autocompleteResult?.Products?.Count > 0)
            {
                autoCompleteModel.AutoCompleteSearchListModel = autocompleteResult.Products
                    .Select(
                        product =>
                            new AutocompleteSearchJsonViewModel
                            {
                                Id = product.Id.ToString(),
                                Label = product.ErpNumber,
                                Value = product.Title,
                                Url = GetProductDetailsUrl(product.Url),
                                ImageUrl = GetImageUrl(product.Image),
                                SearchType = "Product",
                            }
                    )
                    .ToList();
                autoCompleteModel.ShouldShowProductSearchShowAllLink = false;
                if (enableCategorySearch)
                {
                    IncludeCategories(autoCompleteModel, autocompleteResult);
                }
                if (enableBrandSearch)
                {
                    IncludeBrands(autoCompleteModel, autocompleteResult);
                }
            }
        }

        if (enableContentSearch)
        {
            IncludeContentResults(term, autoCompleteModel);
        }
        return Json(new { autoCompleteModel });
    }

    private void IncludeContentResults(
        string query,
        AutocompleteSearchViewModel autocompleteModel
    )
    {
        const int initialPageIndex = 1;
        const int defaultPageSize = 5;
        const int defaultMaxContentResultsFetchCount = 40;

        var contentResult = _contentSearchService.GetContentSearchResult(
            query.Trim(),
            initialPageIndex,
            defaultPageSize,
            defaultMaxContentResultsFetchCount,
            LanguageSelector.AutoDetect().Language.TwoLetterISOLanguageName
        );

        if (contentResult?.ContentSearchResultTotalCount > 0)
        {
            if (autocompleteModel.AutoCompleteSearchListModel == null)
            {
                autocompleteModel.AutoCompleteSearchListModel =
                    new List<AutocompleteSearchJsonViewModel>();
            }

            autocompleteModel.AutoCompleteSearchListModel.AddRange(
                contentResult.ContentSearchItems.Select(
                    contentItem =>
                        new AutocompleteSearchJsonViewModel
                        {
                            Label = contentItem.Title,
                            Value = contentItem.Content,
                            Url = contentItem.Uri,
                            SearchType = "Content",
                        }
                )
            );
            autocompleteModel.ShouldShowContentSearchShowAllLink = true;
        }
    }

    private void IncludeCategories(
        AutocompleteSearchViewModel autocompleteModel,
        AutocompleteResult autocompleteResult
    )
    {
        autocompleteModel.AutoCompleteSearchListModel.AddRange(
            autocompleteResult.Categories.Select(
                category =>
                    new AutocompleteSearchJsonViewModel
                    {
                        Id = category.Id.ToString(),
                        Label = $"{category.Title} {category.Subtitle}",
                        Value = category.Subtitle,
                        Url = GetCatalogPageUrl(category.Url),
                        ImageUrl = GetImageUrl(category.Image),
                        SearchType = "Category",
                    }
            )
        );
        autocompleteModel.ShouldShowCategorySearchShowAllLink = false;
    }

    private void IncludeBrands(
        AutocompleteSearchViewModel autocompleteModel,
        AutocompleteResult autocompleteResult
    )
    {
        const string searchType = "Brand";
        var brandListWithoutFilter = autocompleteResult.Brands.Count();
        autocompleteModel.AutoCompleteSearchListModel.AddRange(
            autocompleteResult.Brands.Select(
                brand =>
                    new AutocompleteSearchJsonViewModel
                    {
                        Id = brand.Id.ToString(),
                        Label = $"{brand.Title}",
                        Value = brand.Title,
                        Url = GetBrandUrl(brand.Url),
                        ImageUrl = GetImageUrl(brand.Url),
                        SearchType = searchType,
                    }
            )
        );
        autocompleteModel.ShouldShowBrandSearchShowAllLink = true;
    }

    private string GetBrandUrl(string brandUrlSegment)
    {
        return $"/{LanguageSelector.AutoDetect().Language.TwoLetterISOLanguageName}{brandUrlSegment}";
    }

    private string GetImageUrl(string productImageUrlSegment)
    {
        return _commerceApiSettings.baseUrl + productImageUrlSegment;
    }

    private string GetProductDetailsUrl(string productUrlSegment)
    {
        return $"/{LanguageSelector.AutoDetect().Language.TwoLetterISOLanguageName}{productUrlSegment}";
    }

    private string GetCatalogPageUrl(string categoryUrlSegment)
    {
        return $"/{LanguageSelector.AutoDetect().Language.TwoLetterISOLanguageName}{categoryUrlSegment}";
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
        Request.Query.TryGetValue("search", out var queryQs);
        var query = new List<string>();
        if (!StringValues.IsNullOrEmpty(queryQs))
        {
            foreach (var p in queryQs.ToString().Split(','))
            {
                query.Add(p);
            }
        }
        return query;
    }

    private string GetCategoryFilter()
    {
        Request.Query.TryGetValue("categoryId", out var queryQs);
        return queryQs.ToString();
    }
}
