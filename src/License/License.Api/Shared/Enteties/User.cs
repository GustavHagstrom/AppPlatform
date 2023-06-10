namespace License.Api.Shared.Enteties;
public class User
{
    public string Id { get; set; }
    // Other user properties

    public ICollection<Role> Roles { get; set; }
    public Organization Organization { get; set; }
    public string OrganizationName { get; set; }
}
