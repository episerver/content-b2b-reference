namespace Sample.Models.Blocks;

[ContentType(
    DisplayName = "Brand List Block",
    GUID = "41be7745-c063-4880-9df1-330d94f8ca09",
    Description = "Brand List Block",
    GroupName = Global.GroupNames.CommerceBlocks
)]
[SiteImageUrl]
public class BrandListBlock : SiteBlockData
{
    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        Title = "Featured Brands";
    }
}
