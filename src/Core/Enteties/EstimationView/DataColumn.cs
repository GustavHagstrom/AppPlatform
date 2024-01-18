using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;
public class DataColumn : IEstimationViewEntity
{
    [StringLength(450)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public int WidthPercent { get; set; }

    [StringLength(450)]
    public string DataSectionTemplateId { get; set; } = string.Empty;
    public DataSectionTemplate? DataSectionTemplate { get; set; }
}
