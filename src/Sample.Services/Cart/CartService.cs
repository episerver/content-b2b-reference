using CartLine = CommerceApiSDK.Models.CartLine;
using Promotion = CommerceApiSDK.Models.Promotion;

namespace Sample.Services.Cart;

public class CartService : BaseService, ICartService
{
    private readonly CommerceApiSDK.Services.Interfaces.ICartService _cartClient;

    public CartService(CommerceApiSDK.Services.Interfaces.ICartService cartClient)
    {
        _cartClient = cartClient;
    }

    public async Task<CommerceApiSDK.Models.Cart> GetCart()
    {
        return await _cartClient.GetCurrentCart(
            new CartQueryParameters { Expand = new List<string> { "cartlines" } }
        );
    }

    public async Task<CommerceApiSDK.Models.Cart> GetCartWithOptions(IEnumerable<string> expands)
    {
        return await _cartClient.GetCurrentCart(
            new CartQueryParameters() { Expand = expands.ToList() }
        );
    }

    public async Task<CartLine> CartLines(
        string productId,
        string qtyOrdered,
        string unitOfMeasure,
        Dictionary<string, Guid> properties
    )
    {
        var line = new AddCartLine()
        {
            ProductId = Guid.Parse(productId),
            QtyOrdered = decimal.Parse(qtyOrdered),
            UnitOfMeasure = unitOfMeasure,
            SectionOptions = properties.ToList().Select(x => new SectionOptionDto
            {
                OptionName = x.Key,
                SectionOptionId = x.Value
            }).ToList()
        };
        return await _cartClient.AddCartLine(line);
    }

    public async Task<bool> RemoveCartLine(string cartLineId)
    {
        if (!string.IsNullOrEmpty(cartLineId))
        {
            var line = new CartLine() { Id = Guid.Parse(cartLineId) };
            return await _cartClient.DeleteCartLine(line);
        }
        else
        {
            return await _cartClient.ClearCart();
        }
    }

    public async Task<bool> EmptyCart()
    {
        return await _cartClient.ClearCart();
    }

    public async Task<CommerceApiSDK.Models.Cart> GetCartSummary()
    {
        return await _cartClient.GetCurrentCart(new CartQueryParameters());
    }

    public async Task<CommerceApiSDK.Models.Cart> GetCartWithShippingDetails()
    {
        return await _cartClient.GetCurrentCart(
            new CartQueryParameters
            {
                Expand = new List<string> { "shipping", "carriers" }
            }
        );
    }

    public async Task<CommerceApiSDK.Models.Cart> SaveCart(CommerceApiSDK.Models.Cart currentCart)
    {
        return await _cartClient.UpdateCart(currentCart);
    }

    public async Task<CommerceApiSDK.Models.Cart> GetCartwithCostcodes()
    {
        return await _cartClient.GetCurrentCart(
            new CartQueryParameters
            {
                Expand = new List<string> { "cartlines", "costcodes" }
            }
        );
    }

    public async Task<CartLine> UpdateCartLine(
        string cartLineId,
        string productId,
        string erpNumber,
        string qty,
        string unitOfMeasure,
        string itemNote,
        Dictionary<string, string> properties
    )
    {
        var line = new CartLine()
        {
            Id = Guid.Parse(cartLineId),
            ProductId = Guid.Parse(productId),
            ErpNumber = erpNumber,
            QtyOrdered = decimal.Parse(qty),
            UnitOfMeasure = unitOfMeasure,
            Notes = itemNote,
            SectionOptions = new List<SectionOptionDto>()
        };
        return await _cartClient.UpdateCartLine(line);
    }

    public async Task<List<CartLine>> AddAllToCart(List<AddCartLine> itemsList)
    {
        return await _cartClient.AddCartLineCollection(itemsList);
    }

    public async Task<CommerceApiSDK.Models.Cart> SubmitCart(CommerceApiSDK.Models.Cart cart)
    {
        return await _cartClient.UpdateCart(cart);
    }

    public async Task<Promotion> ValidatePromo(string promocode)
    {
        var promotion = new AddPromotion() { PromotionCode = promocode };
        return await _cartClient.ApplyPromotion(promotion);
    }

    public async Task<PromotionCollectionModel> GetPromotion()
    {
        return await _cartClient.GetCurrentCartPromotions();
    }

    public virtual async Task<decimal?> GetDiscountAmount()
    {
        decimal discountAmount = 0;
        var promoApplied = await GetPromotion();
        if (promoApplied != null && promoApplied.Promotions.Count > 0)
        {
            foreach (var promo in promoApplied.Promotions)
            {
                discountAmount += promo.Amount;
            }
        }

        return discountAmount;
    }

    public async Task<CartCollectionModel> GetCartSavedOrders(
        CartsQueryParameters savedOrderCart
    )
    {
        return await _cartClient.GetCarts(savedOrderCart);
    }

    public virtual async Task<CommerceApiSDK.Models.Cart> GetCartByIdWithChildren(string cartId, List<string> expand)
    {
        return await _cartClient.GetCart(Guid.Parse(cartId), new CartQueryParameters() { Expand = expand });
    }

    public virtual async Task<bool> DeleteSavedOrder(string cartId)
    {
        return await _cartClient.DeleteCart(Guid.Parse(cartId));
    }

    public virtual async Task<CommerceApiSDK.Models.Cart> GetCartWithChildren(IEnumerable<string> expand)
    {
        return await _cartClient.GetCurrentCart(new CartQueryParameters { Expand = expand.ToList() });
    }

    public async Task<PromotionCollectionModel> GetCartPromotion(string cartId)
    {
        return await _cartClient.GetCartPromotions(Guid.Parse(cartId));
    }
}
