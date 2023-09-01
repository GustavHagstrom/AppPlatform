namespace BidConReport.Client.Shared.Services.EstimationReportServices.Models.CellModels;
public class Cell
{
    public Guid Id { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public int ColumnSpan { get; set; }
    public string Value { get; set; } = string.Empty;
    public bool IsFormula => Value.StartsWith("=");
    public CellFormat Format { get; set; } = new();
}