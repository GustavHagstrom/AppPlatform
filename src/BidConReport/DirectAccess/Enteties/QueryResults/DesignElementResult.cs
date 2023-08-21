namespace BidConReport.DirectAccess.Enteties;
public class DesignElementResult
{
    public required string Id { get; set; }
    public Guid EstimationId { get; set; }
    public required string Unit { get; set; }
}
