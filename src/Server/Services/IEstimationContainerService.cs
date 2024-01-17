using AppPlatform.Shared.DTOs;
using AppPlatform.Shared.DTOs.BidconAccess;

namespace AppPlatform.Server.Services;
public interface IEstimationContainerService
{
    ICollection<BC_EstimationBatchDto> ImportedEstimations { get; set; }
}