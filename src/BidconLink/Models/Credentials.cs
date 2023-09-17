namespace BidconLink.Models;

public record Credentials(string Server, string Database, string User, string PasswordHash, bool ServerAuthentication, DateTime? LastUpdated = null);
