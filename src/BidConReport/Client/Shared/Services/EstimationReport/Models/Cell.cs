namespace BidConReport.Client.Shared.Services.EstimationReport.Models;
public class Cell
{
    public CellFormat CellFormat { get; set; } = new();
    public int Row { get; set; }
    public int Column { get; set; }
    public int ColumnSpan { get; set; }
    public string Value { get; set; } = string.Empty;
    public bool IsFormula => Value.StartsWith("=");
}