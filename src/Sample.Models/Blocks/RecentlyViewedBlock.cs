namespace Sample.Models.Blocks;

[ContentType(
    DisplayName = "Recently Viewed Block",
    GUID = "3a5b2730-d562-43a7-8897-b953a1fc25cb",
    Description = ""
)]
[SiteImageUrl]
public class RecentlyViewedBlock : SiteBlockData
{
    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        Title = "Recently Viewed";
    }
}
