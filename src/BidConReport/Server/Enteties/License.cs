using System.ComponentModel.DataAnnotations;

namespace Server.Enteties;

public class License
{
    public Guid Id { get; set; }
    public int UserLimit { get; set; }
    [StringLength(50)]
    public required string OrganizationId { get; set; }
    public Organization? Organization { get; set; }
    public IEnumerable<User>? Users { get; set; }
}
