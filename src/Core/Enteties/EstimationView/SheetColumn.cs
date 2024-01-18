using AppPlatform.Core.Enums.ViewTemplate;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;

public class SheetColumn : IEstimationViewEntity
{
    [StringLength(450)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public int WidthPercent { get; set; }
    public SheetColumnType ColumnType { get; set; }

    public required CellFormat CellFormat { get; set; }
    [StringLength(450)]
    public string NetSheetSectionTemplateId { get; set; } = string.Empty;
    public SheetSectionTemplate? NetSheetSectionTemplate { get; set; }
}
