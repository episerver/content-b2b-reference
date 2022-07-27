using EPiServer.Shell;

namespace Sample.Models.UIDescriptors;

[UIDescriptorRegistration]
public class CatalogPageUIDescriptor : UIDescriptor<Models.Pages.CatalogPage>
{
    public CatalogPageUIDescriptor() : base("epi-iconCatalog") { }
}
