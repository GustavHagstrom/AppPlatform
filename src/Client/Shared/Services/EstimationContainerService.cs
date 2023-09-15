using SharedLibrary.DTOs;
using SharedLibrary.DTOs.BidconAccess;

namespace Client.Shared.Services;

public class EstimationContainerService : IEstimationContainerService
{
    public ICollection<BC_EstimationBatchDto> ImportedEstimations { get; set; } = new HashSet<BC_EstimationBatchDto>();
}
