using Microsoft.EntityFrameworkCore;
using AppPlatform.Core.Data;
using AppPlatform.Core.Extensions;
using System.Security.Claims;

namespace AppPlatform.Core.Services.Settings;

public class DarkModeService(IDbContextFactory<ApplicationDbContext> ContextFactory) : IDarkModeService
{
    public async Task<bool> GetAsync(ClaimsPrincipal user)
    {
        var dbContext = ContextFactory.CreateDbContext();
        var result = await dbContext.Users.FindAsync(user.GetUserId());
        return result?.IsDarkMode ?? false;
    }
    public async Task SetAsync(ClaimsPrincipal user, bool isDarkMode)
    {
        var dbContext = ContextFactory.CreateDbContext();
        (await dbContext.Users.FindAsync(user.GetUserId()))
            ?.Apply(x => x.IsDarkMode = isDarkMode);
        await dbContext.SaveChangesAsync();
    }
}
