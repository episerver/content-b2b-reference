using System.Net.Http;

namespace Sample.Services.Session;

public interface ISessionService
{
    Task<bool> PatchSessionCustomerInfo(CommerceApiSDK.Models.Session session);
    Task<CommerceApiSDK.Models.Session> GetCurrent();
    Task<bool> ResetPassword(string username);
    Task<HttpResponseMessage> Delete();
}
