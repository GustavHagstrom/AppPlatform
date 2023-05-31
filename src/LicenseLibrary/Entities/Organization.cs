namespace LicenseLibrary.Entities;
public class Organization
{
    public int Id { get; set; }
    public required string Name { get; set; }
    // Other organization properties

    public ICollection<User> Users { get; set; }
    public ICollection<License> Licenses { get; set; }
}
