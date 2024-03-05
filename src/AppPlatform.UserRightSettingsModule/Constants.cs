namespace AppPlatform.UserRightSettingsModule;
internal static class Constants
{
    public static class ModuleRoutes
    {
        public const string UserListPage = "/Settings/Users";
        public const string UserAccessEdit = "/Settings/Users/Edit";
        public const string RoleListPage = "/Settings/Roles/";
        public const string RoleAccessEdit = "/Settings/Roles/Edit";
        
    }
    public static class AuthorizationConstants
    {
        public const string Policy = "UserRightSettingsPolicy";
        public const string AccessClaimValue = "UserRightSettingsAccess";
    }
}
