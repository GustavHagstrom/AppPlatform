using LicenseLibrary;
using Microsoft.EntityFrameworkCore;
using SharedPlatformLibrary.Constants;
using SharedPlatformLibrary.Enteties;
using System.Security.Claims;

namespace License.Api.Features.Claims;
public class ClaimService : IClaimService
{
    private readonly LicenseDbContext _dbContext;

    public ClaimService(LicenseDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public  async Task<ICollection<ClaimModel>> GetCustomClaims(string userId, string applicationName, string organizationName)
    {
        var user = await _dbContext.Users
            .Where(x => x.Id == userId)
            .Include(x => x.Roles)
            .Include(x => x.Organizations)
            .Include(x => x.Licenses)
            .FirstOrDefaultAsync();

        var claims = new List<ClaimModel>();
        if (user is not null)
        {
            var roles = user.Roles
                .Select(x => new ClaimModel(ClaimTypes.Role, x.Name));
            var orgs = user.Organizations
                .Select(x => new ClaimModel(CustomClaimConstants.Organization, x.Name));
            var licenses = user.Licenses
                .Where(x => x.OrganizationName == organizationName && x.ApplicationName == applicationName) 
                .Select(x => new ClaimModel(CustomClaimConstants.License, x.Id.ToString()));

            claims.AddRange(roles);
            claims.AddRange(orgs);
            claims.AddRange(licenses);
        }
        return claims;
    }
}
