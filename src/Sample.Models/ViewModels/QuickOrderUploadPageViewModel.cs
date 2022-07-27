namespace Sample.Models.ViewModels;

public class QuickOrderUploadPageViewModel : ContentViewModel<QuickOrderUploadPage>
{
    public QuickOrderUploadPageViewModel()
    {

    }

    public QuickOrderUploadPageViewModel(QuickOrderUploadPage currentPage) : base(currentPage)
    {
    }

    public string ErrorMessage { get; set; }
    public List<Product> ProductCollections { get; set; }
}