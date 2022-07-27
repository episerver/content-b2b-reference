namespace Sample.Models.Settings;

[SettingsContentType(
    DisplayName = "Footer Settings",
    GUID = "b9d9a172-7dd0-49a7-976c-8d4e6d5a5e0c",
    GroupName = Global.GroupNames.SiteSettings,
    SettingsName = "Footer Settings"
)]
[SiteImageUrl]
public class FooterSettings : SettingsBase
{
    

    [CultureSpecific]
    [Display(Name = "Home Label", GroupName = Global.GroupNames.Labels, Order = 10)]
    public virtual string Home { get; set; }

    [CultureSpecific]
    [Display(Name = "Copyright", GroupName = Global.GroupNames.Labels, Order = 20)]
    public virtual string Copyright { get; set; }

    [CultureSpecific]
    [Display(Name = "About us", GroupName = Global.GroupNames.Labels, Order = 30)]
    public virtual string AboutUs { get; set; }

    [CultureSpecific]
    [Display(Name = "Contact us", GroupName = Global.GroupNames.Labels, Order = 40)]
    public virtual string ContactUs { get; set; }

}
