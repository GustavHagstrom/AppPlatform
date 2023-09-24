namespace Client.Shared.EstimationViewTemplate.Models.CellModels;
public class Cell
{
    public Guid Id { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public string Value { get; set; } = string.Empty;
    public bool IsFormula => Value.StartsWith("=");
    public CellFormat Format { get; set; } = new();
}