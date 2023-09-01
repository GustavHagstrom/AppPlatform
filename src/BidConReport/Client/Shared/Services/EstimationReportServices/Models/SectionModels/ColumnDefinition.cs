namespace BidConReport.Client.Shared.Services.EstimationReportServices.Models.SectionModels;

public class ColumnDefinition : IColumnDefinition
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public int WidthPercent { get; set; }
}
