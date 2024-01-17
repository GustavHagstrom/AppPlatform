using SharedLibrary.DTOs;
using SharedLibrary.DTOs.BidconAccess;

namespace AppPlatform.Server.Services;

public class EstimationContainerService : IEstimationContainerService
{
    public ICollection<BC_EstimationBatchDto> ImportedEstimations { get; set; } = new HashSet<BC_EstimationBatchDto>();
}
