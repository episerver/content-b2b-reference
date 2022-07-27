using CommerceApiSDK.Services;
using CommerceApiSDK.Services.Interfaces;

namespace Sample.Services.Account;

public class AuthenticationService : BaseService, IAuthenticationService
{
    private readonly CommerceApiSDK.Services.Interfaces.IAuthenticationService _authenticationClient;
    private readonly ISessionService _sessionClient;

    public AuthenticationService(
        CommerceApiSDK.Services.Interfaces.IAuthenticationService authenticationClient,
        ISessionService sessionClient
    )
    {
        _authenticationClient = authenticationClient;
        _sessionClient = sessionClient;
    }

    public virtual async Task<(bool, ErrorResponse)> SignInAsync(string username, string password)
    {
        return await _authenticationClient.LogInAsync(username, password);
    }

    public virtual async Task SignOutAsync()
    {
        await _authenticationClient.LogoutAsync();
    }

    public async Task<CommerceApiSDK.Models.Session> GetCurrentSessionAsync()
    {
        return await _sessionClient.GetCurrentSession();
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        return await _authenticationClient.IsAuthenticatedAsync();
    }
}
