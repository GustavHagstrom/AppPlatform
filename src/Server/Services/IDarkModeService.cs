namespace Server.Services;

public interface IDarkModeService
{
    Task<bool> GetUserDarkModeSettingAsync();
    Task SetUserDarkModeSettingAsync(bool isDarkMode);
}