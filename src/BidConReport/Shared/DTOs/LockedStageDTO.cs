namespace BidConReport.Shared.DTOs;
public class LockedStageDTO
{
    public required string Name { get; set; }
    public required ICollection<EstimationItemDTO> Items { get; set; }
}
