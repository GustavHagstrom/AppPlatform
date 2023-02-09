using SharedLibrary.Models;

namespace LicenseServer.Models;

public class Licence
{
    public Guid Id { get; set; }
    public required string OrganizationId { get; set; }
    public required string Name { get; set; }
    public required DateTime ExpireDate { get; set; }
    public required Application Application { get;set; }
}
