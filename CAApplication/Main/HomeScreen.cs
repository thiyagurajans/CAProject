using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;

namespace MainApplication
{
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();

            UpdateUserControl(Constants.About);
        }    

        private void UpdateUserControl(string controltype)
        {
            try
            {
                this.pnlUserControlHolder.Controls.Clear();
                IUserControlPanel rightPane = null;

                rightPane = CreateUserControlFactory.CreateRightPane(controltype);
                rightPane.UpdateStatusToParent -= new EventHandler<MyEventArgs>(rightPane_UpdateStatusToParent);
                rightPane.UpdateStatusToParent += new EventHandler<MyEventArgs>(rightPane_UpdateStatusToParent);
                this.pnlUserControlHolder.Controls.Add((UserControl)rightPane);
                ((UserControl)rightPane).Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void rightPane_UpdateStatusToParent(object sender, MyEventArgs e)
        {
            
            switch(e.Status)
            {
                case Constants.LoginSucceeded:
                case Constants.RegistrationCompleted:
                case Constants.AddClientCancel:
                case Constants.AddClientCompleted:
                    UpdateUserControl(Constants.MainPage);
                    button2.Text = Constants.Logout;
                    button1.Text = Constants.Home;
                    break;
                case Constants.AddClient:
                    UpdateUserControl(Constants.AddClient);
                    break;
                case Constants.RegistrationCanceled:
                    UpdateUserControl(Constants.About);
                    button1.Text = Constants.Register;
                    break;
                case Constants.PanNoLinkClick:
                    UpdateUserControl(Constants.ClientInputData);
                    button2.Text = Constants.Logout;
                    button1.Text = Constants.Home;
                    break;

            }
                        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateUserControl(button1.Text);
            if (button1.Text == Constants.Register)
            {
                button1.Text = Constants.Home;

            }
            if (button1.Text == Constants.Home)
            {
                button1.Text = Constants.Register;

            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateUserControl(button2.Text);
            if (button2.Text == Constants.Logout)
            {
                button2.Text = Constants.Login;
            }
        }
    }
}
