using BidConReport.DirectAccess.Enteties;

namespace BidConReport.DirectAccess.Services;
public interface IDatabaseCredentialsService
{
    Task<DatabaseCredentials> GetAsync();
}
