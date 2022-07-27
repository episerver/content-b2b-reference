namespace Sample.Models.ViewModels;

public class OrderDetailsPageViewModel : ContentViewModel<OrderDetailsPage>
{
    public OrderDetailsPageViewModel()
    {

    }

    public OrderDetailsPageViewModel(OrderDetailsPage currentPage) : base(currentPage)
    {
    }

    public Order Order { get; set; }
    public string ErrorMessage { get; set; }
    public bool IsValid { get; set; }
    public string ReturnPageLink { get; set; }
}