using BidConReport.Shared.Constants;
using Microsoft.AspNetCore.Authentication;
using SharedPlatformLibrary.Constants;
using SharedPlatformLibrary.Enteties;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BidConReport.Server.Features.Claims;

public class ClaimsProvider : IClaimsProvider
{
    private readonly HttpClient _httpClient;

    public ClaimsProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<ICollection<ClaimModel>> GetClaimsAsync()
    {

        var claims = new List<ClaimModel>();
        var claimResult = await _httpClient.GetFromJsonAsync<ICollection<ClaimModel>>($"{LicenseApiEndpoints.Claims}?applicationName={CommonConstants.ApplicationName}");
        if (claimResult is not null)
        {
            claims.AddRange(claimResult);
        }
        return claims;
    }
}
