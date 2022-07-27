using EPiServer.Shell;

namespace Sample.Models.UIDescriptors;

/// <summary>
/// Describes how the UI should appear for <see cref="HomePage"/> content.
/// </summary>
[UIDescriptorRegistration]
public class StartPageUIDescriptor : UIDescriptor<HomePage>
{
    public StartPageUIDescriptor() : base("epi-iconWebsite") { }
}
