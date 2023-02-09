using ApiAccessLibrary.ApiHandlers;
using Microsoft.AspNetCore.Components.Authorization;
using SharedLibrary.Models;

namespace PublicWorkerWasmClient.Authentication.Services;
public class LoginService : ILoginService
{
    private readonly ITokenManagerService _tokenManagerService;
    private readonly IAuthenticationApiHandler _authenticationApiHandler;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public LoginService(ITokenManagerService tokenManagerService, IAuthenticationApiHandler authenticationApiHandler, AuthenticationStateProvider authenticationStateProvider)
    {
        _tokenManagerService = tokenManagerService;
        _authenticationApiHandler = authenticationApiHandler;
        _authenticationStateProvider = authenticationStateProvider;
    }
    public async Task<bool> LoginAsync(LoginModel loginModel)
    {
        var token = await _authenticationApiHandler.LoginAsync(loginModel);
        if (token == null)
        {
            return false;
        }
        await _tokenManagerService.SaveTokenToLocalStorageAsync(token);
        (_authenticationStateProvider as AuthProviderService)!.NotifyAuthenticationState();
        return true;
    }
    public async Task<bool> LogoutAsync()
    {
        await _tokenManagerService.RemoveTokenFromLocalStorageAsync();
        (_authenticationStateProvider as AuthProviderService)!.NotifyAuthenticationState();
        return true;
    }
}
