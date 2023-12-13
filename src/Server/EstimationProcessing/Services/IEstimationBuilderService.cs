using SharedLibrary.DTOs.BidconAccess;
using Server.EstimationProcessing.Models;

namespace Server.EstimationProcessing.Services;
public interface IEstimationBuilderService
{
    Estimation Build(BC_EstimationBatchDto batch);
}