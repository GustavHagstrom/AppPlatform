namespace BidConReport.Client.Shared.BidconAccess.Enteties;
public class BC_ATA
{
    public Guid EstimationId { get; set; }
    public int PMATANum { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}
