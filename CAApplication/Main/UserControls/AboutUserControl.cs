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
    public partial class AboutUserControl : UserControl, IUserControlPanel
    {
        public AboutUserControl()
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
    }
}
