using Client.Shared.Constants;
using SharedLibrary.Constants;
using SharedLibrary.DTOs;
using SharedLibrary.Wrappers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Authentication.WebAssembly.Msal.Models;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using System.Security.Claims;

namespace Client.Features.Authentication;

public class CustomAuthStateProvider : RemoteAuthenticationService<RemoteAuthenticationState, RemoteUserAccount, MsalProviderOptions>
{
    //private readonly IHttpClientWrapper _httpClient;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<RemoteAuthenticationService<RemoteAuthenticationState, RemoteUserAccount, MsalProviderOptions>> _logger;

    public CustomAuthStateProvider(IHttpClientFactory httpClientFactory, IJSRuntime jsRuntime, IOptionsSnapshot<RemoteAuthenticationOptions<MsalProviderOptions>> options, NavigationManager navigation, AccountClaimsPrincipalFactory<RemoteUserAccount> accountClaimsPrincipalFactory, ILogger<RemoteAuthenticationService<RemoteAuthenticationState, RemoteUserAccount, MsalProviderOptions>> logger) : base(jsRuntime, options, navigation, accountClaimsPrincipalFactory, logger)
    {
        //_httpClient = httpClient;
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    protected override async ValueTask<ClaimsPrincipal> GetAuthenticatedUser()
    {
        var httpClient = _httpClientFactory.CreateClient(HttpClientNames.BackendHttpClientName);
        var user = await base.GetAuthenticatedUser();
        var identity = user.Identity as ClaimsIdentity;
        if (identity is not null && identity.IsAuthenticated)
        {
            try
            {
                var response = await httpClient.GetAsync(BackendApiEndpoints.ClaimEnpoints.Get);
                if (response.IsSuccessStatusCode)
                {
                    var claimModels = await response.Content.ReadFromJsonAsync<ICollection<ClaimDto>>();
                    if (claimModels is not null)
                    {
                        foreach (var claimModel in claimModels)
                        {
                            identity?.AddClaim(new Claim(claimModel.Type, claimModel.Value));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //handle this ??
                _logger.LogCritical(e, "Failed to get customClaims");
                throw;
            }

        }
        return user;
    }
}
