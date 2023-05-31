namespace BidConReport.Shared.Entities;
public class LockedCategory
{
    public required string Name { get; set; }
    public required ICollection<LockedStage> LockedStages { get; set; }
}
