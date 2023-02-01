namespace IdentityServer.Models;

public class Organization
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string OrganizationNumber { get; set; }
    public required List<ApplicationUser> Users { get; set; }
}
