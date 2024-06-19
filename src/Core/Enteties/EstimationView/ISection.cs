using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;
public interface ISection
{
    int Order { get; set; }
    [StringLength(450)]
    public string ViewId { get; set; }
    public View? View { get; set; }
}
