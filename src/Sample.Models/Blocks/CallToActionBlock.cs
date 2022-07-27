using EPiServer.Shell.ObjectEditing;
using Sample.Models.UIDescriptors;

namespace Sample.Models.Blocks;


[ContentType(DisplayName = "Call To Action Block",
    GUID = "f82da800-c923-48f6-b701-fd093078c5d9",
    Description = "Provides a CTA anchor or link",
    GroupName = Global.GroupNames.ContentBlocks)]
[SiteImageUrl]
public class CallToActionBlock : SiteBlockData
{
    #region Content

    [CultureSpecific]
    [Display(GroupName = SystemTabNames.Content, Order = 20)]
    public virtual XhtmlString Subtext { get; set; }

    [Display(Name = "Text color", GroupName = SystemTabNames.Content, Order = 30)]
    [SelectOne(SelectionFactoryType = typeof(TextColorSelectionFactory))]
    public virtual string TextColor { get; set; }
    #endregion

    #region image
    [UIHint(UIHint.Image)]
    [Display(Name = "Background image", GroupName = Global.GroupNames.Default, Order = 40)]
    public virtual ContentReference BackgroundImage { get; set; }

    [SelectOne(SelectionFactoryType = typeof(BackgroundImageSelectionFactory))]
    [Display(Name = "Choose image style to fit the block", Order = 41, GroupName = Global.GroupNames.Default)]
    public virtual string BackgroundImageSetting { get; set; }
    #endregion

    [Display(GroupName = Global.GroupNames.Default, Order = 50)]
    public virtual ButtonBlock Button { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);

        TextColor = "text-black";
        BackgroundImageSetting = "image-default";
    }
}