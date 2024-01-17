using AppPlatform.Server.Enteties.EstimationView;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Server.Enteties;

public class UserViewTemplate
{
    [StringLength(450)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [StringLength(450)]
    public required string UserId { get; set; }
    public User? User { get; set; }
    [StringLength(450)]
    public string EstimationViewTemplateId { get; set; } = string.Empty;
    public EstimationViewTemplate? EstimationViewTemplate { get; set; }
}
