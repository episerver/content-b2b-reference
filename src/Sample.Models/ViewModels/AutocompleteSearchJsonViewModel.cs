using Newtonsoft.Json;

namespace Sample.Models.ViewModels;

/// <summary>
/// This view model class is used for product, category and content search
/// </summary>
public class AutocompleteSearchJsonViewModel
{
    //This is ProductId, CategoryId, ContentId
    [JsonProperty("id")]
    public string Id { get; set; }

    //Label should some unique value
    [JsonProperty("label")]
    public string Label { get; set; }

    //Value will be shown in the dropdown
    [JsonProperty("value")]
    public string Value { get; set; }

    //Link to the page for the item
    [JsonProperty("url")]
    public string Url { get; set; }

    //Link to the image
    [JsonProperty("imageUrl")]
    public string ImageUrl { get; set; }

    //Search item type "Product", "Category", "Content" etc.
    [JsonProperty("searchType")]
    public string SearchType { get; set; }
}