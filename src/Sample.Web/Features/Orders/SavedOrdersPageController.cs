using static System.String;
using Sample.Services.Orders;
using Sample.Services.Cart;
using CommerceApiSDK.Models.Results;

namespace Sample.Web.Features.Orders;

[LoginRequired]
public class SavedOrdersPageController : PageControllerBase<SavedOrdersPage>
{
    private readonly ICartService _cartService;
    private readonly IOrderService _orderService;
    private readonly IAccountService _accountService;

    public SavedOrdersPageController(ICartService cartService,
        IOrderService orderService,
        IAccountService accountService)
    {
        _cartService = cartService;
        _orderService = orderService;
        _accountService = accountService;
    }

    public async Task<IActionResult> Index(SavedOrdersPage currentPage)
    {
        var searchParameters = new CartsQueryParameters()
        {
            Page = 1,
            Sort = "OrderDate DESC",
            Status = CartCollectionParameter.CartStatus.Saved.ToString()
        };
        var status = Empty;
        var shipTosResponse = new GetShipTosResult();
        var allAddresses = await _accountService.GetBillToAndShipTos();
        shipTosResponse.ShipTos = allAddresses?.BillTos.SelectMany(x => x.ShipTos).ToList() ?? new List<ShipTo>();
        var savedOrdersResponse = await _cartService.GetCartSavedOrders(searchParameters);
        var model = new SavedOrdersPageViewModel(currentPage)
        {
            SavedOrdersViewModel = new SavedOrdersViewModel
            {
                ShipToCollection = shipTosResponse,
                CartCollection = savedOrdersResponse
            },
            OrderDetailsPageLink = Url.ContentUrl(currentPage.SavedOrderDetailsPageLink)
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> SearchSavedOrder(
        [FromBody] CartCollectionParameter searchParameters
    )
    {
        var searchParameters1 = new CartsQueryParameters()
        {
            Page = searchParameters.Page,
            PageSize = searchParameters.PageSize,
            Sort = searchParameters.Sort,
            Status = CartCollectionParameter.CartStatus.Saved.ToString()
        };
        var ordersResponse = await _cartService.GetCartSavedOrders(searchParameters1);
        return Json(ordersResponse);
    }
}
