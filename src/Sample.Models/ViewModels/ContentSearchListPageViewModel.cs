namespace Sample.Models.ViewModels;

public class ContentSearchListPageViewModel : ContentViewModel<ContentSearchListPage>
{
    public ContentSearchListPageViewModel()
    {

    }

    public ContentSearchListPageViewModel(ContentSearchListPage currentPage) : base(currentPage)
    { }

    public ContentSearchResult Result { get; set; }
}