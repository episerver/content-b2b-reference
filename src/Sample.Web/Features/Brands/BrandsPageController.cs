using CommerceApiSDK.Models.Results;
using CommerceApiSDK.Services.Interfaces;

namespace Sample.Web.Features.Brands;

public class BrandsPageController : PageControllerBase<BrandsPage>
{
    private readonly IBrandService _brandClient;
    private readonly IContentLoader _contentLoader;
    private readonly ISettingsHelper _epicelerSettingHelper;

    public BrandsPageController(
        IBrandService brandClient,
        IContentLoader contentLoader,
        ISettingsHelper epicelerSettingHelper
    )
    {
        _brandClient = brandClient;
        _contentLoader = contentLoader;
        _epicelerSettingHelper = epicelerSettingHelper;
    }

    public async Task<IActionResult> Index(BrandsPage currentPage, string path)
    {
        var model = new BrandsPageViewModel(currentPage)
        {
            Brands = await _brandClient.GetBrands(new BrandsQueryParameters())
        };
        model.BrandsSorting = GetBrandByGroup(model.Brands);
        return View(model);
    }

    public IEnumerable<IGrouping<char, Brand>> GetBrandByGroup(GetBrandsResult brand)
    {
        return (IEnumerable<IGrouping<char, Brand>>)(from brandsCollection in brand.Brands
                                                     group brandsCollection by brandsCollection.Name[0]);
    }

    public async Task<IActionResult> Details(BrandsPage currentPage, string path)
    {
        var model = new BrandsPageViewModel(currentPage);
        return await Task.FromResult(View(model));
    }
}
