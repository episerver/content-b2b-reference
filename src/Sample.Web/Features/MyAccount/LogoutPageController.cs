using Sample.Services.Session;

namespace Sample.Web.Features.MyAccount;

[LoginRequired]
public class LogoutPageController : PageControllerBase<LogoutPage>
{
    private readonly ISessionService _sessionService;
    private readonly IAuthenticationService _authenticationService;

    public LogoutPageController(ISessionService sessionService,
        IAuthenticationService authenticationService)
    {
        _sessionService = sessionService;
        _authenticationService = authenticationService;
    }

    public async Task<IActionResult> Index(LogoutPage currentPage)
    {
        //TODO: Add error handling
        if (await _authenticationService.IsAuthenticatedAsync())
        {
            await _authenticationService.SignOutAsync();
        }
        try
        {
            await ClearSession();
        }
        catch (Exception)
        {
            
        }
        
        return Redirect("/");
    }

    [HttpPost]
    public virtual async Task<JsonResult> Logout(LogoutPage currentPage)
    {
        try
        {
            if (await _authenticationService.IsAuthenticatedAsync())
            {
                await _authenticationService.SignOutAsync();
            }
            return Json(new { Success = "True" });
        }
        catch (Exception ex)
        {
            return Json(new { Success = "False", responseText = ex.Message });
        }
    }

    private async Task ClearSession()
    {
        await _sessionService.Delete();
    }
}
