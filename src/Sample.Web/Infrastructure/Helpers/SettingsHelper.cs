using static System.String;
using CatalogPage = Sample.Models.Pages.CatalogPage;

namespace Sample.Web.Infrastructure.Helpers;

[ServiceConfiguration(ServiceType = typeof(ISettingsHelper), Lifecycle = ServiceInstanceScope.Singleton)]
public class SettingsHelper : ISettingsHelper
{
    private readonly UrlResolver _urlResolver;
    private readonly CommerceApiSettings _commerceApiSettings;
    private readonly ISettingsService _settingsService;

    public SettingsHelper(UrlResolver urlResolver,
        IOptionsMonitor<CommerceApiSettings> commerceApiSettings,
        ISettingsService settingsService)
    {
        _urlResolver = urlResolver;
        _commerceApiSettings = commerceApiSettings.CurrentValue;
        _settingsService = settingsService;
    }

    public T GetSettings<T>() where T: SettingsBase
    {
        return _settingsService.GetSiteSettings<T>();
    }

    public Models.Settings.SearchSettings GetSearchSettings()
    {
        return _settingsService.GetSiteSettings<Models.Settings.SearchSettings>();
    }

    public string GetProductPageLink()
    {
        var pageSettings = _settingsService.GetSiteSettings<PageReferenceSettings>();
        if (pageSettings == null || ContentReference.IsNullOrEmpty(pageSettings.ProductPage))
        {
            return null;
        }
        return _urlResolver.GetUrl(pageSettings.ProductPage, LanguageSelector.AutoDetect().LanguageBranch);
    }

    public ProductDetailPage GetProductDetailPage()
    { 
        var url = GetCatalogPageLink();
        if (url == null)
        {
            return null;
        }
        return _urlResolver.Route(new UrlBuilder(url)) as ProductDetailPage;
    }

    public BrandDetailsPage GetBrandDetailsPage()
    {
        var pageSettings = _settingsService.GetSiteSettings<PageReferenceSettings>();
        if (pageSettings == null || ContentReference.IsNullOrEmpty(pageSettings.BrandsPage))
        {
            return null;
        }
       
        return _urlResolver.Route(new UrlBuilder(_urlResolver.GetUrl(pageSettings.BrandsPage, LanguageSelector.AutoDetect().LanguageBranch))) as BrandDetailsPage;
    }

    public ProductListSettings GetProductListSettings()
    {
        return _settingsService.GetSiteSettings<ProductListSettings>();
    }

    public string GetCatalogPageLink()
    {
        var pageSettings = _settingsService.GetSiteSettings<PageReferenceSettings>();
        if (pageSettings == null || ContentReference.IsNullOrEmpty(pageSettings.CatalogPage))
        {
            return null;
        }
        return _urlResolver.GetUrl(pageSettings.CatalogPage, LanguageSelector.AutoDetect().LanguageBranch);
    }

    public string GetAutoCompleteSearchUrl()
    {
        var pageSettings = _settingsService.GetSiteSettings<PageReferenceSettings>();
        if (pageSettings == null || ContentReference.IsNullOrEmpty(pageSettings.SearchPage))
        {
            return null;
        }
        return _urlResolver.GetUrl(pageSettings.SearchPage, LanguageSelector.AutoDetect().LanguageBranch);
    }

    public string GetLoginPageUrl()
    {
        var pageSettings = _settingsService.GetSiteSettings<PageReferenceSettings>();
        if (pageSettings == null || ContentReference.IsNullOrEmpty(pageSettings.LoginPage))
        {
            return null;
        }
        return _urlResolver.GetUrl(pageSettings.LoginPage, LanguageSelector.AutoDetect().LanguageBranch);
    }

    public Url GetContentSearchListUrl()
    {
        var pageSettings = _settingsService.GetSiteSettings<PageReferenceSettings>();
        if (pageSettings == null || ContentReference.IsNullOrEmpty(pageSettings.SearchPage))
        {
            return null;
        }
        return new Url(_urlResolver.GetUrl(pageSettings.SearchPage, LanguageSelector.AutoDetect().LanguageBranch));
    }

    public string GetDisplayImage(bool isHoverImage, Product product)
    {
        var displayImages = "";
        var defaultImage = product.ERPNumber != "" ? Concat(product.ERPNumber, "_1") : "";
        var hoverImageName =
            product.ERPNumber != "" ? Concat(product.ERPNumber, "_1", "_hover") : "";
        var apiSiteUrl = _commerceApiSettings.baseUrl;
        if (isHoverImage)
        {
            if (!IsNullOrEmpty(hoverImageName))
                displayImages = product.ProductImages
                    .FirstOrDefault(x => x.Name == hoverImageName)
                    ?.MediumImagePath;
        }
        else
        {
            displayImages = product.ProductImages
                .FirstOrDefault(x => x.Name == defaultImage)
                ?.MediumImagePath;
            if (IsNullOrEmpty(defaultImage))
            {
                displayImages = product.ProductImages
                    .FirstOrDefault(x => x.Name == hoverImageName)
                    ?.MediumImagePath;
            }
        }
        displayImages = !IsNullOrEmpty(displayImages)
            ? Concat(apiSiteUrl, displayImages)
            : product.MediumImagePath;
        return displayImages;
    }

    public LabelSettings GetLabelSettings()
    {
        return _settingsService.GetSiteSettings<LabelSettings>();
    }

    public CatalogPage GetCatalogPage()
    {
        var pageSettings = _settingsService.GetSiteSettings<PageReferenceSettings>();
        if (pageSettings == null || ContentReference.IsNullOrEmpty(pageSettings.CatalogPage))
        {
            return null;
        }

        return _urlResolver.Route(new UrlBuilder(_urlResolver.GetUrl(pageSettings.CatalogPage, LanguageSelector.AutoDetect().LanguageBranch))) as CatalogPage;
    }
}
