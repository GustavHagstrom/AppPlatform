using System.ComponentModel.DataAnnotations;

namespace Server.Enteties;

public class License
{
    [StringLength(450)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int UserLimit { get; set; }
    [StringLength(450)]
    public string OrganizationId { get; set; } = string.Empty;
    public Organization? Organization { get; set; }
}
