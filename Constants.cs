using System;

using MongoDB.Bson;

namespace CLPostLibrary
{
    public static class Constants
    {
        //public static int FemaleFirstNameCount = 4275;
        //public static int MaleFirstNameCount = 1219;
        //public static int LastNameCount = 88799;
        //public static int StreetNameCount = 91670;

        //public static Tuple<int, string, string> Created = new Tuple<int, string, string>(AdvertisementStartRange, "Advertisement (Created)", "[" + TokenKeys.UserRole.Replace(TokenKeys.ItemSep, "").Replace(TokenKeys.KVSep, "") + "] account for ([" + TokenKeys.UserFullName.Replace(TokenKeys.ItemSep, "").Replace(TokenKeys.KVSep, "") + "]) Created by ([" + TokenKeys.UpdatedByLoggedinAdminFullName.Replace(TokenKeys.ItemSep, "").Replace(TokenKeys.KVSep, "") + "]).");

        public static Tuple<int, string, string> Base = new Tuple<int, string, string>(EventStartRange, "Event (Base)", "Base Assignments Event Class");
        public static Tuple<int, string, string> Exception = new Tuple<int, string, string>(ExceptionStartRange, "Exception (Error)", "Exceptions Event Class");

        #region TokenKeys

            public static class TokenKeys
            {
                public const string ItemSep = "|";          // Pipe(|) used as item seperator
                public const string KVSep = ":";            // Colon(:) used as Key/value seperator

                public static string UpdatedByLoggedinAdminFullName = ItemSep + "UpdatedByLoggedinAdminFullName" + KVSep;
                public static string UpdatedValues = ItemSep + "UpdatedValues" + KVSep;
                public static string UserFullName = ItemSep + "UserFullName" + KVSep;
                public static string UserName = ItemSep + "UserName" + KVSep;
                public static string UserRole = ItemSep + "UserRole" + KVSep;
            }

        #endregion

        #region Event class range initialization

            public const int EventStartRange = 0;
            public const int ServerStartRange = 1000;
            public const int EmailStartRange = 2000;
            public const int AccountStartRange = 3000;
            public const int AdvertisementStartRange = 4000;
            public const int ExceptionStartRange = 10000;

        #endregion

        #region EventLog

            public static class Event
            {
                public static Tuple<int, string, string> Generic = new Tuple<int, string, string>(EventStartRange + 1, "Event (Generic)", "Generic Event Class");

                public static class Server
                {
                    public static Tuple<int, string, string> Created = new Tuple<int, string, string>(ServerStartRange, "Server (Created)", "");
                    public static Tuple<int, string, string> Updated = new Tuple<int, string, string>(Created.Item1 + 1, "Server (Updated)", "");
                    public static Tuple<int, string, string> Deleted = new Tuple<int, string, string>(Updated.Item1 + 1, "Server (Deleted)", "");
                    public static Tuple<int, string, string> Disabled = new Tuple<int, string, string>(Deleted.Item1 + 1, "Server (Disabled)", "");
                    public static Tuple<int, string, string> Enabled = new Tuple<int, string, string>(Disabled.Item1 + 1, "Server (Enabled)", "");
                    public static Tuple<int, string, string> Flagged = new Tuple<int, string, string>(Enabled.Item1 + 1, "Server (Flagged)", "");
                }

                public static class Email
                {
                    public static Tuple<int, string, string> Created = new Tuple<int, string, string>(EmailStartRange, "Email (Created)", "");
                    public static Tuple<int, string, string> Updated = new Tuple<int, string, string>(Created.Item1 + 1, "Email (Updated)", "");
                    public static Tuple<int, string, string> Deleted = new Tuple<int, string, string>(Updated.Item1 + 1, "Email (Deleted)", "");
                    public static Tuple<int, string, string> Disabled = new Tuple<int, string, string>(Deleted.Item1 + 1, "Email (Disabled)", "");
                    public static Tuple<int, string, string> Enabled = new Tuple<int, string, string>(Disabled.Item1 + 1, "Email (Enabled)", "");
                    public static Tuple<int, string, string> Flagged = new Tuple<int, string, string>(Enabled.Item1 + 1, "Email (Flagged)", "");
                }

                public static class Account
                {
                    public static Tuple<int, string, string> Created = new Tuple<int, string, string>(AccountStartRange, "Account (Created)", "");
                    public static Tuple<int, string, string> Updated = new Tuple<int, string, string>(Created.Item1 + 1, "Account (Updated)", "");
                    public static Tuple<int, string, string> Deleted = new Tuple<int, string, string>(Updated.Item1 + 1, "Account (Deleted)", "");
                    public static Tuple<int, string, string> Disabled = new Tuple<int, string, string>(Deleted.Item1 + 1, "Account (Disabled)", "");
                    public static Tuple<int, string, string> Enabled = new Tuple<int, string, string>(Disabled.Item1 + 1, "Account (Enabled)", "");
                    public static Tuple<int, string, string> Flagged = new Tuple<int, string, string>(Enabled.Item1 + 1, "Account (Flagged)", "");
                }

                public static class Advertisement
                {
                    public static Tuple<int, string, string> Created = new Tuple<int, string, string>(AdvertisementStartRange, "Advertisement (Created)", "");
                    public static Tuple<int, string, string> Updated = new Tuple<int, string, string>(Created.Item1 + 1, "Advertisement (Updated)", "");
                    public static Tuple<int, string, string> Deleted = new Tuple<int, string, string>(Updated.Item1 + 1, "Advertisement (Deleted)", "");
                    public static Tuple<int, string, string> Disabled = new Tuple<int, string, string>(Deleted.Item1 + 1, "Advertisement (Disabled)", "");
                    public static Tuple<int, string, string> Enabled = new Tuple<int, string, string>(Disabled.Item1 + 1, "Advertisement (Enabled)", "");
                    public static Tuple<int, string, string> Queued = new Tuple<int, string, string>(Enabled.Item1 + 1, "Advertisement (Queued)", "");
                    public static Tuple<int, string, string> Published = new Tuple<int, string, string>(Queued.Item1 + 1, "Advertisement (Published)", "");
                }
            }

        #endregion
    }
}
