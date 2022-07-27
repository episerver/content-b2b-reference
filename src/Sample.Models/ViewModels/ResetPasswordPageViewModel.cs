namespace Sample.Models.ViewModels;

public class ResetPasswordPageViewModel : ContentViewModel<ResetPasswordPage>
{
    public ResetPasswordPageViewModel()
    {

    }

    public ResetPasswordPageViewModel(ResetPasswordPage currentPage) : base(currentPage)
    {
    }

    public ResetPasswordModel ResetPasswordModel { get; set; }
    public IEnumerable<string> ErrorMessage { get; set; }
    public string SuccessMessage { get; set; }
}