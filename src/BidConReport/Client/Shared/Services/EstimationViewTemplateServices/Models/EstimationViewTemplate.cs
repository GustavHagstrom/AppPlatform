using BidConReport.Client.Shared.Services.EstimationViewTemplateServices.Models.SectionModels;

namespace BidConReport.Client.Shared.Services.EstimationViewTemplateServices.Models;
public class EstimationViewTemplate
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<IReportSection> Sections { get; set; } = new();
}
