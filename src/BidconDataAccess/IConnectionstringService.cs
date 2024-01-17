namespace AppPlatform.BidconDataAccess;

public interface IConnectionstringService
{
    Task<string> BuildAsync(string? organization);
}