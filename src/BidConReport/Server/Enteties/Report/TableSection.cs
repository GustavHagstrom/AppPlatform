using System.ComponentModel.DataAnnotations.Schema;

namespace BidConReport.Server.Enteties.Report;
public class TableSection : IReportTemplateSection
{
    public int Id { get; set; }
    public int LayoutOrder { get; set; }
    public bool IsEnabled { get; set; } = true;
    public required List<ColumnDefinition> Columns { get; set; }
    public int GroupFontId { get; set; }
    public required FontProperties GroupFont { get; set; }
    public int PartFontId { get; set; }
    public required FontProperties PartFont { get; set; }
    public int CellFontId { get; set; }
    public required FontProperties CellFont { get; set; }
    public int ColumnHeaderFontId { get; set; }
    public required FontProperties ColumnHeaderFont { get; set; }
}
