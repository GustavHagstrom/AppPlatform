using SharedPlatformLibrary.Constants;
using SharedPlatformLibrary.Enteties;
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

    public async Task<ICollection<ClaimModel>> GetClaimsAsync(string userId)
    {
        var currentOrg = await _organizationService.GetCurrent(userId);
        var claims = new List<ClaimModel>
        {
            new ClaimModel(ClaimTypes.Role, Role),
            new ClaimModel(CustomClaimTypes.License, License ),
            new ClaimModel(CustomClaimTypes.CurrentOrganizationId, currentOrg.Id),
        };

        return claims;
    }
}
