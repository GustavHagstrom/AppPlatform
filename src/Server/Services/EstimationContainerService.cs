using AppPlatform.Shared.DTOs;
using AppPlatform.Shared.DTOs.BidconAccess;

namespace AppPlatform.Server.Services;

public class EstimationContainerService : IEstimationContainerService
{
    public ICollection<BC_EstimationBatchDto> ImportedEstimations { get; set; } = new HashSet<BC_EstimationBatchDto>();
}
