using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;
public class DataColumn : IViewEntity
{
    [StringLength(50)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public int WidthPercent { get; set; }

    [StringLength(50)]
    public string DataSectionId { get; set; } = string.Empty;
    public DataSection? DataSection { get; set; }
}
