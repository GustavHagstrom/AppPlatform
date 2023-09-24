namespace SharedLibrary.DTOs.EstimationView;



public class EstimationViewTemplateDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<DataSectionTemplateDto> DataSections { get; set; } = new();
    public List<SheetSectionTemplateDto> SheetSections { get; set; } = new();
    public List<HeaderOrFooterDto> HeaderOrFooters { get; set; } = new();
}
