namespace SharedWasmLibrary.Shared.Services;
internal class RolesProvider_Debug  : IRolesProvider
{
    private static string Role { get; set; } = string.Empty;

    public string GetUserRole()
    {
        return Role;
    }

    public void SetDebugRoles(string role)
    {
        Role = role;
    }
}
