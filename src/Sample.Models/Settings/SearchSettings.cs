namespace Sample.Models.Settings;

[SettingsContentType(
    DisplayName = "Search Settings",
    GUID = "5ca41c43-948f-4623-bdbe-9608245ee382",
    GroupName = Global.GroupNames.SiteSettings,
    SettingsName = "Search Settings"
)]
[SiteImageUrl]
public class SearchSettings : SettingsBase
{
    
    [Display(Name = "Search Icon", GroupName = Global.GroupNames.SiteSettings)]
    [UIHint(UIHint.Image)]
    public virtual ContentReference SearchIcon { get; set; }

    [Display(Name = "Enable Product Search", GroupName = Global.GroupNames.SiteSettings)]
    public virtual bool EnableProductSearch { get; set; }

    [Display(Name = "Enable Category Search", GroupName = Global.GroupNames.SiteSettings)]
    public virtual bool EnableCategorySearch { get; set; }

    [Display(Name = "Enable Content Search", GroupName = Global.GroupNames.SiteSettings)]
    public virtual bool EnableContentSearch { get; set; }

    [Display(Name = "Enable Brand Search", GroupName = Global.GroupNames.SiteSettings)]
    public virtual bool EnableBrandSearch { get; set; }

    [Display(Name = "Auto Complete Search URL", GroupName = Global.GroupNames.SiteSettings)]
    public virtual string AutoCompleteSearchUrl { get; set; }

    [Display(Name = "Auto Complete Search Minimum Character", GroupName = Global.GroupNames.SiteSettings)]
    [Range(1, 10)]
    public virtual int AutoCompleteSearchMinChar { get; set; }

    [Display(Name = "Auto Complete Search Api Call interval", GroupName = Global.GroupNames.SiteSettings)]
    [Range(100, 300)]
    public virtual int AutoCompleteSearchApiDeferRequestBy { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        
        EnableProductSearch = true;
        EnableCategorySearch = true;
        EnableContentSearch = true;
        AutoCompleteSearchUrl = "/searchpage/AutoCompleteSearch";
        AutoCompleteSearchMinChar = 2;
        AutoCompleteSearchApiDeferRequestBy = 200;
        EnableBrandSearch = true;
    }
}
