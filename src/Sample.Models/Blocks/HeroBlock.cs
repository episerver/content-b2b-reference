using EPiServer.Shell.ObjectEditing;

namespace Sample.Models.Blocks;

[ContentType(DisplayName = "Hero Block",
    GUID = "8bdfac81-3dbd-43b9-a092-522bd67ee8b3",
    Description = "Image block with overlay for text",
    GroupName = Global.GroupNames.ContentBlocks)]
[SiteImageUrl]
public class HeroBlock : SiteBlockData
{

    [CultureSpecific]
    [UIHint(UIHint.Image)]
    [Display(Name = "Image", Order = 10)]
    public virtual ContentReference BackgroundImage { get; set; }

    [Display(Order = 30)]
    public virtual Url Link { get; set; }

    [CultureSpecific]
    [Display(Name = "Description", Order = 40)]
    [BackingType(typeof(PropertyLongString))]
    public virtual string Description { get; set; }

    [SelectOne(SelectionFactoryType = typeof(TextColorSelectionFactory))]
    [Display(Name = "Text Color", Order = 55)]
    [BackingType(typeof(PropertyString))]
    public virtual string TextColor { get; set; }

    [CultureSpecific]
    [Display(Name = "Button Text", Order = 50)]
    [BackingType(typeof(PropertyString))]
    public virtual string ButtonText { get; set; }

    [SelectOne(SelectionFactoryType = typeof(BgColorSelectionFactory))]
    [Display(Name = "Button Color", Order = 55)]
    [BackingType(typeof(PropertyString))]
    public virtual string ButtonColor { get; set; }

    [SelectOne(SelectionFactoryType = typeof(TextColorSelectionFactory))]
    [Display(Name = "Button Text Color", Order = 60)]
    [BackingType(typeof(PropertyString))]
    public virtual string ButtonTextColor { get; set; }
}