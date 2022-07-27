namespace Sample.Models.ViewModels;

public class ProductComparisonViewModel : ContentViewModel<ProductComparisonPage>
{
    public ProductComparisonViewModel()
    {

    }
    public ProductComparisonViewModel(ProductComparisonPage currentPage) : base(currentPage) { }

    public ICollection<ExtendedProductModel> product { get; set; }
    public List<AttributeTypes> AttributeList { get; set; }
    public string ReturnUrl { get; set; }
}

public class AttributeTypes
{
    public string AttributeId { get; set; }
    public string AttributeLabel { get; set; }
}