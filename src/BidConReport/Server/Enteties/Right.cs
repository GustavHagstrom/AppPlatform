using System.ComponentModel.DataAnnotations;

namespace BidConReport.Server.Enteties;

public class Right
{
    public int Id { get; set; }
    [StringLength(50)]
    public required string Name { get; set; }
    public IEnumerable<Role>? Roles { get; set; }
    public IEnumerable<User>? Users { get; set; }
}
