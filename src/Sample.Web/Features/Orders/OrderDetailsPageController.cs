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
        model.ReturnPageLink = Url.ContentUrl(currentPage.ReturnPageLink);
        if (!string.IsNullOrEmpty(orderNumber.ToString()))
        {
            model.Order = await _orderService.GetOrderLine(orderNumber.ToString());
        }
        else
        {
            model.Order = new Order();
        }
        return View(model);
    }
}
