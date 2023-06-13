using SharedPlatformLibrary.Enteties;
using SharedPlatformLibrary.HttpRequests;

namespace License.Api.Features.Claims;
public interface IClaimService
{
    Task<ICollection<ClaimModel>> GetCustomClaims(ClaimsRequestBody claimsRequestBody);
}
