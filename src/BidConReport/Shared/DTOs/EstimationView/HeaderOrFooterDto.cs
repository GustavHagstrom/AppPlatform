using SharedLibrary.Enums.ViewTemplate;

namespace SharedLibrary.DTOs.EstimationView;
public class HeaderOrFooterDto
{
    public Guid Id { get; set; }
    public required string Value { get; set; }
    public required HeaderOrFooterPosition Position { get; set; }
    public Guid EstimationViewTemplateId { get; set; }

}
