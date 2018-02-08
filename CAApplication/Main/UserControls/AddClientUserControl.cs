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
    public partial class AddClientUserControl : UserControl, IUserControlPanel
    {        
        public AddClientUserControl()
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

        private void AddClientUserControl_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            ClientInfo clientInfo = new ClientInfo();
            clientInfo.Name = txtName.Text;
            clientInfo.PANNumber = txtPanNumber.Text;
            clientInfo.FatherOrHusbandName = txtFatherOrHusbandName.Text;
            clientInfo.MobileNumber = txtMobileNumber.Text;
            clientInfo.EmailId = txtEmailId.Text;
            clientInfo.Address = txtAddress.Text;
            clientInfo.DateOfBirth = dtDateOfBirth.Value.ToString("yyyy-MM-dd");
            clientInfo.AuditorId = 1;

            // Save client info to data base
            SQLiteDatabaseAccessor db = new SQLiteDatabaseAccessor();
            db.AddClient(clientInfo);

            OnUpdateStatusToParent(new MyEventArgs("AddClientCompleted"));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnUpdateStatusToParent(new MyEventArgs("AddClientCancel"));
        }

        
        private void dtDateOfBirth_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
