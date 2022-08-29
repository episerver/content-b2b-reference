using EPiServer.Find.ClientConventions;
using EPiServer.Find.Cms;
using EPiServer.Find.Cms.Conventions;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sample.Models.Media;

namespace Sample.Web.Infrastructure;

[InitializableModule]
[ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
public class SiteInitialization : IConfigurableModule
{
    public void ConfigureContainer(ServiceConfigurationContext context)
    {
        context.Services.AddSingleton<ICookieService, CookieService>();
        context.Services.AddSingleton<ISettingsService, SettingsService>();
        context.Services.TryAddEnumerable(Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Singleton(typeof(IFirstRequestInitializer), typeof(ContentInstaller)));
    }

    public void Initialize(InitializationEngine context)
    {
       
        ContentIndexer.Instance.Conventions.ForInstancesOf<ImageMediaData>().ShouldIndex(x => false);
        ContentIndexer.Instance.Conventions.ForInstancesOf<VideoFile>().ShouldIndex(x => false);
        ContentIndexer.Instance.Conventions.ForInstancesOf<ContentFolder>().ShouldIndex(x => false);
        ContentIndexer.Instance.Conventions.ForInstancesOf<ContentAssetFolder>().ShouldIndex(x => false);
        
    }

    public void Preload(string[] parameters) { }

    public void Uninitialize(InitializationEngine context)
    {
    }
}
