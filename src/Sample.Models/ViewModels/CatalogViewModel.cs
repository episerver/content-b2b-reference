namespace Sample.Models.ViewModels;

public class CatalogViewModel : ContentViewModel<Pages.CatalogPage>
{
    public CatalogViewModel()
    {

    }
    public CatalogViewModel(Pages.CatalogPage currentPage) : base(currentPage) { }

    public string Path { get; set; }
    public string PreviewType { get; set; }
    public ProductDetailViewModel ProductDetailViewModel { get; set; }
    public ProductListViewModel ProductListViewModel { get; set; }
}