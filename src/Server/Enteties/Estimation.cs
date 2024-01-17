using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Server.Enteties;

public class Estimation
{
    [StringLength(450)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [StringLength(450)]
    public string OrganizationId { get; set; } = string.Empty;
    public Organization? Organization { get; set; }
}
