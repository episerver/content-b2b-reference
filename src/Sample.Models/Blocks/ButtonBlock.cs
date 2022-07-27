using EPiServer.Shell.ObjectEditing;

namespace Sample.Models.Blocks;

[ContentType(DisplayName = "Button Block",
    GUID = "426CF12F-1F01-4EA0-922F-0778314DDAF0",
    Description = "Used to insert a link which is styled as a button",
    GroupName = Global.GroupNames.ContentBlocks,
    AvailableInEditMode = true)]
[SiteImageUrl]
public class ButtonBlock : SiteBlockData
{
    #region Content
    [CultureSpecific]
    [Display(Name = "Label", Order = 10, GroupName = SystemTabNames.Content)]
    public virtual string ButtonText { get; set; }

    [Display(Name = "Link", Order = 20, GroupName = SystemTabNames.Content)]
    public virtual Url ButtonLink { get; set; }

    [SelectOne(SelectionFactoryType = typeof(ButtonBlockStyleSelectionFactory))]
    [Display(Name = "Style", Order = 30, GroupName = SystemTabNames.Content)]
    public virtual string ButtonStyle { get; set; }

    [CultureSpecific]
    [Display(Name = "Reassuring caption", Order = 40, GroupName = SystemTabNames.Content, Prompt = "Cancel anytime...")]
    public virtual string ButtonCaption { get; set; }

    #endregion

    #region Button Text
    [CultureSpecific]
    [Searchable(false)]
    [Display(Name = "Use Custom Text Color", GroupName = Global.GroupNames.Default,
        Description = "This will determine whether or not to overdride text color", Order = 5)]
    public virtual bool TextColorOverride { get; set; }

    [CultureSpecific]
    [Searchable(false)]
    [SelectOne(SelectionFactoryType = typeof(TextColorSelectionFactory))]
    [Display(Name = "Button Text color", GroupName = Global.GroupNames.Default, Order = 10)]
    public virtual string ButtonTextColor
    {
        get { return this.GetPropertyValue(page => page.ButtonTextColor) ?? "text-black"; }
        set { this.SetPropertyValue(page => page.ButtonTextColor, value); }
    }

    #endregion

    #region Button Background
    [CultureSpecific]
    [Searchable(false)]
    [Display(Name = "Use Custom Background Color", GroupName = Global.GroupNames.Default,
        Description = "This will determine whether or not to overdride background color", Order = 15)]
    public virtual bool BackgroundColorOverride { get; set; }

    [CultureSpecific]
    [Display(Name = "Use transparent background", GroupName = Global.GroupNames.Default,
        Description = "This will determine whether or not to use transparent background", Order = 20)]
    public virtual bool ShowTransparentBackground { get; set; }

    [CultureSpecific]
    [Searchable(false)]
    [SelectOne(SelectionFactoryType = typeof(BgColorSelectionFactory))]
    [Display(Name = "Button background color", GroupName = Global.GroupNames.Default, Order = 25)]
    public virtual string ButtonBackgroundColor
    {
        get { return this.GetPropertyValue(page => page.ButtonBackgroundColor) ?? "bg-black"; }
        set { this.SetPropertyValue(page => page.ButtonBackgroundColor, value); }
    }
    #endregion

    #region Border
    [CultureSpecific]
    [Searchable(false)]
    [Display(Name = "Use Custom Border", GroupName = Global.GroupNames.Default,
        Description = "This will determine whether or not to overdride border style", Order = 30)]
    public virtual bool BorderStyleOverride { get; set; }

    [CultureSpecific]
    [Display(Name = "Border Styles", GroupName = Global.GroupNames.Default, Description = "This will determine whether or not to show border", Order = 10)]
    [SelectOne(SelectionFactoryType = typeof(BorderStyleSelectionFactory))]
    public virtual string BorderStyle { get; set; }

    [Display(Name = "Border width (px)", GroupName = Global.GroupNames.Default, Order = 35)]
    [RegularExpression("^[+]?\\d*$", ErrorMessage = "BorderWidth must be non-negative")]
    public virtual int BorderWidth { get; set; }

    [CultureSpecific]
    [Searchable(false)]
    [SelectOne(SelectionFactoryType = typeof(BorderColorSelectionFactory))]
    [Display(Name = "Button Border color", GroupName = Global.GroupNames.Default, Order = 40)]
    public virtual string ButtonBorderColor
    {
        get { return this.GetPropertyValue(page => page.ButtonBorderColor) ?? "border-black"; }
        set { this.SetPropertyValue(page => page.ButtonBorderColor, value); }
    }

    #endregion
    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        ButtonBackgroundColor = "bg-black";
        ButtonTextColor = "text-white";
        ButtonBorderColor = "border-black";
        ShowTransparentBackground = false;
        BorderStyle = "none";
        BorderWidth = 1;
        BackgroundColorOverride = false;
        TextColorOverride = false;
        BorderStyleOverride = false;
    }
}

public class BorderStyleSelectionFactory : ISelectionFactory
{
    public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
    {
        return new ISelectItem[]
        {
                new SelectItem { Text = "None", Value = "none" },
                new SelectItem { Text = "Solid", Value = "solid" },
                new SelectItem { Text = "Dotted	", Value = "dotted" },
                new SelectItem { Text = "Dashed", Value = "dashed" },
                new SelectItem { Text = "Double", Value = "double" },
                new SelectItem { Text = "Groove", Value = "groove" },
                new SelectItem { Text = "Ridge", Value = "ridge" },
                new SelectItem { Text = "Inset", Value = "inset" },
                new SelectItem { Text = "Outset", Value = "outset" },
        };
    }
}
