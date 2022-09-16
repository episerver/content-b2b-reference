using CommerceApiSDK.Models.Enums;
using Sample.Services.Catalog;
using Sample.Services.WishList;
using Sample.Services.Cart;

namespace Sample.Web.Features.Orders;

[LoginRequired]
public class WishListPageController : PageControllerBase<WishListPage>
{
    private readonly IWishListService _wishListService;
    private readonly ICartService _cartService;
    private readonly IProductService _productService;

    public WishListPageController(
        IWishListService wishListService,
        ICartService cartService,
        IProductService productService
    )
    {
        _wishListService = wishListService;
        _cartService = cartService;
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(WishListPage currentPage)
    {
        var pageNumber = 1;
        var pageSize = 16;
        var sortOrder = WishListSortOrder.ModifiedOnDescending;
        string searchText = null;
        var wishListViewModel = new WishListViewModel(currentPage)
        {
            WishListLines = new List<WishListLine>(),
            WishLists = new List<SelectListItem>(),
        };
        var result = await _wishListService.GetWishLists(pageNumber, pageSize, sortOrder, searchText);

        var wishList = new WishList();
        if (
            result != null
            && result.WishListCollection != null
            && result.WishListCollection.Count > 0
        )
        {
            wishListViewModel.IsValid = true;
            wishListViewModel.SelectedWishList = result.WishListCollection.FirstOrDefault().Id;
            wishListViewModel.WishLists = result.WishListCollection
                .Select(
                    w =>
                        new SelectListItem
                        {
                            Text = w.Name,
                            Value = w.Id.ToString(),
                            Selected = w.Id.Equals(wishListViewModel.SelectedWishList)
                        }
                )
                .ToList();
            wishList = await _wishListService.GetWishList(wishListViewModel.SelectedWishList);
            wishListViewModel.CanAddAllToCart = wishList.CanAddAllToCart;
            if (wishList != null && wishList.WishListLineCollection.Count > 0)
            {
                wishListViewModel.WishListLines = wishList.WishListLineCollection.ToList();
                var expands = new List<string>() { };
                foreach (var item in wishListViewModel.WishListLines)
                {
                    var apiResult =
                        await _productService.GetProduct(expands, item.ProductId.ToString());
                    item.Uri = apiResult.Product.ProductDetailUrl;
                }
            }
        }

        wishListViewModel.AvailableStatusCount = wishList.WishListLineCollection != null ? GetAvailableStatusInWishListLine(
            wishList.WishListLineCollection.ToList()
        ) : 0;
        wishListViewModel.OutOfStockStatusCount = wishList.WishListLineCollection != null ? GetOutOfStockStatusInWishListLine(
            wishList.WishListLineCollection.ToList()
        ) : 0;
        return View(wishListViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> GetWishListLines([FromBody] WishlistParam wishlistParam)
    {
        var IsSuccess = false;
        var errorMsg = string.Empty;
        var wishListLines = new List<WishListLine>();
        if (!string.IsNullOrEmpty(wishlistParam.WishListId.ToString()))
        {
            var result = await _wishListService.GetWishList(Guid.Parse(wishlistParam.WishListId));
            if (result != null && result.WishListLineCollection.Count > 0)
            {
                IsSuccess = true;
                wishListLines = result.WishListLineCollection.ToList();
                var expands = new List<string>() { };
                foreach (var item in wishListLines)
                {
                    var apiResult =
                        await _productService.GetProduct(expands, item.ProductId.ToString());
                    item.Uri = apiResult.Product.ProductDetailUrl;
                }
            }
        }
        if (wishListLines.Count == 0)
            errorMsg = "WishList has no items.";
        return Json(new { IsSuccess, wishListLines, errorMsg });
    }

    [HttpPost]
    public async Task<IActionResult> RemoveWishListLine([FromBody] WishlistParam wishlistParam)
    {
        var result = await _wishListService.RemoveWishListLine(
            Guid.Parse(wishlistParam.WishListId),
            Guid.Parse(wishlistParam.WishListLineId)
        );
        return Json(new { IsSuccess = result });
    }

    [HttpPost]
    public async Task<IActionResult> RemoveWishList([FromBody] WishlistParam wishlistParam)
    {
        var result = await _wishListService.RemoveWishList(Guid.Parse(wishlistParam.WishListId));
        return Json(new { IsSuccess = result });
    }

    [HttpGet]
    public async Task<IActionResult> GetWishList()
    {
        var pageNumber = 1;
        var pageSize = 16;
        var sortOrder = WishListSortOrder.ModifiedOnDescending;
        string searchText = null;
        var result = await _wishListService.GetWishLists(pageNumber, pageSize, sortOrder, searchText);
        return Json(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddToWishList([FromBody] WishlistParam wishlistParam)
    {
        var result = new WishListLine();
        if (wishlistParam.ListId != "0")
        {
            result = await _wishListService.AddItemExistWishList(
                wishlistParam.ListId,
                wishlistParam.ProductId,
                wishlistParam.Qty,
                wishlistParam.UnitOfMeasure,
                wishlistParam.wishlistLineProperties
            );
        }
        else
        {
            var properties = new Dictionary<string, string>();
            var wishlist = await _wishListService.CreateNewWishList(wishlistParam.NewList, null);
            if (wishlist != null)
            {
                result = await _wishListService.AddItemExistWishList(
                    wishlist.Id.ToString(),
                    wishlistParam.ProductId,
                    wishlistParam.Qty,
                    wishlistParam.UnitOfMeasure,
                    wishlistParam.wishlistLineProperties
                );
            }
        }
        return Json(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddToDefaultWishList([FromBody] WishlistParam wishlistParam)
    {
        WishList wishList;
        var lists = await _wishListService.GetWishLists(1, 25, WishListSortOrder.ModifiedOnDescending, "");
        
        if (lists == null || !lists.WishListCollection.Any())
        {
            wishList = await _wishListService.CreateNewWishList("Default", "Default wishlist for user");
        }
        else
        {
            wishList = lists.WishListCollection.First();
        }

        var result = await _wishListService.AddItemExistWishList(
            wishList.Id.ToString(),
            wishlistParam.ProductId,
            "1",
            wishlistParam.UnitOfMeasure,
            new Properties());
            
        return Json(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetCart()
    {
        var cart = await _cartService.GetCartSummary();
        return cart != null ? Json(new { cart }) : Json(new EmptyResult());
    }

    [HttpPost]
    public async Task<IActionResult> AddAllToWishList([FromBody] WishlistParam wishlistParam)
    {
        var wishListItems = new List<WishListLine>();
        if (wishlistParam.WishListLines != null && wishlistParam.WishListLines.Count > 0)
        {
            wishListItems = wishlistParam.WishListLines
                .Select(
                    w =>
                        new WishListLine
                        {
                            ProductId = w.ProductId,
                            QtyOrdered = w.QtyOrdered,
                            UnitOfMeasure = w.UnitOfMeasure
                        }
                )
                .ToList();
        }

        var result = false;
        if (wishlistParam.ListId.ToString() != "0")
        {
            result = await _wishListService.AddAllToWishList(wishlistParam.ListId, wishListItems);
        }
        else
        {
            var properties = new Dictionary<string, string>();
            var wishlist = await _wishListService.CreateNewWishList(wishlistParam.NewList, null);
            if (wishlist != null)
            {
                result = await _wishListService.AddAllToWishList(
                    wishlist.Id.ToString(),
                    wishListItems
                );
            }
        }

        return Json(result);
    }

    private int GetOutOfStockStatusInWishListLine(
        List<WishListLine> wishListLineCollection
    )
    {
        var outOfStockStatusCount = 0;
        foreach (var wishListLine in wishListLineCollection)
        {
            if (wishListLine.Availability.Message == "Out of Stock")
            {
                outOfStockStatusCount++;
            }
        }
        return outOfStockStatusCount;
    }

    private int GetAvailableStatusInWishListLine(
        List<WishListLine> wishListLineCollection
    )
    {
        var availableStatusCount = 0;
        foreach (var wishListLine in wishListLineCollection)
        {
            if (wishListLine.Availability.Message != "Out of Stock")
            {
                availableStatusCount++;
            }
        }
        return availableStatusCount;
    }
}
