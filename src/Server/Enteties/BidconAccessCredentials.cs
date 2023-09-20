using System.ComponentModel.DataAnnotations;

namespace Server.Enteties;

public class BidconAccessCredentials
{
    [Key]
    [StringLength(50)]
    public required string OrganizationId { get; set; }
    [StringLength(50)]
    public string? Server { get; set; }
    [StringLength(50)]
    public string? Database { get; set; }
    [StringLength(50)]
    public string? User { get; set; }
    [StringLength(50)]
    public string? Password { get; set; }
    public bool ServerAuthentication { get; set; }
    public bool UseDesktopBidconLink { get; set; }
    public int DesktopPort { get; set; }
    public DateTime LastUpdated { get; set; }
}
