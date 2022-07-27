using CommerceApiSDK.Services.Interfaces;

namespace Sample.Services.Services;

public class NetworkService : INetworkService
{
    public bool IsOnline()
    {
        return true;
    }
}
