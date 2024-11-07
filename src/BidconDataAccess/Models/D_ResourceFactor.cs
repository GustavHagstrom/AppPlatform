namespace AppPlatform.BidconDatabaseAccess.Models;
public class D_ResourceFactor
{
    public Guid EstimationId { get; set; }
    public required int ResourceType { get; set; }
    public required double Factor { get; set; }
}
