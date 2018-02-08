namespace MainApplication
{
    partial class ClientInputDataUserControl
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SelectOrUnselect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.InputDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.InputData = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblFinancialYear = new System.Windows.Forms.Label();
            this.lblPanNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectOrUnselect,
            this.InputDescription,
            this.Category,
            this.InputData});
            this.dataGridView1.Location = new System.Drawing.Point(14, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(725, 189);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // SelectOrUnselect
            // 
            this.SelectOrUnselect.FillWeight = 10.76142F;
            this.SelectOrUnselect.HeaderText = "Select";
            this.SelectOrUnselect.MinimumWidth = 3;
            this.SelectOrUnselect.Name = "SelectOrUnselect";
            this.SelectOrUnselect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SelectOrUnselect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // InputDescription
            // 
            this.InputDescription.FillWeight = 45.04907F;
            this.InputDescription.HeaderText = "Input Description";
            this.InputDescription.MinimumWidth = 8;
            this.InputDescription.Name = "InputDescription";
            this.InputDescription.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Category
            // 
            this.Category.FillWeight = 35.09475F;
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Category.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // InputData
            // 
            this.InputData.FillWeight = 10.09475F;
            this.InputData.HeaderText = "Input Data";
            this.InputData.Name = "InputData";
            this.InputData.Text = "Click";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(55, 287);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 34);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(462, 287);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 34);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(324, 287);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 34);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(185, 287);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 34);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(602, 287);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 34);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(88, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(167, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // lblFinancialYear
            // 
            this.lblFinancialYear.AutoSize = true;
            this.lblFinancialYear.Location = new System.Drawing.Point(11, 48);
            this.lblFinancialYear.Name = "lblFinancialYear";
            this.lblFinancialYear.Size = new System.Drawing.Size(77, 13);
            this.lblFinancialYear.TabIndex = 7;
            this.lblFinancialYear.Text = "Financial Year:";
            // 
            // lblPanNumber
            // 
            this.lblPanNumber.AutoSize = true;
            this.lblPanNumber.Location = new System.Drawing.Point(11, 14);
            this.lblPanNumber.Name = "lblPanNumber";
            this.lblPanNumber.Size = new System.Drawing.Size(69, 13);
            this.lblPanNumber.TabIndex = 8;
            this.lblPanNumber.Text = "Pan Number:";
            // 
            // ClientInputDataUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPanNumber);
            this.Controls.Add(this.lblFinancialYear);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ClientInputDataUserControl";
            this.Size = new System.Drawing.Size(755, 345);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectOrUnselect;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputDescription;
        private System.Windows.Forms.DataGridViewComboBoxColumn Category;
        private System.Windows.Forms.DataGridViewButtonColumn InputData;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblFinancialYear;
        private System.Windows.Forms.Label lblPanNumber;
    }
}
