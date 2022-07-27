using EPiServer.Core.Routing;
using EPiServer.Core.Routing.Pipeline;

namespace Sample.Web.Infrastructure.Routing;

class BrandsPartialRouting : IPartialRouter<BrandsPage, BrandsPage>
{
    public object RoutePartial(BrandsPage content, UrlResolverContext segmentContext)
    {
        segmentContext.RouteValues["path"] =
            $"/{content.URLSegment}/{segmentContext.RemainingSegments}";
        segmentContext.RemainingSegments = string.Empty.ToCharArray();
        return content;
    }

    public PartialRouteData GetPartialVirtualPath(
        BrandsPage content,
        UrlGeneratorContext urlGeneratorContext
    )
    {
        return null;
    }
}
