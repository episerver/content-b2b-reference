namespace Sample.Models.Pages;

[SiteContentType(
    DisplayName = "Cart Page",
    GroupName = Global.GroupNames.CommercePages,
    GUID = "36FBE3C7-5D99-4F46-8BFB-2BC184A9B4E6",
    Description = "To Create Cart Page"
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class CartPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "Line Notes Tab", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string TabName { get; set; }

    [CultureSpecific]
    [Display(Name = "Add Item Notes", GroupName = Global.GroupNames.Labels, Order = 3)]
    public virtual string AddItemNotes { get; set; }

    [CultureSpecific]
    [Display(Name = "Qty", GroupName = Global.GroupNames.Labels, Order = 4)]
    public virtual string Qty { get; set; }

    [CultureSpecific]
    [Display(Name = "Continue Button Text", GroupName = Global.GroupNames.Labels, Order = 5)]
    public virtual string ContinueButtonText { get; set; }

    [Display(Name = "Continue Button Link", GroupName = SystemTabNames.Content, Order = 6)]
    public virtual Url ContinueButtonLink { get; set; }

    [CultureSpecific]
    [Display(Name = "Checkout Button Text", GroupName = Global.GroupNames.Labels, Order = 7)]
    public virtual string CheckoutButtonText { get; set; }

    [Display(Name = "Checkout Button Link", GroupName = SystemTabNames.Content, Order = 8)]
    public virtual Url CheckoutButtonLink { get; set; }

    [CultureSpecific]
    [Display(Name = "Save Order Button Text", GroupName = Global.GroupNames.Labels, Order = 9)]
    public virtual string SaveOrderButtonText { get; set; }

    [Display(Name = "Save Order Button Link", GroupName = SystemTabNames.Content, Order = 10)]
    public virtual Url SaveOrderButtonLink { get; set; }

    [CultureSpecific]
    [Display(Name = "Add All Button Text", GroupName = Global.GroupNames.Labels, Order = 11)]
    public virtual string AddAllButtonText { get; set; }

    [CultureSpecific]
    [Display(Name = "Remove All Button Text", GroupName = Global.GroupNames.Labels, Order = 13)]
    public virtual string RemoveAllButtonText { get; set; }

    [CultureSpecific]
    [Display(Name = "Sub Total", GroupName = Global.GroupNames.Labels, Order = 15)]
    public virtual string SubTotalText { get; set; }

    [Display(Name = "Sign In Page Link", GroupName = SystemTabNames.Content, Order = 16)]
    public virtual Url SignInPageLink { get; set; }

    [Display(
        Name = "Saved Order Details Page Link",
        GroupName = SystemTabNames.Content,
        Order = 17
    )]
    public virtual Url SavedOrderDetailsPageLink { get; set; }

    [CultureSpecific]
    [Display(Name = "Cart Line Empty Message", GroupName = Global.GroupNames.Labels, Order = 18)]
    public virtual string CartLineEmptyMessage { get; set; }

    [Display(Name = "Rating Image", GroupName = SystemTabNames.Content, Order = 19)]
    [UIHint(UIHint.Image)]
    public virtual ContentReference RatingImage { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Secure Checkout Button Text",
        GroupName = Global.GroupNames.Labels,
        Order = 20
    )]
    public virtual string SecureCheckoutButtonText { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Promotion Label",
        Description = "Promotion Label",
        GroupName = Global.GroupNames.Labels,
        Order = 21
    )]
    public virtual string PromotionLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Summary Label",
        Description = "Summary Label",
        GroupName = Global.GroupNames.Labels,
        Order = 22
    )]
    public virtual string SummaryLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Order Subtotal Label",
        Description = "Order Subtotal Label",
        GroupName = Global.GroupNames.Labels,
        Order = 23
    )]
    public virtual string OrderSubTotalLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Shipping Handling Label",
        Description = "Shipping Handling Label",
        GroupName = Global.GroupNames.Labels,
        Order = 24
    )]
    public virtual string ShippingHandlingLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Tax Label",
        Description = "Tax Label",
        GroupName = Global.GroupNames.Labels,
        Order = 25
    )]
    public virtual string TaxLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Total Label",
        Description = "Total Label",
        GroupName = Global.GroupNames.Labels,
        Order = 26
    )]
    public virtual string TotalLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Items Label",
        Description = "Items Label",
        GroupName = Global.GroupNames.Labels,
        Order = 27
    )]
    public virtual string ItemsLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Cart Tools Label",
        Description = "Cart Tools Label",
        GroupName = Global.GroupNames.Labels,
        Order = 28
    )]
    public virtual string CartToolsLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Color Label",
        Description = "Color Label",
        GroupName = Global.GroupNames.Labels,
        Order = 29
    )]
    public virtual string ColorLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Size Label",
        Description = "Size Label",
        GroupName = Global.GroupNames.Labels,
        Order = 30
    )]
    public virtual string SizeLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Price Label",
        Description = "Price Label",
        GroupName = Global.GroupNames.Labels,
        Order = 31
    )]
    public virtual string PriceLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Quantity Label",
        Description = "Quantity Label",
        GroupName = Global.GroupNames.Labels,
        Order = 32
    )]
    public virtual string QuantityLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Subtotal Label",
        Description = "Subtotal Label",
        GroupName = Global.GroupNames.Labels,
        Order = 33
    )]
    public virtual string SubtotalLabel { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "Cart";
        TabName = "Line Notes";
        AddItemNotes = "Add Item Notes";
        Qty = "QTY:";
        ContinueButtonText = "Continue Shopping";
        CheckoutButtonText = "Checkout";
        SaveOrderButtonText = "Save Order";
        AddAllButtonText = "Add All to List";
        RemoveAllButtonText = "Remove All";
        SubTotalText = "Sub-total";
        CartLineEmptyMessage = "There are no items in your cart";
        PromotionLabel = "Promo Applied";
        SummaryLabel = "Summary";
        OrderSubTotalLabel = "Order Subtotal";
        ShippingHandlingLabel = "Shipping & Handling";
        TaxLabel = "Tax";
        TotalLabel = "Total";
        ItemsLabel = "Items";
        CartToolsLabel = "cart tools";
        ColorLabel = "Color";
        SizeLabel = "Size";
        PriceLabel = "Price";
        QuantityLabel = "Qty";
        SubtotalLabel = "Subtotal";
    }
}
