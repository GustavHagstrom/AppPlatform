using BidConReport.BidconDatabaseAccess.Enteties;

namespace BidConReport.BidconDatabaseAccess.Services;
public interface IDatabaseCredentialsService
{
    Task<DatabaseCredentials> GetAsync();
}
