using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Models;
using IdentityServer.Data;
using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentityServer;

public class CustomProfileService : ProfileService<ApplicationUser>
{

    public CustomProfileService(UserManager<ApplicationUser> userManager, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory) : base(userManager, claimsFactory)
    {

    }
    protected override async Task GetProfileDataAsync(ProfileDataRequestContext context, ApplicationUser user)
    {
        var principal = await GetUserClaimsAsync(user);
        var id = (ClaimsIdentity)principal.Identity;
        if (user.Orginization is not null)
        {
            id.AddClaim(new Claim("organization", user.Orginization.Name));
        }
        context.AddRequestedClaims(principal.Claims);
    }
}
