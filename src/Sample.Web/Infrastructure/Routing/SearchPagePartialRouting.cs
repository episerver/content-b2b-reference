using EPiServer.Core.Routing;
using EPiServer.Core.Routing.Pipeline;

namespace Sample.Web.Infrastructure.Routing;

class SearchPagePartialRouting : IPartialRouter<SearchPage, SearchPage>
{
    public object RoutePartial(SearchPage content, UrlResolverContext segmentContext)
    {
        segmentContext.RouteValues["path"] =
            $"/{content.URLSegment}/{segmentContext.RemainingSegments}";
        segmentContext.RemainingSegments = string.Empty.ToCharArray();
        return content;
    }

    public PartialRouteData GetPartialVirtualPath(
        SearchPage content,
        UrlGeneratorContext urlGeneratorContext
    )
    {
        return null;
    }
}
