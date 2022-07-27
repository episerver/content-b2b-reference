using EPiServer.Shell;

namespace Sample.Models.UIDescriptors;

[UIDescriptorRegistration]
public class CartPageUIDescriptor : UIDescriptor<CartPage>
{
    public CartPageUIDescriptor() : base("epi-iconCart") { }
}
