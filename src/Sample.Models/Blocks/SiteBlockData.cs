﻿using EPiServer.Shell.ObjectEditing;

namespace Sample.Models.Blocks;

/// <summary>
/// Base class for all block types on the site
/// </summary>
public abstract class SiteBlockData : BlockData 
{
    [CultureSpecific]
    [Display(
        Name = "Title",
        Description = "Title",
        GroupName = SystemTabNames.Content,
        Order = 1
    )]
    public virtual string Title { get; set; }

    [SelectOne(SelectionFactoryType = typeof(PaddingSelectionFactory))]
    [Display(Name = "Padding", GroupName = Global.GroupNames.BlockStyling, Order = 1)]
    public virtual string Padding
    {
        get => this.GetPropertyValue(page => page.Padding) ?? "p-1";
        set => this.SetPropertyValue(page => page.Padding, value);
    }

    [SelectOne(SelectionFactoryType = typeof(MarginSelectionFactory))]
    [Display(Name = "Margin", GroupName = Global.GroupNames.BlockStyling, Order = 2)]
    public virtual string Margin
    {
        get => this.GetPropertyValue(page => page.Margin) ?? "m-0";
        set => this.SetPropertyValue(page => page.Margin, value);
    }

    [Display(Name = "Background color", GroupName = Global.GroupNames.BlockStyling, Order = 3)]
    [SelectOne(SelectionFactoryType = typeof(BgColorSelectionFactory))]
    public virtual string BackgroundColor
    {
        get { return this.GetPropertyValue(page => page.BackgroundColor) ?? "text-black"; }
        set { this.SetPropertyValue(page => page.BackgroundColor, value); }
    }

    [Range(0, 1.0, ErrorMessage = "Opacity only allows value between 0 and 1")]
    [Display(Name = "Block opacity (0 to 1)", GroupName = Global.GroupNames.BlockStyling, Order = 4)]
    public virtual double? BlockOpacity
    {
        get => this.GetPropertyValue(page => page.BlockOpacity) ?? 1;
        set => this.SetPropertyValue(page => page.BlockOpacity, value);
    }

    public override void SetDefaultValues(ContentType contentType)
    {
        Padding = "p-1";
        Margin = "m-0";
        BackgroundColor = "bg-transparent";
        BlockOpacity = 1;
        base.SetDefaultValues(contentType);
    }
}
