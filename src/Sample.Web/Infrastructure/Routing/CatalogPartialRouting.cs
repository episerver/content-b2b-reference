using EPiServer.Core.Routing;
using EPiServer.Core.Routing.Pipeline;

namespace Sample.Web.Infrastructure.Routing;

class CatalogPartialRouting : IPartialRouter<Models.Pages.CatalogPage, CatalogViewModel>
{
    public object RoutePartial(Models.Pages.CatalogPage content, UrlResolverContext segmentContext)
    {
        var contentx = new CatalogViewModel(content)
        {
            Path = $"/{content.URLSegment}/{segmentContext.RemainingSegments}"
        };
        segmentContext.RemainingSegments = string.Empty.ToCharArray();
        return contentx;
    }

    public PartialRouteData GetPartialVirtualPath(
        CatalogViewModel content,
        UrlGeneratorContext urlGeneratorContext
    )
    {
        return null;
    }
}
