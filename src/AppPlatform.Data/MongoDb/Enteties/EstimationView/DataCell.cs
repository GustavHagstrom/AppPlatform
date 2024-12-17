using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Data.MongoDb.Enteties.EstimationView;
public class DataCell
{
    public int Row { get; set; }
    public int Column { get; set; }
    public string Formula { get; set; } = string.Empty;
    public string DataSectionId { get; set; } = string.Empty;
    public DataCellFormat CellFormat { get; set; } = new();
}