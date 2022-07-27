namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Content Search List Page",
    GUID = "264ad391-f12d-4447-b354-8874796ada95",
    Description = "Content Search List Page",
    GroupName = Global.GroupNames.ContentPages
)]
[SiteImageUrl]
public class ContentSearchListPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "Read More", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string ReadMore { get; set; }

    [CultureSpecific]
    [Display(Name = "Orders Found", GroupName = Global.GroupNames.Labels, Order = 3)]
    public virtual string Ordersfound { get; set; }

    [CultureSpecific]
    [Display(Name = "No Results", GroupName = Global.GroupNames.Labels, Order = 4)]
    public virtual string NoResults { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "Content Search List";
        Ordersfound = "order(s) found";
        ReadMore = "Read More";
        NoResults = "No Results Found";
    }
}
