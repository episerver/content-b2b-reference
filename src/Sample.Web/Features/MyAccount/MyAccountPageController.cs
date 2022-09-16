using CommerceApiSDK.Models.Enums;
using Sample.Services.DashBoardPanel;
using Sample.Services.WishList;

namespace Sample.Web.Features.MyAccount;

[LoginRequired]
public class MyAccountPageController : PageControllerBase<MyAccountPage>
{
    private readonly IWishListService _wishListService;
    private readonly ISharedService _sharedService;

    public MyAccountPageController(
        IWishListService wishListService,
        ISharedService sharedService
    )
    {
        _wishListService = wishListService;
        _sharedService = sharedService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(MyAccountPage currentPage)
    {
        var pageNumber = 1;
        var pageSize = 16;
        var sortOrder = WishListSortOrder.ModifiedOnDescending;
        string searchText = null;
        var model = new MyAccountPageViewModel(currentPage);
        model.MyAccountViewModel = new MyAccountViewModel
        {
            MyListLink = Url.ContentUrl(model.CurrentContent.MyListLink)
        };
        var wishListResponse = await _wishListService.GetWishListsCollection(
            pageNumber,
            pageSize,
            sortOrder,
            searchText
        );
        var dashboardPanelResponse = await _sharedService.GetDashboardPanels();
        model.MyAccountViewModel.WishListCollection = wishListResponse?.WishListCollection ?? new List<WishList>();
        model.MyAccountViewModel.DashBoardPanelCollection = dashboardPanelResponse ?? new CommerceApiSDK.Models.Results.DashboardPanelsResult();
        return View(model);
    }
}
