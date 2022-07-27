namespace Sample.Models.Blocks;

[ContentType(
    DisplayName = "Bread crumb Block",
    GUID = "22793a75-687d-4080-9aa0-f3c725e9805a",
    Description = "Bread crumb",
    GroupName = Global.GroupNames.SharedBlocks
)]
[SiteImageUrl]
public class BreadcrumbBlock : SiteBlockData
{
    [Display(Name = "Destination page", Order = 1, GroupName = SystemTabNames.Content)]
    public virtual PageReference DestinationPage { get; set; }

    [Display(Name = "Breadcrumb separator", Order = 2, GroupName = SystemTabNames.Content)]
    public virtual string Separator { get; set; }

    [CultureSpecific]
    [Display(Name = "Search Result Text", Order = 3, GroupName = Global.GroupNames.Labels)]
    public virtual string SearchResultText { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        Separator = ">";
        SearchResultText = "Search";
    }
}
