namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Return Request Page",
    GUID = "38f44d68-859c-47c6-8a6a-87bf0bd7342c",
    GroupName = Global.GroupNames.CommercePages,
    Description = "To Create Return Request Page"
)]
[SiteImageUrl]
public class ReturnRequestPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "Web Order Number Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string WebOrderNumberLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Order Date Label", GroupName = Global.GroupNames.Labels, Order = 3)]
    public virtual string OrderDateLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "PoNumber Label", GroupName = Global.GroupNames.Labels, Order = 4)]
    public virtual string PoNumberLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Billing Address Information Label",
        GroupName = Global.GroupNames.Labels,
        Order = 5
    )]
    public virtual string BillingAddressInformationLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Return To Order Details Link",
        GroupName = Global.GroupNames.Labels,
        Order = 6
    )]
    public virtual Url ReturnToOrderDetailLink { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Return Reason Validation Message",
        GroupName = SystemTabNames.Content,
        Order = 7
    )]
    public virtual string ReturnReasonValidationMessage { get; set; }

    [CultureSpecific]
    [Display(
        Name = "QTY Returning Validation Message",
        GroupName = Global.GroupNames.Labels,
        Order = 8
    )]
    public virtual string QTYReturningValidationMessage { get; set; }

    [CultureSpecific]
    [Display(Name = "Return Notes Label", GroupName = Global.GroupNames.Labels, Order = 9)]
    public virtual string ReturnNotesLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Send Request Button Text", GroupName = Global.GroupNames.Labels, Order = 10)]
    public virtual string SendRequestButtonText { get; set; }

    [CultureSpecific]
    [Display(Name = "Send Request Label Text", GroupName = Global.GroupNames.Labels, Order = 11)]
    public virtual string SendRequestLabelText { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Return To Order Details Link Text",
        GroupName = Global.GroupNames.Labels,
        Order = 12
    )]
    public virtual string ReturnToOrderDetailLinkText { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Return Quantity Validation Message(Should not be greater then actual quantity)",
        GroupName = Global.GroupNames.Labels,
        Order = 13
    )]
    public virtual string ReturnQuantityValidationMessage { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Return Request Confirmation Title",
        GroupName = Global.GroupNames.Labels,
        Order = 14
    )]
    public virtual string ReturnRequestConfirmationTitle { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Return Request select atleast one validation Message",
        GroupName = Global.GroupNames.Labels,
        Order = 15
    )]
    public virtual string ReturnRequestSelectAtleastOneValidationMessage { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Product Label", GroupName = Global.GroupNames.Labels, Order = 16)]
    public virtual string HeaderProductLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Price Label", GroupName = Global.GroupNames.Labels, Order = 17)]
    public virtual string HeaderPriceLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Qty Ordered Label", GroupName = Global.GroupNames.Labels, Order = 18)]
    public virtual string HeaderQtyOrderedLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Header Qty Returning Label",
        GroupName = Global.GroupNames.Labels,
        Order = 19
    )]
    public virtual string HeaderQtyReturningLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Header Return Reason Label",
        GroupName = Global.GroupNames.Labels,
        Order = 20
    )]
    public virtual string HeaderReturnReasonLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Model No Label", GroupName = Global.GroupNames.Labels, Order = 21)]
    public virtual string ModelNoLabel { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "Return Request(RMA)";
        WebOrderNumberLabel = "Order #";
        OrderDateLabel = "Order Date";
        PoNumberLabel = "PO #";
        BillingAddressInformationLabel = "Billing Information";
        ReturnNotesLabel = "Return Notes";
        SendRequestButtonText = "Send Return Request";
        SendRequestLabelText =
            "By clicking 'Send Return Request' you are agreeing to Terms of Service.";
        ReturnToOrderDetailLinkText = "Return to Order Details";
        ReturnRequestSelectAtleastOneValidationMessage =
            "Please provide a return quantity for at least one item.";
        HeaderProductLabel = "Product";
        HeaderPriceLabel = "Price";
        HeaderQtyOrderedLabel = "Qty Ordered";
        HeaderQtyReturningLabel = "Qty Returning";
        HeaderReturnReasonLabel = "Return reason";
        ModelNoLabel = "Model #";
    }
}
