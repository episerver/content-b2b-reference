namespace Sample.Models.ViewModels;

public class QuickOrderPageViewModel : ContentViewModel<QuickOrderPage>
{
    public QuickOrderPageViewModel()
    {

    }

    public QuickOrderPageViewModel(QuickOrderPage currentPage) : base(currentPage)
    {
    }

    public string ErrorMessage { get; set; }
    public List<Product> ProductCollections { get; set; }
    public string EmptyErrorMessage { get; set; }
    public string InvalidQtyErrorMessage { get; set; }
    public string EmptyProductErrorMessage { get; set; }
}

public class ProductDataModel
{
    public string ProductId { get; set; }
    public string Qty { get; set; }
    public string Uom { get; set; }
}

public class ProductDataViewModel
{
    public List<ProductViewModel> ProductList { get; set; }
}

public class AddToQuickOrder
{
    public ProductInventory ProductInventory { get; set; }

    public Product Product { get; set; }
}