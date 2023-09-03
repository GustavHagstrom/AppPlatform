namespace BidConReport.Shared.DTOs.BidconAccess;
public class ResourceFactorDto 
{
    public Guid EstimationId { get; set; }
    public required int ResourceType { get; set; }
    public required double Factor { get; set; }
}
