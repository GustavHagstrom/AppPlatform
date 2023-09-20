namespace SharedLibrary.DTOs.BidconAccess;

public record BC_DatabaseCredentialsDto(
    string Server, 
    string Database, 
    string User, 
    string PasswordHash,
    bool ServerAuthentication,
    bool UseDesktopBidconLink,
DateTime? LastUpdated = null);