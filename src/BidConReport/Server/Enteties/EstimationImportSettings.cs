﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BidConReport.Server.Enteties;
public class EstimationImportSettings
{
    public int Id { get; set; }
    public int OrganizationId { get; set; }
    [MaxLength(30)]
    public required string Name { get; set; }
    [MaxLength(10)]
    public required string CostFactorAccount { get; set; }
    [MaxLength(10)]
    public required string CostBeforeChangesAccount { get; set; }
    [MaxLength(10)]
    public required string NetCostAccount { get; set; }
    [MaxLength(20)]
    public string? HiddenTag { get; set; }
    [MaxLength(20)]
    public string? HiddenUnitTag { get; set; }
    public required bool UseRevisionAsSelectionTags { get; set; }
    [MaxLength(1000)]
    public ICollection<string>? QuickTags { get; set; } = new List<string>();
    [MaxLength(1000)]
    public ICollection<string>? SelectionTags { get; set; } = new List<string>();
    public override string ToString()
    {
        return Name;
    }

}
