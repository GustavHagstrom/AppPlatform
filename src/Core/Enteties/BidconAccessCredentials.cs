﻿using AppPlatform.Core.Enteties.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AppPlatform.Core.Enteties;

public class BidconAccessCredentials  : ITenantEntety
{
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
    [Key]
    [StringLength(50)]
    public string TenantId { get; set; } = string.Empty;
}
