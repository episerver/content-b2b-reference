namespace Sample.Models.Blocks;

[ContentType(
    DisplayName = "Quick Links Block",
    GUID = "86728910-c8ef-4859-ab1b-d42b43b80636",
    Description = "Display Quick Links",
    GroupName = Global.GroupNames.CommerceBlocks
)]
[SiteImageUrl]
public class QuickLinksBlock : SiteBlockData
{
    [Display(Name = "Quick Links", GroupName = SystemTabNames.Content, Order = 1)]
    public virtual LinkItemCollection Links { get; set; }
}
