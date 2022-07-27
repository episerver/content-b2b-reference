namespace Sample.Services.Website;

public interface IWebsiteService
{
    Task<List<Country>> GetCountriesWithStates();
    Task<WebsiteCrosssells> GetWebsiteCrossSells();
    Task<CommerceApiSDK.Models.Website> GetWebsite(List<string> expand = null);
}
