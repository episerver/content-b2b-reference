namespace Sample.Models.Pages;

[SiteContentType(
    DisplayName = "Wish List Page",
    GUID = "aa8053a3-5752-4487-8ee5-479a88d1b6fe",
    Description = "Wish List Page",
    GroupName = Global.GroupNames.CommercePages
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class WishListPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "Drop Down Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string DropdownLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Delete List Button Label", GroupName = Global.GroupNames.Labels, Order = 3)]
    public virtual string DeleteListButtonLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Add To Cart Button Text", GroupName = Global.GroupNames.Labels, Order = 5)]
    public virtual string AddToCartButtonText { get; set; }

    [CultureSpecific]
    [Display(Name = "ERP Label", GroupName = Global.GroupNames.Labels, Order = 6)]
    public virtual string ErpLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "UOM Label", GroupName = Global.GroupNames.Labels, Order = 7)]
    public virtual string UomLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Availability Label", Order = 8, GroupName = Global.GroupNames.Labels)]
    public virtual string AvailabilityLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Color Label", Order = 9, GroupName = Global.GroupNames.Labels)]
    public virtual string ColorLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Weight Label", Order = 10, GroupName = Global.GroupNames.Labels)]
    public virtual string WeightLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Price Label", Order = 11, GroupName = Global.GroupNames.Labels)]
    public virtual string PriceLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "QTY Label", Order = 12, GroupName = Global.GroupNames.Labels)]
    public virtual string QtyLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Add All To Cart Button Text",
        GroupName = Global.GroupNames.Labels,
        Order = 13
    )]
    public virtual string AddAllToCartButtonText { get; set; }

    [CultureSpecific]
    [Display(Name = "Manufacture Item", GroupName = Global.GroupNames.Labels, Order = 14)]
    public virtual string Mfg { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Wishlist No Product To Display Validation Error Message",
        GroupName = Global.GroupNames.Labels,
        Order = 15
    )]
    public virtual string WishlistNoProductValidationError { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Wishlist Empty Validation Error",
        GroupName = Global.GroupNames.Labels,
        Order = 16
    )]
    public virtual string WishlistEmptyValidationError { get; set; }

    [CultureSpecific]
    [Display(Name = "Part Number", GroupName = Global.GroupNames.Labels, Order = 17)]
    public virtual string PartNumber { get; set; }

    [Display(Name = "Wish List URL", GroupName = SystemTabNames.Content, Order = 18)]
    public virtual Url WishListUrl { get; set; }

    [Display(Name = "Cart Page Url", GroupName = SystemTabNames.Content, Order = 19)]
    public virtual Url CartPageUrl { get; set; }

    [CultureSpecific]
    [Display(Name = "Enable Popup", GroupName = SystemTabNames.Content, Order = 20)]
    public virtual bool EnablePopup { get; set; }

    [CultureSpecific]
    [Display(Name = "Checkout", GroupName = Global.GroupNames.Labels, Order = 21)]
    public virtual string Checkout { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Wish List Cart Pop Up Confirmation Title",
        GroupName = Global.GroupNames.Labels,
        Order = 22
    )]
    public virtual string WishListCartPopUpConfirmationTitle { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Wish List PopUp Confirmation Message",
        GroupName = Global.GroupNames.Labels,
        Order = 23
    )]
    public virtual string WishListPopUpConfirmationMessage { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Wish List Delete Pop Up Title",
        GroupName = Global.GroupNames.Labels,
        Order = 24
    )]
    public virtual string WishListDeletePopUpTitle { get; set; }

    [CultureSpecific]
    [Display(
        Name = "WishList Delete PopUp Confirmation Message",
        GroupName = Global.GroupNames.Labels,
        Order = 25
    )]
    public virtual string WishListDeletePopUpConfirmationMessage { get; set; }

    [Display(Name = "Rating Image", GroupName = SystemTabNames.Content, Order = 26)]
    [UIHint(UIHint.Image)]
    public virtual ContentReference RatingImage { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "Wish List";
        DropdownLabel = "Select List";
        DeleteListButtonLabel = "Delete List";
        AddToCartButtonText = "Add to Cart";
        ErpLabel = "Item #";
        QtyLabel = "QTY";
        AvailabilityLabel = "Available";
        ColorLabel = "Color";
        PriceLabel = "Price";
        WeightLabel = "Weight";
        AddAllToCartButtonText = "Add All to Cart";
        Mfg = "Model #";
        WishlistNoProductValidationError = "No Product to Display";
        WishlistEmptyValidationError = "Wishlist Empty";
        EnablePopup = true;
        Checkout = "Checkout";
        WishListCartPopUpConfirmationTitle = "Item added to cart";
        WishListPopUpConfirmationMessage = "Added to Cart";
        WishListDeletePopUpConfirmationMessage = "Wish list deleted.";
    }
}
