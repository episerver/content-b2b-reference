using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Shell.Security;

namespace Sample.Web.Features.MyAccount;

public class ForgotPasswordPageController : PageControllerBase<ForgotPasswordPage>
{
    public async Task<IActionResult> Index(ForgotPasswordPage currentPage)
    {
        var model = new ForgotPasswordPageViewModel(currentPage)
        {
            ForgotPasswordViewModel = new ForgotPasswordViewModel(),
            ReturnToSignInButtonLink = Url.ContentUrl(currentPage.ReturnToSignInButtonLink),
            CloseButtonLink = Url.ContentUrl(currentPage.CloseInButtonLink),
            ErrorMessage = new List<string>()
        };
        return await Task.FromResult(View(model));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> Index(
        ForgotPasswordPageViewModel forgotPasswordPageViewModel
    )
    {
        forgotPasswordPageViewModel.ErrorMessage = new List<string>();
        if (!ModelState.IsValid)
        {
            return View(forgotPasswordPageViewModel);
        }

        try
        {
            IUIUser uiUser = new ApplicationUser()
            {
                Username = forgotPasswordPageViewModel.ForgotPasswordViewModel.Username
            };
            var forgotPasswordMessage = await UIUserManager.Service.ResetPasswordAsync(uiUser);
            if (!string.IsNullOrWhiteSpace(forgotPasswordMessage))
            {
                forgotPasswordPageViewModel.IsPasswordReset = false;
                forgotPasswordPageViewModel.ReturnToSignInButtonLink = Url.ContentUrl(
                    forgotPasswordPageViewModel.CurrentContent.ReturnToSignInButtonLink
                );
                forgotPasswordPageViewModel.ErrorMessage = new List<string>()
                {
                    forgotPasswordMessage
                };
            }
            else
            {
                forgotPasswordPageViewModel.CloseButtonLink = Url.ContentUrl(
                    forgotPasswordPageViewModel.CurrentContent.CloseInButtonLink
                );
                forgotPasswordPageViewModel.IsPasswordReset = true;
            }
        }
        catch (Exception ex)
        {
            forgotPasswordPageViewModel.ErrorMessage = new List<string>() { ex.Message };
            forgotPasswordPageViewModel.IsPasswordReset = false;
        }
        return View(forgotPasswordPageViewModel);
    }
}
