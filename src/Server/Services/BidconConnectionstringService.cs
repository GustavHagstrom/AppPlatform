using BidconDataAccess;
using Server.Services.Settings;

namespace Server.Services;

public class BidconConnectionstringService : IConnectionstringService
{
    private readonly IBidconCredentialsService _bidconCredentialsService;

    public BidconConnectionstringService(IBidconCredentialsService bidconCredentialsService)
    {
        _bidconCredentialsService = bidconCredentialsService;
    }
    public async Task<string> BuildAsync(string? organization)
    {
        ArgumentException.ThrowIfNullOrEmpty(organization);

        var credentials = await _bidconCredentialsService.GetAsync(organization);

        ArgumentNullException.ThrowIfNull(credentials);
        ArgumentException.ThrowIfNullOrEmpty(credentials.Server);
        ArgumentException.ThrowIfNullOrEmpty(credentials.Database);
        if (credentials.ServerAuthentication)
        {
            ArgumentException.ThrowIfNullOrEmpty(credentials.User);
            ArgumentException.ThrowIfNullOrEmpty(credentials.Password);
        }
        return credentials.ServerAuthentication
            ? $"Data Source={credentials.Server};Initial Catalog={credentials.Database}; Connect Timeout = 60;uid={credentials.User};pwd={credentials.Password};TrustServerCertificate=True"
            : $"Data Source={credentials.Server};Initial Catalog={credentials.Database}; Connect Timeout = 60;Integrated security=true;TrustServerCertificate=True;Encrypt=False;Multi Subnet Failover=False";
    }


}
