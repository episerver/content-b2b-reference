using EPiServer.Logging;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Sample.Web.Infrastructure;

public class LoginRequiredAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var isPageEditMode = (
                context.HttpContext.RequestServices.GetInstance<IContextModeResolver>().CurrentMode
                    == ContextMode.Edit
                || context.HttpContext.RequestServices.GetInstance<IContextModeResolver>().CurrentMode
                    == ContextMode.Preview
            );
            if (isPageEditMode)
            {
                return;
            }
            var isAuthenticated = context.HttpContext.RequestServices
                .GetInstance<IAuthenticationService>()
                .IsAuthenticatedAsync().GetAwaiter().GetResult();
            if (!isAuthenticated)
            {
                var returnUrl = context.HttpContext.Request.GetEncodedUrl();
                context.Result = new RedirectResult(
                    $"{context.HttpContext.RequestServices.GetInstance<ISettingsHelper>().GetLoginPageUrl()}?ReturnUrl={returnUrl}"
                );
            }
            return;
        }
        catch (Exception ex)
        {
            LogManager.GetLogger(GetType()).Error($"{ex.Message}, {ex.StackTrace}");
            throw;
        }
    }
}
