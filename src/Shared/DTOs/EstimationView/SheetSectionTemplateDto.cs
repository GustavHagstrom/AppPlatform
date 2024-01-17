using AppPlatform.Shared.Enums.BidconAccess;

namespace AppPlatform.Shared.DTOs.EstimationView;

public class SheetSectionTemplateDto
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public SheetType SheetType { get; set; }
    public List<SheetColumnDto> Columns { get; set; } = new();
    public Guid EstimationViewTemplateId { get; set; }
}
