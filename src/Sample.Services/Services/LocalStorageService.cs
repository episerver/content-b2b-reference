using CommerceApiSDK.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace Sample.Services.Services;

public class LocalStorageService : ILocalStorageService
{
    private const string KeyPrefix = "lo-";

    private readonly IHttpContextAccessor httpContextAccessor;

    private ISession Session =>
        httpContextAccessor.HttpContext?.Features.Get<ISessionFeature>() == null
            ? null
            : httpContextAccessor.HttpContext.Session;

    public LocalStorageService(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public string Load(string key)
    {
        return Session?.GetString(GetKey(key)) ?? string.Empty;
    }

    public string Load(string key, string defaultValue)
    {
        return Session?.GetString(GetKey(key)) ?? defaultValue;
    }

    public int LoadInt(string key)
    {
        return Session?.GetInt32(GetKey(key)) ?? -1;
    }

    public void Save(string key, string value)
    {
        Session?.SetString(GetKey(key), value);
    }

    public void Save(string key, int value)
    {
        Session?.SetInt32(GetKey(key), value);
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

    private static string GetKey(string key) => $"{KeyPrefix}{key}";
}
