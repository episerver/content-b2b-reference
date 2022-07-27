namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Search Page",
    GUID = "e389bb12-fb37-4fd1-9bc4-41d27a1b6ec6",
    Description = "Search Page",
    GroupName = Global.GroupNames.CommercePages
)]
[SiteImageUrl]
[AvailableContentTypes(
    EPiServer.DataAbstraction.Availability.Specific,
    Include = new[] { typeof(ContentSearchListPage) }
)]
public class SearchPage : ProductListPage { }
