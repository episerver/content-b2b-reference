using CommerceApiSDK.Models.Parameters;
using CommerceApiSDK.Models.Results;

namespace Sample.Models.ViewModels;

public class OrderHistoryPageViewModel : ContentViewModel<OrderHistoryPage>
{
    public OrderHistoryPageViewModel()
    {

    }

    public OrderHistoryPageViewModel(OrderHistoryPage currentPage) : base(currentPage)
    {
    }

    public string ErrorMessage { get; set; }
    public string OrderDetailsPageLink { get; set; }
    public GetShipTosResult ShipToCollection { get; set; }
    public GetOrderCollectionResult OrderCollection { get; set; }
    public PaginationExtendedModel Pagination { get; set; }
    public List<SelectListItem> OrderStatus { get; set; }
    public OrdersQueryParameters QueryParameters { get; set; }
}