using AppPlatform.Core.Enums.ViewTemplate;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;

public class SheetColumn : IViewEntity
{
    [StringLength(50)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public int WidthPercent { get; set; }
    public SheetColumnType ColumnType { get; set; }
    public required CellFormat CellFormat { get; set; }
    [StringLength(50)]
    public string SheetSectionTemplateId { get; set; } = string.Empty;
    public SheetSection? SheetSectionTemplate { get; set; }
}
