namespace BidConReport.Shared.DTOs;
public class LockedCategoryDTO
{
    public required string Name { get; set; }
    public required ICollection<LockedStageDTO> LockedStages { get; set; }
}
