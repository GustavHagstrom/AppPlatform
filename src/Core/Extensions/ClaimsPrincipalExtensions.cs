using AppPlatform.Core.Constants;
using System.Security.Claims;

namespace AppPlatform.Core.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string? GetUserId(this ClaimsPrincipal userPrincipal)
    {
        return userPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}
