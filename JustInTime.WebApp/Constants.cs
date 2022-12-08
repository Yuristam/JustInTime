namespace JustInTime.WebApp
{
    public static class Constants
    {
        public static class Roles
        {
            public const string GroupAdmin = "GroupAdmin";
            public const string GroupMember = "GroupMember";
            public const string User = "User";
        }

        public static class Policies
        {
            public const string RequireAdmin = "RequireAdmin";
            public const string RequireMember = "RequireMember";
        }
    }
}
