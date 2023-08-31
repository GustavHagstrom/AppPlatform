namespace BidConReport.Shared.DTOs.EstimationReportDtos;
public interface IReportSection
{
    Guid Id { get; set; }
    string Name { get; set; }
    int Order { get; set; }
}
