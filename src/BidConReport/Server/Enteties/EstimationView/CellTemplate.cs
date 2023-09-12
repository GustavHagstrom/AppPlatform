namespace BidConReport.Server.Enteties.EstimationView;
public class CellTemplate
{
    public Guid Id { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public string Value { get; set; } = string.Empty;
    public bool IsFormula => Value.StartsWith("=");


    public required CellFormat Format { get; set; }
    public Guid DataSectionTemplateId { get; set; }
    public DataSectionTemplate? DataSectionTemplate { get; set; }
}