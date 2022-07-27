namespace Sample.Web.Features.General;

public class ContactUsController : PageControllerBase<ContactUsPage>
{
    public async Task<IActionResult> Index(ContactUsPage currentPage)
    {
        var model = new ContactUsViewModel(currentPage);
        return await Task.FromResult(View(model));
    }
}
