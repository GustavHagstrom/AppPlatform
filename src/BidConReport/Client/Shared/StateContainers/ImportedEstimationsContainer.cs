using BidConReport.Shared.DTOs;

namespace BidConReport.Client.Shared.StateContainers;

public class ImportedEstimationsContainer
{
    public ICollection<EstimationDTO> ImportedEstimations { get; set; } = new HashSet<EstimationDTO>();
}
