namespace Sample.Services.Account;

public interface IAccountService
{
    Task<GetBillTosResult> GetBillToAndShipTos(BillTosQueryParameters billTosQueryParameters = null);
    
    Task<string> ChangePassword(string newPassword, string currentPassword);
    Task<bool> ResetPassword(string username);
    Task<CommerceApiSDK.Models.Account> CreateAccount(
        string email,
        string username,
        string password,
        bool isSubscribed
    );
   
    Task<CommerceApiSDK.Models.Account> CreateGuestAccount();

    Task<BillTo> UpdateBillToDetails(BillTo billTo);
    Task<ShipTo> UpdateShipToDetails(string billToId, ShipTo shipTo);
    Task<ShipTo> CreateShipTo(ShipTo shipTo);
    Task<string> ChangePassword(string username, string newPassword, string currentPassword);
    Task<GetShipTosResult> GetShipTos(Guid billToId, ShipTosQueryParameters shipTosQueryParameters = null);
    Task<GetBillTosResult> GetBillTos();
    Task<BillTo> GetCurrentBillTos();
    Task<Settings> GetSettings(bool auth);
    Task<string> UpdatePassword(string userId, string newPassword, string passwordResetToken);
    Task<BillTo> GetBillTo(Guid billToId);
    Task<ShipTo> GetShipTo(Guid billToId, Guid shipToId);
}
