using EPiServer.Filters;
using EPiServer.Framework.Cache;

namespace Sample.Web.Features.Shared.Components.Menu;

public class MenuViewComponent : ViewComponent
{
    private const string MenuCacheKey = "MenuItemsCacheKey";
    private readonly IContentLoader _contentLoader;
    private readonly IContextModeResolver _contextModeResolver;
    private readonly IContentCacheKeyCreator _contentCacheKeyCreator;
    private readonly IUrlResolver _urlResolver;
    private readonly ISettingsHelper _settingsService;

    public MenuViewComponent(IContentLoader contentLoader,
        IContextModeResolver contextModeResolver,
        IContentCacheKeyCreator contentCacheKeyCreator,
        IUrlResolver urlResolver,
        ISettingsHelper settingsService)
    {
        _contentLoader = contentLoader;
        _contextModeResolver = contextModeResolver;
        _contentCacheKeyCreator = contentCacheKeyCreator;
        _urlResolver = urlResolver;
        _settingsService = settingsService;
    }

    public virtual async Task<IViewComponentResult> InvokeAsync()
    {
        return await Task.FromResult(View("Default", CreateViewModel()));
    }

    protected List<MenuItemViewModel> CreateViewModel()
    {
       
        var header = _settingsService.GetSettings<HeaderSettings>();
        if (header == null)
        {
            return new List<MenuItemViewModel>();
        }
        var menuItems = new List<MenuItemViewModel>();
        var homeLanguage = LanguageSelector.AutoDetect().LanguageBranch;
        var filter = new FilterContentForVisitor();

        return header.MainMenu?.FilteredItems.Where(x =>
        {
            var _menuItem = _contentLoader.Get<IContent>(x.ContentLink);
            MenuItemBlock _menuItemBlock;
            if (_menuItem is MenuItemBlock)
            {
                _menuItemBlock = _menuItem as MenuItemBlock;
                if (_menuItemBlock.Link == null)
                {
                    return true;
                }
                var linkedItem = UrlResolver.Current.Route(new UrlBuilder(_menuItemBlock.Link));
                if (filter.ShouldFilter(linkedItem))
                {
                    return false;
                }
            }
            return true;
        }).Select(x =>
        {
            var itemCached = CacheManager.Get(x.ContentLink.ID + homeLanguage + ":" + MenuCacheKey) as MenuItemViewModel;
            if (itemCached != null && !_contextModeResolver.CurrentMode.EditOrPreview())
            {
                return itemCached;
            }
            else
            {
                var content = _contentLoader.Get<IContent>(x.ContentLink);
                MenuItemBlock _;
                MenuItemViewModel menuItem;
                if (content is MenuItemBlock)
                {
                    _ = content as MenuItemBlock;
                    menuItem = new MenuItemViewModel
                    {
                        Name = _.Name,
                        ButtonText = _.ButtonText,
                        TeaserText = _.TeaserText,
                        Uri = _.Link == null ? string.Empty : _urlResolver.GetUrl(new UrlBuilder(_.Link.ToString()), new UrlResolverArguments() { ContextMode = ContextMode.Default }),
                        ImageUrl = !ContentReference.IsNullOrEmpty(_.MenuImage) ? _urlResolver.GetUrl(_.MenuImage) : "",
                        ButtonLink = _.ButtonLink?.Host + _.ButtonLink?.PathAndQuery,
                        ChildLinks = _.ChildItems?.ToList() ?? new List<GroupLinkCollection>()
                    };
                }
                else
                {
                    menuItem = new MenuItemViewModel
                    {
                        Name = content.Name,
                        Uri = _urlResolver.GetUrl(content.ContentLink),
                        ChildLinks = new List<GroupLinkCollection>()
                    };
                }

                if (!_contextModeResolver.CurrentMode.EditOrPreview())
                {
                    var keyDependency = new List<string>
                    {
                        _contentCacheKeyCreator.CreateCommonCacheKey(header.ContentLink), // If The HomePage updates menu (remove MenuItems)
                        _contentCacheKeyCreator.CreateCommonCacheKey(x.ContentLink)
                    };
                    var eviction = new CacheEvictionPolicy(TimeSpan.FromDays(1), CacheTimeoutType.Sliding, keyDependency);
                    CacheManager.Insert(x.ContentLink.ID + homeLanguage + ":" + MenuCacheKey, menuItem, eviction);
                }

                return menuItem;
            }
        }).ToList();
    }
}
