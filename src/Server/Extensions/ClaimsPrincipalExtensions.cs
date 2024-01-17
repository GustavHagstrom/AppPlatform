using SharedLibrary.Constants;
using System.Security.Claims;

namespace Server.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string? GetUserId(this ClaimsPrincipal userPrincipal)
    {
        return userPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}
