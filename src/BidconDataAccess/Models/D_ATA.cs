namespace AppPlatform.BidconDatabaseAccess.Models;
public class D_ATA
{
    public Guid EstimationId { get; set; }
    public int PMATANum { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}
