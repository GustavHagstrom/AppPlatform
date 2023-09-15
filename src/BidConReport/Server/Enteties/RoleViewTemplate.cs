using BidConReport.Server.Enteties.EstimationView;

namespace BidConReport.Server.Enteties;

public class RoleViewTemplate
{
    public Guid Id { get; set; }
    public Guid RoleId { get; set; }
    public Role? Role { get; set; }
    public Guid EstimationViewTemplateId { get; set; }
    public EstimationViewTemplate? EstimationViewTemplate { get; set; }
}
