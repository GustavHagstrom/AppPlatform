using BidConReport.Client.Shared.Services.EstimationReportServices.Models.CellModels;

namespace BidConReport.Client.Shared.Services.EstimationReportServices.Models.SectionModels;

public class SheetColumnDefinition : IColumnDefinition
{
    private readonly ColumnDefinition _columnDefinition;

    public SheetColumnDefinition(ColumnDefinition columnDefinition)
    {
        _columnDefinition = columnDefinition;
    }
    public Guid Id { get; set; }
    public int Order { get => _columnDefinition.Order; set => _columnDefinition.Order = value; }
    public int WidthPercent { get => _columnDefinition.WidthPercent; set => _columnDefinition.WidthPercent = value; }
    public SheetColumnType ColumnType { get; set; }
    public CellFormat CellFormat { get; set; } = new();
}
