namespace Sample.Models.ViewModels;

public class ReturnRequestPageViewModel : ContentViewModel<ReturnRequestPage>
{
    public ReturnRequestPageViewModel()
    {

    }

    public ReturnRequestPageViewModel(ReturnRequestPage currentPage) : base(currentPage)
    {
    }

    public ReturnRequestViewModel ReturnRequestViewModel { get; set; }
    public string ErrorMessage { get; set; }
    public bool IsValid { get; set; }
    public string ReturnPageLink { get; set; }
}