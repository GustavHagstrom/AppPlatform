namespace BidConReport.SharedLibrary.Models;
public class LockedCategory
{
    public string Name { get; set; } = string.Empty;
    public List<LockedStage> LockedStages { get; set; } = new();
}
