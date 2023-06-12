using SharedPlatformLibrary.Enteties;

namespace BidConReport.Server.Features.Claims;
public interface IClaimsProvider
{
    Task<ICollection<ClaimModel>> GetClaimsAsync();
}