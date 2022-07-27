namespace Sample.Models.Blocks;

[ContentType(DisplayName = "Video Block",
    GUID = "03D454F9-3BE8-4421-9A5D-CBBE8E38443D",
    Description = "Video Block",
    GroupName = Global.GroupNames.ContentBlocks)]
[SiteImageUrl]
public class VideoBlock : SiteBlockData
{
    [CultureSpecific]
    [UIHint(UIHint.Video)]
    public virtual ContentReference Video { get; set; }
}