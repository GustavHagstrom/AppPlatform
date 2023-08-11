using BidConReport.Server.Data;

namespace BidConReport.Server.Features.DarkMode;

public class DarkModeService : IDarkModeService
{
    private readonly ApplicationDbContext _dbContext;

    public DarkModeService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> GetUserDarkModeSettingAsync(string userId)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        ArgumentNullException.ThrowIfNull(user);
        return user.IsDarkMode;
    }
    public async Task SetUserDarkModeSettingAsync(string userId, bool isDarkMode)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        ArgumentNullException.ThrowIfNull(user);
        user.IsDarkMode = isDarkMode;
        await _dbContext.SaveChangesAsync();
    }
}
