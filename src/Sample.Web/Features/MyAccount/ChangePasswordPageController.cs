using EPiServer.Logging;

namespace Sample.Web.Features.MyAccount;

[LoginRequired]
public class ChangePasswordPageController : PageControllerBase<ChangePasswordPage>
{
    public const string ErrorKey = "CreateError";
    private readonly IAccountService _accountService;
    private readonly LocalizationService _localizationService;

    public ChangePasswordPageController(
        IAccountService accountService,
        LocalizationService localizationService
    )
    {
        _accountService = accountService;
        _localizationService = localizationService;
    }

    public async Task<IActionResult> Index(ChangePasswordPage currentPage)
    {
        var model = new ChangePasswordPageViewModel(currentPage)
        {
            ChangePasswordViewModel = new ChangePasswordViewModel(),
            ErrorMessage = new List<string>()
        };
        return await Task.FromResult(View(model));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public virtual async Task<ActionResult> Index(
        ChangePasswordPageViewModel changePasswordPageViewModel
    )
    {
        changePasswordPageViewModel.ErrorMessage = new List<string>();
        var changePasswordRedirectUrl = Url.ContentUrl(
            changePasswordPageViewModel.CurrentContent.ChangePasswordRedirectUrl
        );
        if (string.IsNullOrWhiteSpace(changePasswordRedirectUrl))
        {
            LogManager.GetLogger(GetType()).Error("Change Password Redirect Url is empty.");
            changePasswordPageViewModel.ErrorMessage = new List<string>()
            {
                _localizationService.GetString(
                    "/ChangePassword/Form/Error/ChangePasswordFailure"
                )
            };
            return View(changePasswordPageViewModel);
        }
        if (!ModelState.IsValid)
        {
            return View(changePasswordPageViewModel);
        }

        try
        {
            var apiResult = await _accountService.ChangePassword(
                changePasswordPageViewModel.ChangePasswordViewModel.Password,
                changePasswordPageViewModel.ChangePasswordViewModel.CurrentPassword
            );
            if (apiResult == null)
            {
                return Redirect(changePasswordRedirectUrl);
            }
            else
            {
                LogManager.GetLogger(GetType()).Error($"{apiResult}");
                changePasswordPageViewModel.ErrorMessage = new List<string>()
                {
                    _localizationService.GetString(
                        "/ChangePassword/Form/Error/ChangePasswordFailure"
                    )
                };
            }
        }
        catch (Exception ex)
        {
            LogManager.GetLogger(GetType()).Error($"{ex.Message}");
            changePasswordPageViewModel.ErrorMessage = new List<string>() { ex.Message };
        }
        return View(changePasswordPageViewModel);
    }
}
