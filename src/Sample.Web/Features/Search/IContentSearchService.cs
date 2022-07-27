namespace Sample.Web.Features.Search;

public interface IContentSearchService
{
    ContentSearchResult GetContentSearchResult(
        string query,
        int page,
        int pageSize,
        int fetchCount,
        string languageBranch
    );
}