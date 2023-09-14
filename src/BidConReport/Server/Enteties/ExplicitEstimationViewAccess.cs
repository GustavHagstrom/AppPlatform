using BidConReport.Server.Enteties.EstimationView;

namespace BidConReport.Server.Enteties;

public class ExplicitEstimationViewAccess
{
    public Guid Id { get; set; }
    public required string UserId { get; set; }
    public User? User { get; set; }
    public Guid EstimationViewTemplateId { get; set; }
    public EstimationViewTemplate? EstimationViewTemplate { get; set; }
    public Guid EstimationId { get; set; }
    public Estimation? Estimation { get; set; }
}
