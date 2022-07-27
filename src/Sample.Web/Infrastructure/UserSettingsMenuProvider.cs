using EPiServer.Shell.Navigation;

namespace Sample.Web.Infrastructure;

[MenuProvider]
public class UserSettingsMenuProvider : IMenuProvider
{
    private readonly IContentLoader _contentLoader;
    private readonly CommerceApiSettings _commerceApiSettings;

    public UserSettingsMenuProvider(IOptionsMonitor<CommerceApiSettings> commerceApiSettings,
        IContentLoader contentLoader)
    {
        _commerceApiSettings = commerceApiSettings.CurrentValue;
        _contentLoader = contentLoader;
    }

    public IEnumerable<MenuItem> GetMenuItems()
    {
        //If StartPage has not been created menu will not be added
        if (
            !_contentLoader.TryGet<HomePage>(
                SiteDefinition.Current.StartPage,
                out var startPage
            )
        )
            return new List<MenuItem>();
        var commerceApiUrl = _commerceApiSettings.baseUrl;
        return new List<MenuItem>
        {
            new UrlMenuItem(
                "B2B Commerce Admin",
                MenuPaths.User + "/episerver2",
                $"{commerceApiUrl}/admin"
            )
            {
                SortIndex = SortIndex.Last + 10,
                IsAvailable = (request) => PrincipalInfo.CurrentPrincipal.IsInRole("CmsAdmins"),
                Target = "_blank"
            }
        };
    }
}
