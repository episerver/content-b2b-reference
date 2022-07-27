namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Brands Page",
    GUID = "abfa894f-46b7-4eb0-b07b-17211404132e",
    GroupName = Global.GroupNames.CommercePages,
    Description = "To Display List of Brands"
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.Specific, Include = new[] { typeof(BrandDetailsPage) })]
public class BrandsPage : BasePage
{
    [CultureSpecific]
    [Display(
        Name = "BackToTopLabel",
        Description = "Back To Top Label",
        GroupName = Global.GroupNames.Labels,
        Order = 2
    )]
    public virtual string BackToTopLabel { get; set; }

    [Display(
        Name = "BrandPageUrl",
        Description = "Brand Page Url",
        GroupName = SystemTabNames.Content,
        Order = 3
    )]
    public virtual Url BrandPageUrl { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "Featured Brands";
        BackToTopLabel = "Back To Top";
    }
}
