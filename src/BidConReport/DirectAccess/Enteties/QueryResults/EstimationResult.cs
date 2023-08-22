﻿namespace BidConReport.DirectAccess.Enteties;
public class EstimationResult
{
    public Guid EstimationID { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Customer { get; set; }
    public string? Place { get; set; }
    public string? HandlingOfficer { get; set; }
    public string? ConfirmationOfficer { get; set; }
    public bool IsLocked { get; set; }
    public int FolderNum { get; set; }
    public int CurrentVersion { get; set; }
}
