namespace LicenseLibrary.Entities;
public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    // Other role properties

    public ICollection<User> Users { get; set; }
    public int ApplicationId { get; set; }
    public Application Application { get; set; }
}
