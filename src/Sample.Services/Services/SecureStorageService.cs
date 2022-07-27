using CommerceApiSDK.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace Sample.Services.Services;

public class SecureStorageService : ISecureStorageService
{
    private const string KeyPrefix = "se-";

    private readonly IHttpContextAccessor httpContextAccessor;

    private ISession Session =>
        httpContextAccessor.HttpContext?.Features.Get<ISessionFeature>() == null
            ? null
            : httpContextAccessor.HttpContext.Session;

    public SecureStorageService(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public string Load(string key)
    {
        return Session?.GetString(GetKey(key)) ?? string.Empty;
    }

    public bool Save(string key, string value)
    {
        try
        {
            Session?.SetString(GetKey(key), value);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Remove(string key)
    {
        try
        {
            Session?.Remove(GetKey(key));
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool ClearAll()
    {
        var success = true;
        foreach (
            var key in Session?.Keys.Where(o => o.StartsWith(KeyPrefix))
                ?? Array.Empty<string>()
        )
        {
            if (!Remove(key))
            {
                success = false;
            }
        }

        return success;
    }

    private static string GetKey(string key) => $"{KeyPrefix}{key}";
}
