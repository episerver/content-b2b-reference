using CommerceApiSDK.Services.Interfaces;

namespace Sample.Web.Features.Brands;

public class BrandDetailsPageController : PageControllerBase<BrandDetailsPage>
{
    private readonly IBrandService _brandClient;
    private readonly IContentLoader _contentLoader;
    private readonly ISettingsHelper _epicelerSettingHelper;

    public BrandDetailsPageController(
        IBrandService brandClient,
        IContentLoader contentLoader,
        ISettingsHelper epicelerSettingHelper
    )
    {
        _brandClient = brandClient;
        _contentLoader = contentLoader;
        _epicelerSettingHelper = epicelerSettingHelper;
    }

    public async Task<IActionResult> Index(BrandDetailsPage currentPage)
    {
        var model = new BrandDetailsPageViewModel(currentPage);
        return await Task.FromResult(View(model));
    }
}
