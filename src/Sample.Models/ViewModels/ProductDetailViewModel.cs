using CommerceApiSDK.Models.Results;

namespace Sample.Models.ViewModels;

public class ProductDetailViewModel : ContentViewModel<Pages.CatalogPage>
{
    public GetProductResult ProductModel { get; set; }
    public CommerceApiSDK.Models.CatalogPage CatalogPage { get; set; }

    public ProductDetailViewModel()
    {

    }
    public ProductDetailViewModel(Pages.CatalogPage currentPage) : base(currentPage) { }

    public string Path { get; set; }
    public string ProductUrl { get; set; }
    public string CommerceApiUrl { get; set; }
    public string MetaDescription { get; set; }
}

public class ProductDetails
{
    public string ProductId { get; set; }
}