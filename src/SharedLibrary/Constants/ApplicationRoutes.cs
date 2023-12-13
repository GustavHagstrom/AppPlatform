namespace SharedLibrary.Constants;

public static class ApplicationRoutes
{
    public const string Dashboard = "/";
    public const string Import = "/bidcon/import";
    public const string Report = "/bidcon/report";
    public const string Settings = "/settings";
    /// <summary>
    /// This class is empty. The authentication routes are defined in the SharedWasmLibrary
    /// </summary>
    public static class Authentication
    {
        public const string Login = "/authentication/login";
        public const string Logout = "/authentication/logout";
    }
}
