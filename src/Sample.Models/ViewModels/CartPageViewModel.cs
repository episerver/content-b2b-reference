using CommerceApiSDK.Models.Results;

namespace Sample.Models.ViewModels;

public class CartPageViewModel : ContentViewModel<CartPage>, ICartViewModel
{
    public CartPageViewModel() : this(null)
    {

    }

    public CartPageViewModel(CartPage currentPage) : base(currentPage)
    {
    }

    public string ErrorMessage { get; set; }
    public GetWarehouseCollectionResult Warehouses { get; set; }
    public PromotionCollectionModel Promotions { get; set; }
    public string CurrentFulfillmentMethod { get; set; }
    public string CurrentPickUpWarehouseId { get; set; }
    public Cart Cart { get; set; }
    public string SubtotalLabel { get; set; }
    public string ShippingHandlingLabel { get; set; }
    public string TaxLabel { get; set; }
    public string TotalLabel { get; set; }
    public string PromotionLabel { get; set; }
}

public class CartDetails
{
    public string cartLineId { get; set; }
    public string productId { get; set; }
    public string erpNumber { get; set; }
    public string qty { get; set; }
    public string unitOfMeasure { get; set; }
    public string itemNote { get; set; }
    public string savedOrderDetailsPageLink { get; set; }
    public string cartPageLink { get; set; }
}