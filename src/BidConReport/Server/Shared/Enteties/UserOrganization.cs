using BidConReport.Shared.Entities;
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
    public int? StandardEstimationSettingsId { get; set; }
    public EstimationImportSettings? StandardEstimationSettings { get; set; }
}
