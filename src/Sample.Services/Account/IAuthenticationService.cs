using CommerceApiSDK.Services;

namespace Sample.Services.Account;

public interface IAuthenticationService
{
    Task<(bool, ErrorResponse)> SignInAsync(string username, string password);
    Task SignOutAsync();
    Task<CommerceApiSDK.Models.Session> GetCurrentSessionAsync();
    Task<bool> IsAuthenticatedAsync();
}
