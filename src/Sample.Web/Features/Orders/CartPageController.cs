using System.Collections.Specialized;
using System.Web;
using CommerceApiSDK.Models.Enums;
using EPiServer.Logging;
using Sample.Services.Catalog;
using Sample.Services.Cart;
using Sample.Services.Session;

namespace Sample.Web.Features.Orders;

public class CartPageController : PageControllerBase<CartPage>
{
    private readonly ICartService _cartService;
    private readonly IProductService _productService;
    private readonly IAuthenticationService _authenticationService;
    private readonly ISettingsHelper _settingsHelper;
    private readonly CommerceApiSDK.Services.Interfaces.IWarehouseService _warehouseService;
    private readonly ICookieService _cookieService;
    private readonly ISessionService _sessionService;

    public CartPageController(
        ICartService cartService,
        IProductService productService,
        IAuthenticationService authenticationService,
        ISettingsHelper settingsHelper,
        CommerceApiSDK.Services.Interfaces.IWarehouseService warehouseService,
        ICookieService cookieService,
        ISessionService sessionService)
    {
        _cartService = cartService;
        _productService = productService;
        _authenticationService = authenticationService;
        _settingsHelper = settingsHelper;
        _warehouseService = warehouseService;
        _cookieService = cookieService;
        _sessionService = sessionService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(CartPage currentPage)
    {
        var isAuthenticated = await _authenticationService.IsAuthenticatedAsync();
        var model = new CartPageViewModel(currentPage);
        List<string> expands;
        if (isAuthenticated)
        {
            expands = new List<string>
            {
                "cartlines",
                "costcodes",
                "hiddenproducts",
                "shiptos",
                "carriers",
                "shipping",
                "validation",
                "tax",
                "restrictions"
            };
        }
        else
        {
            expands = new List<string> { "cartlines", "costcodes", "hiddenproducts" };
        }

        model.Cart = await _cartService.GetCartWithOptions(expands);
        model.Promotions = await _cartService.GetPromotion();
        model.Warehouses = await _warehouseService.GetWarehouses(new WarehousesQueryParameters
        {
            OnlyPickupWarehouses = true,
            Latitude = 44.981047,
            Longitude =-93.27417,
            ExcludeCurrentPickupWarehouse = false,
            Page = 1,
            Sort = "Distance"
        });
        model.CurrentFulfillmentMethod = _cookieService.Get("CurrentFulfillmentMethod") ?? "Ship";
        if ((model.CurrentFulfillmentMethod ?? "").Equals("PickUp"))
        {
            model.CurrentPickUpWarehouseId = _cookieService.Get("CurrentPickUpWarehouseId");
        }
        model.PromotionLabel = model.CurrentContent.PromotionLabel;
        model.SubtotalLabel = model.CurrentContent.SubtotalLabel;
        model.TaxLabel = model.CurrentContent.TaxLabel;
        model.TotalLabel = model.CurrentContent.TotalLabel;
        model.ShippingHandlingLabel = model.CurrentContent.ShippingHandlingLabel;
        return View(model);
    }

    [HttpGet]
    public async Task<int> GetCartCount()
    {
        var cartCount = 0;
        try
        {
            var cartResult = await _cartService.GetCart();
            if (cartResult != null)
                cartCount = cartResult.TotalCountDisplay;
        }
        catch (Exception)
        {
            return 0;
        }
        return cartCount;
    }

    [HttpPost]
    //[ValidateAntiForgeryToken]
    public async Task<bool> AddToCart([FromBody] CartDetails cartDetails)
    {
        LogManager.GetLogger(GetType()).Information("At add to cart");
        try
        {
            var properties = new Dictionary<string, string>();
            var querystring = Request.QueryString;
            if (querystring != default && querystring.HasValue)
            {
                var styleTraitValues = await GetStyleTraitValues(
                    HttpUtility.ParseQueryString(querystring.Value),
                    cartDetails.productId
                );
                if (styleTraitValues != null)
                {
                    properties = styleTraitValues;
                }
            }
            if (string.IsNullOrEmpty(cartDetails.qty))
            {
                cartDetails.qty = "1";
            }
            var result = await _cartService.CartLines(
                cartDetails.productId,
                cartDetails.qty,
                cartDetails.unitOfMeasure,
                properties
            );
            if (result.ProductId != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            LogManager.GetLogger(GetType()).Error($"{ex.Message}");
            return false;
        }
    }

    [HttpPost]
    public async Task<bool> RemoveCartLine([FromBody] CartDetails cartDetails)
    {
        return await _cartService.RemoveCartLine(cartDetails.cartLineId);
    }

    [HttpPost]
    public async Task<bool> UpdateCartQuantity([FromBody] CartDetails cartDetails)
    {
        if (int.Parse(cartDetails.qty) == 0)
        {
            return await _cartService.RemoveCartLine(cartDetails.cartLineId);
        }
        else
        {
            var cart = await _cartService.GetCart();
            var currentCartLine = cart.CartLines.FirstOrDefault(
                l => l.Id.ToString().ToLower().Equals(cartDetails.cartLineId)
            );
            
            var updatedLineResult = await _cartService.UpdateCartLine(
                currentCartLine.Id.ToString(),
                currentCartLine.ProductId.ToString(),
                currentCartLine.ErpNumber,
                cartDetails.qty,
                currentCartLine.UnitOfMeasure,
                currentCartLine.Notes,
                currentCartLine.Properties
            );
            return updatedLineResult != null;
        }
    }

    [HttpPost]
    public async Task<bool> UpdateCartNote([FromBody] CartDetails cartDetails)
    {
        var cart = await _cartService.GetCart();
        var currentCartLine = cart.CartLines.FirstOrDefault(
            l => l.Id.ToString().ToLower().Equals(cartDetails.cartLineId)
        );

        var updatedLineResult = await _cartService.UpdateCartLine(
            currentCartLine.Id.ToString(),
            currentCartLine.ProductId.ToString(),
            currentCartLine.ErpNumber,
            currentCartLine.QtyOrdered.ToString(),
            currentCartLine.UnitOfMeasure,
            cartDetails.itemNote,
            currentCartLine.Properties
        );
        return updatedLineResult != null;
    }

    [HttpPost]
    public async Task<bool> UpdateCartLine([FromBody] CartDetails cartDetails)
    {
        var product = _productService.GetProduct(cartDetails.productId);
        cartDetails.qty = string.IsNullOrEmpty(cartDetails.qty) ? "1" : cartDetails.qty;

        if (int.Parse(cartDetails.qty) == 0)
        {
            return await _cartService.RemoveCartLine(cartDetails.cartLineId);
        }
        else
        {
            var cart = await _cartService.GetCart();
            var currentCartLine = cart.CartLines.FirstOrDefault(
                l => l.Id.ToString().ToLower().Equals(cartDetails.cartLineId)
            );
            var properties = new Dictionary<string, string>();
            if (currentCartLine != null)
            {
                properties = currentCartLine.Properties;
            }

            var updatedLineResult = await _cartService.UpdateCartLine(
                cartDetails.cartLineId,
                cartDetails.productId,
                cartDetails.erpNumber,
                cartDetails.qty,
                currentCartLine.UnitOfMeasure,
                cartDetails.itemNote,
                properties
            );
            return updatedLineResult != null;
        }
    }

    //[HttpPost]
    //public virtual async Task<IActionResult> AddAllToCartCheckout([FromBody] CartLineItems itemsList)
    //{
    //    var isSuccess = false;
    //    var cartLines = itemsList.cartLineItems
    //        .Select(
    //            x =>
    //                new AddCartLine()
    //                {
    //                    ProductId = Guid.Parse(x.ProductId),
    //                    QtyOrdered = decimal.Parse(x.QtyOrdered),
    //                    UnitOfMeasure = x.UnitOfMeasure
    //                }
    //        )
    //        .ToList();
    //    if (cartLines.Count > 0)
    //    {
    //        var currentCart = await _cartService.GetCart();
    //        var result = await _cartService.AddAllToCart(cartLines);
    //        currentCart = await _cartService.GetCart();
    //        var cartQuantity =
    //            currentCart != null
    //                ? currentCart.TotalCountDisplay
    //                : 0;
    //        isSuccess = result != null;
    //        var cartPageUrl = "";
    //        return Json(new { isSuccess, cartPageUrl, cartQuantity });
    //    }
    //    else
    //    {
    //        return Json(new { isSuccess });
    //    }
    //}

    [HttpPost]
    public virtual async Task<bool> UpdateWarehouseId([FromBody] WarehouseViewModel warehouseViewModel)
    {
        var session = await _sessionService.PatchSessionCustomerInfo(new Session
        {
            CustomerWasUpdated = true,
            FulfillmentMethod = "PickUp",
            PickUpWarehouse = new Warehouse
            {
                Id = Guid.Parse(warehouseViewModel.WarehouseId)
            }
        });
       
        if (!session)
        {
            return session;
        }

        _cookieService.Set("CurrentFulfillmentMethod", "PickUp");
        _cookieService.Set("CurrentPickUpWarehouseId", warehouseViewModel.WarehouseId);
        return session;
    }

    [HttpPost]
    public virtual async Task<bool> UpdateFulfillmentMethod([FromBody] WarehouseViewModel warehouseViewModel)
    {
        var session = await _sessionService.PatchSessionCustomerInfo(new Session
        {
            CustomerWasUpdated = true,
            FulfillmentMethod = warehouseViewModel.FullfilmentType
        });

        if (!session)
        {
            return session;
        }

        _cookieService.Set("CurrentFulfillmentMethod", warehouseViewModel.FullfilmentType);
        _cookieService.Remove("CurrentPickUpWarehouseId");
        return session;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> Index(CartPageViewModel cartPageViewModel)
    {
        var isAuthenticated = await _authenticationService.IsAuthenticatedAsync();
        var signinPageRedirectUrl = Url.ContentUrl(
            cartPageViewModel.CurrentContent.SignInPageLink
        );
        var savedOrderDetailPageUrl = Url.ContentUrl(
            cartPageViewModel.CurrentContent.SavedOrderDetailsPageLink
        );
        if (
            string.IsNullOrWhiteSpace(signinPageRedirectUrl)
            && string.IsNullOrWhiteSpace(savedOrderDetailPageUrl)
        )
        {
            LogManager.GetLogger(GetType()).Error("Cart Page button Redirect Url is empty.");
        }
        if (!isAuthenticated)
        {
            return Redirect(signinPageRedirectUrl);
        }
        var currentCart = await _cartService.GetCartwithCostcodes();
        if (currentCart.BillTo.IsGuest)
        {
            return Redirect(signinPageRedirectUrl);
        }
        currentCart.Status = CartStatus.Saved.ToString();
        var result = await _cartService.SaveCart(currentCart);
        if (result != null)
        {
            return Redirect(savedOrderDetailPageUrl + "?cartid=" + result.Id);
        }
        return View(cartPageViewModel);
    }

    [HttpPost]
    public virtual async Task<IActionResult> SaveOrder([FromBody] CartDetails cartDetails)
    {
        var redirectionUrl = "";
        var isAuthenticated = await _authenticationService.IsAuthenticatedAsync();
        var savedOrderDetailPageUrl = Url.ContentUrl(cartDetails.savedOrderDetailsPageLink);
        var cartPageUrl = Url.ContentUrl(cartDetails.cartPageLink);
        redirectionUrl = $"{_settingsHelper.GetLoginPageUrl()}?ReturnUrl={cartPageUrl}";
        if (!isAuthenticated)
        {
            return Json(redirectionUrl);
        }
        var currentCart = await _cartService.GetCartwithCostcodes();
        if (currentCart.BillTo.IsGuest)
        {
            return Json(redirectionUrl);
        }
        currentCart.Status = CartStatus.Saved.ToString();
        var result = await _cartService.SaveCart(currentCart);
        if (result != null)
        {
            redirectionUrl = savedOrderDetailPageUrl + "?cartid=" + result.Id;
        }
        return Json(redirectionUrl);
    }

    private async Task<Dictionary<string, string>> GetStyleTraitValues(
        NameValueCollection querystring,
        string currentProductId
    )
    {
        var parentProductId = querystring.Get("parentId");
        if (string.IsNullOrEmpty(parentProductId))
            return null;
        var parentProduct = await _productService.GetProduct(
            new List<string> { "styledproducts" },
            parentProductId
        );
        var styledProduct = new StyledProduct();
        foreach (var childProduct in parentProduct.Product.StyledProducts)
        {
            if (!childProduct.ProductId.ToString().ToLower().Equals(currentProductId))
                continue;
            styledProduct = childProduct;
            break;
        }

        return styledProduct.StyleValues.ToDictionary(
            styleValue => styleValue.StyleTraitName,
            styleValue => styleValue.ValueDisplay
        );
    }
}
