namespace BidConReport.DirectAccess.Services;

public interface IConnectionStringBuilder
{
    Task<string> BuildAsync();
}