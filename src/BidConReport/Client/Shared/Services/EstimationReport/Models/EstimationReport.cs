namespace BidConReport.Shared.DTOs.EstimationReportDtos;
public class EstimationReport
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required List<IReportSection> Sections { get; set; }
}
