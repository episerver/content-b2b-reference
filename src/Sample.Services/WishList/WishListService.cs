using CommerceApiSDK.Models.Enums;

namespace Sample.Services.WishList;

public class WishListService : BaseService, IWishListService
{
    private readonly CommerceApiSDK.Services.Interfaces.IWishListService _wishListClient;

    public WishListService(CommerceApiSDK.Services.Interfaces.IWishListService wishListClient)
    {
        _wishListClient = wishListClient;
    }

    public async Task<WishListCollectionModel> GetWishListsCollection(
        int pageNumber,
        int pageSize,
        WishListSortOrder sortOrder,
        string searchText
    )
    {
        return await _wishListClient.GetWishLists(
            new WishListsQueryParameters
            {
                Page = pageNumber,
                PageSize = pageSize,
                Sort = sortOrder.ToString(),
                Query = searchText
            }
        );
    }

    public virtual async Task<WishListCollectionModel> GetWishLists(
        int pageNumber,
        int pageSize,
        WishListSortOrder sortOrder,
        string searchText
    )
    {
        return await _wishListClient.GetWishLists(
                new WishListsQueryParameters
                {
                    Page = pageNumber,
                    PageSize = pageSize,
                    Sort = sortOrder.ToString(),
                    Query = searchText
                }
            );
    }

    public virtual async Task<CommerceApiSDK.Models.WishList> GetWishList(Guid wishListId)
    {
        return await _wishListClient.GetWishList(wishListId, new WishListQueryParameters());
    }

    public virtual async Task<bool> RemoveWishListLine(Guid wishListId, Guid wishListLineId)
    {
        return await _wishListClient.DeleteWishListLine(wishListId, wishListLineId);
    }

    public virtual async Task<bool> RemoveWishList(Guid wishListId)
    {
        return await _wishListClient.DeleteWishList(wishListId);
    }

    public virtual async Task<WishListLine> AddItemExistWishList(
        string wishListId,
        string productId,
        string qty,
        string unitOfMeasure,
        Properties wishlistLineProperties
    )
    {
        var model = new AddCartLine()
        {
            ProductId = new Guid(productId),
            QtyOrdered = int.Parse(qty),
            UnitOfMeasure = unitOfMeasure,
            Properties = wishlistLineProperties,
            Uri = ""
        };
        return await _wishListClient.AddProductToWishList(Guid.Parse(wishListId), model);
    }

    public virtual async Task<CommerceApiSDK.Models.WishList> CreateNewWishList(
        string listName,
        string description
    )
    {
        return await _wishListClient.CreateWishList(
                new CreateWishListQueryParameters
                {
                    WishListObj = new CommerceApiSDK.Models.WishList
                    {
                        Name = listName,
                        Description = description
                    }
                }
            );
    }

    public virtual async Task<bool> AddAllToWishList(string wishListId, List<WishListLine> wishListLines)
    {
        var model = new WishListAddToCartCollection
        {
            WishListLines = wishListLines
            .Select(
                w =>
                    new AddCartLine
                    {
                        ProductId = w.ProductId,
                        QtyOrdered = w.QtyOrdered,
                        UnitOfMeasure = w.UnitOfMeasure
                    }
            )
            .ToList()
        };

        return await _wishListClient.AddWishListLinesToWishList(Guid.Parse(wishListId), model);
    }
}
