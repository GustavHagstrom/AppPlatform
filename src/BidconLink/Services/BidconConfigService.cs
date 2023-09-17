using BidconLink.Constants;
using System.Xml.Linq;

namespace BidconLink.Services;

public class BidconConfigService : IBidconConfigService
{
    public Dictionary<string, string> ConfigMap() //converts the bidcon config file to a dictionary
    {
        var configPath = ConfigPath();
        var doc = XDocument.Parse(File.ReadAllText(configPath));
        var settingsElement = doc?.Descendants("appSettings").FirstOrDefault();
        ArgumentNullException.ThrowIfNull(settingsElement);
        var keyValuePairs = settingsElement.Elements("add")
            .Select(x => new KeyValuePair<string, string>(x.Attribute("key")!.Value, x.Attribute("value")!.Value));
        var map = new Dictionary<string, string>(keyValuePairs);
        return map;
    }

    public string ConfigPath() //Path to where the config file should be located
    {
        var iniFilePath = IniPath();
        var builder = new ConfigurationBuilder().AddIniFile(iniFilePath); // Load the INI file
        var configuration = builder.Build();
        var configPath = $"{configuration.GetValue<string>(InitConstants.ConfigFilePathKey)}{ConfigConstants.ConfigFileName}";
        ArgumentException.ThrowIfNullOrEmpty(configPath);
        return configPath;
    }

    public string IniPath() //Path to bidcon ini file where the path to the used config file should be located
    {
        var iniPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), InitConstants.InitFileName);
        return iniPath;
    }
}
