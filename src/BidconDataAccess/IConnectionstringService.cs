namespace BidconDataAccess;

public interface IConnectionstringService
{
    Task<string> BuildAsync(string? organization);
}