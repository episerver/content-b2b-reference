using CatalogPage = Sample.Models.Pages.CatalogPage;

namespace Sample.Web.Infrastructure.Helpers;

public interface ISettingsHelper
{
    Models.Settings.SearchSettings GetSearchSettings();
    string GetProductPageLink();
    ProductDetailPage GetProductDetailPage();
    ProductListSettings GetProductListSettings();
    string GetCatalogPageLink();
    string GetAutoCompleteSearchUrl();
    string GetLoginPageUrl();
    Url GetContentSearchListUrl();
    string GetDisplayImage(bool isHoverImage, Product product);
    LabelSettings GetLabelSettings();
    CatalogPage GetCatalogPage();
    T GetSettings<T>() where T : SettingsBase;
}
