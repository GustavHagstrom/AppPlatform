namespace BidConReport.SharedLibrary.Models;
public class LockedStage
{
    public string Name { get; set; } = string.Empty;
    public List<SimpleEstimationItem> Items { get; set; } = new();
}
