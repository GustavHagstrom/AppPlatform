namespace AppPlatform.Shared.DTOs.BidconAccess;
public class BC_ResourceFactorDto
{
    public Guid EstimationId { get; set; }
    public required int ResourceType { get; set; }
    public required double Factor { get; set; }
}
