using Client.Shared.EstimationViewTemplate.Models.SectionModels;

namespace Client.Shared.EstimationViewTemplate.Models;
public class ViewTemplate
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<IViewSection> Sections { get; set; } = new();
}
