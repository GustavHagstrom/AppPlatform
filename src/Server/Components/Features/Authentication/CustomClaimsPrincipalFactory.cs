using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Server.Data;
using Server.Enteties;
using SharedLibrary.Constants;
using System.Security.Claims;

namespace Server.Components.Features.Authentication;

public class CustomClaimsPrincipalFactory(
    UserManager<User> userManager, 
    IOptions<IdentityOptions> optionsAccessor,
    IDbContextFactory<ApplicationDbContext> dbContextFactory)
    : UserClaimsPrincipalFactory<User>(userManager, optionsAccessor)
{
    public override Task<ClaimsPrincipal> CreateAsync(User user)
    {
        return base.CreateAsync(user);
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
    {
        var identity = await base.GenerateClaimsAsync(user);
        var dbContext = dbContextFactory.CreateDbContext();
        var organization = await dbContext.Organizations
            .Include(x => x.License)
            .FirstOrDefaultAsync(x => x.Id == user.ActiveOrganizationId);
        if (organization?.License is not null)
        {
            identity.AddClaim(new Claim("ValidSubscription_ChangeToConstant", (!organization.License.IsExpired).ToString()));
        }
        
        return identity;
    }
}
