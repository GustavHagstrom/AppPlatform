namespace BidConReport.Client.Shared.Services;

public interface IDarkModeService
{
    Task<bool> GetUserDarkModeSettingAsync();
    Task SetUserDarkModeSettingAsync(string userId, bool isDarkMode);
}