using BidConReport.BidconDatabaseAccess.Enteties;

namespace BidConReport.BidconDatabaseAccess.Services;
public interface IDirectEstimationService
{
    Task<Estimation> GetEstimationAsync(string estimationId);
    Task<List<Estimation>> GetEstimationsAsync(IEnumerable<string> estimationIds);
}