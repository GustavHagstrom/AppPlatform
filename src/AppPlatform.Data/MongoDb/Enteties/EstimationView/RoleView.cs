using AppPlatform.Data.MongoDb.Enteties.Authorization;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Data.MongoDb.Enteties.EstimationView;
public class RoleView
{
    [StringLength(50)]
    public string RoleId { get; set; } = string.Empty;
    public Role? Role { get; set; }
    [StringLength(50)]
    public string ViewId { get; set; } = string.Empty;
    public View? View { get; set; }
}
