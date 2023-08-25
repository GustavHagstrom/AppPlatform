using BidConReport.BidconDatabaseAccess.Enteties;

namespace BidConReport.BidconDatabaseAccess.Services.BidconAccess;
public interface IDatabaseCredentialsService
{
    Task<DatabaseCredentials> GetAsync();
}
