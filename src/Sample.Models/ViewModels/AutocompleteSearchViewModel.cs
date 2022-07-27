namespace Sample.Models.ViewModels;

public class AutocompleteSearchViewModel
{
    public List<AutocompleteSearchJsonViewModel> AutoCompleteSearchListModel { get; set; }
    public bool ShouldShowContentSearchShowAllLink { get; set; }
    public bool ShouldShowCategorySearchShowAllLink { get; set; }
    public bool ShouldShowProductSearchShowAllLink { get; set; }
    public bool ShouldShowBrandSearchShowAllLink { get; set; }
    public Settings.SearchSettings SearchBlock { get; set; }
}