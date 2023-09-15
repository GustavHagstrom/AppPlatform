using BidConReport.Shared.Constants;
using SharedPlatformLibrary.Constants;
using SharedPlatformLibrary.DTOs;
using SharedPlatformLibrary.HttpRequests;

namespace BidConReport.Server.Services.Authentication;

public class ClaimsService : IClaimsService
{
    private readonly HttpClient _httpClient;

    public ClaimsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<ICollection<ClaimDTO>> GetClaimsAsync(string userId)
    {
        throw new NotImplementedException();
        var claims = new List<ClaimDTO>();
        var requestBody = new ClaimsRequestBody(userId, CommonAppConstants.ApplicationName);
        var result = await _httpClient.PostAsJsonAsync(LicenseApiEndpoints.Claims, requestBody);
        result.EnsureSuccessStatusCode();
        var claimResult = await result.Content.ReadFromJsonAsync<ICollection<ClaimDTO>>();
        if (claimResult is not null)
        {
            claims.AddRange(claimResult);
        }
        return claims;
    }
}
