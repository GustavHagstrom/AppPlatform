﻿using System.ComponentModel.DataAnnotations;

namespace BidConReport.Shared.Models;
public class EstimationImportSettings
{
    public int Id { get; set; }
    [MaxLength(50)]
    public required string OrganizationId { get; set; }
    [MaxLength(30)]
    public required string Name { get; set; }
    [MaxLength(10)]
    public required string CostFactorAccount { get; set; }
    [MaxLength(10)]
    public required string CostBeforeChangesAccount { get; set; }
    [MaxLength(10)]
    public required string NetCostAccount { get; set; }
    [MaxLength(10)]
    public required string HiddenTag { get; set; }
    [MaxLength(10)]
    public required string HiddenUnitTag { get; set; }
    public required bool UseRevisionAsSelectionTags { get; set; }
    public required ICollection<string> QuickTags { get; set; }
    public required ICollection<string> SelectionTags { get; set; }

}
