using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using AppPlatform.Core.Data;
using AppPlatform.Core.Enteties;
using AppPlatform.Core.Constants;
using System.Security.Claims;

namespace AppPlatform.Server.Components.Features.Authentication;

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
        var organization = await dbContext.Organizations.FindAsync(user.ActiveOrganizationId);
        
        identity.AddClaim(new Claim("ValidSubscription_ChangeToConstant", organization?.IsExpired.ToString() ?? false.ToString()));
        
        
        return identity;
    }
}
