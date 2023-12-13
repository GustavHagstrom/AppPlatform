//using SharedLibrary.DTOs;
//using SharedLibrary.Wrappers;

//namespace Server.Services.Authentication;

//public class ClaimsService : IClaimsService
//{
//    private readonly IHttpClientWrapper _httpClient;

//    public ClaimsService(IHttpClientWrapper httpClient)
//    {
//        _httpClient = httpClient;
//    }
//    public async Task<ICollection<ClaimDto>> GetClaimsAsync(string userId)
//    {
//        throw new NotImplementedException();
//        //var claims = new List<ClaimDto>();
//        //var requestBody = new ClaimsRequestBody(userId, CommonAppConstants.ApplicationName);
//        //var result = await _httpClient.PostAsJsonAsync(LicenseApiEndpoints.Claims, requestBody);
//        //result.EnsureSuccessStatusCode();
//        //var claimResult = await result.Content.ReadFromJsonAsync<ICollection<ClaimDTO>>();
//        //if (claimResult is not null)
//        //{
//        //    claims.AddRange(claimResult);
//        //}
//        //return claims;
//    }
//}
