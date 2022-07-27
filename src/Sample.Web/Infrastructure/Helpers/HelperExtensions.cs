namespace Sample.Web.Infrastructure.Helpers;

public static class HelperExtensions
{
    public static string Truncate(this string value, int maxChars = 18)
    {
        return value.Length <= maxChars
          ? value
          : string.Concat(value.Substring(0, maxChars), "...");
    }
}
