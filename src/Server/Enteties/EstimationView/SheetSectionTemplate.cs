using SharedLibrary.Enums.BidconAccess;
using System.ComponentModel.DataAnnotations;

namespace Server.Enteties.EstimationView;

public class SheetSectionTemplate : IEstimationViewEntity
{
    [StringLength(450)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public SheetType SheetType { get; set; }



    public List<SheetColumn> Columns { get; set; } = new();
    [StringLength(450)]
    public string EstimationViewTemplateId { get; set; } = string.Empty;
    public EstimationViewTemplate? EstimationViewTemplate { get; set; }
}
