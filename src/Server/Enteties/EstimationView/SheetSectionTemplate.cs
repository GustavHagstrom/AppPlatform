using SharedLibrary.Enums.BidconAccess;

namespace Server.Enteties.EstimationView;

public class SheetSectionTemplate : IEstimationViewEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }
    public SheetType SheetType { get; set; }



    public List<SheetColumn> Columns { get; set; } = new();
    public Guid EstimationViewTemplateId { get; set; }
    public EstimationViewTemplate? EstimationViewTemplate { get; set; }
}
