using SharedLibrary.Models;

namespace ApiClient.Authentication;
public interface IAuthenticationService
{
    Task<TokenModel> GetAuthenticationTokenAsync(LoginModel loginModel);
    Task<TokenModel> ActivateTokenUsingRefreshToken(TokenModel tokenModel);
}
