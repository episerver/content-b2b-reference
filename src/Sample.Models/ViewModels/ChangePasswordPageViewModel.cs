namespace Sample.Models.ViewModels;

public class ChangePasswordPageViewModel : ContentViewModel<ChangePasswordPage>
{
    public ChangePasswordPageViewModel()
    {

    }

    public ChangePasswordPageViewModel(ChangePasswordPage currentPage) : base(currentPage)
    {
    }

    public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
    public IEnumerable<string> ErrorMessage { get; set; }
}