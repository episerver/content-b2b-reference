using CommerceApiSDK.Models.Results;

namespace Sample.Models.ViewModels;

public class OrderHistoryViewModel
{
    public string ClearButtonLink { get; set; }
    public string SearchButtonLink { get; set; }
    public GetShipTosResult ShipToCollection { get; set; }
    public GetOrderCollectionResult OrderCollection { get; set; }
    public PaginationExtendedModel Pagination { get; set; }
    public List<OrderStatusMapping> OrderStatus { get; set; }
}