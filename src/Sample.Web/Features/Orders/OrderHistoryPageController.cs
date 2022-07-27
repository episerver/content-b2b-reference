using static System.String;
using Sample.Services.Orders;
using CommerceApiSDK.Models.Results;

namespace Sample.Web.Features.Orders;

[LoginRequired]
public class OrderHistoryPageController : PageControllerBase<OrderHistoryPage>
{
    private readonly IOrderService _orderService;
    private readonly IAccountService _accountService;

    public OrderHistoryPageController(IOrderService orderService,
        IAccountService accountService)
    {
        _orderService = orderService;
        _accountService = accountService;
    }

    public async Task<IActionResult> Index(OrderHistoryPage currentPage)
    {
        var searchParameters = new OrdersQueryParameters
        {
            PoNumber = Empty,
            OrderTotalOperator = Empty,
            OrderTotal = 1,
            FromDate = null,
            ToDate = null,
            OrderNumber = Empty,
            CustomerSequence = "-1",
            Sort = "OrderDate DESC",
            Status = null,
        };
        
        var allAddresses = await _accountService.GetBillToAndShipTos();
        var status = await _orderService.GetOrderStatus();
        var orders = await _orderService.GetOrderHistory(searchParameters);
        var orderStatus = new List<SelectListItem>()
        {
            new SelectListItem
            {
                Value = "",
                Text = "Select status"
            }
        };
        var model = new OrderHistoryPageViewModel(currentPage)
        {
            ShipToCollection = new GetShipTosResult
            {
                ShipTos = allAddresses?.BillTos.SelectMany(x => x.ShipTos).ToList() ?? new List<ShipTo>()
            },
            OrderCollection = orders,
            OrderStatus = orderStatus.Union(status.GroupBy(p => p.DisplayName).Select(g => new SelectListItem
            {
               Text =  g.First().DisplayName,
               Value = String.Join(",", g.Select(x => x.ErpOrderStatus))
            })).ToList(),
            QueryParameters = searchParameters
        };
        return View(model);
    }

    [HttpPost]
    public async Task<ActionResult> SearchOrder([FromBody] OrdersQueryParameters ordersQueryParameters)
    {
        if (string.IsNullOrEmpty(ordersQueryParameters.CustomerSequence))
        {
            ordersQueryParameters.CustomerSequence = "-1";
        }
        var ordersResponse = await _orderService.GetOrderHistory(ordersQueryParameters);
        return PartialView("_OrderHistoryTable", ordersResponse);
    }
}
