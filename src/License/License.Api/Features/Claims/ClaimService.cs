using License.Api.Shared.Enteties;
using LicenseLibrary;
using Microsoft.EntityFrameworkCore;
using SharedPlatformLibrary.Constants;
using System.Security.Claims;

namespace License.Api.Features.Claims;
public class ClaimService : IClaimService
{
    private readonly LicenseDbContext _dbContext;

    public ClaimService(LicenseDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public  async Task<ICollection<KeyValuePair<string, string>>> GetCustomClaims(string userId, string applicationName)
    {
        var user = await _dbContext.Users.Where(x => x.Id == userId).Include(x => x.Roles).FirstOrDefaultAsync();
        var claims = new List<KeyValuePair<string, string>>();
        if (user is not null)
        {
            var roles = user.Roles.Select(x => new KeyValuePair<string, string>(ClaimTypes.Role, x.Name));
            claims.AddRange(roles);
            claims.Add(new KeyValuePair<string, string>(CustomClaimConstants.Organization, user.OrganizationName));
        }
        return claims;
    }
}
