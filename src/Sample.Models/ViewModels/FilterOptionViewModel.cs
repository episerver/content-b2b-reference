namespace Sample.Models.ViewModels;

[ModelBinder(BinderType = typeof(FilterOptionViewModelBinder))]
public class FilterOptionViewModel
{
    public string SelectedFacet { get; set; }
    public string Sort { get; set; }
    public int Page { get; set; }
    public string Q { get; set; }
    public int TotalCount { get; set; }
    public int PageSize { get; set; } = 8;
    public int DefaultPageSize { get; set; }
    public int TotalItemCount { get; set; }
    public int NumberOfPages { get; set; }
    public IList<int> PageSizeOptions { get; set; }
    public IList<SortOption> SortOptions { get; set; }
    public string SortType { get; set; }
    public string NextPageUri { get; set; }
    public string PrevPageUri { get; set; }
    public string ViewMode { get; set; }

    public List<int> Pages
    {
        get
        {
            if (TotalCount == 0)
            {
                return new List<int>();
            }

            var totalPages = (TotalCount + PageSize - 1) / PageSize;
            var pages = new List<int>();
            var startPage = Page > 2 ? Page - 2 : 1;

            for (var page = startPage; page < Math.Min(totalPages >= 5 ? startPage + 5 : startPage + totalPages, totalPages + 1); page++)
            {
                pages.Add(page);
            }

            return pages;
        }
    }
}

public class SortOption
{
    public string DisplayName { get; set; }
    public string SortType { get; set; }
}