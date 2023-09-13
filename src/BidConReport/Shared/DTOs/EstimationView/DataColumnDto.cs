namespace BidConReport.Shared.DTOs.EstimationView;
public class DataColumnDto
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public int WidthPercent { get; set; }

    public Guid DataSectionTemplateId { get; set; }
}
