﻿namespace BidConReport.DirectAccess.Enteties.QueryResults;
public class WorkResultLayerResult
{
    public required string Id { get; set; }
    public Guid EstimationId { get; set; }
    public required string LayerId { get; set; }
    public bool IsActive { get; set; }
    /// <summary>
    /// Quantity
    /// </summary>
    public double Cons { get; set; }
    public double ConsFactor { get; set; }
    public int Waste { get; set; }
    public int Version { get; set; }
}