using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainApplication
{
    public partial class RegistrationUserControl : UserControl, IUserControlPanel
    {
        public RegistrationUserControl()
        {
            InitializeComponent();
        }

        public event EventHandler<MyEventArgs> UpdateStatusToParent;

        protected virtual void OnUpdateStatusToParent(MyEventArgs e)
        {
            if (UpdateStatusToParent != null)
            {
                UpdateStatusToParent(this, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnUpdateStatusToParent(new MyEventArgs("RegistrationCompleted"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OnUpdateStatusToParent(new MyEventArgs("RegistrationCanceled"));
        }  
    }
}
