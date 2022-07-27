using Microsoft.Extensions.Primitives;
using Sample.Services.Catalog;

namespace Sample.Web.Features.Catalog;

public class ProductComparisonController : PageControllerBase<ProductComparisonPage>
{
    private readonly IProductService _productService;
    private readonly ISettingsHelper _epicelerSettingHelper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ProductComparisonController(
        IProductService productService,
        ISettingsHelper epicelerSettingHelper,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _productService = productService;
        _epicelerSettingHelper = epicelerSettingHelper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IActionResult> Index(ProductComparisonPage currentPage)
    {
        var expands = new List<string>() { "styledproducts", "attributes", "pricing" };
        var result = await _productService.GetCompareProducts(expands);
        var vm = new ProductComparisonViewModel(currentPage);
        if (result.Products != null)
        {
            var list = new List<ExtendedProductModel>();
            foreach (var p in result.Products)
            {
                list.Add(new ExtendedProductModel() { Product = p });
            }

            vm.product = list;
            vm.AttributeList = new List<AttributeTypes>();
            vm.ReturnUrl = GetReturnUrlQueryString();
            foreach (var x in vm.product)
            {
                var product = x.Product;
                product.UrlSegment =
                    $"{_epicelerSettingHelper.GetProductPageLink()}/{product.UrlSegment}";
                x.DisplayImage = _epicelerSettingHelper.GetDisplayImage(false, product);
                x.DisplayHoverImage = _epicelerSettingHelper.GetDisplayImage(true, product);
                foreach (var types in product.AttributeTypes)
                {
                    if (types.IsComparable)
                    {
                        var items = vm.AttributeList.FirstOrDefault(
                            x => x.AttributeId == types.Id.ToString()
                        );
                        if (items == null)
                        {
                            var _type = new AttributeTypes
                            {
                                AttributeId = types.Id.ToString(),
                                AttributeLabel = types.Label
                            };
                            vm.AttributeList.Add(_type);
                        }
                    }
                }
                product.MediumImagePath = product.MediumImagePath;
                product.SmallImagePath = product.SmallImagePath;
                product.LargeImagePath = product.LargeImagePath;
                product.ProductDetailUrl = product.UrlSegment;
            }

            return View(vm);
        }

        return View(vm);
    }

    private string GetReturnUrlQueryString()
    {
        var virtualPath = "/";
        var current = _httpContextAccessor.HttpContext;
        if (current != null)
        {
            var queryString = current.Request.Query;
            if (queryString.TryGetValue("ReturnUrl", out var returnUrl))
                virtualPath = !StringValues.IsNullOrEmpty(returnUrl) ? virtualPath : returnUrl;
        }
        return virtualPath;
    }
}
