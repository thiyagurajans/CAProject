using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using DatabaseLayer;

namespace MainApplication
{
    public partial class ClientInputDataUserControl : UserControl, IUserControlPanel
    {
        public event EventHandler<MyEventArgs> UpdateStatusToParent;
        
        public ClientInputDataUserControl()
        {
            InitializeComponent();
        }

        protected virtual void OnUpdateStatusToParent(MyEventArgs e)
        {
            if (UpdateStatusToParent != null)
            {
                UpdateStatusToParent(this, e);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
    }
}
