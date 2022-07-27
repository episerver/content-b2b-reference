namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Quick Order Upload Page",
    GUID = "c967f0aa-7ab2-4a9f-85de-0922966462b8",
    Description = "Quick Order Upload Page",
    GroupName = Global.GroupNames.CommercePages
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class QuickOrderUploadPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "Short Description", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string ShortDescription { get; set; }

    [CultureSpecific]
    [Display(Name = "Instructions Header", GroupName = Global.GroupNames.Labels, Order = 3)]
    public virtual string InstructionsHeader { get; set; }

    [CultureSpecific]
    [Display(Name = "Instructions Details", GroupName = Global.GroupNames.Labels, Order = 4)]
    public virtual XhtmlString InstructionsDetails { get; set; }

    [CultureSpecific]
    [Display(Name = "Upload Button", GroupName = Global.GroupNames.Labels, Order = 5)]
    public virtual string UploadButton { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Option", GroupName = Global.GroupNames.Labels, Order = 6)]
    public virtual string HeaderOption { get; set; }

    [CultureSpecific]
    [Display(Name = "Upload Area Header", GroupName = Global.GroupNames.Labels, Order = 7)]
    public virtual string UploadAreaHeader { get; set; }

    [CultureSpecific]
    [Display(Name = "Goal Id", GroupName = Global.GroupNames.Labels, Order = 8)]
    public virtual string GoalId { get; set; }

    [Display(Name = "Quick Order Upload URL", Order = 9, GroupName = SystemTabNames.Content)]
    public virtual Url QuickOrderUploadUrl { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Quick Order Pop Up CartConfirmation Title",
        GroupName = Global.GroupNames.Labels,
        Order = 10
    )]
    public virtual string QuickOrderCartPopUpConfirmationTitle { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Quick Order Pop Up CartConfirmation Message",
        GroupName = Global.GroupNames.Labels,
        Order = 11
    )]
    public virtual string QuickOrderPopUpConfirmationMessage { get; set; }

    [Display(Name = "Cart Page Redirect URL", Order = 12, GroupName = SystemTabNames.Content)]
    public virtual Url CartPageRedirectUrl { get; set; }

    [Display(Name = "Quick Order Page Url", Order = 13, GroupName = SystemTabNames.Content)]
    public virtual Url QuickOrderPageUrl { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Quick Order Popup Button Label",
        GroupName = Global.GroupNames.Labels,
        Order = 14
    )]
    public virtual string QuickOrderPopupButtonLabel { get; set; }
}
