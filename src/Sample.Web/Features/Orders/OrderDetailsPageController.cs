using Sample.Services.Orders;

namespace Sample.Web.Features.Orders;

[LoginRequired]
public class OrderDetailsPageController : PageControllerBase<OrderDetailsPage>
{
    private readonly IOrderService _orderService;

    public OrderDetailsPageController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<IActionResult> Index(OrderDetailsPage currentPage)
    {
        Request.Query.TryGetValue("ordernumber", out var orderNumber);
        var model = new OrderDetailsPageViewModel(currentPage);
        if (!string.IsNullOrEmpty(orderNumber.ToString()))
        {
            model.Order = await _orderService.GetOrderLine(orderNumber.ToString());
            model.ReturnPageLink = Url.ContentUrl(currentPage.ReturnPageLink);
        }
        return View(model);
    }
}
