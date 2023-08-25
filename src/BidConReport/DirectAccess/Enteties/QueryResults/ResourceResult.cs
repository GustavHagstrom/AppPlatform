﻿namespace BidConReport.BidconAccess.Enteties.QueryResults;
public class ResourceResult
{
    public required string Id { get; set; }
    public string? Description { get; set; }
    public Guid EstimationId { get; set; }
    public int ResourceType { get; set; }
    public double Price { get; set; }
    //public int Version { get; set; }
}
