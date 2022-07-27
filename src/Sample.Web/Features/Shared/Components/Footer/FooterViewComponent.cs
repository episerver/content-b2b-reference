namespace Sample.Web.Features.Shared.Components.Footer;

public class FooterViewComponent : ViewComponent
{
    private readonly ISettingsHelper _settingsService;

    public FooterViewComponent(ISettingsHelper settingsService)
    {
        _settingsService = settingsService;
    }

    public virtual async Task<IViewComponentResult> InvokeAsync()
    {
        return await Task.FromResult(View("Default", _settingsService.GetSettings<FooterSettings>()));
    }
}
