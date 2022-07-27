namespace Sample.Models.Pages;

public abstract class ProductListPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "ERP Label", GroupName = Global.GroupNames.Labels)]
    public virtual string ErpLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "MFG Label", GroupName = Global.GroupNames.Labels)]
    public virtual string MfgLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Availability Label", GroupName = Global.GroupNames.Labels)]
    public virtual string AvailabilityLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Color Label", GroupName = Global.GroupNames.Labels)]
    public virtual string ColorLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Weight Label", GroupName = Global.GroupNames.Labels)]
    public virtual string WeightLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Price Label", GroupName = Global.GroupNames.Labels)]
    public virtual string PriceLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Customer Part Number Label", GroupName = Global.GroupNames.Labels)]
    public virtual string CustomerPartNumberLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Sort By Text", GroupName = Global.GroupNames.Labels)]
    public virtual string SortByText { get; set; }

    [CultureSpecific]
    [Display(Name = "Pagesize Text", GroupName = Global.GroupNames.Labels)]
    public virtual string PagesizeText { get; set; }

    [CultureSpecific]
    [Display(Name = "ClearAll Label", GroupName = Global.GroupNames.Labels)]
    public virtual string ClearAllLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Compare Button Label", GroupName = Global.GroupNames.Labels)]
    public virtual string CompareLabel { get; set; }

    [Display(Name = "Compare Page URL", GroupName = SystemTabNames.Content)]
    public virtual Url ComparePageURL { get; set; }

    [CultureSpecific]
    [Display(Name = "Compare Product Message Label", GroupName = Global.GroupNames.Labels)]
    public virtual string CompareProductMessageLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Compare Product Warning Label", GroupName = Global.GroupNames.Labels)]
    public virtual string CompareProductWarningLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Products Empty Message", GroupName = Global.GroupNames.Labels)]
    public virtual string ProductsEmptyMessage { get; set; }

    [Display(Name = "Item Action Content Area", GroupName = SystemTabNames.Content)]
    [AllowedTypes(new[] { typeof(LabelSettings) })]
    public virtual ContentArea ItemActionContentArea { get; set; }

    [CultureSpecific]
    [Display(Name = "Items Label", GroupName = Global.GroupNames.Labels)]
    public virtual string ItemsLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Sort By Label", GroupName = Global.GroupNames.Labels)]
    public virtual string SortByLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "View Label", GroupName = Global.GroupNames.Labels)]
    public virtual string ViewLabel { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        ErpLabel = "Item #";
        MfgLabel = "Model #";
        AvailabilityLabel = "Availability";
        ColorLabel = "Color";
        WeightLabel = "Weight";
        PriceLabel = "Price";
        CustomerPartNumberLabel = "Customer Part #";
        SortByText = "Sort By";
        PagesizeText = "Per Page";
        ClearAllLabel = "Clear All";
        CompareLabel = "Compare";
        CompareProductMessageLabel = "Please \"compare\" or remove item";
        CompareProductWarningLabel = "You have reached the maximum number of items.";
        ProductsEmptyMessage = "No results found.";
        ItemsLabel = "Items";
        SortByLabel = "Sort By";
        ViewLabel = "Views";
    }
}
