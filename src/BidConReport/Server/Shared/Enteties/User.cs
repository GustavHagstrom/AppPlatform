using BidConReport.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace BidConReport.Server.Shared.Enteties;

public class User
{
    [MaxLength(50)]
    public required string Id { get; set; }
    public int? StandardEstimationSettingsId { get; set; }
    public EstimationImportSettings? StandardEstimationSettings { get; set; }
}
