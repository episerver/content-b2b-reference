using CommerceApiSDK.Services.Interfaces;

namespace Sample.Services.Account;

public class AccountService : BaseService, IAccountService
{
    private readonly CommerceApiSDK.Services.Interfaces.IAccountService _accountClient;
    private readonly ISettingsService _settingClient;
    private readonly IBillToService _billToService;
    private readonly ISessionService _sessionService;

    public AccountService(
        CommerceApiSDK.Services.Interfaces.IAccountService accountClient,
        ISettingsService settingClient,
        IBillToService billToService,
        ISessionService sessionService
    )
    {
        _accountClient = accountClient;
        _settingClient = settingClient;
        _billToService = billToService;
        _sessionService = sessionService;
    }

    public async Task<GetBillTosResult> GetBillToAndShipTos(BillTosQueryParameters billTosQueryParameters = null)
    {
        return await _billToService.GetBillTosAsync(billTosQueryParameters ?? new BillTosQueryParameters());
    }

    public async Task<GetBillTosResult> GetBillTos()
    {
        return await _billToService.GetBillTosAsync(null);
    }

    public async Task<BillTo> GetBillTo(Guid billToId)
    {
        return await _billToService.GetBillTo(billToId);
    }

    public async Task<ShipTo> GetShipTo(Guid billToId, Guid shipToId)
    {
        return await _billToService.GetShipTo(billToId, shipToId);
    }

    public async Task<GetShipTosResult> GetShipTos(Guid billToId, ShipTosQueryParameters shipTosQueryParameters = null)
    {
        return await _billToService.GetShipTosAsync(billToId, shipTosQueryParameters);
    }

    public async Task<string> ChangePassword(string newPassword, string currentPassword)
    {
        var session = new CommerceApiSDK.Models.Session()
        {
            NewPassword = newPassword,
            Password = currentPassword
        };
        var result = await _sessionService.PatchSession(session);
        return result is null ? null : "";
    }

    public async Task<bool> ResetPassword(string username)
    {
        var session = new CommerceApiSDK.Models.Session()
        {
            UserName = username,
            ResetPassword = true
        };
        var result = _sessionService.PatchSession(session);
        return await (result is null ? Task.FromResult(true) : Task.FromResult(false));
    }

    public async Task<string> UpdatePassword(
        string UserId,
        string newpassword,
        string passwordResetToken
    )
    {
        var session = new CommerceApiSDK.Models.Session()
        {
            NewPassword = newpassword,
            ResetToken = passwordResetToken
        };
        var result = _sessionService.PatchSession(session);
        return await (result is null ? Task.FromResult((string)null) : Task.FromResult(""));
    }

    public async Task<CommerceApiSDK.Models.Account> CreateAccount(
        string email,
        string username,
        string password,
        bool isSubscribed
    )
    {
        var model = new CommerceApiSDK.Models.Account()
        {
            Email = email,
            UserName = username,
            Password = password,
            IsSubscribed = isSubscribed
        };
        return await _accountClient.PostAccountsAsync(model);
    }

    public async Task<BillTo> UpdateBillToDetails(BillTo billTo)
    {
        return await _billToService.PatchBillTo(Guid.Parse(billTo.Id), billTo);
    }

    public async Task<ShipTo> UpdateShipToDetails(string billToId, ShipTo shipTo)
    {
        if (string.IsNullOrEmpty(shipTo.Id) || !Guid.TryParse(shipTo.Id, out var id) )
        {
            return await _billToService.PostShipToAsync(Guid.Parse(billToId), shipTo);
        }
        else
        {
            return await _billToService.PatchShipTo(Guid.Parse(billToId), id, shipTo);
        }
        
    }

    public async Task<ShipTo> CreateShipTo(ShipTo shipTo)
    {
        return await _billToService.PostShipToAsync(Guid.Empty, shipTo);
    }


    public async Task<string> ChangePassword(
        string username,
        string newPassword,
        string currentPassword
    )
    {
        var session = new CommerceApiSDK.Models.Session()
        {
            NewPassword = newPassword,
            Password = currentPassword,
            UserName = username,
            ResetPassword = false
        };
        var result = await _sessionService.PatchSession(session);
        return result is null ? null : "";
    }

    public async Task<BillTo> GetCurrentBillTos()
    {
        var result = await _billToService.GetBillTosAsync();
        return result.BillTos[0];
    }

    public async Task<Settings> GetSettings(bool auth = false)
    {
        return await _settingClient.GetSettingsAsync();
    }

    public async Task<CommerceApiSDK.Models.Account> CreateGuestAccount()
    {
        var model = new CommerceApiSDK.Models.Account
        {
            IsGuest = true,
            DefaultFulfillmentMethod = "Ship"
        };
        return await _accountClient.PostAccountsAsync(model);
    }
}
