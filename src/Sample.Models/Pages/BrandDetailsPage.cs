namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Brand Details Page",
    GUID = "2ee7dcea-8a84-4168-8202-e557bd9d16ef",
    GroupName = Global.GroupNames.CommercePages,
    Description = "Brand Details Page"
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class BrandDetailsPage : BasePage
{
    [CultureSpecific]
    [Display(
        Name = "Brand Name",
        Description = "Brand Name",
        GroupName = SystemTabNames.Content,
        Order = 1
    )]
    public virtual string BrandName { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        BrandName = "Brand Name";
    }
}
