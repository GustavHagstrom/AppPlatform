using Blazored.LocalStorage;
using SharedLibrary.Models;

namespace PublicWorkerWasmClient.Authentication.Services;
public class TokenManagerService : ITokenManagerService
{
    private readonly ILocalStorageService _localStorageService;

    public TokenManagerService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }
    public async Task SaveTokenToLocalStorageAsync(TokenModel tokenModel)
    {
        await _localStorageService.SetItemAsStringAsync(Constants.LocalStorageTokenKey, tokenModel.Token);
        await _localStorageService.SetItemAsStringAsync(Constants.LocalStorageRefreshTokenKey, tokenModel.RefreshToken);
    }
    public async Task<TokenModel> GetTokenModelFromLocalStorageAsync()
    {
        var token = await _localStorageService.GetItemAsStringAsync(Constants.LocalStorageTokenKey);
        var refreshToken = await _localStorageService.GetItemAsStringAsync(Constants.LocalStorageRefreshTokenKey);
        return new TokenModel { Token = token, RefreshToken = refreshToken };
    }
    public async Task RemoveTokenFromLocalStorageAsync()
    {
        await _localStorageService.RemoveItemAsync(Constants.LocalStorageTokenKey);
        await _localStorageService.RemoveItemAsync(Constants.LocalStorageRefreshTokenKey);
    }
}
