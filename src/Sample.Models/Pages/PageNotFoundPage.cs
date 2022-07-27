namespace Sample.Models.Pages;

[SiteContentType(
    DisplayName = "Page Not Found",
    GroupName = Global.GroupNames.Utility,
    GUID = "E6ED8A16-661C-4784-98DA-C6E7C94DE43D",
    Description = "Use this page to display page not found message."
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class PageNotFoundPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "Message Title", GroupName = Global.GroupNames.Labels, Order = 1)]
    public virtual string MessageTitle { get; set; }

    [CultureSpecific]
    [Display(Name = "Message", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual XhtmlString Message { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MessageTitle = "Page Not Found";
        Message = new XhtmlString("Sorry, this page doesn't exist.");
    }
}
