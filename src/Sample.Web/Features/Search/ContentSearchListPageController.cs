namespace Sample.Web.Features.Search;

public class ContentSearchListPageController : PageControllerBase<ContentSearchListPage>
{
    private IContentSearchService _contentSearchService;

    public ContentSearchListPageController(IContentSearchService contentSearchService)
    {
        _contentSearchService = contentSearchService;
    }

    [HttpGet]
    public virtual async Task<IActionResult> Index(ContentSearchListPage currentPage)
    {
        const int initialPageIndex = 1;
        const int defaultMaxContentResultsFetchCount = 40;
        const int defaultContentSearchShowLineCount = 2;

        var contentSearchListPageViewModel = new ContentSearchListPageViewModel(currentPage);
        var query = Request.Query["search"].ToString();
        var result = !string.IsNullOrEmpty(query)
            ? _contentSearchService.GetContentSearchResult(
                  query.Trim(),
                  initialPageIndex,
                  defaultMaxContentResultsFetchCount,
                  defaultMaxContentResultsFetchCount,
                  LanguageSelector.AutoDetect().Language.TwoLetterISOLanguageName
              )
            : new ContentSearchResult();

        result.ContentSearchShowLineCount = defaultContentSearchShowLineCount;
        contentSearchListPageViewModel.Result = result;

        return await Task.FromResult(View(contentSearchListPageViewModel));
    }
}
