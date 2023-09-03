namespace BidConReport.Shared.DTOs.EstimationView;
public class EstimationViewTemplateDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<DataSectionDto> DataSections { get; set; } = new();
    public List<SheetSectionDto> SheetSections { get; set; } = new();
}
