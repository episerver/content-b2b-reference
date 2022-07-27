using EPiServer.Data;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;

namespace Sample.Models.Attributes;

public class AllowDBWriteAttribute : ActionMethodSelectorAttribute
{
    protected Injected<IDatabaseMode> DBMode;

    public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
    {
        return DBMode.Service != null && DBMode.Service.DatabaseMode != DatabaseMode.ReadOnly;
    }
}
