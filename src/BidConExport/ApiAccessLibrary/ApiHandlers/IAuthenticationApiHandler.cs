using SharedLibrary.Models;

namespace ApiAccessLibrary.ApiHandlers;
public interface IAuthenticationApiHandler
{
    Task<TokenModel> LoginAsync(LoginModel loginModel);
    Task<TokenModel> RefreshTokenAsync(TokenModel tokenModel);
}