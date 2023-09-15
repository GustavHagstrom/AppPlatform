namespace SharedLibrary.Constants;
public static class CommonAppConstants
{
    /// <summary>
    /// This is used as a primary key in the LicenseDb and 
    /// probably cannot be changed once in production
    /// </summary>
    public const string ApplicationName = "BidconReport";
    /// <summary>
    /// This is used in the licenseDb and probably a bad idea to change once in production
    /// </summary>
    public static readonly string[] AppRoles = 
    { 
        RoleConstants.Admin,
        RoleConstants.Creator,
        RoleConstants.Reader,
        RoleConstants.Guest,
    };

    /// <summary>
    /// Contains the role constants. They are to be seeded into license DB and should not be changed once deployed
    /// </summary>
    public static class RoleConstants
    {
        public const string Admin = "admin";
        public const string Creator = "creator";
        public const string Reader = "reader";
        public const string Guest = "guest";
    }
    
}
