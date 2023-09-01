namespace BidConReport.Client.Shared.Services.EstimationReportServices.Models.SectionModels;

public interface IColumnDefinition
{
    Guid Id { get; set; }
    int Order { get; set; }
    int WidthPercent { get; set; }
}