using BidConReport.Server.Services.Settings;
using SharedPlatformLibrary.Constants;
using SharedPlatformLibrary.DTOs;
using System.Security.Claims;

namespace BidConReport.Server.Services.Authentication;

public class ClaimsService_debug : IClaimsService
{

    public string Role { get; set; } = "admin";
    public string License { get; set; } = "debug_license";


    public async Task<ICollection<ClaimDTO>> GetClaimsAsync(string userId)
    {
        var claims = new List<ClaimDTO>
        {
            new ClaimDTO(ClaimTypes.Role, Role),
            new ClaimDTO(CustomClaimTypes.License, License ),
        };

        return await Task.FromResult(claims);
    }
}
