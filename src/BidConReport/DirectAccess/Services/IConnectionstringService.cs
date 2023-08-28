namespace BidConReport.BidconAccess.Services;

public interface IConnectionstringService
{
    Task<string> BuildAsync();
}