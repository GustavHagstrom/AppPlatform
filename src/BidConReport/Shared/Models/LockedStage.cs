namespace BidConReport.Shared.Models;
public class LockedStage
{
    public string Name { get; set; } = string.Empty;
    public List<EstimationItem> Items { get; set; } = new();
}
