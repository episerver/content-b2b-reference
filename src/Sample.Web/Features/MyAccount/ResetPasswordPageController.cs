using EPiServer.Logging;

namespace Sample.Web.Features.MyAccount;

public class ResetPasswordPageController : PageControllerBase<ResetPasswordPage>
{
    private readonly IAccountService _accountService;
    private readonly LocalizationService _localizationService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ResetPasswordPageController(
        IAccountService accountService,
        LocalizationService localizationService,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _accountService = accountService;
        _localizationService = localizationService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IActionResult> Index(ResetPasswordPage currentPage)
    {
        var model = new ResetPasswordPageViewModel(currentPage);
        var current = _httpContextAccessor.HttpContext;
        if (current != null)
        {
            var queryString = current.Request.Query;
            model.ResetPasswordModel = new ResetPasswordModel();
            if (queryString.TryGetValue("resetToken", out var token))
                model.ResetPasswordModel.Token = token;
            if (queryString.TryGetValue("userId", out var userId))
                model.ResetPasswordModel.UserId = userId;
            model.ErrorMessage = new List<string>();
        }
        return await Task.FromResult(View(model));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(
        ResetPasswordPageViewModel resetPasswordPageViewModel
    )
    {
        resetPasswordPageViewModel.ErrorMessage = new List<string>();
        var passwordResetToken = resetPasswordPageViewModel.ResetPasswordModel.Token;
        var userId = resetPasswordPageViewModel.ResetPasswordModel.UserId;
        if (!ModelState.IsValid)
        {
            return View(resetPasswordPageViewModel);
        }
        if (string.IsNullOrWhiteSpace(passwordResetToken) && string.IsNullOrEmpty(userId))
        {
            LogManager.GetLogger(GetType()).Error("Password reset token is empty.");
            resetPasswordPageViewModel.ErrorMessage = new List<string>()
            {
                _localizationService.GetString("/ResetPassword/Form/Error/ResetPasswordFailure")
            };
            return View(resetPasswordPageViewModel);
        }

        var apiResult = await _accountService.UpdatePassword(
            userId,
            resetPasswordPageViewModel.ResetPasswordModel.NewPassword,
            passwordResetToken
        );

        if (apiResult == null)
        {
            resetPasswordPageViewModel.SuccessMessage = _localizationService.GetString(
                "/ResetPassword/Form/Success/ResetPasswordSuccess"
            );
        }
        else
        {
            LogManager.GetLogger(GetType()).Error($"{apiResult}");
            resetPasswordPageViewModel.ErrorMessage = new List<string>()
            {
                _localizationService.GetString("/ResetPassword/Form/Error/ResetPasswordFailure")
            };
        }

        return View(resetPasswordPageViewModel);
    }
}
