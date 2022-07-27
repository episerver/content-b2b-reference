namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Invoice History Page",
    GUID = "1fdfdec5-6ede-46b2-a041-c0ec4650c1dc",
    GroupName = Global.GroupNames.CommercePages,
    Description = "To Create Invoice History Page"
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.Specific, Include = new[] { typeof(InvoiceDetailsPage) })]
public class InvoiceHistoryPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "Tab Name", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string TabName { get; set; }

    [CultureSpecific]
    [Display(Name = "Ship To Address", GroupName = Global.GroupNames.Labels, Order = 3)]
    public virtual string ShipToAddress { get; set; }

    [CultureSpecific]
    [Display(Name = "Invoice #", GroupName = Global.GroupNames.Labels, Order = 4)]
    public virtual string InvoiceNo { get; set; }

    [CultureSpecific]
    [Display(Name = "Order #", GroupName = Global.GroupNames.Labels, Order = 5)]
    public virtual string OrderNumber { get; set; }

    [CultureSpecific]
    [Display(Name = "PO #", GroupName = Global.GroupNames.Labels, Order = 6)]
    public virtual string PoNumber { get; set; }

    [CultureSpecific]
    [Display(Name = "Invoice Total", GroupName = Global.GroupNames.Labels, Order = 7)]
    public virtual string Total { get; set; }

    [CultureSpecific]
    [Display(Name = "From Date", GroupName = Global.GroupNames.Labels, Order = 8)]
    public virtual string DateRangeFrom { get; set; }

    [CultureSpecific]
    [Display(Name = "To Date", GroupName = Global.GroupNames.Labels, Order = 9)]
    public virtual string DateRangeTo { get; set; }

    [CultureSpecific]
    [Display(Name = "Date Range", GroupName = Global.GroupNames.Labels, Order = 10)]
    public virtual string DateRange { get; set; }

    [CultureSpecific]
    [Display(Name = "Clear Button Text", GroupName = Global.GroupNames.Labels, Order = 11)]
    public virtual string ClearButton { get; set; }

    [CultureSpecific]
    [Display(Name = "Search Button Text", GroupName = Global.GroupNames.Labels, Order = 12)]
    public virtual string SearchButton { get; set; }

    [Display(
        Name = "Invoice Details Page Link",
        GroupName = SystemTabNames.Content,
        Order = 13
    )]
    public virtual Url InvoiceDetailsPageLink { get; set; }

    [CultureSpecific]
    [Display(Name = "Per Page", GroupName = Global.GroupNames.Labels, Order = 14)]
    public virtual string PerPage { get; set; }

    [Display(
        Name = "Invoice History Page Link",
        GroupName = SystemTabNames.Content,
        Order = 15
    )]
    public virtual Url InvoicHistoryPageLink { get; set; }

    [Display(Name = "Invoice Status", GroupName = Global.GroupNames.Labels, Order = 16)]
    public virtual string InvoiceStatus { get; set; }

    [CultureSpecific]
    [Display(Name = "Invoices Found Text", GroupName = Global.GroupNames.Labels, Order = 17)]
    public virtual string InvoicesFoundText { get; set; }

    [CultureSpecific]
    [Display(Name = "Page Of", GroupName = Global.GroupNames.Labels, Order = 18)]
    public virtual string PageOf { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Date", GroupName = Global.GroupNames.Labels, Order = 19)]
    public virtual string HeaderDate { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Invoice #", GroupName = Global.GroupNames.Labels, Order = 20)]
    public virtual string HeaderInvoiceNo { get; set; }

    [CultureSpecific]
    [Display(Name = "Header ShipTo/PickTo ", GroupName = Global.GroupNames.Labels, Order = 21)]
    public virtual string HeaderShipToPickTo { get; set; }

    [CultureSpecific]
    [Display(Name = "Header PO", GroupName = Global.GroupNames.Labels, Order = 22)]
    public virtual string HeaderPO { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Total", GroupName = Global.GroupNames.Labels, Order = 23)]
    public virtual string HeaderTotal { get; set; }

    [CultureSpecific]
    [Display(Name = "Show Open Invoices", GroupName = Global.GroupNames.Labels, Order = 24)]
    public virtual string ShowOpenInvoices { get; set; }

    [CultureSpecific]
    [Display(Name = "Table Header Date", GroupName = Global.GroupNames.Labels, Order = 25)]
    public virtual string TableHeaderDate { get; set; }

    [CultureSpecific]
    [Display(Name = "Table Header InvoiceNo", GroupName = Global.GroupNames.Labels, Order = 26)]
    public virtual string TableHeaderInvoiceNo { get; set; }

    [CultureSpecific]
    [Display(Name = "Table Header Duedate", GroupName = Global.GroupNames.Labels, Order = 27)]
    public virtual string TableHeaderDuedate { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Table Header ShipTo/PickUp",
        GroupName = Global.GroupNames.Labels,
        Order = 28
    )]
    public virtual string TableHeaderShipToPickUp { get; set; }

    [CultureSpecific]
    [Display(Name = "Table Header PoNumber", GroupName = Global.GroupNames.Labels, Order = 29)]
    public virtual string TableHeaderPoNumber { get; set; }

    [CultureSpecific]
    [Display(Name = "Table Header Terms", GroupName = Global.GroupNames.Labels, Order = 30)]
    public virtual string TableHeaderTerms { get; set; }

    [CultureSpecific]
    [Display(Name = "Table Header Total", GroupName = Global.GroupNames.Labels, Order = 31)]
    public virtual string TableHeaderTotal { get; set; }

    [CultureSpecific]
    [Display(Name = "Table Header Balance", GroupName = Global.GroupNames.Labels, Order = 32)]
    public virtual string TableHeaderBalance { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "Invoice History";
        TabName = "Search Invoices";
        ShipToAddress = "Ship To Address";
        PoNumber = "PO #";
        OrderNumber = "Order #";
        DateRange = "Date Range";
        DateRangeFrom = "From";
        DateRangeTo = "To";
        ClearButton = "Clear";
        SearchButton = "Search";
        PerPage = "Per page";
        InvoiceStatus = "Status";
        InvoicesFoundText = "invoice(s) found";
        PageOf = "of";
        HeaderDate = "Date";
        HeaderInvoiceNo = "Invoice #";
        HeaderPO = "Ship To / Pick Up";
        HeaderShipToPickTo = "PO #";
        HeaderTotal = "Total";
        InvoiceNo = "Invoice #";
        ShowOpenInvoices = "Open Invoices Only";
        TableHeaderDate = "Date";
        TableHeaderInvoiceNo = "Invoice #";
        TableHeaderDuedate = "DueDate";
        TableHeaderShipToPickUp = "Ship To / Pick Up";
        TableHeaderPoNumber = "PO #";
        TableHeaderTerms = "Terms";
        TableHeaderTotal = "Total";
        TableHeaderBalance = "Balance";
    }
}
