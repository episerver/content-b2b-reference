using EPiServer.Shell;

namespace Sample.Models.UIDescriptors;

[UIDescriptorRegistration]
public class ProductComparisonPageUIDescriptor : UIDescriptor<ProductComparisonPage>
{
    public ProductComparisonPageUIDescriptor() : base("epi-iconBoxes") { }
}
