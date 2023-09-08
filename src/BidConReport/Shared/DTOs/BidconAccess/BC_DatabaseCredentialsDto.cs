namespace BidConReport.Shared.DTOs.BidconAccess;

public record BC_DatabaseCredentialsDto(string Server, string Database, string User, string PasswordHash, bool ServerAuthentication, DateTime? LastUpdated = null);