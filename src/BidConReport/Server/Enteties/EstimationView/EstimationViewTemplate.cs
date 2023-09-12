namespace BidConReport.Server.Enteties.EstimationView;
public class EstimationViewTemplate
{
    public Guid Id { get; set; }
    public required string Name { get; set; }




    public List<DataSectionTemplate> DataSectionTemplates { get; set; } = new();
    public NetSheetSectionTemplate? NetSheetSectionTemplate { get; set; }
    public List<HeaderOrFooter> HeaderOrFooters { get; set; } = new();
}
