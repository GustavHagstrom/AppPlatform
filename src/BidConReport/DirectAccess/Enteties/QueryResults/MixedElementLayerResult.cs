﻿namespace BidConReport.DirectAccess.Enteties;
public class MixedElementLayerResult
{
    public required string Id { get; set; }
    public Guid EstimationId { get; set; }
    public required string LayerId { get; set; }
    public bool IsActive { get; set; }
    /// <summary>
    /// Quantity
    /// </summary>
    public double Cons { get; set; }
    public int LayerType { get; set; }
    public int Version { get; set; }
}