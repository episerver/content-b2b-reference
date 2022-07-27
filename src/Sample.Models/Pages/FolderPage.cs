namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Folder Page",
    GUID = "69EEB000-E24A-4362-8BA0-64EADCD5C8A4",
    Description = "A page which allows you to structure pages.",
    GroupName = Global.GroupNames.Utility
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.All, Exclude = new[] { typeof(HomePage) })]
public class FolderPage : PageData { }
