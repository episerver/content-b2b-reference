using EPiServer.Shell.Security;

namespace Sample.Web.Features.Shared;

/// <summary>
/// All controllers that renders pages should inherit from this class so that we can
/// apply action filters, such as for output caching site wide, should we want to.
/// </summary>
public abstract class PageControllerBase<T> : PageController<T>
    where T : BasePage
{
    protected Injected<UISignInManager> UISignInManager;
    protected Injected<UIUserManager> UIUserManager;

    protected string GetPageReferenceUrl(Func<PageReferenceSettings, ContentReference> getReference)
    {
        var setting = HttpContext.RequestServices.GetInstance<ISettingsHelper>().GetSettings<PageReferenceSettings>();
        if (setting == null)
        {
            return null;
        }

        var reference = getReference(setting);
        if (ContentReference.IsNullOrEmpty(reference))
        {
            return null;
        }

        return HttpContext.RequestServices.GetInstance<IUrlResolver>()
            .GetUrl(reference, HttpContext.RequestServices.GetInstance<IContentLanguageAccessor>().Language?.Name ?? "en");
    }
}
