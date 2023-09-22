namespace Client.Shared.EstimationViewTemplate.Models.SectionModels;
public interface IViewSection
{
    Guid Id { get; set; }
    int Order { get; set; }
    string Name { get; set; }
}
