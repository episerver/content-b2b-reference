namespace Sample.Services.Website;

public class WebsiteService : BaseService, IWebsiteService
{
    private readonly CommerceApiSDK.Services.Interfaces.IWebsiteService _websiteClient;

    public WebsiteService(CommerceApiSDK.Services.Interfaces.IWebsiteService websiteClient)
    {
        _websiteClient = websiteClient;
    }

    public async Task<List<Country>> GetCountriesWithStates()
    {
        var countries = await _websiteClient.GetCountries();
        return ((List<Country>)countries?.Countries) ?? new List<Country>();
    }

    public async Task<WebsiteCrosssells> GetWebsiteCrossSells()
    {
        return await _websiteClient.GetCrosssells();
    }

    public async Task<CommerceApiSDK.Models.Website> GetWebsite(List<string> expand = null)
    {
        return await _websiteClient.GetWebsite(new WebsiteQueryParameters
        {
            Expand = expand
        });
    }
}
