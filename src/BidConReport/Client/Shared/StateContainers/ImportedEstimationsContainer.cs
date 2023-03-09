using BidConReport.Shared.Models;

namespace BidConReport.Client.Shared.StateContainers;

public class ImportedEstimationsContainer
{
    public ICollection<Estimation> ImportedEstimations { get; set; } = new HashSet<Estimation>();
}
