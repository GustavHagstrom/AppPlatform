using BidConReport.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Authentication.WebAssembly.Msal.Models;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using System.Security.Claims;

namespace BidConReport.Client.Features.Authentication;

public class CustomAuthStateProvider : RemoteAuthenticationService<RemoteAuthenticationState, RemoteUserAccount, MsalProviderOptions>
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CustomAuthStateProvider(IHttpClientFactory httpClientFactory, IJSRuntime jsRuntime, IOptionsSnapshot<RemoteAuthenticationOptions<MsalProviderOptions>> options, NavigationManager navigation, AccountClaimsPrincipalFactory<RemoteUserAccount> accountClaimsPrincipalFactory, ILogger<RemoteAuthenticationService<RemoteAuthenticationState, RemoteUserAccount, MsalProviderOptions>> logger) : base(jsRuntime, options, navigation, accountClaimsPrincipalFactory, logger)
    {
        _httpClientFactory = httpClientFactory;
    }
    protected override async ValueTask<ClaimsPrincipal> GetAuthenticatedUser()
    {
        var user = await base.GetAuthenticatedUser();
        var identity = user.Identity;
        if (identity is not null && identity.IsAuthenticated)
        {
            var client = _httpClientFactory.CreateClient(AppConstants.BackendHttpClientName);
            var response = await client.GetAsync("/api/authorization/roles");
            if(response.IsSuccessStatusCode)
            {
                var roles = await response.Content.ReadFromJsonAsync<ICollection<string>>();
                if(roles is not null)
                {
                    List<Claim> roleClaims = new();
                    foreach (var role in roles)
                    {
                        roleClaims.Add(new Claim(ClaimTypes.Role, role));
                    }
                    user.AddIdentity(new ClaimsIdentity(roleClaims));
                }
            }
        }
        return user;
    }
}
