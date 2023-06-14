using SharedPlatformLibrary.Constants;
using SharedPlatformLibrary.Enteties;
using System.Security.Claims;

namespace BidConReport.Server.Features.Claims;

public class ClaimsProvider_debug : IClaimsProvider
{
    private readonly string _role = "admin";
    private readonly string _organization = "debug_organization";
    private readonly string _license = "debug_license";

    public Task<ICollection<ClaimModel>> GetClaimsAsync(string userId)
    {
        var claims = new List<ClaimModel>
        {
            new ClaimModel(ClaimTypes.Role, _role),
            new ClaimModel(CustomClaimTypes.Organization, _organization),
            new ClaimModel(CustomClaimTypes.License, _license ),
        };

        return Task.FromResult<ICollection<ClaimModel>>(claims);
    }
}
