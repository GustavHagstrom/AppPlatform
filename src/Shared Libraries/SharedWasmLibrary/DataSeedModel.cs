namespace SharedWasmLibrary;
public class AppSeedModel
{
    public required string ApplicationName { get; set; }
    public required ICollection<string> Roles { get; set; }
}
