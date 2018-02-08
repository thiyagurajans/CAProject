using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace MainApplication
{
    class CreateUserControlFactory
    {

        public static IUserControlPanel CreateRightPane(string controlType)
        {
            IUserControlPanel rightPane = null;
            switch (controlType)
            {
                case Constants.Register:
                    rightPane = new RegistrationUserControl();
                    break;
                case Constants.Login:
                    rightPane = new LoginUserControl();
                    break;
                case Constants.About:
                case Constants.Home:
                case Constants.Logout:
                    rightPane = new AboutUserControl();
                    break;
                case Constants.MainPage:
                    rightPane = new MainPageUserControl();
                    break;
                case Constants.AddClient:
                    rightPane = new AddClientUserControl();
                    break;
                case Constants.ClientInputData:
                    rightPane = new ClientInputDataUserControl();
                    break;
            }

            return rightPane;
        }
    }

    public interface IUserControlPanel
    {
        event EventHandler<MyEventArgs> UpdateStatusToParent;  
    }

    public class MyEventArgs : EventArgs
    {
        public string  Status { get; set; }

        public MyEventArgs(string status)
        {
            Status = status;
        }
    }  
}

