using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BidConReport.Shared.Models;
public class EstimationImportSettings
{
    public int Id { get; set; }
    [MaxLength(50)]
    public required string OrganizationId { get; set; }
    [Required]
    [MaxLength(30)]
    public required string Name { get; set; }
    [Required]
    [MaxLength(10)]
    public required string CostFactorAccount { get; set; }
    [Required]
    [MaxLength(10)]
    public required string CostBeforeChangesAccount { get; set; }
    [Required]
    [MaxLength(10)]
    public required string NetCostAccount { get; set; }
    [Required]
    [MaxLength(10)]
    public required string HiddenTag { get; set; }
    [Required]
    [MaxLength(10)]
    public required string HiddenUnitTag { get; set; }
    public required bool UseRevisionAsSelectionTags { get; set; }
    [Required]
    [MaxLength(20)]
    public required ICollection<string> QuickTags { get; set; }
    [Required]
    [MaxLength(20)]
    public required ICollection<string> SelectionTags { get; set; }


    [NotMapped]
    public static EstimationImportSettings Empty => new EstimationImportSettings
    {
        Name = string.Empty,
        OrganizationId = string.Empty,
        CostFactorAccount = string.Empty,
        NetCostAccount = string.Empty,
        CostBeforeChangesAccount = string.Empty,
        HiddenTag = string.Empty,
        HiddenUnitTag = string.Empty,
        UseRevisionAsSelectionTags = false,
        QuickTags = new List<string>(),
        SelectionTags = new List<string>(),
    };

}
