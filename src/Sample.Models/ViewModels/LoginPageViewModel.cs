namespace Sample.Models.ViewModels;

public class LoginPageViewModel : ContentViewModel<LoginPage>
{
    public LoginPageViewModel() : base()
    {

    }

    public LoginPageViewModel(LoginPage currentPage) : base(currentPage)
    {
    }

    public LoginViewModel LoginViewModel { get; set; }
    public IEnumerable<string> ErrorMessage { get; set; }
}