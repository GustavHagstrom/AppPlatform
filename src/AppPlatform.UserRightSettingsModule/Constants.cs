namespace AppPlatform.UserRightSettingsModule;
internal static class Constants
{
    public static class ModuleRoutes
    {
        public const string SettingsBasePage = "/Settings/UserRightSettings";
    }
    public static class AuthorizationConstants
    {
        public const string Policy = "UserRightSettingsPolicy";
        public const string AccessClaimValue = "UserRightSettingsAccess";
    }
}
