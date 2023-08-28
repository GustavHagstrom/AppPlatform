using BidConReport.BidconAccess.Enteties;

namespace BidConReport.BidconAccess.Services;
public interface IDatabaseCredentialsService
{
    Task<DatabaseCredentials> GetAsync();
}
