using SharedLibrary.Enums.BidconAccess;

namespace SharedLibrary.DTOs.EstimationView;

public class SheetSectionTemplateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }
    public SheetType SheetType { get; set; }
    public List<SheetColumnDto> Columns { get; set; } = new();
    public Guid EstimationViewTemplateId { get; set; }
}
