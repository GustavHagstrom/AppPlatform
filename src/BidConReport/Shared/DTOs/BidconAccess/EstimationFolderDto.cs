﻿namespace BidConReport.Shared.DTOs.BidconAccess;
public class EstimationFolderDto
{
    public int FolderNum { get; set; }
    public int ParentNum { get; set; }
    public required string Name { get; set; }
}
