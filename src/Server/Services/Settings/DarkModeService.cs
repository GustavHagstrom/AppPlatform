using Server.Data;
using Server.Extensions;
using System.Security.Claims;

namespace Server.Services.Settings;

public class DarkModeService(ApplicationDbContext DbContext) : IDarkModeService
{
    public async Task<bool> GetAsync(ClaimsPrincipal user)
    {
        var result = await DbContext.Users.FindAsync(user.GetUserId());
        return result?.IsDarkMode ?? false;
    }
    public async Task SetAsync(ClaimsPrincipal user, bool isDarkMode)
    {
        (await DbContext.Users.FindAsync(user.GetUserId()))
            ?.Apply(x => x.IsDarkMode = isDarkMode);
        await DbContext.SaveChangesAsync();
    }
}
