using AutoMapper;
using CommerceApiSDK.Extensions;
using EPiServer.Authorization;
using EPiServer.Cms.Shell;
using EPiServer.Cms.Shell.UI;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Core.Routing;
using EPiServer.Core.Routing.Pipeline;
using EPiServer.DependencyInjection;
using EPiServer.Find.Cms;
using EPiServer.Framework.Web.Resources;
using EPiServer.Framework.Web.Resources.Internal;
using Geta.NotFoundHandler.Infrastructure.Configuration;
using Geta.NotFoundHandler.Infrastructure.Initialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sample.Services;
using Sample.Web.Infrastructure.Routing;

namespace Sample.Web;

public class Startup
{
    private readonly IWebHostEnvironment _webHostingEnvironment;
    private readonly IConfiguration _configuration;

    public Startup(IWebHostEnvironment webHostingEnvironment, IConfiguration configuration)
    {
        _webHostingEnvironment = webHostingEnvironment;
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        if (_webHostingEnvironment.IsDevelopment())
        {
            //Add development configuration
        }

        services.Configure<CommerceApiSettings>(_configuration.GetSection("CommerceApi"));
        services.AddMvc(o => o.Conventions.Add(new FeatureConvention()))
             .AddRazorOptions(ro => ro.ViewLocationExpanders.Add(new FeatureViewLocationExpander()));

        services
            .AddCms()
            .AddCmsAspNetIdentity<ApplicationUser>()
            .AddAdminUserRegistration(options =>
            {
                options.Behavior = RegisterAdminUserBehaviors.Enabled;
                options.Roles.Add(Roles.Administrators);
                options.Roles.Add(Roles.WebAdmins);
            });
        services.AddFind();
        services.AddEmbeddedLocalization<Startup>();
        if (!_webHostingEnvironment.IsDevelopment())
        {
            services.AddAzureBlobProvider();
            services.AddAzureEventProvider();
            services.ConfigureDatabase();
            services.AddDataProtectionToBlobStorage(_configuration);
            services.AddCloudPlatformForwardedFor();
       }

        services.Configure<FindCmsOptions>(x =>
        {
            x.DisableEventedIndexing = true;
            x.DisableScheduledPageQueue = true;
        });
        services.ConfigureApplicationCookie(
            options =>
            {
                options.LoginPath = "/util/Login";
            }
        );

        //services.AddTransient<IContentRenderer, ErrorHandlingContentRenderer>();
        services.AddTransient<ContentAreaRenderer, SampleContentAreaRenderer>();
        // Auto Mapper Configurations
        var mappingConfig = new MapperConfiguration(
            mc =>
            {
                mc.AddProfile(new MappingProfile());
            }
        );
        var mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);

        //Registration of Partial Routes
        services.AddSampleServices();
        services.AddSingleton<ISettingsHelper, SettingsHelper>();
        //services.AddSingleton<IPartialRouter, ProductDetailPartialRouting>();
        services.AddSingleton<IPartialRouter, CatalogPartialRouting>();
        //services.AddSingleton<IPartialRouter, SearchPagePartialRouting>();
        services.AddSingleton<IPartialRouter, BrandDetailsPartialRouting>();
        services.AddSingleton<IPartialRouter, BrandsPartialRouting>();
        //services.AddSingleton<IClientResourceService, ClientResourceService>();
       

        services.AddRazorPages();
        
        services.AddCommerceSdk(
            _configuration.GetSection("CommerceApi:BaseUrl").Value,
            _configuration.GetSection("CommerceApi:ClientId").Value,
            _configuration.GetSection("CommerceApi:ClientSecret").Value,
            Convert.ToBoolean(_configuration.GetSection("CommerceApi:EnableCaching").Value)
        );
        
        services.AddDistributedMemoryCache();
        services.AddSession(
            options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            }
        );

        var connectionString =
            _configuration.GetSection("ConnectionStrings:EPiServerDB").Value;
        //Epiceler custom starting point for routes. Comment this code if not necessary.
        services.AddNotFoundHandler(
            o =>
            {
                o.UseSqlServer(connectionString);
                o.BufferSize = 30;
                o.ThreshHold = 5;
                o.HandlerMode = FileNotFoundMode.On;
                o.IgnoredResourceExtensions = new[]
                {
                    "jpg",
                    "gif",
                    "png",
                    "css",
                    "js",
                    "ico",
                    "swf",
                    "woff"
                };
            }
        );

        services.Configure<FormOptions>(x =>
        {
            x.MultipartBodyLengthLimit = 209715200;
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseDeveloperExceptionPage();
        app.UseNotFoundHandler();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseSession();
        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapControllerRoute(name: "Default", pattern: "{controller}/{action}/{id?}");
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapContent();
            }
        );
    }
}
