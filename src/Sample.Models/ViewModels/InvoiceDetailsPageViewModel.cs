namespace Sample.Models.ViewModels;

public class InvoiceDetailsPageViewModel : ContentViewModel<InvoiceDetailsPage>
{
    public InvoiceDetailsPageViewModel()
    {

    }

    public InvoiceDetailsPageViewModel(InvoiceDetailsPage currentPage) : base(currentPage)
    {
    }

    public InvoiceDetailsViewModel InvoiceDetailsViewModel { get; set; }
    public string ErrorMessage { get; set; }
    public bool IsValid { get; set; }
    public Invoice Invoice { get; set; }
    public string ReturnPageLink { get; set; }
}