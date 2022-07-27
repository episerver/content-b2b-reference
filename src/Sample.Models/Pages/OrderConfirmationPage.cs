namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Order Confirmation Page",
    GUID = "0a60e87a-879e-49df-acca-dd0b04c2e90a",
    Description = "Order Confirmation",
    GroupName = Global.GroupNames.CommercePages
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class OrderConfirmationPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "Order Number Label", GroupName = Global.GroupNames.Labels, Order = 1)]
    public virtual string OrderNumberLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Status Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string StatusLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Order Date Label", GroupName = Global.GroupNames.Labels, Order = 3)]
    public virtual string OrderDateLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Billing Information Heading",
        GroupName = Global.GroupNames.Labels,
        Order = 4
    )]
    public virtual string BillingInformationHeading { get; set; }

    [CultureSpecific]
    [Display(Name = "Continue Shopping Text", GroupName = Global.GroupNames.Labels, Order = 5)]
    public virtual string ContinueShoppingText { get; set; }

    [Display(Name = "Continue Shopping Link", GroupName = SystemTabNames.Content, Order = 6)]
    public virtual Url ContinueShoppingLink { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Shipping Information Heading",
        GroupName = Global.GroupNames.Labels,
        Order = 7
    )]
    public virtual string ShippingInformationHeading { get; set; }

    [CultureSpecific]
    [Display(Name = "Shipping Method Heading", GroupName = Global.GroupNames.Labels, Order = 8)]
    public virtual string ShippingMethodHeading { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Card Billing Address Heading",
        GroupName = Global.GroupNames.Labels,
        Order = 9
    )]
    public virtual string CardBillingAddressHeading { get; set; }

    [CultureSpecific]
    [Display(Name = "Print Text", GroupName = Global.GroupNames.Labels, Order = 10)]
    public virtual string PrintText { get; set; }

    [CultureSpecific]
    [Display(Name = "Add Items To List Text", GroupName = Global.GroupNames.Labels, Order = 11)]
    public virtual string AddItemsToListText { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Thank You Message",
        Description = "Thank you message",
        GroupName = Global.GroupNames.Labels,
        Order = 13
    )]
    public virtual string ThankYouMessage { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Payment Method Label",
        Description = "Payment Method Label",
        GroupName = Global.GroupNames.Labels,
        Order = 14
    )]
    public virtual string PaymentMethodLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Purchase Order Number Label",
        Description = "Purchase Order Number Label",
        GroupName = Global.GroupNames.Labels,
        Order = 15
    )]
    public virtual string PurchaseOrderNumberLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Product Label",
        Description = "Product Label",
        GroupName = Global.GroupNames.Labels,
        Order = 16
    )]
    public virtual string ProductLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Price Label",
        Description = "Price Label",
        GroupName = Global.GroupNames.Labels,
        Order = 17
    )]
    public virtual string PriceLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Qty Ordered Label",
        Description = "Qty Ordered Label",
        GroupName = Global.GroupNames.Labels,
        Order = 18
    )]
    public virtual string QtyOrderedLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Qty Shipped Label",
        Description = "Qty Shipped Label",
        GroupName = Global.GroupNames.Labels,
        Order = 19
    )]
    public virtual string QtyShippedLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Sub Total Label",
        Description = "Sub Total Label",
        GroupName = Global.GroupNames.Labels,
        Order = 20
    )]
    public virtual string SubTotalLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Item No Label",
        Description = "Item No Label",
        GroupName = Global.GroupNames.Labels,
        Order = 21
    )]
    public virtual string ItemNoLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Model No Label",
        Description = "Model No Label",
        GroupName = Global.GroupNames.Labels,
        Order = 22
    )]
    public virtual string ModelNoLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Color Label",
        Description = "Color Label",
        GroupName = Global.GroupNames.Labels,
        Order = 23
    )]
    public virtual string ColorLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Size Label",
        Description = "Size Label",
        GroupName = Global.GroupNames.Labels,
        Order = 24
    )]
    public virtual string SizeLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Qty Label",
        Description = "Qty Label",
        GroupName = Global.GroupNames.Labels,
        Order = 25
    )]
    public virtual string QtyLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Shipped Label",
        Description = "Shipped Label",
        GroupName = Global.GroupNames.Labels,
        Order = 26
    )]
    public virtual string ShippedLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Order Sub Total Label",
        Description = "Order Sub Total Label",
        GroupName = Global.GroupNames.Labels,
        Order = 27
    )]
    public virtual string OrderSubTotalLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Shipping And Handling Label",
        Description = "Shipping and Handling Label",
        GroupName = Global.GroupNames.Labels,
        Order = 28
    )]
    public virtual string ShippingAndHandlingLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Tax Label",
        Description = "Tax Label",
        GroupName = Global.GroupNames.Labels,
        Order = 29
    )]
    public virtual string TaxLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Grand Total Label",
        Description = "Grand Total Label",
        GroupName = Global.GroupNames.Labels,
        Order = 30
    )]
    public virtual string GrandTotalLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Promotion Label",
        Description = "Promotion Label",
        GroupName = Global.GroupNames.Labels,
        Order = 31
    )]
    public virtual string PromotionLabel { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        OrderNumberLabel = "Order No.";
        StatusLabel = "Order Status";
        OrderDateLabel = "Order Date";
        BillingInformationHeading = "Billing Address";
        ContinueShoppingText = "Continue Shopping";
        ShippingInformationHeading = "Shipping Address";
        ShippingMethodHeading = "Shipping Method";
        CardBillingAddressHeading = "Credit Card Billing Address";
        PrintText = "Print";
        AddItemsToListText = "Add All to List";
        MetaTitle = "Order Confirmation";
        ThankYouMessage = "Thank you for your order!";
        PaymentMethodLabel = "Terms";
        PurchaseOrderNumberLabel = "PO#";
        ProductLabel = "Product";
        PriceLabel = "Price";
        QtyOrderedLabel = "QTY Ordered";
        QtyShippedLabel = "QTY Shipped";
        SubTotalLabel = "Subtotal";
        ItemNoLabel = "Item #";
        ModelNoLabel = "Model #";
        ColorLabel = "Color";
        SizeLabel = "Size";
        QtyLabel = "QTY";
        ShippedLabel = "Shipped";
        OrderSubTotalLabel = "Order Sub Total";
        ShippingAndHandlingLabel = "Shipping & Handling";
        TaxLabel = "Tax";
        GrandTotalLabel = "Total";
        PromotionLabel = "Promo Applied";
    }
}
