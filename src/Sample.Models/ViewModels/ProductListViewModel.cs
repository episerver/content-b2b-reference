using CommerceApiSDK.Models.Results;
using Category = CommerceApiSDK.Models.Category;

namespace Sample.Models.ViewModels;

public class ProductListViewModel : ContentViewModel<ProductListPage>
{
    public string ProductUrlBase { get; set; }
    public string CommerceApiUrl { get; set; }
    public Category Category { get; set; }
    public CommerceApiSDK.Models.CatalogPage CatalogPage { get; set; }
    public GetProductCollectionResult ProductCollection { get; set; }
    public ICollection<string> ViewModeSelections { get; set; }
    public string DataViewStyle { get; set; }
    public bool CanShowAvailability { get; set; }
    public int MaxCompareProducts { get; set; }
    public FilterOptionViewModel FilterOptionViewModel { get; set; }
    public string MetaDescription { get; set; }

    public ProductListViewModel()
    {

    }
    public ProductListViewModel(ProductListPage currentPage) : base(currentPage) { }
}

public class PaginationExtendedModel
{
    public string PerPage { get; set; }
    public Pagination Pagination { get; set; }
}