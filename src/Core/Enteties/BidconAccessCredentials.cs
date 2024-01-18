using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AppPlatform.Core.Enteties;

public class BidconAccessCredentials
{
    [Key]
    [StringLength(450)]
    public string OrganizationId { get; set; } = string.Empty;
    public Organization? Organization { get; set; }
    [StringLength(50)]
    [AllowNull]
    public string Server { get; set; } = string.Empty;
    [StringLength(50)]
    [AllowNull]
    public string Database { get; set; } = string.Empty;
    [StringLength(50)]
    [AllowNull]
    public string User { get; set; } = string.Empty;
    [StringLength(50)]
    [AllowNull]
    public string Password { get; set; } = string.Empty;
    public bool ServerAuthentication { get; set; }
    public bool UseDesktopBidconLink { get; set; }
    public int DesktopPort { get; set; }
    public DateTime LastUpdated { get; set; }
}
