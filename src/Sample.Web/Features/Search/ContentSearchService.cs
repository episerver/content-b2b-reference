using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework.Statistics;
using EPiServer.Find.UnifiedSearch;

namespace Sample.Web.Features.Search;


[ServiceConfiguration(ServiceType = typeof(IContentSearchService))]
public class ContentSearchService : IContentSearchService
{
    private readonly IClient _searchClient;
    private const int ExcerptLength = 36;

    public ContentSearchService(IClient searchClient)
    {
        _searchClient = searchClient;
    }

    public ContentSearchResult GetContentSearchResult(
        string query,
        int page,
        int pageSize,
        int fetchCount,
        string language
    )
    {
        ContentSearchResult searchResult;
        var searchQuery = BuildQuery(query, page, pageSize, null);
        var hitSpec = new HitSpecification
        {
            HighlightTitle = true,
            HighlightExcerpt = true,
            ExcerptLength = ExcerptLength
        };

        try
        {
            var results = searchQuery.GetResult(hitSpec);
            searchResult = new ContentSearchResult
            {
                ContentSearchItems = results.Hits
                    .Select(
                        h =>
                            new ContentSearchItem
                            {
                                Title = h.Document.Title,
                                Uri = h.Document.Url,
                                Content = h.Document.Excerpt
                            }
                    )
                    .ToList(),
                ContentSearchResultTotalCount = results.Hits.Count(),
                ContentSearchPageCount = (int)Math.Ceiling(
                    (double)results.Hits.Count() / pageSize
                ),
                ContentSearchResultWithoutFilterCount = results.TotalMatching
            };
            return searchResult;
        }
        catch
        {
            searchResult = new ContentSearchResult
            {
                ContentSearchItems = new List<ContentSearchItem>()
            };
        }

        return searchResult = new ContentSearchResult();
    }

    private ITypeSearch<ISearchContent> BuildQuery(
        string userQuery,
        int page,
        int pageSize,
        string selectedAnalyzer
    )
    {
        var language = _searchClient.Settings.Languages.GetSupportedLanguage(selectedAnalyzer);

        var queryFor =
            language != null
                ? _searchClient.UnifiedSearch(language)
                : _searchClient.UnifiedSearch();

        var querySearch =
            string.IsNullOrEmpty(selectedAnalyzer) || language == null
                ? queryFor.For(userQuery)
                : queryFor.For(userQuery, x => x.Analyzer = language.Analyzer);

        querySearch = querySearch.WithAndAsDefaultOperator();

        return querySearch
            .TermsFacetFor(x => x.SearchSection)
            .FilterFacet("AllSections", x => x.SearchSection.Exists())
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ApplyBestBets()
            .Track();
    }
}
