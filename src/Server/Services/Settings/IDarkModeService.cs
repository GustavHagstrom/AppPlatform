using System.Security.Claims;

namespace Server.Services.Settings;

public interface IDarkModeService
{
    Task<bool> GetAsync(ClaimsPrincipal user);
    Task SetAsync(ClaimsPrincipal user, bool isDarkMode);
}