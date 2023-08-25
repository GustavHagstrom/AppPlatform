namespace BidConReport.BidconAccess.Services.BidconAccess;

public interface IConnectionstringService
{
    Task<string> BuildAsync();
}