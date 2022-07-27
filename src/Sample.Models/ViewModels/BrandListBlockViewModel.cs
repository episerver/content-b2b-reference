using CommerceApiSDK.Models.Results;

namespace Sample.Models.ViewModels;

public class BrandListBlockViewModel
{
    public BrandListBlock BrandListBlock { get; set; }
    public GetBrandsResult Brands { get; set; }

    public BrandListBlockViewModel(BrandListBlock brandListBlock, GetBrandsResult brands)
    {
        BrandListBlock = brandListBlock;
        Brands = brands;
    }
}