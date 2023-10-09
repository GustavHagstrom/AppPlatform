using Client.Shared.EstimationViewTemplate.Models.CellModels;

namespace Client.Shared.EstimationViewTemplate.Models.SectionModels;

public class SheetCell
{
    public Guid Id { get; set; }
    public CellFormat CellFormat { get; set; } = new();
    public required Guid SheetRowId { get; set; }
    public required Guid SheetColumnId { get; set; }
}
