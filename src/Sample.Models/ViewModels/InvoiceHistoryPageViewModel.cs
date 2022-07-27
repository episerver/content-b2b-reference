namespace Sample.Models.ViewModels;

public class InvoiceHistoryPageViewModel : ContentViewModel<InvoiceHistoryPage>
{
    public InvoiceHistoryPageViewModel()
    {

    }

    public InvoiceHistoryPageViewModel(InvoiceHistoryPage currentPage) : base(currentPage)
    {
    }

    public InvoiceHistoryViewModel InvoiceHistoryViewModel { get; set; }
    public string ErrorMessage { get; set; }
    public string InvoiceDetailsPageLink { get; set; }
}