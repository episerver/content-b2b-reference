using EPiServer.Core.Routing;
using EPiServer.Core.Routing.Pipeline;

namespace Sample.Web.Infrastructure.Routing;

public class BrandDetailsPartialRouting : IPartialRouter<BrandDetailsPage, BrandDetailsPage>
{
    public object RoutePartial(BrandDetailsPage content, UrlResolverContext segmentContext)
    {
        segmentContext.RouteValues["path"] =
            $"/{content.URLSegment}/{segmentContext.RemainingSegments}";

        segmentContext.RemainingSegments = string.Empty.ToCharArray();
        return content;
    }

    public PartialRouteData GetPartialVirtualPath(
        BrandDetailsPage content,
        UrlGeneratorContext urlGeneratorContext
    )
    {
        return null;
    }
}
