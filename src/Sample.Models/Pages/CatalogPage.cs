namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Catalog Page",
    GroupName = Global.GroupNames.CommercePages,
    GUID = "1060A9F7-78DF-40E8-B8D2-E71AA3338A84",
    Description = "Catalog page for product listing"
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class CatalogPage : ProductListPage { }
