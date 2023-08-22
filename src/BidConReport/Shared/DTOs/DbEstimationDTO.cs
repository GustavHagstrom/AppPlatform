﻿namespace BidConReport.Shared.DTOs;
public class DbEstimationDTO
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Id { get; set; } = string.Empty;
    public override string ToString() => Description is null ? Name : $"{Name} - {Description}";
}