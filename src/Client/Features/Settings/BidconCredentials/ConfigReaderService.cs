using SharedLibrary.DTOs.BidconAccess;
using Microsoft.AspNetCore.Components.Forms;
using System.Xml.Linq;

namespace Client.Features.Settings.BidconSettings.BicdonCredentials;

public class ConfigReaderService : IConfigReaderService
{
    private const string DBMode = "DBMode";

    private const string CentralEstimationServerName = "CentralEstimationServerName";
    private const string CentralEstimationDatabaseName = "CentralEstimationDatabaseName";
    private const string CentralEstimationDatabaseUserId = "CentralEstimationDatabaseUserId";
    private const string CentralEstimationDatabasePassword = "CentralEstimationDatabasePassword";

    private const string LocalEstimationServerName = "LocalEstimationServerName";
    private const string LocalEstimationDatabaseName = "LocalEstimationDatabaseName";
    private const string LocalEstimationDatabaseUserId = "LocalEstimationDatabaseUserId";
    private const string LocalEstimationDatabasePassword = "LocalEstimationDatabasePassword";

    private const string SqlServerAuthenticationMode = "SqlServerAuthenticationMode";

    public async Task<BC_DatabaseCredentialsDto?> ReadCredentialsAsync(IBrowserFile browserFile)
    {
        var fileString = await GetFileStringAsync(browserFile);

        var doc = XDocument.Parse(fileString);
        var settingsElement = doc?.Descendants("appSettings").FirstOrDefault();
        if (settingsElement is null) return null;

        var keyValuePairs = settingsElement.Elements("add")
            .Select(x => new KeyValuePair<string, string>(x.Attribute("key")!.Value, x.Attribute("value")!.Value));
        var map = new Dictionary<string, string>(keyValuePairs);
        var requirePassword = map[SqlServerAuthenticationMode].Trim() == "1";
        var dbMode = map[DBMode].Trim();

        if (dbMode == "1")
        {
            return new BC_DatabaseCredentialsDto(
                map[CentralEstimationServerName],
                map[CentralEstimationDatabaseName],
                map[CentralEstimationDatabaseUserId],
                map[CentralEstimationDatabasePassword],
                true,
                requirePassword);
        }
        else
        {
            return new BC_DatabaseCredentialsDto(
                map[LocalEstimationServerName],
                map[LocalEstimationDatabaseName],
                map[LocalEstimationDatabaseUserId],
                map[LocalEstimationDatabasePassword],
                true,
                requirePassword);
        }
    }
    private async Task<string> GetFileStringAsync(IBrowserFile browserFile)
    {
        using (var stream = browserFile.OpenReadStream())
        using (var reader = new StreamReader(stream))
        {
            var fileString = await reader.ReadToEndAsync();
            return fileString;
        }
    }
}
