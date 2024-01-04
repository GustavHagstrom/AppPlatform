using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Enteties;

public class Subscription
{
    [StringLength(450)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int UserLimit { get; set; }
    [StringLength(450)]
    public string OrganizationId { get; set; } = string.Empty;
    public Organization? Organization { get; set; }
    [NotMapped]
    public bool IsExpired => ExpirationDate < DateTime.UtcNow;
    public DateTime ExpirationDate { get; set; }
}
