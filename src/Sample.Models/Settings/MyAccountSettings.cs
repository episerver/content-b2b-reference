using EPiServer.Shell.ObjectEditing;

namespace Sample.Models.Settings;

[SettingsContentType(
    DisplayName = "My Account Settings",
    GUID = "2207a08e-3af1-429c-a78d-e1c79ba0e644",
    GroupName = Global.GroupNames.SiteSettings,
    SettingsName = "My Account Settings"
)]
[SiteImageUrl]
public class MyAccountSettings : SettingsBase
{
    [Display(Name = "Menu", GroupName = Global.GroupNames.SiteSettings, Order = 20)]
    public virtual LinkItemCollection Menu { get; set; }

}
