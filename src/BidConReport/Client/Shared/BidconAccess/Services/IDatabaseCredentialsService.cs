using BidConReport.Client.Shared.BidconAccess.Enteties;

namespace BidConReport.Client.Shared.BidconAccess.Services;
public interface IDatabaseCredentialsService
{
    Task<DatabaseCredentials> GetAsync();
}
