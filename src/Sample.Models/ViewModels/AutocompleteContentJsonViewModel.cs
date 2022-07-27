namespace Sample.Models.ViewModels;

public class AutocompleteContentJsonViewModel
{
    public string productId { get; set; }
    public string label { get; set; }
    public string value => string.Empty;
    public string productUrl { get; set; }
    public string Name { get; set; }
    public string Image => string.Empty;
    public string type => "2";
}