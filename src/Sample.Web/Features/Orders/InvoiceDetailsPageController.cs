﻿using Microsoft.Extensions.Primitives;
using Sample.Services.Invoices;

namespace Sample.Web.Features.Orders;

[LoginRequired]
public class InvoiceDetailsPageController : PageControllerBase<InvoiceDetailsPage>
{
    private readonly IInvoiceService _invoiceService;

    public InvoiceDetailsPageController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    public async Task<IActionResult> Index(InvoiceDetailsPage currentPage)
    {
        StringValues invoiceNumber;
        Request.Query.TryGetValue("invoicenumber", out invoiceNumber);
        var expands = new List<string> { "invoicelines", "shipments" };
        var model = new InvoiceDetailsPageViewModel(currentPage);
        if (!string.IsNullOrEmpty(invoiceNumber))
        {
            var invoiceDetailParameter = new InvoiceDetailParameter()
            {
                InvoiceNumber = invoiceNumber,
                Expand = expands
            };
            var invoiceDetails = await
                _invoiceService.GetInvoiceDetail(invoiceDetailParameter);
            model.InvoiceDetailsViewModel = new InvoiceDetailsViewModel
            {
                Invoice = invoiceDetails
            };
            model.ReturnPageLink = Url.ContentUrl(currentPage.ReturnPageLink);
        }
        return View(model);
    }
}