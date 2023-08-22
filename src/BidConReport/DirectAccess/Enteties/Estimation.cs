namespace BidConReport.DirectAccess.Enteties;
public class Estimation
{
    public Guid EstimationId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Customer { get; set; }
    public string? Place { get; set; }
    public string? HandlingOfficer { get; set; }
    public string? ConfirmationOfficer { get; set; }
    public bool IsLocked { get; set; }
    public required SheetItem NetSheet { get; set; }
    public ICollection<LockedStageCollection> LockedStages { get; set; } = new List<LockedStageCollection>();

}
