using BidConReport.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace BidConReport.Server.Features.Authorization.Models;

public class User
{
    [MaxLength(50)]
    public required string Id { get; set; }
    public required ICollection<Role> Roles { get; set; }
    //public int? SettingsId { get; set; }
    public EstimationImportSettings? StandardSettings { get; set; }
}
