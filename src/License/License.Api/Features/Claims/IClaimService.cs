using SharedPlatformLibrary.DTOs;
using SharedPlatformLibrary.HttpRequests;

namespace License.Api.Features.Claims;
public interface IClaimService
{
    Task<ICollection<ClaimDTO>> GetCustomClaims(ClaimsRequestBody claimsRequestBody);
}
