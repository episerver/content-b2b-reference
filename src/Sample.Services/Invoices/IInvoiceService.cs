namespace Sample.Services.Invoices;

public interface IInvoiceService
{
    Task<GetInvoiceResult> GetInvoiceHistory(InvoiceQueryParameters searchParameters);
    Task<Invoice> GetInvoiceDetail(InvoiceDetailParameter parameters);
}
