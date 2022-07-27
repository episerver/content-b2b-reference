namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Invoice Details Page",
    GUID = "01743029-66fe-44f0-94ec-21e96191ee8b",
    GroupName = Global.GroupNames.CommercePages,
    Description = "To Create Invoice Details Page"
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class InvoiceDetailsPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "Web Order", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string WebOrderNumber { get; set; }

    [CultureSpecific]
    [Display(Name = "Invoice Date", GroupName = Global.GroupNames.Labels, Order = 3)]
    public virtual string InvoiceDate { get; set; }

    [CultureSpecific]
    [Display(Name = "Invoice Due Date", GroupName = Global.GroupNames.Labels, Order = 4)]
    public virtual string InvoiceDueDate { get; set; }

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
    [Display(Name = "Invoice Number", GroupName = Global.GroupNames.Labels, Order = 14)]
    public virtual string InvoiceNo { get; set; }

    [CultureSpecific]
    [Display(Name = "PO #", GroupName = Global.GroupNames.Labels, Order = 15)]
    public virtual string PoNumber { get; set; }

    [CultureSpecific]
    [Display(Name = "Notes Label", GroupName = Global.GroupNames.Labels, Order = 16)]
    public virtual string NotesLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Shipping Method Label", GroupName = Global.GroupNames.Labels, Order = 17)]
    public virtual string ShippingMethodLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Invoice Subtotal Label", GroupName = Global.GroupNames.Labels, Order = 18)]
    public virtual string InvoiceSubtotalLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Tax Label", GroupName = Global.GroupNames.Labels, Order = 19)]
    public virtual string TaxLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Total Label", GroupName = Global.GroupNames.Labels, Order = 20)]
    public virtual string TotalLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Promotion Label",
        Description = "Promotion Label",
        GroupName = Global.GroupNames.Labels,
        Order = 21
    )]
    public virtual string PromotionLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Shipping Handling Label", GroupName = Global.GroupNames.Labels, Order = 20)]
    public virtual string ShippingHandlingLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Product", GroupName = Global.GroupNames.Labels, Order = 21)]
    public virtual string Headerproduct { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Price", GroupName = Global.GroupNames.Labels, Order = 22)]
    public virtual string HeaderPrice { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Qty Ordered", GroupName = Global.GroupNames.Labels, Order = 23)]
    public virtual string HeaderQtyOrdered { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Qty Shipped", GroupName = Global.GroupNames.Labels, Order = 24)]
    public virtual string HeaderQtyShipped { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Sub Total", GroupName = Global.GroupNames.Labels, Order = 24)]
    public virtual string HeaderSubTotal { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "Invoice Details";
        WebOrderNumber = "Web Order #";
        InvoiceDate = "Invoice Date";
        InvoiceDueDate = "Due Date";
        ShippingAddress = "Shipping Address";
        BillingAddress = "Billing Address";
        Terms = "Terms";
        ReturnButton = "Return to Invoice History";
        InvoiceNo = "Invoice #";
        PoNumber = "PO #";
        NotesLabel = "Notes";
        ShippingMethodLabel = "Shipping Method";
        InvoiceSubtotalLabel = "Invoice Subtotal";
        TaxLabel = "Tax";
        TotalLabel = "Order Total";
        PromotionLabel = "Promo Applied";
        ShippingHandlingLabel = "Shipping Handling";
        Headerproduct = "Product";
        HeaderPrice = "Price";
        HeaderQtyOrdered = "Qty Ordered";
        HeaderQtyShipped = "Qty Shipped";
        HeaderSubTotal = "Sub Total";
    }
}
