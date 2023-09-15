namespace Server.Enteties.EstimationView;

public class NetSheetSectionTemplate : IEstimationViewEntity
{
    public Guid Id { get; set; }
    public int Order { get; set; }




    public List<SheetColumn> Columns { get; set; } = new();
    public Guid EstimationViewTemplateId { get; set; }
    public EstimationViewTemplate? EstimationViewTemplate { get; set; }
}
