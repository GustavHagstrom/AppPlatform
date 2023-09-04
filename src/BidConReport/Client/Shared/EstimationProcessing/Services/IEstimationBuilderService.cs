using BidConReport.Client.Shared.BidconAccess.Enteties;
using BidConReport.Client.Shared.EstimationProcessing.Models;

namespace BidConReport.Client.Shared.EstimationProcessing.Services;
public interface IEstimationBuilderService
{
    Estimation Build(EstimationBatch batch);
}