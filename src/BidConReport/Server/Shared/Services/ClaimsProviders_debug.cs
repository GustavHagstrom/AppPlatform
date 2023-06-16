using SharedPlatformLibrary.Constants;
using SharedPlatformLibrary.Enteties;
using System.Security.Claims;

namespace BidConReport.Server.Shared.Services;

public class ClaimsProvider_debug : IClaimsProvider
{
    private readonly string _role = "admin";
    private readonly string _organization = "debug_organizationId";
    private readonly string _organization2 = "debug_organizationId_2";
    private readonly string _currentOrganization = "debug_organizationId";
    private readonly string _license = "debug_license";

    public Task<ICollection<ClaimModel>> GetClaimsAsync(string userId)
    {
        var claims = new List<ClaimModel>
        {
            new ClaimModel(ClaimTypes.Role, _role),
            new ClaimModel(CustomClaimTypes.OrganizationMemberOf, _organization),
            new ClaimModel(CustomClaimTypes.OrganizationMemberOf, _organization2),
            new ClaimModel(CustomClaimTypes.License, _license ),
            new ClaimModel(CustomClaimTypes.CurrentOrganization, _currentOrganization ),
        };

        return Task.FromResult<ICollection<ClaimModel>>(claims);
    }
}
