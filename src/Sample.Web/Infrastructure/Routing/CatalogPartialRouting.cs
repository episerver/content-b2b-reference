using EPiServer.Core.Routing;
using EPiServer.Core.Routing.Pipeline;

namespace Sample.Web.Infrastructure.Routing;

class CatalogPartialRouting : IPartialRouter<Models.Pages.CatalogPage, CatalogRoutedViewModel>
{
    private readonly ISettingsHelper _settingsHelper;

    public CatalogPartialRouting(ISettingsHelper settingsHelper)
    {
        _settingsHelper = settingsHelper;
    }

    public object RoutePartial(Models.Pages.CatalogPage content, UrlResolverContext segmentContext)
    {
        var path = new CatalogRoutedViewModel()
        {
            Path = $"/{content.URLSegment}/{segmentContext.RemainingSegments}"
        };
        segmentContext.RemainingSegments = string.Empty.ToCharArray();
        return path;
    }

    public PartialRouteData GetPartialVirtualPath(
       CatalogRoutedViewModel content,
        UrlGeneratorContext urlGeneratorContext
    )
    {
        return new PartialRouteData()
        {
            BasePathRoot = _settingsHelper.GetCatalogPage().ContentLink,
            PartialVirtualPath = content.Path
        };
    }
}
