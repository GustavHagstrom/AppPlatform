using BidConReport.Shared.Enums;
using SharedPlatformLibrary.Constants;
using SharedPlatformLibrary.DTOs;

namespace BidConReport.Server.Services.Authentication;

public class ClaimsService_debug : IClaimsService
{
    public string License { get; set; } = "debug_license";


    public async Task<ICollection<ClaimDTO>> GetClaimsAsync(string userId)
    {
        var claims = new List<ClaimDTO>
        {
            new ClaimDTO(CustomClaimTypes.License, License)
        };
        foreach (var right in Enum.GetValues(typeof(ApplicationRight)))
        {
            claims.Add(new ClaimDTO(CustomClaimTypes.ApplicationRight, ((int)right).ToString()));
        }

        return await Task.FromResult(claims);
    }
}
