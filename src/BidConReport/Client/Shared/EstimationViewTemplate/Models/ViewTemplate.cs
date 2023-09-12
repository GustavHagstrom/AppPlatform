using BidConReport.Client.Shared.EstimationViewTemplate.Models.SectionModels;

namespace BidConReport.Client.Shared.EstimationViewTemplate.Models;
public class ViewTemplate
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<IViewSection> Sections { get; set; } = new();
}
