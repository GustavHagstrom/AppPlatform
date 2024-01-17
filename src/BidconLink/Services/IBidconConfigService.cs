namespace AppPlatform.BidconLink.Services;

public interface IBidconConfigService
{
    Dictionary<string, string> ConfigMap();
    string ConfigPath();
    string IniPath();
}
