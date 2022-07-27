using EPiServer.Logging;
using EPiServer.Web.Routing.Matching;
using CommerceApiSettings = Sample.Web.Infrastructure.CommerceApiSettings;
using Sample.Services.Catalog;

namespace Sample.Web.Features.Catalog;

public class ProductDetailPageController : Controller, IRenderTemplate<ProductDetailViewModel>
{
    private readonly IProductService _productService;
    private readonly IContentLoader _contentLoader;
    private readonly ISettingsHelper _epicelerSettingHelper;
    private readonly CommerceApiSettings _commerceApiSettings;

    public ProductDetailPageController(
        IProductService productService,
        IContentLoader contentLoader,
        ISettingsHelper epicelerSettingHelper,
        IOptionsMonitor<CommerceApiSettings> commerceApiSettings
    )
    {
        _productService = productService;
        _contentLoader = contentLoader;
        _epicelerSettingHelper = epicelerSettingHelper;
        _commerceApiSettings = commerceApiSettings.CurrentValue;
    }

    public async Task<IActionResult> Index(ProductDetailPage currentPage)
    {
        var productDetailViewModel =
            HttpContext.Features.Get<IContentRouteFeature>().RoutedContentData.PartialRoutedObject
            as ProductDetailViewModel;
        var path = productDetailViewModel.Path;
        ViewData["path"] = productDetailViewModel.Path;
        var commerceApiUrl = new Uri(_commerceApiSettings.baseUrl).ToString();
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

        var catalogPage = await _productService.GetCatalogPage(path);
        var expands = new List<string>()
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
        };
        var productId = catalogPage.ProductId;
        productDetailViewModel.ProductModel = await _productService.GetProduct(expands, productId.ToString());
        productDetailViewModel.CatalogPage = catalogPage;
        productDetailViewModel.CommerceApiUrl = commerceApiUrl ?? "";
        productDetailViewModel.ProductUrl =
            $"{_epicelerSettingHelper.GetProductPageLink()}/{productDetailViewModel.ProductModel.Product.UrlSegment}";
        foreach (var productImage in productDetailViewModel.ProductModel.Product.ProductImages)
        {
            productImage.MediumImagePath = productImage.MediumImagePath;
            productImage.LargeImagePath = productImage.LargeImagePath;
            productImage.SmallImagePath = productImage.SmallImagePath;
        }
        return View(productDetailViewModel);
    }
}
