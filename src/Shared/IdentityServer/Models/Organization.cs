namespace IdentityServer.Models;

public class Organization
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string OrganizationNumber { get; set; }
    public List<ApplicationUser> Users { get; set; }
}
