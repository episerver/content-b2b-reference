namespace Sample.Models.ViewModels;

public class SavedOrderDetailPageViewModel : ContentViewModel<SavedOrderDetailsPage>
{
    public SavedOrderDetailPageViewModel()
    {

    }

    public SavedOrderDetailPageViewModel(SavedOrderDetailsPage currentPage) : base(currentPage)
    {
    }

    public string ErrorMessage { get; set; }
    public SavedOrderDetailViewModel SavedOrderDetailViewModel { get; set; }
}