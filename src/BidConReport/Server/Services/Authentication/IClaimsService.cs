using SharedPlatformLibrary.DTOs;

namespace BidConReport.Server.Services.Authentication;
public interface IClaimsService
{
    Task<ICollection<ClaimDTO>> GetClaimsAsync(string userId);
}