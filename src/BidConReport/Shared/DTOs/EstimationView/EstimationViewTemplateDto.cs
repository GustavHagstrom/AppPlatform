namespace BidConReport.Shared.DTOs.EstimationView;
public class EstimationViewTemplateDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<DataSectionTemplateDto> DataTemplateSections { get; set; } = new();
    public NetSheetSectionTemplateDto? NetSheetSectionTemplate { get; set; }
    public HeaderOrFooter? TopLeftHeader { get; set; }
    public HeaderOrFooter? TopRightHeader { get; set; }
    public HeaderOrFooter? BottomLeftFooter { get; set; }
    public HeaderOrFooter? BottomRightFooter { get; set; }
}
