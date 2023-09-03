namespace BidConReport.Shared.DTOs.EstimationView;
public class CellDto
{
    public Guid Id { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public int ColumnSpan { get; set; }
    public string Value { get; set; } = string.Empty;
    public bool IsFormula => Value.StartsWith("=");
    public CellFormatDto Format { get; set; } = new();
}