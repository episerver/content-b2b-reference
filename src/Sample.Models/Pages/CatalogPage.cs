using EPiServer.Shell.ObjectEditing;

namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Catalog Page",
    GroupName = Global.GroupNames.CommercePages,
    GUID = "1060A9F7-78DF-40E8-B8D2-E71AA3338A84",
    Description = "Catalog page for product listing"
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class CatalogPage : ProductListPage
{
    [SelectOne(SelectionFactoryType = typeof(PreviewTypeSelectionFactory))]
    public virtual string PreviewType { get; set; }
}

public class PreviewTypeSelectionFactory : ISelectionFactory
{
    public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
    {
        return new List<SelectItem>
        {
            new SelectItem { Text = "Listing", Value = "Listing" },
            new SelectItem { Text = "Detail", Value = "Detail" }
        };
    }
}
