using SharedLibrary.Enums.ViewTemplate;
using System.ComponentModel.DataAnnotations;

namespace Server.Enteties.EstimationView;
public class HeaderOrFooter : IEstimationViewEntity
{
    [StringLength(450)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [StringLength(50)]
    public required string Value { get; set; }
    public required HeaderOrFooterPosition Position { get; set; }



    [StringLength(450)]
    public string EstimationViewTemplateId { get; set; } = string.Empty;
    public EstimationViewTemplate? EstimationViewTemplate { get; set; }
}
