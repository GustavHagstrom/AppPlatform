using AppPlatform.Core.Enteties.EstimationEnteties;

namespace AppPlatform.BidconDatabaseAccess.Services;
public interface IBidconAccess
{
    Task<IEnumerable<Estimation>> GetEstimationListAsync();

}
