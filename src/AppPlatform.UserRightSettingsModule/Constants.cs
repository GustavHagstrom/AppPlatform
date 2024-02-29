namespace AppPlatform.UserRightSettingsModule;
internal static class Constants
{
    public static class ModuleRoutes
    {
        public const string SettingsBasePage = "/Settings/UserAccess";
        public const string UserAccessSettings = "/Settings/UserAccess/Edit";
        public const string RoleSettings = "/Settings/RoleAccess/";
    }
    public static class AuthorizationConstants
    {
        public const string Policy = "UserRightSettingsPolicy";
        public const string AccessClaimValue = "UserRightSettingsAccess";
    }
}
