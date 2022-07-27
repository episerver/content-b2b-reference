namespace Sample.Web.Features.General;

[Route("error")]
public class PageNotFoundPageController : PageControllerBase<PageNotFoundPage>
{
    [HttpGet]
    [Route("404")]
    public async Task<IActionResult> Index(PageNotFoundPage currentPage)
    {
        var model = new PageNotFoundPageViewModel(currentPage);
        return await Task.FromResult(View(model));
    }
}
