namespace Sample.Models.ViewModels;

public class OrderConfirmationPageViewModel : ContentViewModel<OrderConfirmationPage>
{
    public OrderConfirmationPageViewModel()
    {

    }

    public OrderConfirmationPageViewModel(OrderConfirmationPage currentPage) : base(currentPage)
    {
    }

    public string ErrorMessage { get; set; }
    public Cart Cart { get; set; }
    public PromotionCollectionModel Promotions { get; set; }
}