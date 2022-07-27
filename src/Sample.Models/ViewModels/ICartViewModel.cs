using CommerceApiSDK.Models.Results;

namespace Sample.Models.ViewModels;

public interface ICartViewModel<out T> : IContentViewModel<T> where T : IContent
{
    GetWarehouseCollectionResult Warehouses { get; set; }
    Cart Cart { get; set; }
    PromotionCollectionModel Promotions { get; set; }
    string CurrentFulfillmentMethod { get; set; }
    string CurrentPickUpWarehouseId { get; set; }
    string SubtotalLabel { get; set; }
    string ShippingHandlingLabel { get; set; }
    string TaxLabel { get; set; }
    string TotalLabel { get; set; }
    string PromotionLabel { get; set; }

}
