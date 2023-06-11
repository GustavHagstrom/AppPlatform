using System.ComponentModel.DataAnnotations;

namespace License.Api.Shared.Enteties;
public class AppLicense
{
    public int Id { get; set; }
    public required int MaxUserCount { get; set; }
    public ICollection<User> Users { get; set; }
    [StringLength(50)]
    public string ApplicationName { get; set; }
    public required Application Application { get; set; }
    [StringLength(50)]
    public string OrganizationName { get; set; }
    public required Organization Organization { get; set; }
    public required DateTime EndDate { get; set; }
}
