using EPiServer.Shell;

namespace Sample.Models.UIDescriptors;

[UIDescriptorRegistration]
public class PageNotFoundPageUIDescriptor : UIDescriptor<PageNotFoundPage>
{
    public PageNotFoundPageUIDescriptor() : base("epi-iconError") { }
}
