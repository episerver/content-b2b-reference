namespace Sample.Services.Tokenization;

public interface ITokenizationService
{
    Task<TokenExDto> GetAuthenticationKey(string requestOrigin, string token = null, bool isEcheck = false);
}
