using Promotion = CommerceApiSDK.Models.Promotion;

namespace Sample.Services.Cart;

public interface ICartService
{
    Task<CommerceApiSDK.Models.Cart> GetCart();
    Task<CommerceApiSDK.Models.Cart> GetCartWithOptions(IEnumerable<string> expands);
    Task<CartLine> CartLines(
        string productId,
        string qtyOrdered,
        string unitOfMeasure,
        Dictionary<string, string> properties
    );
    Task<bool> RemoveCartLine(string cartLineId);
    Task<bool> EmptyCart();
    Task<CommerceApiSDK.Models.Cart> GetCartSummary();
    Task<CartLine> UpdateCartLine(
        string cartLineId,
        string productId,
        string erpNumber,
        string qtyOrdered,
        string unitOfMeasure,
        string itemNote,
        Dictionary<string, string> properties
    );
    Task<List<CartLine>> AddAllToCart(List<AddCartLine> itemsList);
    Task<CommerceApiSDK.Models.Cart> SubmitCart(CommerceApiSDK.Models.Cart originalCart);
    Task<Promotion> ValidatePromo(string promocode);
    Task<PromotionCollectionModel> GetPromotion();
    Task<decimal?> GetDiscountAmount();
    Task<CommerceApiSDK.Models.Cart> GetCartWithShippingDetails();
    Task<CommerceApiSDK.Models.Cart> SaveCart(CommerceApiSDK.Models.Cart currentCart);
    Task<CommerceApiSDK.Models.Cart> GetCartwithCostcodes();
    Task<CartCollectionModel> GetCartSavedOrders(CartsQueryParameters savedOrderCart);
    Task<CommerceApiSDK.Models.Cart> GetCartByIdWithChildren(string cartId, List<string> expand);
    Task<CommerceApiSDK.Models.Cart> GetCartWithChildren(IEnumerable<string> expand);
    Task<bool> DeleteSavedOrder(string cartId);
    Task<PromotionCollectionModel> GetCartPromotion(string cartId);
}
