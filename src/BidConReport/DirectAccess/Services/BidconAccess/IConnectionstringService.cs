namespace BidConReport.BidconDatabaseAccess.Services.BidconAccess;

public interface IConnectionstringService
{
    Task<string> BuildAsync();
}