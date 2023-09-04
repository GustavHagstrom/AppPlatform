namespace BidConReport.Client.Shared.EstimationViewTemplate.Models.SectionModels;

public interface IColumnDefinition
{
    Guid Id { get; set; }
    int Order { get; set; }
    int WidthPercent { get; set; }
}