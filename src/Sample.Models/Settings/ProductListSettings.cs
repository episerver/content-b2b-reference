namespace Sample.Models.Settings;

[SettingsContentType(
    DisplayName = "Product List Settings",
    GUID = "67D50288-7D55-4222-8F10-294C1E46AD0C",
    GroupName = Global.GroupNames.SiteSettings,
    SettingsName = "Product List Settings"
)]
[SiteImageUrl]
public class ProductListSettings : SettingsBase
{
    [CultureSpecific]
    [Display(Name = "Default View Mode", Description = "Default view mode for product list page.", GroupName = Global.GroupNames.SiteSettings, Order = 1)]
    [UIHint("DefaultProductListView")]
    public virtual string DefaultProductListViewMode { get; set; }

    [Display(Name = "Max Product To Compare", Description = "Maximum product to compare in product list page.", GroupName = Global.GroupNames.SiteSettings, Order = 2)]
    [UIHint("DefaultProductListView")]
    [Range(0, 10)]
    public virtual int MaxCompareProducts { get; set; }

    [Display(Name = "Default Page Size", GroupName = Global.GroupNames.SiteSettings, Order = 2)]
    public virtual int DefaultPageSize { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        DefaultProductListViewMode = "Grid";
        MaxCompareProducts = 6;
        DefaultPageSize = 16;
    }
}
