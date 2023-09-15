﻿namespace Client.Shared.EstimationProcessing.Models;
public class Estimation
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Customer { get; set; }
    public string? Place { get; set; }
    public string? HandlingOfficer { get; set; }
    public string? ConfirmationOfficer { get; set; }
    public required ISheetItem NetSheet { get; set; }
    public ICollection<ISheetItem> LockedStages { get; set; } = new List<ISheetItem>();
    public double? TenderTotal { get; set; }
}
