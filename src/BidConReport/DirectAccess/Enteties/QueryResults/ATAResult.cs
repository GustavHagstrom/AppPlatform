﻿namespace BidConReport.BidconAccess.Enteties.QueryResults;
public class ATAResult
{
    public Guid EstimationId { get; set; }
    public int PMATANum { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}
