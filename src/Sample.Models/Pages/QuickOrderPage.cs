namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Quick Order Page",
    GUID = "ADCEE67C-83B9-49EA-8DC4-CF06CA1C2378",
    Description = "Quick Order Page",
    GroupName = Global.GroupNames.CommercePages
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class QuickOrderPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "Introduction Text", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string IntroductionText { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Quick Order Search Box Placeholder Text",
        GroupName = Global.GroupNames.Labels,
        Order = 3
    )]
    public virtual string SearchPlaceholderText { get; set; }

    [Display(
        Name = "Auto Complete Search Minimum Character",
        GroupName = SystemTabNames.Content,
        Order = 4
    )]
    [Range(1, 10)]
    public virtual int AutoCompleteSearchMinChar { get; set; }

    [Display(
        Name = "Auto Complete Search Api Call interval",
        GroupName = SystemTabNames.Content,
        Order = 5
    )]
    [Range(200, 300)]
    public virtual int AutoCompleteSearchApideferRequestBy { get; set; }

    [CultureSpecific]
    [Display(Name = "Quantity Label", GroupName = Global.GroupNames.Labels, Order = 6)]
    public virtual string QuantityLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Form Action Text", GroupName = Global.GroupNames.Labels, Order = 7)]
    public virtual string FormActionText { get; set; }

    [CultureSpecific]
    [Display(Name = "Empty List Text", GroupName = Global.GroupNames.Labels, Order = 8)]
    public virtual string EmptyListText { get; set; }

    [CultureSpecific]
    [Display(Name = "Add Button Label", GroupName = Global.GroupNames.Labels, Order = 9)]
    public virtual string AddButtonLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Upload Order Label", GroupName = Global.GroupNames.Labels, Order = 10)]
    public virtual string UploadOrderLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Quick Order Pop Up CartConfirmation Title",
        GroupName = Global.GroupNames.Labels,
        Order = 11
    )]
    public virtual string QuickOrderCartPopUpConfirmationTitle { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Quick Order Pop Up CartConfirmation Message",
        GroupName = Global.GroupNames.Labels,
        Order = 12
    )]
    public virtual string QuickOrderPopUpConfirmationMessage { get; set; }

    [Display(Name = "Cart Page Redirect URL", Order = 13, GroupName = SystemTabNames.Content)]
    public virtual Url CartPageRedirectURL { get; set; }

    [Display(Name = "Quick Order Upload URL", Order = 14, GroupName = SystemTabNames.Content)]
    public virtual Url QuickOrderUploadUrl { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Quick Order Success Message",
        Order = 15,
        GroupName = Global.GroupNames.Labels
    )]
    public virtual string QuickOrderSuccessMessage { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Add To All Cart & Check Out Button Text",
        Order = 16,
        GroupName = Global.GroupNames.Labels
    )]
    public virtual string AddToAllCartButtonText { get; set; }

    [CultureSpecific]
    [Display(Name = "Quick Order Description", Order = 17, GroupName = Global.GroupNames.Labels)]
    public virtual string QuickOrderDescription { get; set; }

    [CultureSpecific]
    [Display(Name = "Quick Order Availability", Order = 18, GroupName = Global.GroupNames.Labels)]
    public virtual string QuickOrderAvailability { get; set; }

    [CultureSpecific]
    [Display(Name = "Quick Order Price", Order = 19, GroupName = Global.GroupNames.Labels)]
    public virtual string QuickOrderPrice { get; set; }

    [CultureSpecific]
    [Display(Name = "Quick Order U/M", Order = 20, GroupName = Global.GroupNames.Labels)]
    public virtual string QuickOrderUM { get; set; }

    [CultureSpecific]
    [Display(Name = "Quick Order Qty", Order = 21, GroupName = Global.GroupNames.Labels)]
    public virtual string QuickOrderQty { get; set; }

    [CultureSpecific]
    [Display(Name = "Quick Order Total", Order = 22, GroupName = Global.GroupNames.Labels)]
    public virtual string QuickOrderTotal { get; set; }

    [CultureSpecific]
    [Display(Name = "Quick Order Compare", Order = 23, GroupName = Global.GroupNames.Labels)]
    public virtual string QuickOrderCompare { get; set; }

    [CultureSpecific]
    [Display(Name = "Quick Order Available", Order = 24, GroupName = Global.GroupNames.Labels)]
    public virtual string QuickOrderAvailable { get; set; }

    [CultureSpecific]
    [Display(Name = "Variant Popup Heading", Order = 25, GroupName = Global.GroupNames.Labels)]
    public virtual string VariantPopupHeading { get; set; }

    [CultureSpecific]
    [Display(Name = "Size", Order = 26, GroupName = Global.GroupNames.Labels)]
    public virtual string Size { get; set; }

    [CultureSpecific]
    [Display(Name = "Color", Order = 27, GroupName = Global.GroupNames.Labels)]
    public virtual string Color { get; set; }

    [CultureSpecific]
    [Display(Name = "Search Text", Order = 28, GroupName = Global.GroupNames.Labels)]
    public virtual string SearchLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Add to Quick Order Form Button Text",
        Order = 28,
        GroupName = Global.GroupNames.Labels
    )]
    public virtual string AddtoQuickOrderFormButtonText { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "Quick Order";
        IntroductionText =
            "To add an item to your quick order form, search by keyword or item # then click on the item.";
        SearchPlaceholderText = "Enter product name or item #";
        AutoCompleteSearchMinChar = 2;
        AutoCompleteSearchApideferRequestBy = 200;
        QuantityLabel = "QTY";
        FormActionText = "Add all to cart";
        EmptyListText = "Empty List";
        AddButtonLabel = "Add";
        UploadOrderLabel = "Upload Order";
        QuickOrderCartPopUpConfirmationTitle = "Add to Cart";
        QuickOrderPopUpConfirmationMessage = "Added to cart";
        QuickOrderSuccessMessage = "Item successfully added to order";
        AddToAllCartButtonText = "Add To All Cart & Checkout";
        QuickOrderDescription = "Description";
        QuickOrderAvailability = "Availability";
        QuickOrderPrice = "Price";
        QuickOrderUM = "U/M";
        QuickOrderQty = "Qty";
        QuickOrderTotal = "Total:";
        QuickOrderCompare = "Compare";
        QuickOrderAvailable = "Available";
        Size = "Size";
        Color = "Color";
        VariantPopupHeading = "Select options before adding to order:";
        AddtoQuickOrderFormButtonText = "Add to Quick Order Form";
        SearchLabel = "Search";
    }
}
