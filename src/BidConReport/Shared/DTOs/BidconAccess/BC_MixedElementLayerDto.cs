namespace SharedLibrary.DTOs.BidconAccess;
public class BC_MixedElementLayerDto
{
    public required string Id { get; set; }
    public Guid EstimationId { get; set; }
    public required string LayerId { get; set; }
    /// <summary>
    /// Quantity
    /// </summary>
    public double Cons { get; set; }
    public int LayerType { get; set; }
}
