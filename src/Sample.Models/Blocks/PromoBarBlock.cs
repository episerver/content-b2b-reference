namespace Sample.Models.Blocks;

[ContentType(
    DisplayName = "PromoBar Block",
    Description = "This block can be used as CTA for promotion in any page.",
    GUID = "233969DB-0A6C-4ABE-B21C-E69EBAF457C9",
    GroupName = Global.GroupNames.ContentBlocks
)]
[SiteImageUrl]
public class PromoBarBlock : SiteBlockData
{
    [CultureSpecific]
    [Display(Name = "CTA Text", GroupName = SystemTabNames.Content, Order = 2)]
    public virtual string CtaText { get; set; }

    [CultureSpecific]
    [Display(Name = "CTA Link", GroupName = SystemTabNames.Content, Order = 3)]
    public virtual Url CtaLink { get; set; }

    [Display(Name = "CTA Image", GroupName = SystemTabNames.Content, Order = 4)]
    [UIHint(UIHint.Image)]
    public virtual ContentReference CTAImage { get; set; }
}
