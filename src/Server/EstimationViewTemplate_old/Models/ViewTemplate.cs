using SharedLibrary.DTOs.EstimationView;

namespace AppPlatform.Server.EstimationViewTemplate_old.Models;
public class ViewTemplate
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<DataSection> DataSections { get; set; } = new();
    public List<SheetSection> SheetSections { get; set; } = new();
    public List<HeaderOrFooter> HeaderOrFooters { get; set; } = new();

    public IEnumerable<IViewSection> SectionsInOrder => ((IEnumerable<IViewSection>)SheetSections).Concat(DataSections).OrderBy(x => x.Order);
}
