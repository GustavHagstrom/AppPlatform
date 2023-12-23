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
    ApplicationDbContext dbContext)
    : UserClaimsPrincipalFactory<User>(userManager, optionsAccessor)
{
    public override Task<ClaimsPrincipal> CreateAsync(User user)
    {
        return base.CreateAsync(user);
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
    {
        var identity = await base.GenerateClaimsAsync(user);
        //var organizationId = user.ActiveOrganizationId.ToString();
        //var organizationName = user.ActiveOrganization?.Name;
        //if (!string.IsNullOrWhiteSpace(organizationId))
        //{
        //    identity.AddClaim(new Claim(AuthenticationConstants.OrganizationIdClaim, organizationId));
        //}
        var organization = await dbContext.Organizations.FindAsync(user.ActiveOrganizationId);
        if (organization is not null)
        {
            identity.AddClaim(new Claim(AuthenticationConstants.OrganizationIdClaim, organization.Id.ToString()));
            identity.AddClaim(new Claim(AuthenticationConstants.OrganizationNameClaim, organization.Name));
        }
        return identity;
    }
}
