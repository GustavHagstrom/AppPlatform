using AppPlatform.Shared.Constants;
using System.Security.Claims;

namespace AppPlatform.Shared.Models;
public class AccessClaim : Claim
{
    public AccessClaim(string value) : base(SharedApplicationClaimTypes.AccessClaim, value)
    {

    }
}
