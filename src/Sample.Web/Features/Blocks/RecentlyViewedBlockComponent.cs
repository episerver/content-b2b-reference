using Sample.Services.Catalog;

namespace Sample.Web.Features.Blocks;

public class RecentlyViewedBlockComponent : BlockControllerBase<RecentlyViewedBlock>
{
    private readonly IProductService _productService;

    public RecentlyViewedBlockComponent(IProductService productService)
    {
        _productService = productService;
    }

    public override async Task<IViewComponentResult> Index(RecentlyViewedBlock currentBlock)
    {
        var model = new RecentlyViewedBlockViewModel
        {
            RecentlyViewedBlock = currentBlock,
            ProductCollection = await _productService.GetRecentlyViewedProducts()
        };
        return View(model);
    }
}
