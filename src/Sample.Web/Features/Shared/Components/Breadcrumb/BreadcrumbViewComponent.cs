namespace Sample.Web.Features.Shared.Components.Breadcrumb;

public class BreadcrumbViewComponent : ViewComponent
{
    private readonly IPageRouteHelper _pageRouteHelper;
    private readonly IContentLoader _contentLoader;
    private readonly ITemplateResolver _templateResolver;
    private readonly IUrlResolver _urlResolver;

    public BreadcrumbViewComponent(IPageRouteHelper pageRouteHelper,
        ITemplateResolver templateResolver,
        IContentLoader contentLoader, IUrlResolver urlResolver)
    {
        _pageRouteHelper = pageRouteHelper;
        _templateResolver = templateResolver;
        _contentLoader = contentLoader;
        _urlResolver = urlResolver;
    }

    public virtual async Task<IViewComponentResult> InvokeAsync()
    {
        return await Task.FromResult(View("Default", CreateViewModel()));
    }

    protected List<SelectListItem> CreateViewModel()
    {
        var links = new List<SelectListItem>();
        var page = _pageRouteHelper.Page;
        if (page == null)
        {
            return links;
        }

       return _contentLoader.GetAncestors(page.ContentLink)
            .Where(x => x.ContentLink != ContentReference.RootPage)
            .Reverse()
            .Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = _urlResolver.GetUrl(x.ContentLink, page.Language.Name),
                Disabled = !_templateResolver.HasTemplate(x, EPiServer.Framework.Web.TemplateTypeCategories.Mvc)
            })
            .ToList();
    }
}

