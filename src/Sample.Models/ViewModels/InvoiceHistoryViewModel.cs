using CommerceApiSDK.Models.Results;

namespace Sample.Models.ViewModels;

public class InvoiceHistoryViewModel
{
    public string ClearButtonLink { get; set; }
    public string SearchButtonLink { get; set; }
    public GetShipTosResult ShipToCollection { get; set; }
    public GetInvoiceResult InvoiceCollection { get; set; }
    public PaginationExtendedModel Pagination { get; set; }
}