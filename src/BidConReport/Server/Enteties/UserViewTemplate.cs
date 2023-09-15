using BidConReport.Server.Enteties.EstimationView;
using System.ComponentModel.DataAnnotations;

namespace BidConReport.Server.Enteties;

public class UserViewTemplate
{
    public Guid Id { get; set; }
    [StringLength(50)]
    public required string UserId { get; set; }
    public User? User { get; set; }
    public Guid EstimationViewTemplateId { get; set; }
    public EstimationViewTemplate? EstimationViewTemplate { get; set; }
}
