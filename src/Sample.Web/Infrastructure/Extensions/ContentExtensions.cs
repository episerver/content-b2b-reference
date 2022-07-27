using EPiServer.Filters;
using EPiServer.Framework.Web;

namespace Sample.Web.Infrastructure.Extensions;

public static class ContentExtensions
{
    private static readonly Lazy<IContentLoader> _contentLoader = new Lazy<IContentLoader>(() => ServiceLocator.Current.GetInstance<IContentLoader>());

    public static IEnumerable<PageData> GetSiblings(this PageData pageData) => GetSiblings(pageData, _contentLoader.Value);

    public static IEnumerable<PageData> GetSiblings(this PageData pageData, IContentLoader contentLoader)
    {
        var filter = new FilterContentForVisitor();
        return contentLoader.GetChildren<PageData>(pageData.ParentLink).Where(page => !filter.ShouldFilter(page));
    }

    public static IEnumerable<T> FilterForDisplay<T>(this IEnumerable<T> contents, bool requirePageTemplate = false,
        bool requireVisibleInMenu = false)
        where T : IContent
    {
        var accessFilter = new FilterAccess();
        var publishedFilter = new FilterPublished();
        contents = contents.Where(x => !publishedFilter.ShouldFilter(x) && !accessFilter.ShouldFilter(x));
        if (requirePageTemplate)
        {
            var templateFilter = ServiceLocator.Current.GetInstance<FilterTemplate>();
            templateFilter.TemplateTypeCategories = TemplateTypeCategories.Request;
            contents = contents.Where(x => !templateFilter.ShouldFilter(x));
        }

        if (requireVisibleInMenu)
        {
            contents = contents.Where(x => VisibleInMenu(x));
        }

        return contents;
    }

    private static bool VisibleInMenu(IContent content)
    {
        var page = content as PageData;
        return page == null || page.VisibleInMenu;
    }

    public static string GetUrl<T>(this T content, bool isAbsolute = false) where T : IContent, ILocale, IRoutable
    {
        return content.GetUri(isAbsolute).ToString();
    }

    public static Uri GetUri<T>(this T content, bool isAbsolute = false) where T : IContent, ILocale, IRoutable
    {
        return content.ContentLink.GetUri(content.Language.Name, isAbsolute);
    }

    public static List<T> GetFilteredItemsOfType<T>(this ContentArea contentArea)
       where T : IContentData
    {
        var items = new List<T>();

        if (contentArea.IsNullOrEmpty())
        {
            return items;
        }

        foreach (var contentAreaItem in contentArea.FilteredItems)
        {
            IContentData item;
            if (!_contentLoader.Value.TryGet(contentAreaItem.ContentLink, out item))
            {
                continue;
            }
            if (item is T)
            {
                items.Add((T)item);
            }
        }

        return items;
    }

    public static bool IsNullOrEmpty(this ContentArea contentArea)
    {
        return contentArea == null || !contentArea.FilteredItems.Any();
    }
}