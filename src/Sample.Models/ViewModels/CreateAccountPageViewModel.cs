namespace Sample.Models.ViewModels;

public class CreateAccountPageViewModel : ContentViewModel<CreateAccountPage>
{
    public CreateAccountPageViewModel()
    {

    }

    public CreateAccountPageViewModel(CreateAccountPage currentPage) : base(currentPage)
    {
    }

    public CreateAccountViewModel CreateAccountViewModel { get; set; }
    public IEnumerable<string> ErrorMessage { get; set; }
}