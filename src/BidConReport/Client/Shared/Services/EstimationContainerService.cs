using BidConReport.Shared.DTOs;
using BidConReport.Shared.DTOs.BidconAccess;

namespace BidConReport.Client.Shared.Services;

public class EstimationContainerService : IEstimationContainerService
{
    public ICollection<BC_EstimationBatchDto> ImportedEstimations { get; set; } = new HashSet<BC_EstimationBatchDto>();
}
