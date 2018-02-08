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
    public partial class MainPageUserControl : UserControl, IUserControlPanel
    {
        public MainPageUserControl()
        {
            InitializeComponent();
            LoadDataGridClients();

        }
        public event EventHandler<MyEventArgs> UpdateStatusToParent;

        protected virtual void OnUpdateStatusToParent(MyEventArgs e)
        {
            if (UpdateStatusToParent != null) 
            {
                UpdateStatusToParent(this, e);
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            OnUpdateStatusToParent(new MyEventArgs(Constants.AddClient));
        }

        public void LoadDataGridClients()
        {
            SQLiteDatabaseAccessor db = new SQLiteDatabaseAccessor();
            List<ClientInfo> clients = db.GetClients(1);
            
            if (clients.Count > 0)
            {
                dataGridClients.Rows.Clear();
                dataGridClients.Rows.Add(clients.Count);
                int rowIndex = 0;

                foreach (ClientInfo client in clients)
                {
                    dataGridClients.Rows[rowIndex].Cells[0].Value = client.Name;
                    dataGridClients.Rows[rowIndex].Cells[1].Value = client.PANNumber;
                    dataGridClients.Rows[rowIndex].Cells[2].Value = "Click Here";
                    dataGridClients.Rows[rowIndex].Cells[3].Value = "Click Here";
                    rowIndex++;                    
                }
 
            }
        }

        private void dataGridClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {            
            // bool isLinkColumn = ((DataGridView)sender).Columns[e.ColumnIndex].GetType() == typeof(DataGridViewLinkColumn);
            
            // Check if it is Pan No link column
            if (e.ColumnIndex == ((DataGridView)sender).Columns["pancardColumn"].Index)
            {                
                // set the pan no here before updating to parent. This pan no is used in Client input data screen to load client inputs
                GlobalData.Instance.PanNumber = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                OnUpdateStatusToParent(new MyEventArgs(Constants.PanNoLinkClick));
            }            
        }
    }
}
