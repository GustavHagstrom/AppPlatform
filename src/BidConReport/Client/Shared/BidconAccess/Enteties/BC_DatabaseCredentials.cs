namespace BidConReport.Client.Shared.BidconAccess.Enteties;

public record BC_DatabaseCredentials(string Server, string Databse, string User, string PwHash, bool ServerAuthentication);