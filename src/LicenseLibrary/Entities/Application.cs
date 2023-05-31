namespace LicenseLibrary.Entities;
public class Application
{
    public int Id { get; set; }
    public required string Name { get; set; }
    // Other application properties

    public ICollection<Role> Roles { get; set; }
    public ICollection<License> Licenses { get; set; }
}
