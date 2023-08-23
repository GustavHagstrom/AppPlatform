namespace BidConReport.BidconDatabaseAccess.Services;

public interface IConnectionstringService
{
    Task<string> BuildAsync();
}