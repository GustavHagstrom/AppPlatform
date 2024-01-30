using Microsoft.EntityFrameworkCore;
using AppPlatform.Core.Data;
using AppPlatform.Core.Extensions;
using System.Security.Claims;
using AppPlatform.Core.Enteties;

namespace AppPlatform.Core.Services.Settings;

public class DarkModeService(IDbContextFactory<ApplicationDbContext> ContextFactory) : IDarkModeService
{
    public async Task<bool> GetAsync(ClaimsPrincipal user)
    {
        var dbContext = ContextFactory.CreateDbContext();
        var result = await dbContext.UserSettings.FindAsync(user.GetUserId());
        return result?.IsDarkMode ?? false;
    }
    public async Task SetAsync(ClaimsPrincipal user, bool isDarkMode)
    {
        var userId = user.GetUserId();
        if (userId is null)
        {
            return;
        }
        var dbContext = ContextFactory.CreateDbContext();
        var userSettings = await dbContext.UserSettings.FindAsync(user.GetUserId());
        if (userSettings is null)
        {
            userSettings = new UserSettings
            {
                UserId = userId,
                IsDarkMode = isDarkMode
            };
            dbContext.UserSettings.Add(userSettings);
        }
        else
        {
            userSettings.IsDarkMode = isDarkMode;
        }
        await dbContext.SaveChangesAsync();
    }
}
