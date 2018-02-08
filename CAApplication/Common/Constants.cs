using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Constants
    {
        public  const string SQLiteDatabase = "SQLiteDatabase.sqlite";

        // User Actions
        public const string LoginSucceeded = "LoginSucceeded";
        public const string RegistrationCompleted = "RegistrationCompleted";
        public const string AddClientCancel = "AddClientCancel";
        public const string AddClientCompleted = "AddClientCompleted";
        public const string AddClient = "AddClient";
        public const string RegistrationCanceled = "RegistrationCanceled";
        public const string PanNoLinkClick = "PanNoLinkClick";

        // Control Types
        public const string Register = "Register";
        public const string Login = "Login";
        public const string About = "About";
        public const string Home = "Home";
        public const string Logout = "Logout";
        public const string MainPage = "MainPage";
        public const string ClientInputData = "ClientInputData";
        
    }
}
