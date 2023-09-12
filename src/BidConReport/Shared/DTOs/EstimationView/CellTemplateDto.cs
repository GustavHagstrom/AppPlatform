namespace BidConReport.Shared.DTOs.EstimationView;
public class CellTemplateDto
{
    public Guid Id { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public string Value { get; set; } = string.Empty;
    public bool IsFormula => Value.StartsWith("=");
    public required CellFormatTemplateDto Format { get; set; }
}