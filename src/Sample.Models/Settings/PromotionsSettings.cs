namespace Sample.Models.Settings;

[SettingsContentType(
    DisplayName = "Promotion Settings",
    GUID = "59CE48F2-75FC-43F8-8A0B-4F433E00CB22",
    GroupName = Global.GroupNames.SiteSettings,
    SettingsName = "Promotion Settings"
)]
[SiteImageUrl]
public class PromotionsSettings : SettingsBase
{
    [CultureSpecific]
    [Display(Name = "Site level promotion message", GroupName = Global.GroupNames.SiteSettings)]
    public virtual string PromoMessage { get; set; }

    [Display(
        Name = "Site level promotion detail URL",
        GroupName = Global.GroupNames.SiteSettings
    )]
    public virtual Url PromoMessageDetailUrl { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        PromoMessage = "LIMITED TIME FREE SHIPPING ON ORDERS OVER $100";
    }
}
