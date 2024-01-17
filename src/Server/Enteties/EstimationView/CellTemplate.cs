using System.ComponentModel.DataAnnotations;

namespace Server.Enteties.EstimationView;
public class CellTemplate : IEstimationViewEntity
{
    [StringLength(450)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int Row { get; set; }
    public int Column { get; set; }
    [StringLength(50)]
    public string Value { get; set; } = string.Empty;
    public required CellFormat Format { get; set; }
    [StringLength(450)]
    public string DataSectionTemplateId { get; set; } = string.Empty;
    public DataSectionTemplate? DataSectionTemplate { get; set; }
}