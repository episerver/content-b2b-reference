namespace Sample.Models.Blocks;

[ContentType(DisplayName = "Text Block",
    GUID = "32782B29-278B-410A-A402-9FF46FAF32B9",
    Description = "Simple Rich Text Block",
    GroupName = Global.GroupNames.ContentBlocks)]
[SiteImageUrl]
public class TextBlock : SiteBlockData
{
    [CultureSpecific]
    [Display(Name = "Main body")]
    public virtual XhtmlString MainBody { get; set; }
}