namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Search Page",
    GUID = "e389bb12-fb37-4fd1-9bc4-41d27a1b6ec6",
    Description = "Search Page",
    GroupName = Global.GroupNames.CommercePages
)]
[SiteImageUrl]
public class SearchPage : ProductListPage
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
        Ordersfound = "order(s) found";
        ReadMore = "Read More";
        NoResults = "No Results Found";
    }
}
