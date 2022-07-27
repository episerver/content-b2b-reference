namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Saved Order Details Page",
    GUID = "49e0a0fc-2c75-46d7-b73b-99f0dd7ac3dc",
    Description = "Saved Order Details Page",
    GroupName = Global.GroupNames.CommercePages
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class SavedOrderDetailsPage : BasePage
{
    [CultureSpecific]
    [Display(
        Name = "Saved Order Details Heading",
        GroupName = Global.GroupNames.Labels,
        Order = 1
    )]
    public virtual string SavedOrderDetailsHeading { get; set; }

    [CultureSpecific]
    [Display(Name = "Date Heading", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string DateHeading { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Billing Information Heading",
        GroupName = Global.GroupNames.Labels,
        Order = 3
    )]
    public virtual string BillingInformationHeading { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Shipping Information Heading",
        GroupName = Global.GroupNames.Labels,
        Order = 4
    )]
    public virtual string ShippingInformationHeading { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Return to Saved Orders Text",
        GroupName = Global.GroupNames.Labels,
        Order = 5
    )]
    public virtual string ReturntoSavedOrdersText { get; set; }

    [Display(
        Name = "Return to Saved Orders Link",
        GroupName = SystemTabNames.Content,
        Order = 6
    )]
    public virtual Url ReturntoSavedOrdersLink { get; set; }

    [CultureSpecific]
    [Display(Name = "Print Text", GroupName = Global.GroupNames.Labels, Order = 7)]
    public virtual string PrintText { get; set; }

    [CultureSpecific]
    [Display(Name = "Delete Saved Order Text", GroupName = Global.GroupNames.Labels, Order = 8)]
    public virtual string DeleteSavedOrderText { get; set; }

    [CultureSpecific]
    [Display(Name = "Place Saved Order Text", GroupName = Global.GroupNames.Labels, Order = 9)]
    public virtual string PlaceSavedOrderText { get; set; }

    [CultureSpecific]
    [Display(Name = "Add All to List Text", GroupName = Global.GroupNames.Labels, Order = 10)]
    public virtual string AddAlltoListText { get; set; }

    [Display(Name = "Cart Page Link", GroupName = SystemTabNames.Content, Order = 11)]
    public virtual Url CartPageLink { get; set; }

    [CultureSpecific]
    [Display(Name = "Sub Total Text", GroupName = Global.GroupNames.Labels, Order = 12)]
    public virtual string SubTotalText { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Product", GroupName = Global.GroupNames.Labels, Order = 13)]
    public virtual string HeaderProduct { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Price ", GroupName = Global.GroupNames.Labels, Order = 14)]
    public virtual string HeaderPrice { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Qty", GroupName = Global.GroupNames.Labels, Order = 15)]
    public virtual string HeaderQty { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Sub Total", GroupName = Global.GroupNames.Labels, Order = 16)]
    public virtual string HeaderSubTotal { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        SavedOrderDetailsHeading = "Saved Order Details";
        DateHeading = "Date";
        BillingInformationHeading = "Billing Information";
        ShippingInformationHeading = "Shipping Information";
        ReturntoSavedOrdersText = "Return to Saved Orders";
        PrintText = "Print";
        DeleteSavedOrderText = "Delete Saved Order";
        PlaceSavedOrderText = "Place Saved Order";
        AddAlltoListText = "Add All to List";
        SubTotalText = "Sub Total";
        HeaderProduct = "Product";
        HeaderPrice = "Price";
        HeaderQty = "Qty Ordered";
        HeaderSubTotal = "Sub Total";
    }
}
