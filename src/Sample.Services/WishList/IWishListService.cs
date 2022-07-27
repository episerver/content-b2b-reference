using CommerceApiSDK.Models.Enums;

namespace Sample.Services.WishList;

public interface IWishListService
{
    Task<WishListCollectionModel> GetWishListsCollection(
        int pageNumber,
        int pageSize,
        WishListSortOrder sortOrder,
        string searchText
    );
    Task<CommerceApiSDK.Models.WishList> GetWishList(Guid wishListId);
    Task<bool> RemoveWishListLine(Guid wishListId, Guid wishListLineId);
    Task<bool> RemoveWishList(Guid wishListId);
    Task<WishListLine> AddItemExistWishList(
        string wishListId,
        string productId,
        string qty,
        string unitOfMeasure,
        Properties wishlistLineProperties
    );
    Task<CommerceApiSDK.Models.WishList> CreateNewWishList(string listName, string description);
    Task<WishListCollectionModel> GetWishLists(
        int pageNumber,
        int pageSize,
        WishListSortOrder sortOrder,
        string searchText
    );
    Task<bool> AddAllToWishList(string wishListId, List<WishListLine> wishListLines);
}
