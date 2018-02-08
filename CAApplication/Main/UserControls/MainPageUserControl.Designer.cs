namespace MainApplication
{
    partial class MainPageUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddClient = new System.Windows.Forms.Button();
            this.dataGridClients = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pancardColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.computationColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.declarationColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClients)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddClient
            // 
            this.btnAddClient.Location = new System.Drawing.Point(21, 19);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(92, 33);
            this.btnAddClient.TabIndex = 0;
            this.btnAddClient.Text = "Add Client";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // dataGridClients
            // 
            this.dataGridClients.AllowUserToAddRows = false;
            this.dataGridClients.AllowUserToDeleteRows = false;
            this.dataGridClients.AllowUserToResizeColumns = false;
            this.dataGridClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridClients.ColumnHeadersHeight = 25;
            this.dataGridClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.pancardColumn,
            this.computationColumn,
            this.declarationColumn});
            this.dataGridClients.Location = new System.Drawing.Point(21, 72);
            this.dataGridClients.Name = "dataGridClients";
            this.dataGridClients.RowHeadersVisible = false;
            this.dataGridClients.Size = new System.Drawing.Size(597, 275);
            this.dataGridClients.TabIndex = 1;
            this.dataGridClients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridClients_CellContentClick);
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            // 
            // pancardColumn
            // 
            this.pancardColumn.HeaderText = "Pan No";
            this.pancardColumn.Name = "pancardColumn";
            this.pancardColumn.ReadOnly = true;
            this.pancardColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pancardColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // computationColumn
            // 
            this.computationColumn.HeaderText = "Computation";
            this.computationColumn.Name = "computationColumn";
            this.computationColumn.ReadOnly = true;
            // 
            // declarationColumn
            // 
            this.declarationColumn.HeaderText = "Declaration";
            this.declarationColumn.Name = "declarationColumn";
            this.declarationColumn.ReadOnly = true;
            // 
            // MainPageUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridClients);
            this.Controls.Add(this.btnAddClient);
            this.Name = "MainPageUserControl";
            this.Size = new System.Drawing.Size(644, 371);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.DataGridView dataGridClients;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewLinkColumn pancardColumn;
        private System.Windows.Forms.DataGridViewLinkColumn computationColumn;
        private System.Windows.Forms.DataGridViewLinkColumn declarationColumn;
    }
}
