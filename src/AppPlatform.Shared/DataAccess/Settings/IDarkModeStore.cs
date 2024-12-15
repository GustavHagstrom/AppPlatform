using System.Security.Claims;

namespace AppPlatform.Shared.DataAccess.Settings;

public interface IDarkModeStore
{
    Task<bool> GetAsync(ClaimsPrincipal user);
    Task SetAsync(ClaimsPrincipal user, bool isDarkMode);
}