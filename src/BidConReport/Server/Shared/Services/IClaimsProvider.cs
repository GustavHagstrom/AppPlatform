using SharedPlatformLibrary.Enteties;

namespace BidConReport.Server.Shared.Services;
public interface IClaimsProvider
{
    Task<ICollection<ClaimModel>> GetClaimsAsync(string userId);
}