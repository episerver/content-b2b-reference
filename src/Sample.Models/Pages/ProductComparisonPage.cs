namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Product Comparison Page",
    GUID = "c1568978-f573-4366-9764-b18cbd6435b7",
    GroupName = Global.GroupNames.CommercePages,
    Description = "Product Comparison Page to display in ProductListing Page"
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class ProductComparisonPage : BasePage
{
    [CultureSpecific]
    [Display(
        Name = "Return To Previous Button Label",
        GroupName = Global.GroupNames.Labels,
        Order = 1
    )]
    public virtual string PreviousButtonLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "RemoveAll Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string RemoveAllLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Product Comparison Error Label",
        GroupName = Global.GroupNames.Labels,
        Order = 4
    )]
    public virtual string ProductComparisonWarningLabel { get; set; }

    [Display(Name = "Item Action Content Area", GroupName = SystemTabNames.Content, Order = 5)]
    [AllowedTypes(new[] { typeof(LabelSettings) })]
    public virtual ContentArea ItemActionContentArea { get; set; }

    [Display(Name = "Rating Image", GroupName = SystemTabNames.Content, Order = 6)]
    [UIHint(UIHint.Image)]
    public virtual ContentReference RatingImage { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        PreviousButtonLabel = "Return to Previous Page";
        RemoveAllLabel = "Remove All";
        MetaTitle = "Product Comparison";
        ProductComparisonWarningLabel = "There are no products to compare!";
    }
}
