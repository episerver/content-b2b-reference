namespace Sample.Models.ViewModels;

public class SearchPageViewModel : ContentViewModel<SearchPage>
{
    public SearchPageViewModel()
    {

    }

    public SearchPageViewModel(SearchPage currentPage) : base(currentPage) { }

    public string Path { get; set; }
    public string GetSearchPageLink { get; set; }
    public ProductListViewModel ProductListViewModel { get; set; }
}