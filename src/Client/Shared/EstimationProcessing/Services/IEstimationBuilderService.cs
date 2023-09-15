using SharedLibrary.DTOs.BidconAccess;
using Client.Shared.EstimationProcessing.Models;

namespace Client.Shared.EstimationProcessing.Services;
public interface IEstimationBuilderService
{
    Estimation Build(BC_EstimationBatchDto batch);
}