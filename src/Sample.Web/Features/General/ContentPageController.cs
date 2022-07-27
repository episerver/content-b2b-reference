namespace Sample.Web.Features.General;

public class ContentPageController : PageController<ContentPage>
{
    [HttpGet]
    public async Task<IActionResult> Index(ContentPage currentContent)
    {
        var model = new ContentPageViewModel(currentContent);
        return await Task.FromResult(View(model));
    }
}
