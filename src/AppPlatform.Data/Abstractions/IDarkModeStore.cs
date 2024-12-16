using AppPlatform.Core.Models;
using System.Security.Claims;

namespace AppPlatform.Data.Abstractions;

public interface IDarkModeStore
{
    Task<bool> GetAsync(ClaimsPrincipal user);
    Task SetAsync(ClaimsPrincipal user, bool isDarkMode);
}