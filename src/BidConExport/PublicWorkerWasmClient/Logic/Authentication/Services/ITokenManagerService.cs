using SharedLibrary.Models;

namespace PublicWorkerWasmClient.Authentication.Services;
public interface ITokenManagerService
{
    Task<TokenModel> GetTokenModelFromLocalStorageAsync();
    Task RemoveTokenFromLocalStorageAsync();
    Task SaveTokenToLocalStorageAsync(TokenModel tokenModel);
}