using Sample.Services.Orders;

namespace Sample.Web.Features.Orders;

[LoginRequired]
public class ReturnRequestPageController : PageControllerBase<ReturnRequestPage>
{
    private readonly IOrderService _orderService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ReturnRequestPageController(
        IOrderService orderService,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _httpContextAccessor = httpContextAccessor;
        _orderService = orderService;
    }

    public async Task<IActionResult> Index(ReturnRequestPage currentPage)
    {
        var query = _httpContextAccessor.HttpContext.Request.Query;
        query.TryGetValue("ordernumber", out var orderNumber);
        var model = new ReturnRequestPageViewModel(currentPage);
        if (!string.IsNullOrEmpty(orderNumber))
        {
            var orderDetails = await _orderService.GetOrderLine(orderNumber);
            model.ReturnRequestViewModel = new ReturnRequestViewModel
            {
                Order = orderDetails
            };
            model.ReturnPageLink = Url.ContentUrl(currentPage.ReturnToOrderDetailLink);
        }
        return View(model);
    }
}
