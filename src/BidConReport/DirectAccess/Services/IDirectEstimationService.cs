using BidConReport.DirectAccess.Enteties;

namespace BidConReport.DirectAccess.Services;
public interface IDirectEstimationService
{
    Task<Estimation> GetEstimationAsync(string estimationId);
    Task<IEnumerable<Estimation>> GetEstimationsAsync(IEnumerable<string> estimationIds);
}