using BidConReport.Server.Enteties.EstimationView;

namespace BidConReport.Server.Enteties;

public class EstimationViewRight
{
    public Guid Id { get; set; }
    public Guid EstimationViewTemplateId { get; set; }
    public EstimationViewTemplate? EstimationViewTemplate { get; set; }
}
