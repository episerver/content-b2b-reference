using Sample.Web.Features.Shared.Components.Menu;

namespace Sample.Web.Features.Shared.Components.MobileMenu;

public class MobileMenuViewComponent : MenuViewComponent
{
    public MobileMenuViewComponent(IContentLoader contentLoader,
        IContextModeResolver contextModeResolver,
        IContentCacheKeyCreator contentCacheKeyCreator,
        IUrlResolver urlResolver,
        ISettingsHelper settingsService)
        : base(contentLoader, contextModeResolver, contentCacheKeyCreator, urlResolver, settingsService)
    {

    }

    public override async Task<IViewComponentResult> InvokeAsync()
    {
        return await Task.FromResult(View("Default", CreateViewModel()));
    }
}
