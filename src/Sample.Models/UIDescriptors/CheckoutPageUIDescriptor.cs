using EPiServer.Shell;

namespace Sample.Models.UIDescriptors;

[UIDescriptorRegistration]
public class CheckoutPageUIDescriptor : UIDescriptor<CheckoutPage>
{
    public CheckoutPageUIDescriptor() : base("epi-iconPricing") { }
}
