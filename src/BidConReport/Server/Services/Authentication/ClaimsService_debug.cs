using BidConReport.Server.Services.Settings;
using SharedPlatformLibrary.Constants;
using SharedPlatformLibrary.DTOs;
using System.Security.Claims;

namespace BidConReport.Server.Services.Authentication;

public class ClaimsService_debug : IClaimsService
{
    private readonly IOrganizationService _organizationService;

    public string Role { get; set; } = "admin";
    public string License { get; set; } = "debug_license";
    public ClaimsService_debug(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }

    public async Task<ICollection<ClaimDTO>> GetClaimsAsync(string userId)
    {
        var currentOrg = await _organizationService.GetCurrent(userId);
        var claims = new List<ClaimDTO>
        {
            new ClaimDTO(ClaimTypes.Role, Role),
            new ClaimDTO(CustomClaimTypes.License, License ),
            new ClaimDTO(CustomClaimTypes.CurrentOrganizationId, currentOrg.Id),
        };

        return claims;
    }
}
