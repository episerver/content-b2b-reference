namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Order History Page",
    GUID = "39bd5fa5-f7b5-407e-a10c-49f849e16706",
    GroupName = Global.GroupNames.CommercePages,
    Description = "To Create Order History Page"
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.Specific, Include = new[] { typeof(OrderDetailsPage) })]
public class OrderHistoryPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "Tab Name", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string TabName { get; set; }

    [CultureSpecific]
    [Display(Name = "Ship To Address", GroupName = Global.GroupNames.Labels, Order = 3)]
    public virtual string ShipToAddress { get; set; }

    [CultureSpecific]
    [Display(Name = "PO #", GroupName = Global.GroupNames.Labels, Order = 4)]
    public virtual string PoNumber { get; set; }

    [CultureSpecific]
    [Display(Name = "Order Total", GroupName = Global.GroupNames.Labels, Order = 5)]
    public virtual string OrderTotal { get; set; }

    [CultureSpecific]
    [Display(Name = "Status", GroupName = Global.GroupNames.Labels, Order = 6)]
    public virtual string OrderStatus { get; set; }

    [CultureSpecific]
    [Display(Name = "Order #", GroupName = Global.GroupNames.Labels, Order = 7)]
    public virtual string OrderNumber { get; set; }

    [CultureSpecific]
    [Display(Name = "Date Range", GroupName = Global.GroupNames.Labels, Order = 8)]
    public virtual string DateRange { get; set; }

    [CultureSpecific]
    [Display(Name = "From Date", GroupName = Global.GroupNames.Labels, Order = 9)]
    public virtual string DateRangeFrom { get; set; }

    [CultureSpecific]
    [Display(Name = "To Date", GroupName = Global.GroupNames.Labels, Order = 10)]
    public virtual string DateRangeTo { get; set; }

    [CultureSpecific]
    [Display(Name = "Product #", GroupName = Global.GroupNames.Labels, Order = 11)]
    public virtual string ProductNumber { get; set; }

    [CultureSpecific]
    [Display(Name = "Clear Button Text", GroupName = Global.GroupNames.Labels, Order = 12)]
    public virtual string ClearButton { get; set; }

    [CultureSpecific]
    [Display(Name = "Search Button Text", GroupName = Global.GroupNames.Labels, Order = 13)]
    public virtual string SearchButton { get; set; }

    [Display(Name = "Order Details Page Link", GroupName = SystemTabNames.Content, Order = 14)]
    public virtual Url OrderDetailsPageLink { get; set; }

    [CultureSpecific]
    [Display(Name = "Orders Found Text", GroupName = Global.GroupNames.Labels, Order = 15)]
    public virtual string OrdersFoundText { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Date", GroupName = Global.GroupNames.Labels, Order = 16)]
    public virtual string HeaderDate { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Order#", GroupName = Global.GroupNames.Labels, Order = 17)]
    public virtual string HeaderOrderNo { get; set; }

    [CultureSpecific]
    [Display(Name = "Header ShipTo ", GroupName = Global.GroupNames.Labels, Order = 18)]
    public virtual string HeaderShipTo { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Status", GroupName = Global.GroupNames.Labels, Order = 19)]
    public virtual string HeaderStatus { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Web Order#", GroupName = Global.GroupNames.Labels, Order = 20)]
    public virtual string HeaderWebOrder { get; set; }

    [CultureSpecific]
    [Display(Name = "Header PO#", GroupName = Global.GroupNames.Labels, Order = 21)]
    public virtual string HeaderPO { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Total", GroupName = Global.GroupNames.Labels, Order = 22)]
    public virtual string HeaderTotal { get; set; }

    [CultureSpecific]
    [Display(Name = "Page Of", GroupName = Global.GroupNames.Labels, Order = 23)]
    public virtual string PageOf { get; set; }

    [CultureSpecific]
    [Display(Name = "Per Page", GroupName = Global.GroupNames.Labels, Order = 24)]
    public virtual string PerPage { get; set; }

    [Display(Name = "Order History Page Link", GroupName = SystemTabNames.Content, Order = 25)]
    public virtual Url OrderHistoryPageLink { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "Order History";
        TabName = "Search Orders";
        ShipToAddress = "Ship To Address";
        PoNumber = "PO #";
        OrderTotal = "Order Total";
        OrderStatus = "Status";
        OrderNumber = "Order #";
        DateRange = "Date Range";
        DateRangeFrom = "From";
        DateRangeTo = "To";
        ProductNumber = "Product #";
        ClearButton = "Clear";
        SearchButton = "Search";
        OrdersFoundText = "order(s) found";
        HeaderDate = "Date";
        HeaderOrderNo = "Order #";
        HeaderShipTo = "Ship To / Pick Up";
        HeaderStatus = "Status";
        HeaderWebOrder = "Web Order #";
        HeaderPO = "PO #";
        HeaderTotal = "Total";
        PageOf = "of";
        PerPage = "Per page";
    }
}
