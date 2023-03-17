using BidConReport.Shared.Features.ReportLayout.Models.Table;
using BidConReport.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace BidConReport.Shared.Features.ReportLayout.Models.Table;
public class ColumnDefinition
{
    public bool IsActive { get; set; }
    public ColumnDataSource DataSource { get; set; }
    public FontProperties TitleFont { get; set; } = FontProperties.Default;
    public FontProperties GroupFont { get; set; } = FontProperties.Default;
    public FontProperties PartFont { get; set; } = FontProperties.Default;
    public FontProperties CelleFont { get; set; } = FontProperties.Default;
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;
    [Range(1,12)]
    public int Width { get; set; }

}
public enum ColumnDataSource
{
    RowNumber,
    Name,
    Unit,
    DisplayedUnit,
    Quantity,
    DisplayedQuantity,
    Comment,
}


