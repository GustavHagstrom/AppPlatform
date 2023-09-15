namespace SharedLibrary.DTOs.EstimationView;
public class EstimationViewTemplateDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public List<DataSectionTemplateDto> DataSectionTemplates { get; set; } = new();
    public NetSheetSectionTemplateDto? NetSheetSectionTemplate { get; set; }
    public List<HeaderOrFooterDto> HeaderOrFooters { get; set; } = new();
}
