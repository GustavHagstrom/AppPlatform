namespace BidConReport.Client.Shared.Services.EstimationReportServices.Models.SectionModels;
public interface IReportSection
{
    Guid Id { get; set; }
    string Name { get; set; }
    int Order { get; set; }
}
