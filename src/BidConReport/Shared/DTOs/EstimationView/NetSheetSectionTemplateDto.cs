namespace BidConReport.Shared.DTOs.EstimationView;

public class NetSheetSectionTemplateDto
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public List<SheetColumnTemplateDto> Columns { get; set; } = new();
}
