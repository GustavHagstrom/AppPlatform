﻿namespace AppPlatform.Server.EstimationViewTemplate_old.Models;
public class DataCell
{
    public Guid Id { get; set; }
    public int Row { get; set; }
    public string Value { get; set; } = string.Empty;
    public bool IsFormula => Value.StartsWith("=");
    public CellFormat Format { get; set; } = new();
}