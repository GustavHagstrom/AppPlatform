﻿namespace BidConReport.DirectAccess.Enteties.QueryResults;
public class ResourceResult
{
    public required string Id { get; set; }
    public Guid EstimationId { get; set; }
    public required string Unit { get; set; }
    public double Price { get; set; }
}
