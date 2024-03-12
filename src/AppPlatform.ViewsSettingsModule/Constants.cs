namespace AppPlatform.ViewSettingsModule;
internal static class Constants
{
    internal static class Authorization
    {
        public const string Policy = "ViewSettings";
        public const string AccessClaimValue = "ViewSettings";
    }
    internal static class Routes
    {
        public const string SettingsBasePage = "/Settings/ViewSettings";
        public const string SettingsPage = "/Settings/ViewSettings/Edit";
    }
}
