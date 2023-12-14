namespace SharedLibrary.Constants;
public static class CommonAppConstants
{

    public const string ApplicationName = "Bidcon Companion";
    public const string ApplicationVersion = "0.1";


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
