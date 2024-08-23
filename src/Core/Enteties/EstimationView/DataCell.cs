using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;
public class DataCell : IViewEntity
{
    [StringLength(50)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int Row { get; set; }
    public int Column { get; set; }
    [StringLength(500)]
    public string Formula { get; set; } = string.Empty;
    [StringLength(50)]
    public string DataSectionId { get; set; } = string.Empty;
    public DataSection? DataSection { get; set; }
    [StringLength(50)]
    public string CellFormatId { get; set; } = string.Empty;
    public DataCellFormat? CellFormat { get; set; }
}