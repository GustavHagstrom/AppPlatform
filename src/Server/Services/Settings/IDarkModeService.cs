using System.Security.Claims;

namespace AppPlatform.Server.Services.Settings;

public interface IDarkModeService
{
    Task<bool> GetAsync(ClaimsPrincipal user);
    Task SetAsync(ClaimsPrincipal user, bool isDarkMode);
}