using BidConReport.Client.Shared.Services.EstimationReportServices.Models.SectionModels;

namespace BidConReport.Client.Shared.Services.EstimationReportServices.Models;
public class EstimationReport
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<IReportSection> Sections { get; set; } = new();
}
