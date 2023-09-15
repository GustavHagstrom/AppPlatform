namespace Server.Enteties.EstimationView;
public class DataColumn : IEstimationViewEntity
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public int WidthPercent { get; set; }

    public Guid DataSectionTemplateId { get; set; }
    public DataSectionTemplate? DataSectionTemplate { get; set; }
}
