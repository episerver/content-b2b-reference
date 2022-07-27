namespace Sample.Models.ViewModels;

public class SavedOrdersPageViewModel : ContentViewModel<SavedOrdersPage>
{
    public SavedOrdersPageViewModel()
    {
            
    }

    public SavedOrdersPageViewModel(SavedOrdersPage currentPage) : base(currentPage)
    {
    }

    public SavedOrdersViewModel SavedOrdersViewModel { get; set; }
    public string ErrorMessage { get; set; }
    public string OrderDetailsPageLink { get; set; }
}