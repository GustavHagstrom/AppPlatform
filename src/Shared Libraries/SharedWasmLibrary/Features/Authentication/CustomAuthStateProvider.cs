using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Authentication.WebAssembly.Msal.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using System.Security.Claims;

namespace SharedWasmLibrary.Features.Authentication;

public class CustomAuthStateProvider : RemoteAuthenticationService<RemoteAuthenticationState, RemoteUserAccount, MsalProviderOptions>
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CustomAuthStateProvider(IHttpClientFactory httpClientFactory, IJSRuntime jsRuntime, IOptionsSnapshot<RemoteAuthenticationOptions<MsalProviderOptions>> options, NavigationManager navigation, AccountClaimsPrincipalFactory<RemoteUserAccount> accountClaimsPrincipalFactory, ILogger<RemoteAuthenticationService<RemoteAuthenticationState, RemoteUserAccount, MsalProviderOptions>> logger) : base(jsRuntime, options, navigation, accountClaimsPrincipalFactory, logger)
    {
        _httpClientFactory = httpClientFactory;
    }

    protected override async ValueTask<ClaimsPrincipal> GetAuthenticatedUser()
    {
        var client = _httpClientFactory.CreateClient("Backend");
        var user = await base.GetAuthenticatedUser();
        var identity = user.Identity as ClaimsIdentity;
        if (identity is not null && identity.IsAuthenticated)
        {
            try
            {
                var response = await client.GetAsync("/api/authorization/claims");
                if (response.IsSuccessStatusCode)
                {
                    var value = await response.Content.ReadAsStringAsync();
                    var claimValues = await response.Content.ReadFromJsonAsync<IEnumerable<KeyValuePair<string, string>>>();
                    if (claimValues is not null)
                    {
                        foreach (var claimValue in claimValues)
                        {
                            identity?.AddClaim(new Claim(claimValue.Key, claimValue.Value));
                        }
                    }
                }
            }
            catch (Exception)
            {
                //handle this ??
                throw;
            }
            
        }
        return user;
    }
}
