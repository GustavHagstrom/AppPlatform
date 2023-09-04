namespace BidConReport.Client.Shared.BidconAccess.Services;

public interface IConnectionstringService
{
    Task<string> BuildAsync();
}