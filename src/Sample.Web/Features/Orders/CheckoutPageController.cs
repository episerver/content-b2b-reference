using Microsoft.AspNetCore.Http.Extensions;
using Sample.Services.Cart;
using Sample.Services.Session;
using Sample.Services.Tokenization;
using static System.String;

namespace Sample.Web.Features.Orders;

[LoginRequired]
public class CheckoutPageController : PageControllerBase<CheckoutPage>
{
    private readonly ICartService _cartService;
    private readonly IWebsiteService _websiteService;
    private readonly ISessionService _sessionService;
    private readonly IAccountService _accountService;
    private readonly ITokenizationService _tokenizationService;
    private readonly CommerceApiSDK.Services.Interfaces.IWarehouseService _warehouseService;
    private readonly ICookieService _cookieService;
    private readonly ISettingsHelper _settingsHelper;
    private readonly IUrlResolver _urlResolver;

    public CheckoutPageController(
        ICartService cartService,
        IWebsiteService websiteService,
        ISessionService sessionService,
        IAccountService accountService,
        ITokenizationService tokenizationService,
        CommerceApiSDK.Services.Interfaces.IWarehouseService warehouseService,
        ICookieService cookieService,
        ISettingsHelper settingsHelper,
        IUrlResolver urlResolver)
    {
        _cartService = cartService;
        _websiteService = websiteService;
        _sessionService = sessionService;
        _accountService = accountService;
        _tokenizationService = tokenizationService;
        _warehouseService = warehouseService;
        _cookieService = cookieService;
        _settingsHelper = settingsHelper;
        _urlResolver = urlResolver;
    }

    [HttpGet]
    public async Task<IActionResult> Index(CheckoutPage currentPage)
    {
        var model = new CheckoutPageViewModel(currentPage);
        var cartExpand = new List<string>()
        {
            "tax",
            "shiptos",
            "validation",
            "carriers",
            "shipping",
            "paymentoptions",
            "paymentMethod",
            "cartlines"
        };

        model.Cart = await _cartService.GetCartWithOptions(cartExpand);

        if (model.Cart.CanBypassCheckoutAddress && (!Request.Query.TryGetValue("step", out var step) || step.Equals("payment")))
        {
            return await ReviewAndSubmit(currentPage);
        }
        model.Addresses = await _accountService.GetBillToAndShipTos();
        model.Promotions = await _cartService.GetPromotion();
        model.Warehouses = await _warehouseService.GetWarehouses(new WarehousesQueryParameters
        {
            OnlyPickupWarehouses = true,
            Latitude = 44.981047,
            Longitude = -93.27417,
            ExcludeCurrentPickupWarehouse = false,
            Page = 1,
            Sort = "Distance"
        });
        model.CurrentFulfillmentMethod = model.Cart.FulfillmentMethod;
        if ((model.CurrentFulfillmentMethod ?? "").Equals("PickUp"))
        {
            model.CurrentPickUpWarehouseId = model.Cart.ShipVia?.Id.ToString();
        }
        model.PromotionLabel = model.CurrentContent.PromotionLabel;
        model.SubtotalLabel = model.CurrentContent.Subtotal;
        model.TaxLabel = model.CurrentContent.Tax;
        model.TotalLabel = model.CurrentContent.Total;
        model.ShippingHandlingLabel = model.CurrentContent.ShippingHandling;
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> ReviewAndSubmit(CheckoutPage currentPage)
    {
        var model = new CheckoutPageViewModel(currentPage);
        var cartExpand = new List<string>()
        {
            "tax",
            "shiptos",
            "validation",
            "carriers",
            "shipping",
            "paymentoptions",
            "paymentMethod",
            "cartlines"
        };

        model.Cart = await _cartService.GetCartWithOptions(cartExpand);
        
        model.TokenExDto = await _tokenizationService.GetAuthenticationKey(
            new Uri(Request.GetDisplayUrl()).GetLeftPart(UriPartial.Authority)
        );
        model.Promotions = await _cartService.GetPromotion();

       
        model.PromotionLabel = model.CurrentContent.PromotionLabel;
        model.SubtotalLabel = model.CurrentContent.Subtotal;
        model.TaxLabel = model.CurrentContent.Tax;
        model.TotalLabel = model.CurrentContent.Total;
        model.ShippingHandlingLabel = model.CurrentContent.ShippingHandling;
        return View("ReviewAndSubmit", model);
    }
    
    [HttpPost]
    public ActionResult ValidatePromo(string promoCode)
    {
        var result = _cartService.ValidatePromo(promoCode);
        return Json(result);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateNotes([FromBody] UpdateNotes updateNotes)
    {
        var cart = await _cartService.GetCart();
        if (cart == null)
        {
            return Json(null);
        }
        cart.Notes = updateNotes.ItemNote;
        var result = await _cartService.SaveCart(cart);
        return Json(result);
    }


    [HttpPost]
    public async Task<IActionResult> UpdateCart([FromBody] UpdateCartCarrierService updateCartCarrierService)
    {
        var expands = new List<string>
        {
            "carriers",
            "tax",
            "shipping",
            "paymentoptions",
            "paymentMethod"
        };
        var cart = await _cartService.GetCartWithChildren(expands);
        cart.Carrier = cart.Carriers.FirstOrDefault(c => c.Id.ToString() == updateCartCarrierService.CarrierId);
        if (cart.Carrier != null)
        {
            cart.ShipVia = cart.Carrier.ShipVias.FirstOrDefault(c => c.Id.ToString() == updateCartCarrierService.ShipVia);
        }
        var result = await _cartService.SaveCart(cart);
        cart = await _cartService.GetCartWithChildren(expands);
        return Json(cart);
    }

    [HttpGet]
    public async Task<IActionResult> GetStates(string countryId)
    {
        var countries = await _websiteService.GetCountriesWithStates();
        var statesForCountry = countries
            .Where(x => x.Id == countryId)
            .Select(x => x.States)
            .ToList();

        return Json(statesForCountry.FirstOrDefault());
    }

    [HttpGet]
    public async Task<IActionResult> GetCart()
    {
        var cart = await _cartService.GetCartSummary();
        return cart != null ? Json(new { cart }) : Json(new EmptyResult());
    }

    [HttpPost]
    public async Task<IActionResult> UpdateShipTo([FromBody] AddressViewModel addressViewModel)
    {
        
        var billTo = await _accountService.GetCurrentBillTos();
        if (billTo == null)
        {
            return Json(null);
        }
        var shipTos = await _accountService.GetShipTos(Guid.Parse(billTo.Id));
        var shipTo = shipTos.ShipTos.FirstOrDefault(x => x.Id == addressViewModel.AddressId);
        if (shipTo == null)
        {
            return Json(null);
        }
        var result =await _sessionService.PatchSessionCustomerInfo(new Session
        {
            ShipTo = shipTo
        });
        return Json(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateShipTo([FromBody]ShipToViewModel shipToViewModel)
    {
        var billToId = Guid.Empty.ToString();
        var billTo = await _accountService.GetCurrentBillTos();
        if (billTo == null)
        {
            return Json(null);
        }
       
        billToId = billTo.Id;
        var countries = await _websiteService.GetCountriesWithStates();
        var country = countries.FirstOrDefault(x => x.Id == shipToViewModel.CountryId);
        var state = countries.FirstOrDefault(x => x.Id == shipToViewModel.CountryId)?.States.FirstOrDefault(x => x.Id == shipToViewModel.StateId);
        
        var shipTo = new ShipTo
        {
            FullAddress = shipToViewModel.FullAddress ?? Empty,
            Phone = shipToViewModel.Phone ?? Empty,
            Country = country ?? new Country { Id = shipToViewModel.CountryId },
            State = state ?? new State { Id = shipToViewModel.StateId },
            PostalCode = shipToViewModel.PostalCode ?? Empty,
            City = shipToViewModel.City ?? Empty,
            Address4 = shipToViewModel.Address4 ?? Empty,
            Address3 = shipToViewModel.Address3 ?? Empty,
            Address2 = shipToViewModel.Address2 ?? Empty,
            Address1 = shipToViewModel.Address1 ?? Empty,
            Attention = shipToViewModel.Attention ?? Empty,
            Email = shipToViewModel.Email ?? Empty,
            CompanyName = shipToViewModel.CompanyName ?? Empty,
            LastName = shipToViewModel.LastName ?? Empty,
            FirstName = shipToViewModel.FirstName ?? Empty,
            CustomerName = shipToViewModel.CustomerName ?? Empty,
            CustomerSequence = shipToViewModel.CustomerSequence ?? Empty,
            CustomerNumber = billTo.CustomerNumber,
            Id = "Create New Address",
            IsDefault = shipToViewModel.IsDefault,
            Label = shipToViewModel.Label,
            OneTimeAddress = shipToViewModel.OneTimeAddress,
            IsNew = shipToViewModel.IsNew,
            Fax = shipToViewModel.Fax ?? Empty,
            IsVmiLocation = "false"
        };
        
        var newShipTo = await _accountService.UpdateShipToDetails(billToId, shipTo);
        return Json(newShipTo);
    }

    [HttpGet]
    public async Task<IActionResult> GetCountries()
    {
        var countries = await _websiteService.GetCountriesWithStates();
        return Json(countries);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCurrentPromotions()
    {
        var promotions = await _cartService.GetPromotion();
        return promotions != null
          ? Json(new { promotions })
          : Json(new EmptyResult());
    }

    [HttpGet]
    public async Task<IActionResult> GetCarriers()
    {
        var cart = await _cartService.GetCartWithShippingDetails();
        return Json(cart.Carriers);
    }

    [HttpGet]
    public async Task<IActionResult> GetCarrierServices(string carrierId)
    {
        var cart = await _cartService.GetCartWithShippingDetails();
        var carrier = cart.Carriers.FirstOrDefault(x => x.Id.Value.ToString().Equals(carrierId));
        return Json(carrier.ShipVias ?? new List<ShipViaDto>());
    }

    [HttpGet]
    public async Task<IActionResult> GetAuthenticationKey(string token, string origin)
    {
        return Json(await _tokenizationService.GetAuthenticationKey(origin, token, false));
    }

    [HttpPost]
    public async Task<IActionResult> SubmitOrder([FromBody] ReviewAndSubmitViewModel model)
    {
        var cart = await _cartService.GetCartWithOptions(new List<string>()
        {
            "tax",
            "shiptos",
            "validation",
            "carriers",
            "shipping",
            "paymentoptions",
            "paymentMethod",
            "cartlines"
        });

        if (cart == null)
        {
            return Json(null);
        }

        cart.Carrier = cart.Carriers.FirstOrDefault(x => Guid.TryParse(model.CarrierId, out var id) && x.Id == id);
        if (cart.Carrier != null)
        {
            cart.ShipVia = cart.Carrier.ShipVias.FirstOrDefault(x => Guid.TryParse(model.ServiceId, out var id) && x.Id == id);
        }

        cart.PaymentMethod = cart.PaymentOptions.PaymentMethods.FirstOrDefault(x => x.Name.Equals(model.PaymentMethodId));
        if (cart.PaymentMethod != null)
        {
            if ((model.PaymentMethodId ?? "").Equals("CC"))
            {
                cart.PaymentOptions.StorePaymentProfile = cart.PaymentOptions.CanStorePaymentProfile && model.SaveCard;
                cart.PaymentOptions.CreditCard.CardHolderName = model.NameOnCard;
                cart.PaymentOptions.CreditCard.CardNumber = model.CardToken;
                cart.PaymentOptions.CreditCard.SecurityCode = model.CvvToken;
                cart.PaymentOptions.CreditCard.ExpirationMonth = int.Parse(model.ExpirationDate.Substring(0, 2));
                cart.PaymentOptions.CreditCard.ExpirationYear = int.Parse(model.ExpirationDate.Substring(3, 2));
                cart.CreditCardBillingAddress = new CreditCardBillingAddress();
                if (model.UseBillingAddress)
                {
                    
                    cart.CreditCardBillingAddress.Address1 = cart.BillTo.Address1;
                    cart.CreditCardBillingAddress.Address2 = cart.BillTo.Address2;
                    cart.CreditCardBillingAddress.City = cart.BillTo.City;
                    cart.CreditCardBillingAddress.CountryAbbreviation = cart.BillTo.Country.Abbreviation;
                    cart.CreditCardBillingAddress.PostalCode = cart.BillTo.PostalCode;
                    cart.CreditCardBillingAddress.StateAbbreviation = cart.BillTo.State.Abbreviation;
                }
                else
                {
                    cart.CreditCardBillingAddress.Address1 = model.Address1;
                    cart.CreditCardBillingAddress.City = model.City;
                    cart.CreditCardBillingAddress.CountryAbbreviation = model.CountryId;
                    cart.CreditCardBillingAddress.PostalCode = model.PostalCode;
                    cart.CreditCardBillingAddress.StateAbbreviation = model.RegionId;
                }
            }
            else
            {
                cart.PaymentOptions.CreditCard.SecurityCode = model.CvvToken;
            }
        }
        
        if (!string.IsNullOrEmpty(model.DeliveryDate))
        {
            cart.RequestedDeliveryDate = model.DeliveryDate;
        }

        if (!string.IsNullOrEmpty(model.PONumber))
        {
            cart.PoNumber = model.DeliveryDate;
        }
        
        cart = await _cartService.SubmitCart(cart);
        if (cart.Status.Equals("Submitted"))
        {
            return Json(new
            {
                Success = true,
                Url = _urlResolver.GetUrl(_settingsHelper.GetSettings<PageReferenceSettings>().OrderConfirmationPage) + $"?cartId={cart.Id}"
            });
        }
        return Json(new
        {
            Success = false,
            message = ""
        });

    }
}
