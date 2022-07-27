using AngleSharp;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace Sample.Web.Infrastructure.Extensions;

public static class StringExtensions
{
    private static readonly Lazy<IConfiguration> _angleConfig = new Lazy<IConfiguration>(() => Configuration.Default);

    public static bool IsLocalUrl(this string url, HttpRequest request)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out var absoluteUri) && string.Equals(request.Host.Host,
                   absoluteUri.Host, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsNullOrEmpty(this string input) => string.IsNullOrEmpty(input);

    public static bool IsEmpty(this string input) => input == null || input.Equals("");

    public static string MakeCompactString(this string str, int maxLength = 30, string suffix = "...")
    {
        var newStr = string.IsNullOrEmpty(str) ? string.Empty : str;
        var strLength = string.IsNullOrEmpty(str) ? 0 : str.Length;
        if (strLength > maxLength)
            newStr = str?.Substring(0, maxLength);

        return newStr + suffix;
    }

    public static string GetPageUrl(this string url, int page)
    {
        var uri = new Uri(url);
        var querystring = uri.Query.IsNullOrEmpty() ? new Dictionary<string, StringValues>() : QueryHelpers.ParseQuery(uri.Query);
        querystring["page"] = page.ToString();
        return QueryHelpers.AddQueryString(uri.AbsolutePath, querystring);
    }

    public static async Task<string> GetBodyInnerHtml(this string html)
    {
        using var context = BrowsingContext.New(_angleConfig.Value);
        using var doc = await context.OpenAsync(req => req.Content(html));
        return doc.Body.InnerHtml.Trim();
    }
}