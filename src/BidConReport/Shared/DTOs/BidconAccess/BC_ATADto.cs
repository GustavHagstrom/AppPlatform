namespace BidConReport.Shared.DTOs.BidconAccess;
public class BC_ATADto
{
    public Guid EstimationId { get; set; }
    public int PMATANum { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}
