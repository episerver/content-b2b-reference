using EPiServer.Core.Routing.Pipeline;

namespace Sample.Web.Infrastructure.Routing;

public class EpicelerContentRouteRegister : IContentRouteRegister
{
    public ContentRouteDefinition ContentRouteDefintion =>
        new ContentRouteDefinition() { Name = "Epi" };
}
