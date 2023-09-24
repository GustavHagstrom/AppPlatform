namespace SharedLibrary.DTOs.EstimationView;
public class EstimationViewTemplateDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public List<DataSectionTemplateDto> DataSectionTemplates { get; set; } = new();
    public List<SheetSectionTemplateDto> SheetSectionTemplates { get; set; } = new();
    public List<HeaderOrFooterDto> HeaderOrFooters { get; set; } = new();
}
