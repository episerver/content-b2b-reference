using EPiServer.Shell.ObjectEditing;

namespace Sample.Models.Settings;

[SettingsContentType(
    DisplayName = "Header Settings",
    GUID = "da77c9c2-d14b-4fb7-829c-44bf38cfcac1",
    Description = "Header Settings",
    GroupName = Global.GroupNames.SiteSettings,
    SettingsName = "Header Settings"
)]
[SiteImageUrl]
public class HeaderSettings : SettingsBase
{
    [DefaultDragAndDropTarget]
    [UIHint(UIHint.Image)]
    [Display(Name = "Logo", GroupName = Global.GroupNames.SiteSettings, Order = 1)]
    public virtual Url Logo
    {
        get
        {
            var url = this.GetPropertyValue(b => b.Logo);

            return url == null || url.IsEmpty() ? new Url("/Static/gfx/logotype.png") : url;
        }
        set { this.SetPropertyValue(b => b.Logo, value); }
    }

    [CultureSpecific]
    [Display(Name = "Logo Title", GroupName = Global.GroupNames.SiteSettings, Order = 10)]
    public virtual string Title { get; set; }

    [CultureSpecific]
    [AllowedTypes(new[] { typeof(MenuItemBlock), typeof(PageData) })]
    [Display(Name = "Main menu", GroupName = Global.GroupNames.SiteSettings, Order = 20)]
    public virtual ContentArea MainMenu { get; set; }

}
