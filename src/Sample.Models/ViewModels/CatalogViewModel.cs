namespace Sample.Models.ViewModels;

public class CatalogViewModel : ContentViewModel<Models.Pages.CatalogPage>
{
    public CatalogViewModel()
    {

    }
    public CatalogViewModel(Models.Pages.CatalogPage currentPage) : base(currentPage) { }

    public string Path { get; set; }
    public ProductDetailViewModel ProductDetailViewModel { get; set; }
    public ProductListViewModel ProductListViewModel { get; set; }
}