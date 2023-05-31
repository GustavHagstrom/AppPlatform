namespace LicenseLibrary.Entities;
public class User
{
    public string Id { get; set; }
    // Other user properties

    public ICollection<Role> Roles { get; set; }
    public Organization Organization { get; set; }
    public int OrganizationId { get; set; }
}
