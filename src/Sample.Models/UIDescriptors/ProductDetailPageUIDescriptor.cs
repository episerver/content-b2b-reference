using EPiServer.Shell;

namespace Sample.Models.UIDescriptors;

[UIDescriptorRegistration]
public class ProductDetailPageUIDescriptor : UIDescriptor<ProductDetailPage>
{
    public ProductDetailPageUIDescriptor() : base("epi-iconProduct") { }
}
