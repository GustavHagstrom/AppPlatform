namespace AppPlatform.BidconDataAccess.Models;
public class BC_ResourceFactor
{
    public Guid EstimationId { get; set; }
    public required int ResourceType { get; set; }
    public required double Factor { get; set; }
}
