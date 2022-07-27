namespace Sample.Models.Pages;

[SiteContentType(
    GroupName = Global.GroupNames.CommercePages,
    DisplayName = "Address Page",
    GUID = "15F570D6-CA94-4887-BC83-61B86582EB7B",
    Description = "Address Page"
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class AddressesPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "Save Button Text", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string SaveButtonText { get; set; }

    [Display(Name = "My Account Page URL", GroupName = SystemTabNames.Content, Order = 3)]
    public virtual Url MyAccountPageURL { get; set; }

    [Display(Name = "Checkout Page URL", GroupName = SystemTabNames.Content, Order = 4)]
    public virtual Url CheckoutPageURL { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "Addresses";
        SaveButtonText = "Save";
    }
}
