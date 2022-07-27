namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Saved Orders Page",
    GUID = "fa9d7ac5-f42a-41c0-b7c9-9ddab251a248",
    Description = "Saved orders page",
    GroupName = Global.GroupNames.CommercePages
)]
[SiteImageUrl]
[AvailableContentTypes(
    EPiServer.DataAbstraction.Availability.Specific,
    Include = new[] { typeof(SavedOrderDetailsPage) }
)]
public class SavedOrdersPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "Tab Name", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string TabName { get; set; }

    [CultureSpecific]
    [Display(Name = "Ship To Address", GroupName = Global.GroupNames.Labels, Order = 3)]
    public virtual string ShipToAddress { get; set; }

    [CultureSpecific]
    [Display(Name = "Order Total", GroupName = Global.GroupNames.Labels, Order = 4)]
    public virtual string OrderTotal { get; set; }

    [CultureSpecific]
    [Display(Name = "Saved Order Status", GroupName = Global.GroupNames.Labels, Order = 5)]
    public virtual string SavedOrderStatus { get; set; }

    [CultureSpecific]
    [Display(Name = "Date Range", GroupName = Global.GroupNames.Labels, Order = 6)]
    public virtual string DateRange { get; set; }

    [CultureSpecific]
    [Display(Name = "From Date", GroupName = Global.GroupNames.Labels, Order = 7)]
    public virtual string DateRangeFrom { get; set; }

    [CultureSpecific]
    [Display(Name = "To Date", GroupName = Global.GroupNames.Labels, Order = 8)]
    public virtual string DateRangeTo { get; set; }

    [CultureSpecific]
    [Display(Name = "Clear Button Text", GroupName = Global.GroupNames.Labels, Order = 9)]
    public virtual string ClearButton { get; set; }

    [CultureSpecific]
    [Display(Name = "Search Button Text", GroupName = Global.GroupNames.Labels, Order = 10)]
    public virtual string SearchButton { get; set; }

    [Display(
        Name = "Saved Order Details Page Link",
        GroupName = SystemTabNames.Content,
        Order = 11
    )]
    public virtual Url SavedOrderDetailsPageLink { get; set; }

    [CultureSpecific]
    [Display(Name = "Orders Found Text", GroupName = Global.GroupNames.Labels, Order = 12)]
    public virtual string OrdersFoundText { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Date", GroupName = Global.GroupNames.Labels, Order = 13)]
    public virtual string HeaderDate { get; set; }

    [CultureSpecific]
    [Display(Name = "Header ShipTo ", GroupName = Global.GroupNames.Labels, Order = 14)]
    public virtual string HeaderShipTo { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Total", GroupName = Global.GroupNames.Labels, Order = 15)]
    public virtual string HeaderTotal { get; set; }

    [CultureSpecific]
    [Display(Name = "Page Of", GroupName = Global.GroupNames.Labels, Order = 16)]
    public virtual string PageOf { get; set; }

    [CultureSpecific]
    [Display(Name = "Per Page", GroupName = Global.GroupNames.Labels, Order = 17)]
    public virtual string PerPage { get; set; }

    [Display(Name = "Saved Order Page Link", GroupName = SystemTabNames.Content, Order = 18)]
    public virtual Url SavedOrderPageLink { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "Saved Orders";
        TabName = "Saved Orders";
        ShipToAddress = "Ship To Address";
        OrderTotal = "Order Total";
        SavedOrderStatus = "Status";
        DateRange = "Date Range";
        DateRangeFrom = "From Date";
        DateRangeTo = "To Date";
        ClearButton = "Clear";
        SearchButton = "Search";
        OrdersFoundText = "order(s) found";
        HeaderDate = "Date";
        HeaderShipTo = "Ship To / Pick Up";
        HeaderTotal = "Total";
        PageOf = "of";
        PerPage = "Per page";
    }
}
