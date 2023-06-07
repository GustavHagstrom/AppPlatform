namespace SharedWasmLibrary.Shared.Services;
internal interface IRolesProvider
{
    string GetUserRole();
    /// <summary>
    /// Only used in debug
    /// </summary>
    /// <param name="role">The role to use while debuging</param>
    void SetDebugRoles(string role);
}
