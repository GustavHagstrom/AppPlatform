namespace AppPlatform.BidconDatabaseAccess.Models;

public record D_DatabaseCredentials(
    string Server,
    string Database,
    string User,
    string Password,
    bool ServerAuthentication,
    bool UseDesktopBidconLink,
DateTime? LastUpdated = null);