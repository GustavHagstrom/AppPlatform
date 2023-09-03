using BidConReport.Client.Shared.Services.EstimationViewTemplateServices.Models.CellModels;

namespace BidConReport.Client.Shared.Services.EstimationViewTemplateServices.Models.SectionModels;

public class DataSection : IReportSection
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Order { get; set; }
    public List<ColumnDefinition> Columns { get; } = new();
    public int RowCount { get; set; }
    public List<Cell> Cells { get; set; } = new();
}
