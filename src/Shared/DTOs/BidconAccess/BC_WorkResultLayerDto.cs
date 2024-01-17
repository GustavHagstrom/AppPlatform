﻿namespace AppPlatform.Shared.DTOs.BidconAccess;
public class BC_WorkResultLayerDto
{
    public required string Id { get; set; }
    public Guid EstimationId { get; set; }
    public required string LayerId { get; set; }
    /// <summary>
    /// Quantity
    /// </summary>
    public double Cons { get; set; }
    public double ConsFactor { get; set; }
    public int Waste { get; set; }
}
