using SharedPlatformLibrary.DTOs;

namespace BidConReport.Server.Shared.Services;
public interface IClaimsProvider
{
    Task<ICollection<ClaimDTO>> GetClaimsAsync(string userId);
}