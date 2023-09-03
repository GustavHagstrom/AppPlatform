using BidConReport.Shared.Enums.BidconAccess;

namespace BidConReport.Shared.DTOs.EstimationView;

public class SheetSectionDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Order { get; set; }
    public SheetType SheetType { get; set; }
    public List<ColumnDefinitionDto> Columns { get; set; } = new();
}
