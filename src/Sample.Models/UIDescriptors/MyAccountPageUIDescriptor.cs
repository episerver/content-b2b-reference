using EPiServer.Shell;

namespace Sample.Models.UIDescriptors;

[UIDescriptorRegistration]
public class MyAccountPageUIDescriptor : UIDescriptor<MyAccountPage>
{
    public MyAccountPageUIDescriptor() : base("epi-iconUser") { }
}
