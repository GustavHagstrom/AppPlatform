using System.ComponentModel.DataAnnotations;

namespace BidConReport.Shared.Models;
public class EstimationImportSettings
{
    public int Id { get; set; }
    [MaxLength(30)]
    public required string SettingsName { get; set; }
    [MaxLength(10)]
    public required string CostFactorAccount { get; set; }
    [MaxLength(10)]
    public required string CostBeforeChangesAccount { get; set; }
    [MaxLength(10)]
    public required string NetCostAccount { get; set; }
    [MaxLength(10)]
    public required string HiddenTag { get; set; }
    public required List<Tag> QuickTags { get; set; } = new();
    public required List<Tag> SelectionTags { get; set; } = new();

}
