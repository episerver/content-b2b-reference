namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Contact Us",
    GUID = "18de82df-086c-4153-99a4-ac2f482661a9",
    Description = "Contact Us",
    GroupName = Global.GroupNames.CommercePages
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class ContactUsPage : BasePage
{
    [CultureSpecific]
    [Display(
        Name = "Contact Us Form ContentArea",
        GroupName = SystemTabNames.Content,
        Order = 2
    )]
    public virtual ContentArea ContactUsFormContentArea { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "Contact Us";
    }
}
