using Sample.Services.Cart;

namespace Sample.Web.Features.Orders;

public class OrderConfirmationPageController : PageControllerBase<OrderConfirmationPage>
{
    private readonly ICartService _cartService;

    public OrderConfirmationPageController(ICartService cartService)
    {
        _cartService = cartService;
    }

    public async Task<IActionResult> Index(OrderConfirmationPage currentPage)
    {
        var queryString = Request.Query;
        var model = new OrderConfirmationPageViewModel(currentPage);
        queryString.TryGetValue("cartid", out var cartid);
        var expands = new List<string>
        {
            "cartlines",
            "carriers",
            "creditCardBillingAddress",
            "paymentMethod",
            "tax",
            "shipping",
            "paymentoptions"
        };
        model.Cart = await _cartService.GetCartByIdWithChildren(cartid, expands);
        model.Promotions = await _cartService.GetCartPromotion(cartid);
        return View(model);
    }
}
