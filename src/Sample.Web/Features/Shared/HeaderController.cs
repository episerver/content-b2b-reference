using Sample.Services.Session;

namespace Sample.Web.Features.Shared;

public class HeaderController : Controller
{
    private readonly IAccountService _accountService;
    private readonly ISessionService _sessionService;

    public HeaderController (IAccountService accountService, 
        ISessionService sessionService)
    {
        _accountService = accountService;
        _sessionService = sessionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBillTos()
    {
        var billTo = await _accountService.GetBillToAndShipTos();
        return Json(billTo.BillTos);
    }

    [HttpGet]
    public async Task<IActionResult> GetShipTos(string billTo)
    {
        var shipTos = await _accountService.GetShipTos(new Guid(billTo), new ShipTosQueryParameters
        {
            Expand = new List<string> { "ExcludeBillTo", "ExcludeCreateNew", "ExcludeShowAll" }
        });
        return Json(shipTos.ShipTos ?? new List<ShipTo>());
    }

    [HttpPost]
    public async Task<IActionResult> ChangeCustomer([FromBody] ChangeCustomer changeCustomer)
    {
        var session = await _sessionService.GetCurrent();
        session.FulfillmentMethod = changeCustomer.FulfillmentMethod;
        session.BillTo = new BillTo
        {
            Id = changeCustomer.BillTo
        };
        if (changeCustomer.FulfillmentMethod.Equals("PickUp"))
        {
            session.PickUpWarehouse = new Warehouse
            {
                Id = Guid.Parse(changeCustomer.Warehouse)
            };
        }
        else
        {
            session.ShipTo = new ShipTo
            {
                Id = changeCustomer.ShipTo
            };
        }
        await _sessionService.PatchSessionCustomerInfo(session);
        return Json(true);
    }

    [HttpPost]
    public async Task<IActionResult> ChangeLanguage(string languageId)
    {
        var session = await _sessionService.GetCurrent();
        session.Language = new Language
        {
            Id = languageId
        };
        await _sessionService.PatchSessionCustomerInfo(session);
        return Json(true);
    }

    [HttpPost]
    public async Task<IActionResult> ChangeCurrency(string currencyId)
    {
        var session = await _sessionService.GetCurrent();
        session.Currency = new Currency
        {
            ID = new Guid(currencyId)
        };
        await _sessionService.PatchSessionCustomerInfo(session);
        return Json(true);
    }
}
