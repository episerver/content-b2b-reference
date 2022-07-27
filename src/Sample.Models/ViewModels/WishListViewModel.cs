namespace Sample.Models.ViewModels;

public class WishListViewModel : ContentViewModel<WishListPage>
{
    public WishListViewModel()
    {

    }

    public WishListViewModel(WishListPage currentPage) : base(currentPage)
    {
    }

    public bool IsValid { get; set; }
    public List<SelectListItem> WishLists { get; set; }
    public Guid SelectedWishList { get; set; }
    public bool CanAddAllToCart { get; set; }
    public List<WishListLine> WishListLines { get; set; }
    public virtual int AvailableStatusCount { get; set; }
    public virtual int OutOfStockStatusCount { get; set; }
}

public class WishlistParam
{
    public string ListId { get; set; }
    public string NewList { get; set; }
    public string ProductId { get; set; }
    public string Qty { get; set; }
    public string UnitOfMeasure { get; set; }
    public string WishListId { get; set; }
    public string WishListLineId { get; set; }
    public List<WishListLine> WishListLines { get; set; }
    public Properties wishlistLineProperties { get; set; }
}