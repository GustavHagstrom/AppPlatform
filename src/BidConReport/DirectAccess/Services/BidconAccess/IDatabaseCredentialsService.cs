using BidConReport.BidconAccess.Enteties;

namespace BidConReport.BidconAccess.Services.BidconAccess;
public interface IDatabaseCredentialsService
{
    Task<DatabaseCredentials> GetAsync();
}
