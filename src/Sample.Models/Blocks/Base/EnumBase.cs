using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace Sample.Models.Blocks.Base;

public class EnumSelectionFactory<TEnum> : ISelectionFactory
{
    public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
    {
        foreach (var value in Enum.GetValues(typeof(TEnum)))
        {
            yield return new SelectItem { Text = GetValueName(value), Value = value };
        }
    }

    private string GetValueName(object value)
    {
        var staticName = Enum.GetName(typeof(TEnum), value);

        var localizationPath = $"/property/enum/{typeof(TEnum).Name.ToLowerInvariant()}/{staticName.ToLowerInvariant()}";

        string localizedName;
        if (LocalizationService.Current.TryGetString(localizationPath, out localizedName))
        {
            return localizedName;
        }

        return staticName;
    }
}

public class EnumEditorDescriptor<TEnum> : EditorDescriptor
{
    public override void ModifyMetadata(
        ExtendedMetadata metadata,
        IEnumerable<Attribute> attributes
    )
    {
        SelectionFactoryType = typeof(EnumSelectionFactory<TEnum>);

        ClientEditingClass = "epi-cms/contentediting/editors/SelectionEditor";

        base.ModifyMetadata(metadata, attributes);
    }
}
