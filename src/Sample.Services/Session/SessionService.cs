using System.Net.Http;

namespace Sample.Services.Session;

public class SessionService : BaseService, ISessionService
{
    private readonly CommerceApiSDK.Services.Interfaces.ISessionService _sessionClient;

    public SessionService(CommerceApiSDK.Services.Interfaces.ISessionService sessionClient)
    {
        _sessionClient = sessionClient;
    }

    public async Task<bool> PatchSessionCustomerInfo(CommerceApiSDK.Models.Session session)
    {
        var response = await _sessionClient.PatchSession(session);
        if (response != null)
            return true;
        return false;
    }

    public virtual async Task<CommerceApiSDK.Models.Session> GetCurrent()
    {
        return await _sessionClient.GetCurrentSession();
    }

    public async Task<bool> ResetPassword(string username)
    {
        var session = new CommerceApiSDK.Models.Session()
        {
            UserName = username,
            ResetPassword = true
        };
        var response = await _sessionClient.PatchSession(session);
        if (response != null)
            return true;
        return false;
    }

    public virtual async Task<HttpResponseMessage> Delete()
    {
        return await _sessionClient.DeleteCurrentSession();
    }
}
