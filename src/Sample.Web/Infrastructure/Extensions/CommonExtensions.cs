using Microsoft.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace Sample.Web.Infrastructure.Extensions;

public static class CommonExtensions
{
    private static Regex _mobileRegex1 = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);

    public static bool IsMobile(this IHeaderDictionary headers)
    {
        if (headers == null)
        {
            return false;
        }

        if (!headers.ContainsKey(HeaderNames.UserAgent))
        {
            return false;
        }

        return _mobileRegex1.IsMatch(headers[HeaderNames.UserAgent].ToString()) || _mobileRegex1.IsMatch(headers[HeaderNames.UserAgent].ToString().Substring(0, 4));
    }
}
