namespace BidConReport.Server.Features.DarkMode;

public interface IDarkModeService
{
    Task<bool> GetUserDarkModeSettingAsync(string userId);
    Task SetUserDarkModeSettingAsync(string userId, bool isDarkMode);
}