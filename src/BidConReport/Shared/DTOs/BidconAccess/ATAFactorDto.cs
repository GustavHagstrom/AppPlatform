﻿namespace BidConReport.Shared.DTOs.BidconAccess;
public class ATAFactorDto
{
    public Guid EstimationId { get; set; }
    public int PMATANum { get; set; }
    public int ResourceType { get; set; }
    public double RemovalPercent { get; set; }
    public double RemovalExpensePercent { get; set; }
    public double AdditionalPercent { get; set; }
    public double AdditionalExpensePercent { get; set; }
}
