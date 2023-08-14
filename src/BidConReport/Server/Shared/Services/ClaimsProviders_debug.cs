using SharedPlatformLibrary.Constants;
using SharedPlatformLibrary.DTOs;
using System.Security.Claims;

namespace BidConReport.Server.Shared.Services;

public class ClaimsProvider_debug : IClaimsProvider
{
    private readonly IOrganizationService _organizationService;

    public string Role { get; set; } = "admin";
    public string License { get; set; } = "debug_license";
    public ClaimsProvider_debug(IOrganizationService organizationService)
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
