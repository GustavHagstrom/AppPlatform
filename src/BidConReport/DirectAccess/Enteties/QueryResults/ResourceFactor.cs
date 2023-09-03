namespace BidConReport.BidconAccess.Enteties.QueryResults;
public class ResourceFactor
{
    public Guid EstimationId { get; set; }
    public required int ResourceType { get; set; }
    public required double Factor { get; set; }
}
