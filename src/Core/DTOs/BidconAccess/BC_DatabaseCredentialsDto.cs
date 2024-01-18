namespace AppPlatform.Core.DTOs.BidconAccess;

public record BC_DatabaseCredentialsDto(
    string Server, 
    string Database, 
    string User, 
    string Password,
    bool ServerAuthentication,
    bool UseDesktopBidconLink,
DateTime? LastUpdated = null);