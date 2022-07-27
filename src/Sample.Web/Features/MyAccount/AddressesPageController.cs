using Sample.Services.Session;

namespace Sample.Web.Features.MyAccount;

[LoginRequired]
public class AddressesPageController : PageControllerBase<AddressesPage>
{
    private readonly IWebsiteService _websiteService;
    private readonly IAccountService _accountService;
    private readonly ISessionService _sessionService;

    public AddressesPageController(IWebsiteService websiteService,
        IAccountService accountService, 
        ISessionService sessionService)
    {
        _websiteService = websiteService;
        _accountService = accountService;
        _sessionService = sessionService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(AddressesPage currentPage)
    {
        var model = new AddressesViewModel(currentPage)
        {
            BillTos = await _accountService.GetBillTos(),
            ShipTos = new CommerceApiSDK.Models.Results.GetShipTosResult(),
            Session = await _sessionService.GetCurrent(),
            ShipTosQueryParameters = new ShipTosQueryParameters
            {
                Page = 1,
                PageSize = 25,
                Expand = new List<string> { "ExcludeBillTo", "ExcludeCreateNew", "ExcludeShowAll" }
            }
        };
        model.BIllToId = model.Session?.BillTo?.Id;
        if ((model.BillTos?.BillTos.Count ?? 0) > 0)
        {
            model.BIllToId ??= model.BillTos.BillTos.First().Id;
            model.ShipTos = await _accountService.GetShipTos(new Guid(model.BIllToId), model.ShipTosQueryParameters);
        }
        
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(AddressesPage currentPage, string billToId, string shipToId = null)
    {
        var hasBillToId = Guid.TryParse(billToId, out var parsedBillToId);
        var hasShipToId = Guid.TryParse(shipToId, out var parsedShipToId);
        var isBillTo = shipToId == null;
        var isNew = shipToId != null && hasShipToId && parsedShipToId == Guid.Empty;
        var model = new AddressesViewModel(currentPage)
        {
            IsBillTo = isBillTo,
            IsNew = isNew,
            BIllToId = billToId
        };

        if (isBillTo && hasBillToId)
        {
            model.BillTo = await _accountService.GetBillTo(parsedBillToId);
        }
        else if (hasBillToId && hasShipToId && !isNew)
        {
            model.ShipTo = await _accountService.GetShipTo(parsedBillToId, parsedShipToId);
        }
        
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> GetCountries()
    {
        var countries = await _websiteService.GetCountriesWithStates();
        return Json(countries);
    }

    [HttpPost]
    public async Task<IActionResult> SearchAddresses([FromBody] ShipTosQueryParameters shipTosQueryParameters, string billToId)
    {
        var model = new AddressesViewModel()
        {
            ShipTos = new CommerceApiSDK.Models.Results.GetShipTosResult(),
            ShipTosQueryParameters = shipTosQueryParameters,
            BIllToId = billToId
        };
        model.ShipTosQueryParameters.Expand = new List<string> { "ExcludeBillTo", "ExcludeCreateNew", "ExcludeShowAll" };
        model.ShipTos = await _accountService.GetShipTos(new Guid(model.BIllToId), model.ShipTosQueryParameters);
        
        return PartialView("_addresses", model);
    }

    [HttpPost]
    public async Task<IActionResult> SaveAddrress([FromBody] SaveAddress saveAddress)
    {
        var hasBillToId = Guid.TryParse(saveAddress.BillToId, out var parsedBillToId);
        var hasShipToId = Guid.TryParse(saveAddress.ShipToId, out var parsedShipToId);
        var isBillTo = string.IsNullOrEmpty(saveAddress.ShipToId);
        var isNew = !string.IsNullOrEmpty(saveAddress.ShipToId) && hasShipToId && parsedShipToId == Guid.Empty;
        if (isBillTo && hasBillToId)
        {
            var billTo = await _accountService.GetBillTo(parsedBillToId);
            UpdateAddress(billTo, saveAddress);
            await _accountService.UpdateBillToDetails(billTo);
        }
        else if(hasBillToId)
        {
            ShipTo shipTo = null;
            if (isNew)
            {
                shipTo = new ShipTo
                {
                    Label = saveAddress.Label,
                    IsDefault = saveAddress.IsDefault
                };
                UpdateAddress(shipTo, saveAddress);
                shipTo = await _accountService.CreateShipTo(shipTo);
            }
            else
            {
                shipTo = await _accountService.GetShipTo(parsedBillToId, parsedShipToId);
                UpdateAddress(shipTo, saveAddress);
               
            }
            await _accountService.UpdateShipToDetails(saveAddress.BillToId, shipTo);
        }
        return Json(new { url = GetPageReferenceUrl(x => x.AddresesPage) });
    }

    public async Task<JsonResult> GetStatesOfCountry(string countryId)
    {
        var countries = await _websiteService.GetCountriesWithStates();
        var statesForCountry = countries
            .Where(x => x.Id == countryId)
            .Select(x => x.States)
            .ToList();

        return Json(statesForCountry.FirstOrDefault());
    }

    private void UpdateAddress(Address address, SaveAddress saveAddress)
    {
        if (address == null || saveAddress == null)
        {
            return;
        }

        address.Address1 = saveAddress.Address1;
        address.Address2 = saveAddress.Address2;
        address.Attention = saveAddress.Attention;
        address.City = saveAddress.City;
        address.CompanyName = saveAddress.CompanyName;
        address.Country = new Country
        {
            Id = saveAddress.Country
        };
        address.Email = saveAddress.Email;
        address.Label = saveAddress.Label;
        address.Phone = saveAddress.Phone;
        address.PostalCode = saveAddress.PostalCode
            ;
        address.State = new State
        {
            Id = saveAddress.State
        };
    }
}
