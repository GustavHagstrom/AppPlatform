namespace BidConReport.DirectAccess.Enteties;

public record DatabaseCredentials(string Server, string Databse, string User, string PwHash, bool ServerAuthentication);