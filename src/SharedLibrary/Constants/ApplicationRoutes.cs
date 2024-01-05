namespace SharedLibrary.Constants;

public static class ApplicationRoutes
{
    public const string Dashboard = "/";
    public const string Import = "/bidcon/import";
    public const string Report = "/bidcon/report";

    public const string InvitationConfirmation = "/invitationconfirmation";
    public static class Settings
    {
        public const string Common = "/settings";
        public const string Bidcon = "/settings/bidcon";
        public const string Views = "/settings/views";
        
        public const string Rights = "/settings/rights";
        public static class  Organization
        {
            public const string Index = "/settings/organization";
            public const string Edit = "/settings/organization/edit";
            public const string New = "/settings/organization/new";
            public const string SubscriptionHandle ="/settings/organization/subscription";
        }
    }
}
