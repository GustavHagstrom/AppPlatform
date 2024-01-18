using AppPlatform.Server.EstimationProcessing.Models;
using AppPlatform.Core.DTOs.BidconAccess;

namespace AppPlatform.Server.EstimationProcessing.Services;
public interface IEstimationBuilderService
{
    Estimation Build(BC_EstimationBatchDto batch);
}