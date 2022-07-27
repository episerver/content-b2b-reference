namespace Sample.Web.Infrastructure;

public class CommerceApiSettings
{
    public string baseUrl { get; set; }
    public string clientId { get; set; }
    public string clientSecret { get; set; }
    public string grantType { get; set; }
    public string scope { get; set; }
    public string queryValueSeparator { get; set; }
    public string valueSeparator { get; set; }
    public bool enableCaching { get; set; }
    public int cacheExpiryInHour { get; set; } = 1;
}
