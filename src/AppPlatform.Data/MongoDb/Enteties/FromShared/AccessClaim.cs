using AppPlatform.Core.Constants;
using System.Security.Claims;

namespace AppPlatform.Data.MongoDb.Enteties.FromShared;
public class AccessClaim : Claim
{
    public AccessClaim(string value) : base(SharedApplicationClaimTypes.AccessClaim, value)
    {

    }
}
