using System.ComponentModel.DataAnnotations;

namespace License.Api.Shared.Enteties;
public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    // Other role properties

    public ICollection<User> Users { get; set; }
    [StringLength(50)]
    public string ApplicationName { get; set; }
    public Application Application { get; set; }
}
