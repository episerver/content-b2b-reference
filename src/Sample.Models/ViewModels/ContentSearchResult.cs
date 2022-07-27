namespace Sample.Models.ViewModels;

public class ContentSearchResult
{
    public virtual int ContentSearchResultTotalCount { get; set; }
    public virtual int ContentSearchPageCount { get; set; }
    public virtual List<ContentSearchItem> ContentSearchItems { get; set; }
    public virtual int ContentSearchShowLineCount { get; set; }
    public virtual int ContentSearchResultWithoutFilterCount { get; set; }
}
