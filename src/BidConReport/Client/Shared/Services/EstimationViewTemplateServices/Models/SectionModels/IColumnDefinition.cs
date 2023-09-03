namespace BidConReport.Client.Shared.Services.EstimationViewTemplateServices.Models.SectionModels;

public interface IColumnDefinition
{
    Guid Id { get; set; }
    int Order { get; set; }
    int WidthPercent { get; set; }
}