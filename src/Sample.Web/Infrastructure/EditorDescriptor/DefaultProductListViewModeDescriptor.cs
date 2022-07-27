using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace Sample.Web.Infrastructure.EditorDescriptor;

[EditorDescriptorRegistration(TargetType = typeof(string), UIHint = "DefaultProductListView")]
public class DefaultProductListViewModeDescriptor
    : EPiServer.Shell.ObjectEditing.EditorDescriptors.EditorDescriptor
{
    public override void ModifyMetadata(
        ExtendedMetadata metadata,
        IEnumerable<Attribute> attributes
    )
    {
        SelectionFactoryType = typeof(ProductListViewModeSelectionFactory);
        ClientEditingClass = "epi-cms/contentediting/editors/SelectionEditor";
        base.ModifyMetadata(metadata, attributes);
    }
}

public class ProductListViewModeSelectionFactory : ISelectionFactory
{
    public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
    {
        var viewModes = new List<SelectItem>();
        viewModes.Add(new SelectItem() { Value = "vm-list", Text = "List" });
        viewModes.Add(new SelectItem() { Value = "vm-table-small", Text = "Small Table" });
        viewModes.Add(new SelectItem() { Value = "vm-table", Text = "Large Table" });
        return viewModes;
    }
}
