using BidConReport.Shared.Constants;
using SharedPlatformLibrary.Constants;
using SharedPlatformLibrary.Enteties;
using SharedPlatformLibrary.HttpRequests;

namespace BidConReport.Server.Shared.Services;

public class ClaimsProvider : IClaimsProvider
{
    private readonly HttpClient _httpClient;

    public ClaimsProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<ICollection<ClaimModel>> GetClaimsAsync(string userId)
    {

        var claims = new List<ClaimModel>();
        var requestBody = new ClaimsRequestBody(userId, CommonAppConstants.ApplicationName);
        var result = await _httpClient.PostAsJsonAsync(LicenseApiEndpoints.Claims, requestBody);
        result.EnsureSuccessStatusCode();
        var claimResult = await result.Content.ReadFromJsonAsync<ICollection<ClaimModel>>();
        if (claimResult is not null)
        {
            claims.AddRange(claimResult);
        }
        return claims;
    }
}
