namespace BidConReport.BidconAccess.Enteties;

public record DatabaseCredentials(string Server, string Databse, string User, string PwHash, bool ServerAuthentication);