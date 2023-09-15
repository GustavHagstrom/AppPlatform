using System.ComponentModel.DataAnnotations;

namespace Server.Enteties;

public class BidconCredentials
{
    [Key]
    [StringLength(50)]
    public required string OrganizationId { get; set; }
    [StringLength(50)]
    public required string Server { get; set; }
    [StringLength(50)]
    public required string Database { get; set; }
    [StringLength(50)]
    public required string User { get; set; }
    [StringLength(50)]
    public required string PasswordHash { get; set; }
    public bool ServerAuthentication { get; set; }
    public DateTime LastUpdated { get; set; }
}
