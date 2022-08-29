using EPiServer.Framework.Web;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Sample.Web.Features.General;

[TemplateDescriptor(
    Inherited = true,
    TemplateTypeCategory = TemplateTypeCategories.MvcController,
    Tags = new[] { RenderingTags.Preview, RenderingTags.Edit },
    AvailableWithoutTag = false
)]
public class PreviewPageController : ActionControllerBase, IRenderTemplate<BlockData>
{
    private readonly IContentLoader _contentLoader;

    public PreviewPageController(IContentLoader contentLoader)
    {
        _contentLoader = contentLoader;
    }

    public async Task<IActionResult> RenderResult(IContent currentContent)
    {
        var startPage = _contentLoader.Get<HomePage>(SiteDefinition.Current.StartPage);
        var viewmodel = new PreviewPageViewModel(startPage, currentContent);
        return await Task.FromResult(new ViewResult
        {
            ViewName = "~/Features/General/PreviewPage.Index.cshtml",
            ViewData = new ViewDataDictionary<PreviewPageViewModel>(ViewData, viewmodel)
        });
    }
}
