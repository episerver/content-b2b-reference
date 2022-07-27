using CommerceApiSDK.Models.Results;
using Sample.Services.Invoices;

namespace Sample.Web.Features.Orders;

public class InvoiceHistoryPageController : PageControllerBase<InvoiceHistoryPage>
{
    private readonly IInvoiceService _invoiceService;
    private readonly IAccountService _accountService;

    public InvoiceHistoryPageController(
        IInvoiceService invoiceService,
        IAccountService accountService)
    {
        _invoiceService = invoiceService;
        _accountService = accountService;
    }

    public async Task<IActionResult> Index(InvoiceHistoryPage currentPage)
    {
        var searchParameters = new InvoiceQueryParameters
        {
            PoNumber = "",
            FromDate = null,
            ToDate = null,
            OrderNumber = "",
            CustomerSequence = "-1",
            Sort = "InvoiceDate DESC"
        };
        var shipTosResponse = new GetShipTosResult();
        var allAddresses = await _accountService.GetBillToAndShipTos();
        shipTosResponse.ShipTos = allAddresses?.BillTos.SelectMany(x => x.ShipTos).ToList() ?? new List<ShipTo>();
        var invoiceHistoryResponse = await _invoiceService.GetInvoiceHistory(searchParameters);
        var model = new InvoiceHistoryPageViewModel(currentPage)
        {
            InvoiceHistoryViewModel = new InvoiceHistoryViewModel()
        };
        model.InvoiceHistoryViewModel.ShipToCollection = shipTosResponse;
        model.InvoiceHistoryViewModel.InvoiceCollection = invoiceHistoryResponse;
        model.InvoiceDetailsPageLink = Url.ContentUrl(currentPage.InvoiceDetailsPageLink);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> SearchInvoice([FromBody] InvoiceQueryParameters searchParameters)
    {
        var invoiceResponse = await _invoiceService.GetInvoiceHistory(searchParameters);
        return Json(invoiceResponse);
    }
}
