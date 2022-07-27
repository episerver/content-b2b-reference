using CommerceApiSDK.Models.Results;

namespace Sample.Models.ViewModels;

public class BrandsPageViewModel : ContentViewModel<BrandsPage>
{
    public BrandsPageViewModel()
    {

    }

    public BrandsPageViewModel(BrandsPage page) : base(page)
    {
        
    }

    public GetBrandsResult Brands { get; set; }
    public IEnumerable<IGrouping<char, Brand>> BrandsSorting { get; set; }
}