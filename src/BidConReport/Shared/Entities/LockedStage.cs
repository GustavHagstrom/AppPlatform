namespace BidConReport.Shared.Entities;
public class LockedStage
{
    public required string Name { get; set; }
    public required ICollection<EstimationItem> Items { get; set; }
}
