namespace BidConReport.DirectAccess.Services;

internal interface IConnectionStringBuilder
{
    Task<string> BuildAsync();
}