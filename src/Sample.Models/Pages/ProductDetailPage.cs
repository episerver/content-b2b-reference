namespace Sample.Models.Pages;

[SiteContentType(
    GroupName = Global.GroupNames.CommercePages,
    GUID = "AF041781-950C-4C2D-AF1B-E40B7A4D5ADF",
    DisplayName = "Product Detail Page",
    Description = "To create Product Detail page"
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class ProductDetailPage : BasePage
{
    [Display(GroupName = SystemTabNames.Content, Order = 1)]
    public virtual ContentArea RelatedProductContentArea { get; set; }

    [CultureSpecific]
    [Display(Name = "ERP Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string ErpLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "UOM Label", GroupName = Global.GroupNames.Labels, Order = 3)]
    public virtual string UomLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Availability Label", Order = 4, GroupName = Global.GroupNames.Labels)]
    public virtual string AvailabilityLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Color Label", Order = 5, GroupName = Global.GroupNames.Labels)]
    public virtual string ColorLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Weight Label", Order = 6, GroupName = Global.GroupNames.Labels)]
    public virtual string WeightLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Price Label", Order = 7, GroupName = Global.GroupNames.Labels)]
    public virtual string PriceLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "QTY Label", Order = 8, GroupName = Global.GroupNames.Labels)]
    public virtual string QtyLabel { get; set; }

    [Display(Name = "Item Action Content Area", GroupName = SystemTabNames.Content, Order = 9)]
    [AllowedTypes(new[] { typeof(LabelSettings) })]
    public virtual ContentArea ItemActionContentArea { get; set; }

    [CultureSpecific]
    [Display(Name = "Model #", GroupName = Global.GroupNames.Labels, Order = 10)]
    public virtual string ModelNumberLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Review Label", GroupName = Global.GroupNames.Labels, Order = 11)]
    public virtual string ReviewLabel { get; set; }

    [UIHint(UIHint.Image)]
    public virtual ContentReference RatingImage { get; set; }

    [CultureSpecific]
    [Display(Name = "Compare Label", GroupName = Global.GroupNames.Labels, Order = 13)]
    public virtual string CompareLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Compare Error Message", GroupName = Global.GroupNames.Labels, Order = 14)]
    public virtual string CompareErrorMessage { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        ErpLabel = "Item #";
        UomLabel = "UOM";
        AvailabilityLabel = "Availability";
        WeightLabel = "Weight";
        PriceLabel = "Price";
        QtyLabel = "Qty";
        ModelNumberLabel = "Model #";
        CompareLabel = "Compare";
        CompareErrorMessage = "Too many items selected for comparison";
    }
}
