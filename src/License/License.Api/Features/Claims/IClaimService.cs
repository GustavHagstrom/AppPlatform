using SharedPlatformLibrary.Enteties;

namespace License.Api.Features.Claims;
public interface IClaimService
{
    Task<ICollection<ClaimModel>> GetCustomClaims(string userId, string applicationName, string organizationName);
}
