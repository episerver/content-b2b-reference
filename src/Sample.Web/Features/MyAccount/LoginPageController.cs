using Microsoft.Extensions.Primitives;
using static System.String;
using Sample.Services.Session;
using CommerceApiSDK.Services;

namespace Sample.Web.Features.MyAccount;

public class LoginPageController : PageControllerBase<LoginPage>
{
    private readonly ISessionService _sessionService;
    private readonly IAccountService _accountService;
    private readonly ISettingsHelper _epicelerSettingHelper;
    private readonly Injected<LocalizationService> _localizationService;
    private readonly IAuthenticationService _authenticationService;

    public LoginPageController(
        ISessionService sessionService,
        ISettingsHelper epicelerSettingHelper,
        IAccountService accountService,
        IAuthenticationService authenticationService)
    {
        _sessionService = sessionService;
        _epicelerSettingHelper = epicelerSettingHelper;
        _accountService = accountService;
        _authenticationService = authenticationService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(LoginPage currentPage)
    {
        var virtualPath = "/";
        
        var queryString =Request.Query;
        if (queryString.TryGetValue("ReturnUrl", out var returnUrl))
        {
            virtualPath = StringValues.IsNullOrEmpty(returnUrl) ? virtualPath : returnUrl;
        }
        
        var model = new LoginPageViewModel(currentPage)
        {
            LoginViewModel = new LoginViewModel
            {
                ReturnUrl = virtualPath,
                ShouldShowGuestUserButton = virtualPath.Contains("checkout")
            },
            ErrorMessage = new List<string>()
        };

        var session = await _sessionService.GetCurrent();
        if (session != null)
        {
            if (session.BillTo != null)
            {
                if (model != null)
                    model.LoginViewModel.IsGuestUser = session.BillTo.IsGuest;
            }
            else
            {
                model.LoginViewModel.IsGuestUser = true;
            }
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> Index(LoginPage currentPage, LoginPageViewModel loginPageViewModel)
    {
        loginPageViewModel.CurrentContent = currentPage;
        if (!ModelState.IsValid)
        {
            return View(loginPageViewModel);
        }
        try
        {
            var returnUrl = GetReturnUrl();
            var response = await _authenticationService.SignInAsync(
                loginPageViewModel.LoginViewModel.Username,
                loginPageViewModel.LoginViewModel.Password
            );
            if (!response.Item1)
            {
                var localizedInvalidMessage = _localizationService.Service.GetString(
                    "/Login/Form/Error/InvalidCredentials"
                );
                loginPageViewModel.ErrorMessage = new List<string> { localizedInvalidMessage };
                loginPageViewModel.LoginViewModel.ReturnUrl = returnUrl;
                return View(loginPageViewModel);
            }
            var currentSession = await _sessionService.GetCurrent();
            //if (currentSession.DisplayChangeCustomerLink)
            //{
            //    var changeCustomerPageUrl =
            //        $"{_epicelerSettingHelper.GetChangeCustomerPageLink()}";
            //    return Redirect(
            //        changeCustomerPageUrl
            //            + (returnUrl != "/" ? "?ReturnUrl=" + returnUrl : returnUrl)
            //    );
            //}
            return Redirect(returnUrl);
        }
        catch (Exception ex)
        {
            loginPageViewModel.ErrorMessage = new List<string> { ex.Message };
        }
        return View(loginPageViewModel);
    }

    [HttpPost]
    public virtual async Task<IActionResult> Login([FromBody] UserLogin userLogin)
    {
        try
        {
            var returnUrl = GetLoginPopupReturnUrl();
            var localizedInvalidMessage = _localizationService.Service.GetString(
                "/Login/Form/Error/InvalidCredentials"
            );
            var returnValueSignIn = await _authenticationService.SignInAsync(
                userLogin.Username,
                userLogin.Password
            );
            var currentSession = await _sessionService.GetCurrent();
            var response = returnValueSignIn.Item1 == false ? "False" : "True";
            var responseText = returnValueSignIn.Item1 == false ? localizedInvalidMessage : Empty;
            return Json(new { Success = response, returnUrl, responseText });
        }
        catch (Exception ex)
        {
            return Json(new { Success = "False", responseText = ex.Message });
        }
    }

    [HttpPost]
    public virtual async Task<IActionResult> CreateGuestAccount()
    {
        var result = await _accountService.CreateGuestAccount();
        if (
            result != null && !IsNullOrEmpty(result.UserName) && !IsNullOrEmpty(result.Password)
        )
        {
            var loginResult = await UISignInManager.Service.SignInAsync(
                result.UserName,
                result.Password
            );
            if (loginResult)
            {
                var returnUrl = getUrl();
                var redirection = !IsNullOrEmpty(returnUrl) ? returnUrl : "/";
                return Json(new { IsSuccess = true, ErrorMessgae = Empty, url = redirection });
            }
        }
        return Json(new { IsSuccess = false, ErrorMessage = "Something went wrong." });
        ;
    }

    private string GetReturnUrl()
    {
        var virtualPath = "/";
        var queryString = Request.Query;
        if (queryString != null && queryString.TryGetValue("ReturnUrl", out var returnUrl))
        {
            virtualPath = StringValues.IsNullOrEmpty(returnUrl)
                ? virtualPath
                : returnUrl;
        }

        return virtualPath;
    }

    private string GetLoginPopupReturnUrl()
    {
        var virtualPath = "/";
        var queryString = Request.Query;
        if (queryString.TryGetValue("ReturnUrl", out var returnUrl))
        {
            virtualPath = StringValues.IsNullOrEmpty(returnUrl) ? virtualPath : returnUrl;
        }

        return virtualPath;
    }

    private string getUrl()
    {
        var virtualPath = "/";
        var queryString = Request.GetTypedHeaders().Referer.ToString();
        if (queryString != null)
        {
            virtualPath = queryString.Substring(queryString.LastIndexOf('=') + 1) ?? virtualPath;

            
        }
        return virtualPath;
    }

    private async Task<(bool, ErrorResponse)> SingIn(string username, string password)
    {
        return await _authenticationService.SignInAsync(username, password);
    }

    private async Task SignOutFromCommerce()
    {
        await _authenticationService.SignOutAsync();
    }

    public async Task<bool> IsAuthenticated()
    {
        return await _authenticationService.IsAuthenticatedAsync();
    }
}
