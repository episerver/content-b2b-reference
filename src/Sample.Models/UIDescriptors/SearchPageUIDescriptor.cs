using EPiServer.Shell;

namespace Sample.Models.UIDescriptors;

/// <summary>
/// Describes how the UI should appear for <see cref="SearchPage"/> content.
/// </summary>
[UIDescriptorRegistration]
public class SearchPageUIDescriptor : UIDescriptor<SearchPage>
{
    public SearchPageUIDescriptor() : base("epi-iconSearch") { }
}
