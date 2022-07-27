namespace Sample.Models.ViewModels;

public class ForgotPasswordPageViewModel : ContentViewModel<ForgotPasswordPage>
{
    public ForgotPasswordPageViewModel()
    {

    }

    public ForgotPasswordPageViewModel(ForgotPasswordPage currentPage) : base(currentPage)
    {
    }

    public ForgotPasswordViewModel ForgotPasswordViewModel { get; set; }
    public IEnumerable<string> ErrorMessage { get; set; }
    public string ReturnToSignInButtonLink { get; set; }
    public string CloseButtonLink { get; set; }
    public bool IsPasswordReset { get; set; }
}