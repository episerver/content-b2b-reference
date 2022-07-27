using EPiServer.Shell;

namespace Sample.Models.UIDescriptors;

[UIDescriptorRegistration]
public class QuickOrderPageUIDescriptor : UIDescriptor<QuickOrderPage>
{
    public QuickOrderPageUIDescriptor() : base("epi-iconPricing") { }
}
