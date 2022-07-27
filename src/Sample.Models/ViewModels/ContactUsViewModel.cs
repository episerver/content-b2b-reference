namespace Sample.Models.ViewModels;

public class ContactUsViewModel : ContentViewModel<ContactUsPage>
{
    public ContactUsViewModel()
    {

    }

    public ContactUsViewModel(ContactUsPage currentPage) : base(currentPage)
    {
    }

    public string ErrorMessage { get; set; }
}