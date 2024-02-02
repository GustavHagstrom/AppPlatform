namespace AppPlatform.BidconDataAccess.Models;

public record BC_DatabaseCredentials(
    string Server,
    string Database,
    string User,
    string Password,
    bool ServerAuthentication,
    bool UseDesktopBidconLink,
DateTime? LastUpdated = null);