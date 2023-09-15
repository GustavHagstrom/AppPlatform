using SharedLibrary.Enums.ViewTemplate;
using System.ComponentModel.DataAnnotations;

namespace Server.Enteties.EstimationView;
public class HeaderOrFooter : IEstimationViewEntity
{
    public Guid Id { get; set; }
    [StringLength(50)]
    public required string Value { get; set; }
    public required HeaderOrFooterPosition Position { get; set; }



    public Guid EstimationViewTemplateId { get; set; }
    public EstimationViewTemplate? EstimationViewTemplate { get; set; }
}
