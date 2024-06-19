using AppPlatform.Core.Enums.ViewTemplate;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;
public class Header : IViewEntity, IHeaderOrFooter
{
    [StringLength(50)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [StringLength(500)]
    public string Formula { get; set; } = string.Empty;
    [StringLength(50)]
    public string EstimationViewTemplateId { get; set; } = string.Empty;
    public View? EstimationViewTemplate { get; set; }
}
