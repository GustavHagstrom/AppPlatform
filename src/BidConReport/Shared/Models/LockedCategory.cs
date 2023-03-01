namespace BidConReport.Shared.Models;
public class LockedCategory
{
    public required string Name { get; set; }
    public required ICollection<LockedStage> LockedStages { get; set; }
}
