using CommerceApiSDK.Services.Interfaces;

namespace Sample.Services.Tokenization;

public class TokenizationService : BaseService, ITokenizationService
{
    private readonly ITokenExConfigService _tokenizationClient;

    public TokenizationService(ITokenExConfigService tokenizationClient)
    {
        _tokenizationClient = tokenizationClient;
    }

    public async Task<TokenExDto> GetAuthenticationKey(string requestOrigin, string token = null, bool isEcheck = false)
    {
        var parameters = new TokenExConfigQueryParameters
        {
            Origin = requestOrigin,
            IsECheck = isEcheck
        };

        if (!string.IsNullOrEmpty(token))
        {
            parameters.Token = token;
        }

        return await _tokenizationClient.GetTokenExConfig(parameters);
    }
}
