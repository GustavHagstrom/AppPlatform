﻿namespace BidConReport.Client.Shared.Services.EstimationReport.Models;

public class Border
{
    public bool BorderLeft { get; set; }
    public bool BorderTop { get; set; }
    public bool BorderRight { get; set; }
    public bool BorderBottom { get; set; }
    public int BorderThickness => 1;
    public BorderStyle Style { get; set; }

}
