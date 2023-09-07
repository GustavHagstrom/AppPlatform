namespace BidConReport.Shared.DTOs.BidconAccess;

public record BC_DatabaseCredentialsDto(string Server, string Databse, string User, string PasswordHash, bool ServerAuthentication, DateTime? LastUpdated = null);