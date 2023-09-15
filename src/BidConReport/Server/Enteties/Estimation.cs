using System.ComponentModel.DataAnnotations;

namespace Server.Enteties;

public class Estimation
{
    public Guid Id { get; set; }
    [StringLength(50)]
    public required string OrganizationId { get; set; }
    public Organization? Organization { get; set; }
}
