namespace Sample.Models.ViewModels;

public class RecentlyViewedItemViewModel
{
    public string Id { get; set; }
    public string ShortDescription { get; set; }
    public string ERPNumber { get; set; }
    public string ManufacturerItem { get; set; }
    public decimal ActualPrice { get; set; }
    public string ActualPriceDisplay { get; set; }
    public string MediumImagePath { get; set; }
    public string ProductDetailUrl { get; set; }
}