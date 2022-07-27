using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace Sample.Web.Infrastructure;

[InitializableModule]
[ModuleDependency(typeof(InitializationModule))]
public class DisplayRegistryInitialization : IInitializableModule
{
    public void Initialize(InitializationEngine context)
    {
        if (context.HostType == HostType.WebApplication)
        {
            // Register Display Options
            var options = context.Locate.Advanced.GetInstance<DisplayOptions>();

            options.Add("full", "/displayoptions/full", Global.ContentAreaTags.FullWidth, "", "epi-icon__layout--full");
            options.Add("onesixth", "/displayoptions/onesixth", Global.ContentAreaTags.OneSixthWidth, "", "epi-icon__layout--full");
            options.Add("onethird", "/displayoptions/onethird", Global.ContentAreaTags.OneThirdWidth, "", "epi-icon__layout--full");
            options.Add("half", "/displayoptions/half", Global.ContentAreaTags.HalfWidth, "", "epi-icon__layout--full");
            options.Add("twothird", "/displayoptions/twothird", Global.ContentAreaTags.TwoThirdsWidth, "", "epi-icon__layout--full");
            options.Add("fivesixth", "/displayoptions/fivesixth", Global.ContentAreaTags.FiveSixthWidth, "", "epi-icon__layout--full");
        }
    }

    public void Preload(string[] parameters) { }

    public void Uninitialize(InitializationEngine context) { }
}
