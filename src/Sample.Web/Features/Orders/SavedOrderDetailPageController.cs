using EPiServer.Logging;
using Sample.Services.Cart;

namespace Sample.Web.Features.Orders;

[LoginRequired]
public class SavedOrderDetailPageController : PageControllerBase<SavedOrderDetailsPage>
{
    private readonly ICartService _cartService;
    private readonly ISettingsHelper _epicelerSettingHelper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SavedOrderDetailPageController(
        ICartService cartService,
        ISettingsHelper epicelerSettingHelper,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _cartService = cartService;
        _epicelerSettingHelper = epicelerSettingHelper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IActionResult> Index(SavedOrderDetailsPage currentPage)
    {
        var current = _httpContextAccessor.HttpContext;
        var queryString = current.Request.Query;
        var model = new SavedOrderDetailPageViewModel(currentPage);
        if (queryString.TryGetValue("cartid", out var cartid))
            model.SavedOrderDetailViewModel.CartId = cartid;
        model.SavedOrderDetailViewModel.Language =
            $"/{LanguageSelector.AutoDetect().Language.TwoLetterISOLanguageName}";
        var expands = new List<string> { "cartlines", "costcodes", "hiddenproducts" };
        model.SavedOrderDetailViewModel.Cart = await _cartService.GetCartByIdWithChildren(
            model.SavedOrderDetailViewModel.CartId,
            expands
        );
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(
        SavedOrderDetailPageViewModel savedOrderDetailPageViewModel
    )
    {
        try
        {
            var cartId = savedOrderDetailPageViewModel.SavedOrderDetailViewModel.CartId;
            if (
                _httpContextAccessor.HttpContext != null
                && !string.IsNullOrEmpty(
                    _httpContextAccessor.HttpContext.Request.Form["saveSubmitButton"].ToString()
                )
            )
            {
                var cartPageRedirectUrl = Url.ContentUrl(
                    savedOrderDetailPageViewModel.CurrentContent.CartPageLink
                );
                if (string.IsNullOrWhiteSpace(cartPageRedirectUrl))
                {
                    LogManager.GetLogger(GetType()).Error("Cart Redirect Url is empty.");
                }
                if (await PlaceSavedOrder(cartId))
                {
                    var model = await _cartService.DeleteSavedOrder(cartId);
                    return Redirect(cartPageRedirectUrl);
                }
            }
            else if (
                _httpContextAccessor.HttpContext != null
                && !string.IsNullOrEmpty(
                    _httpContextAccessor.HttpContext.Request.Form[
                        "deleteSubmitButton"
                    ].ToString()
                )
            )
            {
                var savedOrderRedirectUrl = Url.ContentUrl(
                    savedOrderDetailPageViewModel.CurrentContent.ReturntoSavedOrdersLink
                );
                if (string.IsNullOrWhiteSpace(savedOrderRedirectUrl))
                {
                    LogManager.GetLogger(GetType()).Error("Saved order redirect Url is empty.");
                }
                var cart = await DeleteSavedOrder(cartId);
                return Redirect(savedOrderRedirectUrl);
            }
            else
            {
                LogManager.GetLogger(GetType()).Error($"Unknown submit operation.");
            }
        }
        catch (Exception ex)
        {
            LogManager.GetLogger(GetType()).Error($"{ex.Message}");
            savedOrderDetailPageViewModel.ErrorMessage = ex.Message;
        }
        return View(savedOrderDetailPageViewModel);
    }

    private async Task<bool> PlaceSavedOrder(string cartId)
    {
        var expands = new List<string> { "cartlines", "costcodes", "hiddenproducts" };
        var savedCart = await _cartService.GetCartByIdWithChildren(cartId, expands);
        var cartLineCollection = new List<AddCartLine>();
        foreach (var line in savedCart.CartLines)
        {
            cartLineCollection.Add(
                new AddCartLine()
                {
                    ProductId = line.ProductId,
                    QtyOrdered = line.QtyOrdered,
                    UnitOfMeasure = line.UnitOfMeasure,
                    Properties = line.Properties
                }
            );
        }

        var result = _cartService.AddAllToCart(cartLineCollection).Result;
        return result != null;
    }

    private async Task<bool> DeleteSavedOrder(string cartId)
    {
        return await _cartService.DeleteSavedOrder(cartId);
    }
}
