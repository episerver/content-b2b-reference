namespace Sample.Web.Features.Home;

public class HomeController : PageController<HomePage>
{
    public async Task<IActionResult> Index(HomePage currentContent)
    {
        return await Task.FromResult(View(new HomeViewModel(currentContent)));
    }

}