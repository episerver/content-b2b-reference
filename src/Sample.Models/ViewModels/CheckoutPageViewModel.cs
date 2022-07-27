using CommerceApiSDK.Models.Results;

namespace Sample.Models.ViewModels;

public class CheckoutPageViewModel : ContentViewModel<CheckoutPage>, ICartViewModel<CheckoutPage>
{
    public CheckoutPageViewModel()
    {

    }

    public CheckoutPageViewModel(CheckoutPage currentPage) : base(currentPage)
    {
        
    }

    public string ErrorMessage { get; set; }
    public List<ShipToAddressCollection> CartShipToCollection { get; set; }
    public GetWarehouseCollectionResult Warehouses { get; set; }
    public Cart Cart { get; set; }
    public string CurrentFulfillmentMethod { get; set; }
    public string CurrentPickUpWarehouseId { get; set; }
    public PromotionCollectionModel Promotions { get; set; }
    public string SubtotalLabel { get; set; }
    public string ShippingHandlingLabel { get; set; }
    public string TaxLabel { get; set; }
    public string TotalLabel { get; set; }
    public string PromotionLabel { get; set; }
    public GetBillTosResult Addresses { get; set; }
    public string IframeAuthenticationToken { get; set; }
    public string PaymentToken { get; set; }
    public List<Country> Countries { get; set; }
    public TokenExDto TokenExDto { get; set; }
}

public class ShipToAddressCollection
{
    public ShipTo ShipTo { get; set; }
    public string ShipToAddress { get; set; }
    public string DropDownValue { get; set; }
    public string DropDownSelectedValue { get; set; }
}

public class UpdateCartCarrierService
{
    public string CarrierId { get; set; }
    public string ShipVia { get; set; }
}

public class UpdateNotes
{
    public string ItemNote { get; set; }
}