using Microsoft.Extensions.DependencyInjection;
using Sample.Services.Account;
using Sample.Services.Cart;
using Sample.Services.Catalog;
using Sample.Services.Category;
using Sample.Services.DashBoardPanel;
using Sample.Services.Invoices;
using Sample.Services.Orders;
using Sample.Services.Services;
using Sample.Services.Session;
using Sample.Services.Tokenization;
using Sample.Services.Website;
using Sample.Services.WishList;

namespace Sample.Services;

/// <summary>
/// Contains convenient extension methods to add Sample.Services to application.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the services required by the Sample.Services to an <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>The configured service container.</returns>
    public static IServiceCollection AddSampleServices(this IServiceCollection services)
    {
        services.AddSingleton<CommerceApiSDK.Services.Interfaces.ILocalStorageService, LocalStorageService>();
        services.AddSingleton<CommerceApiSDK.Services.Interfaces.ISecureStorageService, SecureStorageService>();
        services.AddSingleton<CommerceApiSDK.Services.Interfaces.INetworkService, NetworkService>();
        services.AddSingleton<CommerceApiSDK.Services.Interfaces.ITrackingService, TrackingService>();
        services.AddSingleton<ICategoryService, CategoryService>();
        services.AddSingleton<IAuthenticationService, AuthenticationService>();
        services.AddSingleton<IAccountService, AccountService>();
        services.AddSingleton<ICartService, CartService>();
        services.AddSingleton<IProductService, ProductService>();
        services.AddSingleton<IInvoiceService, InvoiceService>();
        services.AddSingleton<IOrderService, OrderService>();
        services.AddSingleton<ISessionService, SessionService>();
        services.AddSingleton<ISharedService, SharedService>();
        services.AddSingleton<ITokenizationService, TokenizationService>();
        services.AddSingleton<IWebsiteService, WebsiteService>();
        services.AddSingleton<IWishListService, WishListService>();
        return services;
    }
}
