using AppPlatform.Shared.DTOs.BidconAccess;
using AppPlatform.Server.EstimationProcessing.Models;

namespace AppPlatform.Server.EstimationProcessing.Services;
public interface IEstimationBuilderService
{
    Estimation Build(BC_EstimationBatchDto batch);
}