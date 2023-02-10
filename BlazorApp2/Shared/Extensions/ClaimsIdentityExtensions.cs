using System.Security.Claims;

namespace BidConReport.Shared.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string GetMicrosoftName(this ClaimsPrincipal principal)
    {
        return GetClaimValueOfType("name", principal);
    }
    public static string GetMicrosoftGivenName(this ClaimsPrincipal principal)
    {
        return GetClaimValueOfType("givenname", principal);
    }
    public static string GetMicrosoftSurName(this ClaimsPrincipal principal)
    {
        return GetClaimValueOfType("surname", principal);
    }
    public static string GetMicrosoftNameIdentifier(this ClaimsPrincipal principal)
    {
        return GetClaimValueOfType("nameidentifier", principal);
    }
    public static string GetMicrosoftEmail(this ClaimsPrincipal principal)
    {
        return GetClaimValueOfType("emailaddress", principal);
    }
    private static string GetClaimValueOfType(string type, ClaimsPrincipal principal)
    {
        var claim = principal.Claims.Where(x =>
        {
            var split = x.Type.Split("/");
            return split.Last() == type;
        });
        return claim.Single().Value;
    }
}
