namespace AppPlatform.BidconDataAccess.Models;
public class ResourceFactor
{
    public Guid EstimationId { get; set; }
    public required int ResourceType { get; set; }
    public required double Factor { get; set; }
}
