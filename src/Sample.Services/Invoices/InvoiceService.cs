namespace Sample.Services.Invoices;

public class InvoiceService : BaseService, IInvoiceService
{
    private readonly CommerceApiSDK.Services.Interfaces.IInvoiceService _invoiceClient;

    public InvoiceService(CommerceApiSDK.Services.Interfaces.IInvoiceService invoiceClient)
    {
        _invoiceClient = invoiceClient;
    }

    public async Task<GetInvoiceResult> GetInvoiceHistory(InvoiceQueryParameters searchParameters)
    {
        return await _invoiceClient.GetInvoices(searchParameters);
    }

    public async Task<Invoice> GetInvoiceDetail(InvoiceDetailParameter parameters)
    {
        return await _invoiceClient.GetInvoice(parameters);
    }
}
