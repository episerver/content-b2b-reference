using CommerceApiSDK.Services.Interfaces;

namespace Sample.Web.Features.Blocks;

public class BrandListBlockComponent : BlockControllerBase<BrandListBlock>
{
    private readonly IBrandService _brandClient;
    private readonly CommerceApiSettings _commerceApiSettings;

    public BrandListBlockComponent(
        IBrandService brandClient,
        IOptionsMonitor<CommerceApiSettings> commerceApiSettings
    )
    {
        _brandClient = brandClient;
        _commerceApiSettings = commerceApiSettings.CurrentValue;
    }

    public override async Task<IViewComponentResult> Index(BrandListBlock currentBlock)
    {
        var parameters = new BrandsQueryParameters();
        var brands = await _brandClient.GetBrands(parameters);
        var commerceApiUrl = _commerceApiSettings.baseUrl;
        foreach (var brand in brands.Brands)
        {
            brand.LogoLargeImagePath = string.Concat(commerceApiUrl, brand.LogoLargeImagePath);
            brand.LogoSmallImagePath = string.Concat(commerceApiUrl, brand.LogoSmallImagePath);
        }
        var model = new BrandListBlockViewModel(currentBlock, brands);
        ViewData.Model = model;
        return await Task.FromResult(View(model));
    }
}