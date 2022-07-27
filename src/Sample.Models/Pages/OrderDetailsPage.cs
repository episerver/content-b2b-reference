namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Order Details Page",
    GUID = "028057eb-f5d7-4933-a831-8aaaf45a9fcc",
    GroupName = Global.GroupNames.CommercePages,
    Description = "To Create Order Details Page"
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.Specific, Include = new[] { typeof(ReturnRequestPage) })]
public class OrderDetailsPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "Web Order", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string WebOrderNumber { get; set; }

    [CultureSpecific]
    [Display(Name = "Order Date", GroupName = Global.GroupNames.Labels, Order = 3)]
    public virtual string OrderDate { get; set; }

    [CultureSpecific]
    [Display(Name = "Order Status", GroupName = Global.GroupNames.Labels, Order = 4)]
    public virtual string OrderStatus { get; set; }

    [CultureSpecific]
    [Display(Name = "Shipping Address", GroupName = Global.GroupNames.Labels, Order = 5)]
    public virtual string ShippingAddress { get; set; }

    [CultureSpecific]
    [Display(Name = "Billing Address", GroupName = Global.GroupNames.Labels, Order = 6)]
    public virtual string BillingAddress { get; set; }

    [CultureSpecific]
    [Display(Name = "Terms", GroupName = Global.GroupNames.Labels, Order = 7)]
    public virtual string Terms { get; set; }

    [CultureSpecific]
    [Display(Name = "Order Summary", GroupName = Global.GroupNames.Labels, Order = 8)]
    public virtual string OrderSummary { get; set; }

    [CultureSpecific]
    [Display(Name = "Print Button Text", GroupName = Global.GroupNames.Labels, Order = 9)]
    public virtual string PrintButton { get; set; }

    [CultureSpecific]
    [Display(Name = "Return Button Text", GroupName = Global.GroupNames.Labels, Order = 10)]
    public virtual string ReturnButton { get; set; }

    [Display(Name = "Return Page Link", GroupName = SystemTabNames.Content, Order = 11)]
    public virtual Url ReturnPageLink { get; set; }

    [CultureSpecific]
    [Display(Name = "Reorder Button Text", GroupName = Global.GroupNames.Labels, Order = 12)]
    public virtual string ReorderButton { get; set; }

    [CultureSpecific]
    [Display(Name = "ReorderAll Button Text", GroupName = Global.GroupNames.Labels, Order = 13)]
    public virtual string ReorderAllButton { get; set; }

    [CultureSpecific]
    [Display(
        Name = "ReorderAll PopUp Success Message Title ",
        GroupName = Global.GroupNames.Labels,
        Order = 22
    )]
    public virtual string ReorderAllPopUpSuccessMessageTitle { get; set; }

    [CultureSpecific]
    [Display(
        Name = "ReorderAll PopUp Success Message ",
        GroupName = Global.GroupNames.Labels,
        Order = 23
    )]
    public virtual string ReorderAllPopUpSuccessMessage { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Order Detail PopUp Confirmation Message",
        GroupName = Global.GroupNames.Labels,
        Order = 14
    )]
    public virtual string OrderDetailPopUpConfirmationMessage { get; set; }

    [Display(Name = "Cart Page Url", GroupName = SystemTabNames.Content, Order = 15)]
    public virtual Url CartPageUrl { get; set; }

    [CultureSpecific]
    [Display(Name = "PO Label", GroupName = Global.GroupNames.Labels, Order = 16)]
    public virtual string PoLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Notes Label", GroupName = Global.GroupNames.Labels, Order = 17)]
    public virtual string NotesLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Shipping Method Label", GroupName = Global.GroupNames.Labels, Order = 18)]
    public virtual string ShippingMethodLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Order Subtotal Label", GroupName = Global.GroupNames.Labels, Order = 19)]
    public virtual string OrderSubtotalLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Shipping Handling Label", GroupName = Global.GroupNames.Labels, Order = 20)]
    public virtual string ShippingHandlingLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Tax Label", GroupName = Global.GroupNames.Labels, Order = 21)]
    public virtual string TaxLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Total Label", GroupName = Global.GroupNames.Labels, Order = 22)]
    public virtual string TotalLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Promotion Label",
        Description = "Promotion Label",
        GroupName = Global.GroupNames.Labels,
        Order = 21
    )]
    public virtual string PromotionLabel { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "Order Details";
        WebOrderNumber = "Web Order #";
        OrderDate = "Order Date:";
        OrderStatus = "Order Status";
        ShippingAddress = "Shipping Information";
        BillingAddress = "Billing Information";
        Terms = "Terms";
        OrderSummary = "Order Summary";
        PrintButton = "Print";
        ReturnButton = "Return to Order History";
        ReorderButton = "Reorder";
        ReorderAllButton = "Reorder All";
        PoLabel = "PO";
        NotesLabel = "Notes";
        ShippingMethodLabel = "Shipping Method";
        ShippingHandlingLabel = "Shipping Handling";
        OrderSubtotalLabel = "Order Subtotal";
        TaxLabel = "Tax";
        TotalLabel = "Order Total";
        PromotionLabel = "Promo Applied";
        ReorderAllPopUpSuccessMessageTitle = "Add All to Cart";
        ReorderAllPopUpSuccessMessage = "The requested products have been added to your cart.";
    }

    [CultureSpecific]
    [Display(
        Name = "Return Request Button Text",
        GroupName = Global.GroupNames.Labels,
        Order = 14
    )]
    public virtual string ReturnRequestButtonText { get; set; }

    [CultureSpecific]
    [Display(Name = "Return Request Link", GroupName = SystemTabNames.Content, Order = 15)]
    public virtual Url ReturnRequestLink { get; set; }
}
