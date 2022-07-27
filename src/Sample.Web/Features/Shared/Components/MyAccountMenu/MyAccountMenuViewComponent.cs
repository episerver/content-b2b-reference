using EPiServer.SpecializedProperties;

namespace Sample.Web.Features.Shared.Components.MyAccountMenu;

public class MyAccountMenuViewComponent : ViewComponent
{
    private readonly ISettingsHelper _settingsService;

    public MyAccountMenuViewComponent(ISettingsHelper settingsService)
    {
        _settingsService = settingsService;
    }

    public virtual async Task<IViewComponentResult> InvokeAsync()
    {
        return await Task.FromResult(View("Default", CreateViewModel()));
    }

    protected LinkItemCollection CreateViewModel()
    {
       
        var myAccount = _settingsService.GetSettings<MyAccountSettings>();
        if (myAccount == null)
        {
            return new LinkItemCollection();
        }

        return myAccount.Menu;
    }
}