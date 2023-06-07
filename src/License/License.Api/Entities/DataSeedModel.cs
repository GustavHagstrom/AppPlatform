namespace License.Api.Entities;
public class AppSeedModel
{
    public required string ApplicationName { get; set; }
    public required ICollection<string> Roles { get; set; }
}
