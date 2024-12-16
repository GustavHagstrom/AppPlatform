using AppPlatform.Core.Constants;
using System.Security.Claims;

namespace AppPlatform.Core.Models.FromShared;
public class AccessClaim : Claim
{
    public AccessClaim(string value) : base(SharedApplicationClaimTypes.AccessClaim, value)
    {

    }
}
