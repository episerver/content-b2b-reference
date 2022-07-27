using Microsoft.AspNetCore.Http.Extensions;
using Sample.Services.Cart;

namespace Sample.Web.Features.Shared.Components.Header;

public class HeaderViewComponent : ViewComponent
{
    private readonly ISettingsHelper _settingsService;
    private readonly IAuthenticationService _authenticationService;
    private readonly ICartService _cartService;
    private readonly IWebsiteService _websiteService;
    private readonly CommerceApiSDK.Services.Interfaces.IWarehouseService _warehouseService;

    public HeaderViewComponent(ISettingsHelper settingsService,
        IAuthenticationService authenticationService,
        ICartService cartService,
        IWebsiteService websiteService, 
        CommerceApiSDK.Services.Interfaces.IWarehouseService warehouseService)
    {
        _settingsService = settingsService;
        _authenticationService = authenticationService;
        _cartService = cartService;
        _websiteService = websiteService;
        _warehouseService = warehouseService;
    }

    public virtual async Task<IViewComponentResult> InvokeAsync()
    {
        return await Task.FromResult(View("Default", await CreateViewModel()));
    }

    protected async Task<HeaderViewModel> CreateViewModel()
    {
        var session = await _authenticationService.GetCurrentSessionAsync();
        var warehouses = await _warehouseService.GetWarehouses(new WarehousesQueryParameters
        {
            OnlyPickupWarehouses = true,
            Latitude = 44.981047,
            Longitude = -93.27417,
            ExcludeCurrentPickupWarehouse = false,
            Page = 1,
            Sort = "Distance"
        });
        var model = new HeaderViewModel
        {
            Session = session,
            CurrentUrl = Request.GetEncodedUrl(),
            Website = await _websiteService.GetWebsite(new List<string> { "languages", "currencies" }),
            Warehouses = warehouses.Warehouses.Select(x => new Warehouse
            {
                Name = x.Name,
                Id = x.Id,
                IsDefault = (session?.PickUpWarehouse?.Id ?? Guid.Empty) == x.Id
            }).ToList()

        };
        model.IsAuthenticated = model.Session?.IsAuthenticated ?? false; 
        if (model.IsAuthenticated)
        {
            var cart = await _cartService.GetCart();
            if (cart != null)
            {
                model.CartCount = cart.LineCount;
            }
        }

        var header = _settingsService.GetSettings<HeaderSettings>();
        if (header != null)
        {
            model.Title = header.Title;
            model.Logo = header.Logo;
        }

        var labels = _settingsService.GetSettings<LabelSettings>();
        if (labels != null)
        {
            model.CartText = labels.CartText;
            model.LoginText = labels.LoginText;
            model.CustomerNumberText = labels.CustomerNameLabel;
            model.ChangeCustomerText = labels.CustomerChangeLinkText;
            model.ChangePasswordText = labels.ChangePasswordLabel;
            model.ForgotPasswordText = labels.ForgetPasswordLabel;
            model.MyAccountText = labels.MyAcountLabel;
            model.SingoutText = labels.LogoutLinkText;
        }

        var pages = _settingsService.GetSettings<PageReferenceSettings>();
        if (pages != null)
        {
            model.CartPage = pages.CartPage;
            model.LoginPage = pages.LoginPage;
            model.ForgotPasswordPage = pages.ForgotPasswordPage;
            model.ChangePasswordPage = pages.ChangePasswordPage;
            model.MyAccountPage = pages.MyAccountPage;
            model.SignoutPage = pages.LogoutPage;
        }

        return model;
    }
}
