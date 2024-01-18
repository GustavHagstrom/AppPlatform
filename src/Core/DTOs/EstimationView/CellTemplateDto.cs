namespace AppPlatform.Core.DTOs.EstimationView;
public class CellTemplateDto
{
    public Guid Id { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public string Value { get; set; } = string.Empty;
    public required CellFormatDto Format { get; set; }
    public Guid DataSectionTemplateId { get; set; }
}