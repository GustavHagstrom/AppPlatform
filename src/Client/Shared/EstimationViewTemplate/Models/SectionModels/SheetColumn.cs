using Client.Shared.EstimationViewTemplate.Models.CellModels;
using SharedLibrary.Enums.ViewTemplate;

namespace Client.Shared.EstimationViewTemplate.Models.SectionModels;
public class SheetColumn
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public int WidthPercent { get; set; }
    public SheetColumnType ColumnType { get; set; }
    public CellFormat CellFormat { get; set; } = new();
}
