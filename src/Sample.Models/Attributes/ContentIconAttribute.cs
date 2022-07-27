namespace Sample.Models.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class ContentIconAttribute : Attribute
{
    public ContentIconAttribute(string iconClass)
    {
        IconClass = iconClass;
    }

    /// <summary>
    /// Css class to apply to the icon
    /// </summary>
    public string IconClass { get; set; }
}
