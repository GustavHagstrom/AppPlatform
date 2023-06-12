namespace License.Api.Features.Claims;
public interface IClaimService
{
    Task<ICollection<KeyValuePair<string, string>>> GetCustomClaims(string userId, string applicationName, string organizationName);
}
