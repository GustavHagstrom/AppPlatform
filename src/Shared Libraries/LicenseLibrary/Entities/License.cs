namespace LicenseLibrary.Entities;
public class License
{
    public int Id { get; set; }
    // License properties

    public int ApplicationId { get; set; }
    public required Application Application { get; set; }
    public int OrganizationId { get; set; }
    public required Organization Organization { get; set; }
}
