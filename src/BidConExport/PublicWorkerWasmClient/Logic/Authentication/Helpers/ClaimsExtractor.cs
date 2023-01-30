using SharedLibrary.Authentication;
using SharedLibrary.Models;
using System.Security.Claims;

namespace PublicWorkerWasmClient.Authentication.Helpers;
public static class ClaimsExtractor
{
    public static string GetFirstName(ClaimsPrincipal user)
    {
        return user.Claims.Where(x => x.Type == CustomClaimTypes.FirstName).Select(x => x.Value).FirstOrDefault() ?? string.Empty;
    }
    public static string GetLastName(ClaimsPrincipal user)
    {
        return user.Claims.Where(x => x.Type == CustomClaimTypes.LastName).Select(x => x.Value).FirstOrDefault() ?? string.Empty;
    }
    public static IEnumerable<string> GetRoles(ClaimsPrincipal user)
    {
        var rolesString = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        if (rolesString is not null)
        {
            var roles = rolesString.Replace("[", string.Empty).Replace("]", string.Empty).Replace("\"", string.Empty).Split(",");
            foreach (var role in roles)
            {
                yield return role;
            }
        }
    }
    public static string GetEmail(ClaimsPrincipal user)
    {
        return user.Claims.Where(x => x.Type == ClaimTypes.Email).Select(x => x.Value).First();
    }
}
