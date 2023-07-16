using BidConReport.Shared.Entities;
using BidConReport.Shared.Features.ReportTemplate;
using System.ComponentModel.DataAnnotations;

namespace BidConReport.Server.Shared.Enteties;

public class UserOrganization
{
    public int Id { get; set; }
    [StringLength(50)]
    public required string UserId { get; set; }
    public User? User { get; set; }
    [StringLength(50)]
    public required string OrganizationId { get; set; }
    public int? DefaultEstimationSettingsId { get; set; }
    public EstimationImportSettings? DefaultEstimationSettings { get; set; }
    public int? DefaultReportTemplateId { get; set; }
    public ReportTemplate? DefaultReportTemplate { get; set; }
}
