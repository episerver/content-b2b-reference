namespace Sample.Models.Pages;

public abstract class BasePage : PageData
{
    [CultureSpecific]
    [Display(Name = "Main body", GroupName = Global.GroupNames.Base, Order = 10)]
    public virtual XhtmlString MainBody { get; set; }

    [Display(Name = "Main Content Area", GroupName = Global.GroupNames.Base, Order =  20)]
    public virtual ContentArea MainContentArea { get; set; }

    [Display(Name = "Body CSS", GroupName = Global.GroupNames.Base, Order = 90)]
    public virtual string BodyCss { get; set; }

    [Display(GroupName = Global.GroupNames.Base, Order = 0)]
    [CultureSpecific]
    public virtual string MetaTitle
    {
        get
        {
            var metaTitle = this.GetPropertyValue(p => p.MetaTitle);

            // Use explicitly set meta title, otherwise fall back to page name
            return !string.IsNullOrWhiteSpace(metaTitle) ? metaTitle : PageName;
        }
        set { this.SetPropertyValue(p => p.MetaTitle, value); }
    }

    [Display(GroupName = Global.GroupNames.Base, Order = 5)]
    [CultureSpecific]
    [UIHint(UIHint.Textarea)]
    public virtual string MetaDescription { get; set; }

    [Display(GroupName = Global.GroupNames.Base, Order = 400)]
    [CultureSpecific]
    public virtual bool DisableIndexing { get; set; }

    [Display(GroupName = Global.GroupNames.Base, Order = 30)]
    [UIHint(UIHint.Image)]
    public virtual ContentReference PageImage { get; set; }

    [Display(GroupName = Global.GroupNames.Base, Order = 40)]
    [CultureSpecific]
    [UIHint(UIHint.Textarea)]
    public virtual string TeaserText
    {
        get
        {
            var teaserText = this.GetPropertyValue(p => p.TeaserText);

            // Use explicitly set teaser text, otherwise fall back to description
            return !string.IsNullOrWhiteSpace(teaserText) ? teaserText : MetaDescription;
        }
        set { this.SetPropertyValue(p => p.TeaserText, value); }
    }
    [CultureSpecific]
    [Display(Name = "Highlight in page list", GroupName = Global.GroupNames.Base, Order = 70)]
    public virtual bool Highlight { get; set; }

    [CultureSpecific]
    [UIHint(UIHint.Video)]
    [Display(Name = "Video", GroupName = Global.GroupNames.Base, Order = 50)]
    public virtual ContentReference TeaserVideo { get; set; }

    [Display(Name = "Login Required", GroupName = Global.GroupNames.Base, Order = 80)]
    [CultureSpecific]
    public virtual bool LoginRequired
    {
        get
        {
            var showInNavigation = this.GetPropertyValue(p => p.LoginRequired);
            return (showInNavigation);
        }
        set { this.SetPropertyValue(p => p.LoginRequired, value); }
    }
}
