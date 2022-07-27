

namespace Sample.Web.Features.Home;

[ApiController]
[Route("[controller]")]
public class LanguageController : ControllerBase
{
    private const string LanguageCookie = "Language";
    private readonly ICookieService _cookieService;
    private readonly IUpdateCurrentLanguage _defaultUpdateCurrentLanguage;
    private readonly UrlResolver _urlResolver;
    private readonly IContentRouteHelper _contentRouteHelper;

    public LanguageController(UrlResolver urlResolver,
        IContentRouteHelper contentRouteHelper,
        IUpdateCurrentLanguage defaultUpdateCurrentLanguage,
        ICookieService cookieService)

    {
        _urlResolver = urlResolver;
        _contentRouteHelper = contentRouteHelper;
        _defaultUpdateCurrentLanguage = defaultUpdateCurrentLanguage;
        _cookieService = cookieService;
    }

    [HttpGet]
    [Route("Set/{language}")]
    public ActionResult Set([FromRoute] string language, ContentReference contentLink)
    {
        var chosenLanguage = language;
        var cookieLanguage = _cookieService.Get(LanguageCookie);

        if (string.IsNullOrEmpty(chosenLanguage))
        {
            if (cookieLanguage != null)
            {
                chosenLanguage = cookieLanguage;
            }
            else
            {
                chosenLanguage = "en";
            }
        }

        var currentContent = _contentRouteHelper.Content;
        _defaultUpdateCurrentLanguage.SetRoutedContent(currentContent, chosenLanguage);

        if (cookieLanguage == null || cookieLanguage != chosenLanguage)
        {
            _cookieService.Set(LanguageCookie, chosenLanguage);
        }
        
        return Redirect(_urlResolver.GetUrl(contentLink, language));
    }
}