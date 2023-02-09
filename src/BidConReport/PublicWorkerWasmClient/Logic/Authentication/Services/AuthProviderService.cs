using ApiAccessLibrary.ApiHandlers;
using Microsoft.AspNetCore.Components.Authorization;
using PublicWorkerWasmClient.Authentication.Helpers;
using SharedLibrary.Models;
using System.Security.Claims;

namespace PublicWorkerWasmClient.Authentication.Services;
public class AuthProviderService : AuthenticationStateProvider
{
    private readonly IAuthenticationApiHandler _authenticationApiHandler;
    private readonly ITokenManagerService _tokenManagerService;
    private readonly PeriodicTimer _periodicTimer = new(TimeSpan.FromMinutes(14));
    private bool _initialized = false;

    public AuthProviderService(IAuthenticationApiHandler authenticationApiHandler, ITokenManagerService tokenManagerService)
    {
        _authenticationApiHandler = authenticationApiHandler;
        _tokenManagerService = tokenManagerService;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        if (!_initialized)
        {
            _initialized = true;
            await RefreshTokenIfTokenExistsAsync();
            _ = Task.Run(ContiousUpdatingAsync);
        }

        var tokenModel = await _tokenManagerService.GetTokenModelFromLocalStorageAsync();
        if (string.IsNullOrEmpty(tokenModel.Token) || string.IsNullOrEmpty(tokenModel.RefreshToken))
        {
            return new AuthenticationState(new ClaimsPrincipal());
        }

        

        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(tokenModel.Token), "BidConExportAuth"));
        return new AuthenticationState(claimsPrincipal);
    }

    private async Task ContiousUpdatingAsync()
    {
        while (await _periodicTimer.WaitForNextTickAsync())
        {
            await RefreshTokenIfTokenExistsAsync();
        }
    }
    private async Task RefreshTokenIfTokenExistsAsync()
    {
        var tokenModel = await _tokenManagerService.GetTokenModelFromLocalStorageAsync();
        if (!string.IsNullOrEmpty(tokenModel.Token) && !string.IsNullOrEmpty(tokenModel.RefreshToken))
        {
            await RefreshTokenAsync(tokenModel);
        }
    }
    private async Task RefreshTokenAsync(TokenModel tokenModel)
    {
        try
        {
            tokenModel = await _authenticationApiHandler.RefreshTokenAsync(tokenModel);
            await _tokenManagerService.SaveTokenToLocalStorageAsync(tokenModel!);
        }
        catch
        {
            await _tokenManagerService.RemoveTokenFromLocalStorageAsync();
            NotifyAuthenticationState();
        }
        
    }
    public void NotifyAuthenticationState()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
