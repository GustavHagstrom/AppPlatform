namespace BidConReport.Server.Enteties.EstimationView;

public class NetSheetSectionTemplate
{
    public Guid Id { get; set; }
    public int Order { get; set; }




    public List<SheetColumn> Columns { get; set; } = new();
    public Guid EstimationViewTemplateId { get; set; }
    public EstimationViewTemplate? EstimationViewTemplate { get; set; }
}
