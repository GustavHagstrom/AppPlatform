namespace BidConReport.Server.Services.Settings;

public interface IDarkModeService
{
    Task<bool> GetUserDarkModeSettingAsync(string userId);
    Task SetUserDarkModeSettingAsync(string userId, bool isDarkMode);
}