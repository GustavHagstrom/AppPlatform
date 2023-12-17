using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Server.Enteties;
using SharedLibrary.Constants;
using System.Security.Claims;

namespace Server.Components.Features.Authentication;

public class CustomClaimsPrincipalFactory(UserManager<User> userManager, IOptions<IdentityOptions> optionsAccessor)
    : UserClaimsPrincipalFactory<User>(userManager, optionsAccessor)
{
    public override Task<ClaimsPrincipal> CreateAsync(User user)
    {
        return base.CreateAsync(user);
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
    {
        var identity = await base.GenerateClaimsAsync(user);
        var organizationId = user.ActiveOrganizationId.ToString();
        if(!string.IsNullOrWhiteSpace(organizationId))
        {
            identity.AddClaim(new Claim(AuthenticationConstants.OrganizationIdClaim, organizationId));
        }
        identity.AddClaim(new Claim("testClaim", "bajskorv"));
        return identity;
    }
}
