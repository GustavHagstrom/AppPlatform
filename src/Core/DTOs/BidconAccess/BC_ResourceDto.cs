﻿namespace AppPlatform.Core.DTOs.BidconAccess;
public class BC_ResourceDto
{
    public required string Id { get; set; }
    public string? Description { get; set; }
    public Guid EstimationId { get; set; }
    public int ResourceType { get; set; }
    public double Price { get; set; }
    //public int Version { get; set; }
    public override string ToString()
    {
        return Description ?? "ResourceResult";
    }
}
