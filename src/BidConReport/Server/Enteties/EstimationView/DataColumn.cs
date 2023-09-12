namespace BidConReport.Server.Enteties.EstimationView;
public class DataColumn
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public int WidthPercent { get; set; }

    public Guid DataSectionTemplateId { get; set; }
    public DataSectionTemplate? DataSectionTemplate { get; set; }
}
