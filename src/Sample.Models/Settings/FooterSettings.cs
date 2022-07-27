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
    [Display(Name = "Our company Links", GroupName = SystemTabNames.Content, Order = 25)]
    public virtual LinkItemCollection CompanyLinks { get; set; }

    [Display(Name = "Support Links", GroupName = SystemTabNames.Content, Order = 26)]
    public virtual LinkItemCollection SupportLinks { get; set; }

    [Display(Name = "Brand Links", GroupName = SystemTabNames.Content, Order = 27)]
    public virtual LinkItemCollection BrandLinks { get; set; }

    [Display(Name = "Product Line Links", GroupName = SystemTabNames.Content, Order = 28)]
    public virtual LinkItemCollection ProductLineLinks { get; set; }

    [CultureSpecific]
    [Display(Name = "Our company Heading", GroupName = Global.GroupNames.Labels, Order = 10)]
    public virtual string OurCompanyHeading { get; set; }

    [CultureSpecific]
    [Display(Name = "Support Heading", GroupName = Global.GroupNames.Labels, Order = 20)]
    public virtual string SupportHeading { get; set; }

    [CultureSpecific]
    [Display(Name = "Brand Heading", GroupName = Global.GroupNames.Labels, Order = 30)]
    public virtual string BrandHeading { get; set; }

    [CultureSpecific]
    [Display(Name = "Product Line Heading", GroupName = Global.GroupNames.Labels, Order = 40)]
    public virtual string ProductLineHeading { get; set; }

}
