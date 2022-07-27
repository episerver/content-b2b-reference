using EPiServer.Shell.ObjectEditing;

namespace Sample.Models.Blocks;

[ContentType(DisplayName = "Teaser Block",
    GUID = "EB67A99A-E239-41B8-9C59-20EAA5936047",
    Description = "Image block with overlay for text",
    GroupName = Global.GroupNames.ContentBlocks)]
[SiteImageUrl]
public class TeaserBlock : SiteBlockData
{
    #region Content
    [CultureSpecific]
    [Display(GroupName = SystemTabNames.Content, Order = 20)]
    public virtual string Description { get; set; }

    [Display(GroupName = SystemTabNames.Content, Order = 21)]
    public virtual PageReference Link { get; set; }
    #endregion

    #region Header
    [CultureSpecific]
    [Required(AllowEmptyStrings = false)]
    [Display(Name = "Heading text", GroupName = Global.GroupNames.Default, Order = 10)]
    public virtual string Heading { get; set; }

    [Display(Name = "Heading size", GroupName = Global.GroupNames.Default, Order = 11)]
    public virtual int HeadingSize { get; set; }

    [SelectOne(SelectionFactoryType = typeof(TeaserBlockHeadingStyleSelectionFactory))]
    [Display(Name = "Heading style", GroupName = Global.GroupNames.Default, Order = 12)]
    public virtual string HeadingStyle { get; set; }

    [SelectOne(SelectionFactoryType = typeof(TextColorSelectionFactory))]
    [Display(Name = "Heading color", GroupName = Global.GroupNames.Default, Order = 13)]
    public virtual string HeadingColor
    {
        get { return this.GetPropertyValue(page => page.HeadingColor) ?? "#000000ff"; }
        set { this.SetPropertyValue(page => page.HeadingColor, value); }
    }
    #endregion

    #region Text
    [CultureSpecific]
    [Display(GroupName = Global.GroupNames.Default, Order = 30)]
    public virtual XhtmlString Text { get; set; }

    [Display(Name = "Text color", GroupName = Global.GroupNames.Default, Order = 50)]
    [SelectOne(SelectionFactoryType = typeof(TextColorSelectionFactory))]
    public virtual string TextColor
    {
        get { return this.GetPropertyValue(page => page.TextColor) ?? "text-white"; }
        set { this.SetPropertyValue(page => page.TextColor, value); }
    }
    #endregion

    #region Image
    [CultureSpecific]
    [UIHint(UIHint.Image)]
    [Display(GroupName = Global.GroupNames.Default, Order = 40)]
    public virtual ContentReference Image { get; set; }

    [Range(1, 100, ErrorMessage = "Set image width from 1 to 100")]
    [Display(Name = "Image size (%)", GroupName = Global.GroupNames.Default, Order = 41)]
    public virtual int ImageSize { get; set; }

    [CultureSpecific]
    [UIHint(UIHint.Image)]
    [Display(Name = "Second Image", GroupName = Global.GroupNames.Default, Order = 45)]
    public virtual ContentReference SecondImage { get; set; }

    [Range(1, 100, ErrorMessage = "Set image width from 1 to 100")]
    [Display(Name = "Image size (%)", GroupName = Global.GroupNames.Default, Order = 46)]
    public virtual int SecondImageSize { get; set; }
    #endregion

    #region Style
    [SelectOne(SelectionFactoryType = typeof(TeaserBlockHeightStyleSelectionFactory))]
    [Display(Name = "Height", GroupName = Global.GroupNames.Default, Order = 100)]
    public virtual string Height { get; set; }
    #endregion

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);

        HeadingSize = 28;
        HeadingStyle = "none";
        HeadingColor = "text-black";
        ImageSize = 100;
        SecondImageSize = 100;
        BackgroundColor = "bg-transparent";
        TextColor = "text-black";
    }
}