namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Content Page",
    GUID = "69ea667f-0bb9-4fa8-bf25-8c8b185cb23f",
    Description = "Used for pages that contain searchable content",
    GroupName = Global.GroupNames.ContentPages
)]
[SiteImageUrl]
public class ContentPage : BasePage
{
    [Display(GroupName = SystemTabNames.Content, Order = 1)]
    public virtual ContentArea SearchableContentArea { get; set; }
}
