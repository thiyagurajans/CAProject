namespace MainApplication
{
    partial class AddClientUserControl
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.gbClientInfo = new System.Windows.Forms.GroupBox();
            this.txtEmailId = new System.Windows.Forms.TextBox();
            this.lblEmailId = new System.Windows.Forms.Label();
            this.txtMobileNumber = new System.Windows.Forms.TextBox();
            this.lblMobileNumber = new System.Windows.Forms.Label();
            this.txtFatherOrHusbandName = new System.Windows.Forms.TextBox();
            this.lblFatherOrHusbandName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPanNumber = new System.Windows.Forms.TextBox();
            this.dtDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblPanNumber = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.gbClientInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(243, 257);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(359, 257);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(92, 30);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // gbClientInfo
            // 
            this.gbClientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbClientInfo.Controls.Add(this.txtEmailId);
            this.gbClientInfo.Controls.Add(this.lblEmailId);
            this.gbClientInfo.Controls.Add(this.txtMobileNumber);
            this.gbClientInfo.Controls.Add(this.lblMobileNumber);
            this.gbClientInfo.Controls.Add(this.txtFatherOrHusbandName);
            this.gbClientInfo.Controls.Add(this.lblFatherOrHusbandName);
            this.gbClientInfo.Controls.Add(this.lblName);
            this.gbClientInfo.Controls.Add(this.txtName);
            this.gbClientInfo.Controls.Add(this.txtPanNumber);
            this.gbClientInfo.Controls.Add(this.dtDateOfBirth);
            this.gbClientInfo.Controls.Add(this.lblPanNumber);
            this.gbClientInfo.Controls.Add(this.lblDateOfBirth);
            this.gbClientInfo.Controls.Add(this.txtAddress);
            this.gbClientInfo.Controls.Add(this.lblAddress);
            this.gbClientInfo.Location = new System.Drawing.Point(17, 16);
            this.gbClientInfo.Name = "gbClientInfo";
            this.gbClientInfo.Size = new System.Drawing.Size(685, 226);
            this.gbClientInfo.TabIndex = 31;
            this.gbClientInfo.TabStop = false;
            this.gbClientInfo.Text = "Client Information";
            // 
            // txtEmailId
            // 
            this.txtEmailId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtEmailId.Location = new System.Drawing.Point(464, 122);
            this.txtEmailId.Name = "txtEmailId";
            this.txtEmailId.Size = new System.Drawing.Size(203, 20);
            this.txtEmailId.TabIndex = 44;
            // 
            // lblEmailId
            // 
            this.lblEmailId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblEmailId.AutoSize = true;
            this.lblEmailId.Location = new System.Drawing.Point(377, 123);
            this.lblEmailId.Name = "lblEmailId";
            this.lblEmailId.Size = new System.Drawing.Size(47, 13);
            this.lblEmailId.TabIndex = 43;
            this.lblEmailId.Text = "Email Id:";
            // 
            // txtMobileNumber
            // 
            this.txtMobileNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtMobileNumber.Location = new System.Drawing.Point(464, 77);
            this.txtMobileNumber.Name = "txtMobileNumber";
            this.txtMobileNumber.Size = new System.Drawing.Size(203, 20);
            this.txtMobileNumber.TabIndex = 42;
            // 
            // lblMobileNumber
            // 
            this.lblMobileNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblMobileNumber.AutoSize = true;
            this.lblMobileNumber.Location = new System.Drawing.Point(377, 82);
            this.lblMobileNumber.Name = "lblMobileNumber";
            this.lblMobileNumber.Size = new System.Drawing.Size(81, 13);
            this.lblMobileNumber.TabIndex = 41;
            this.lblMobileNumber.Text = "Mobile Number:";
            // 
            // txtFatherOrHusbandName
            // 
            this.txtFatherOrHusbandName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtFatherOrHusbandName.Location = new System.Drawing.Point(157, 82);
            this.txtFatherOrHusbandName.Name = "txtFatherOrHusbandName";
            this.txtFatherOrHusbandName.Size = new System.Drawing.Size(203, 20);
            this.txtFatherOrHusbandName.TabIndex = 40;
            // 
            // lblFatherOrHusbandName
            // 
            this.lblFatherOrHusbandName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblFatherOrHusbandName.AutoSize = true;
            this.lblFatherOrHusbandName.Location = new System.Drawing.Point(17, 82);
            this.lblFatherOrHusbandName.Name = "lblFatherOrHusbandName";
            this.lblFatherOrHusbandName.Size = new System.Drawing.Size(131, 13);
            this.lblFatherOrHusbandName.TabIndex = 39;
            this.lblFatherOrHusbandName.Text = "Father Or Husband Name:";
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(17, 45);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 31;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtName.Location = new System.Drawing.Point(157, 42);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(203, 20);
            this.txtName.TabIndex = 33;
            // 
            // txtPanNumber
            // 
            this.txtPanNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtPanNumber.Location = new System.Drawing.Point(464, 42);
            this.txtPanNumber.Name = "txtPanNumber";
            this.txtPanNumber.Size = new System.Drawing.Size(203, 20);
            this.txtPanNumber.TabIndex = 34;
            // 
            // dtDateOfBirth
            // 
            this.dtDateOfBirth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateOfBirth.Location = new System.Drawing.Point(464, 167);
            this.dtDateOfBirth.Name = "dtDateOfBirth";
            this.dtDateOfBirth.Size = new System.Drawing.Size(203, 20);
            this.dtDateOfBirth.TabIndex = 38;
            // 
            // lblPanNumber
            // 
            this.lblPanNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblPanNumber.AutoSize = true;
            this.lblPanNumber.Location = new System.Drawing.Point(377, 45);
            this.lblPanNumber.Name = "lblPanNumber";
            this.lblPanNumber.Size = new System.Drawing.Size(29, 13);
            this.lblPanNumber.TabIndex = 32;
            this.lblPanNumber.Text = "Pan:";
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(377, 169);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(39, 13);
            this.lblDateOfBirth.TabIndex = 37;
            this.lblDateOfBirth.Text = "D.O.B:";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAddress.Location = new System.Drawing.Point(157, 123);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(203, 85);
            this.txtAddress.TabIndex = 36;
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(17, 123);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 35;
            this.lblAddress.Text = "Address:";
            // 
            // AddClientUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbClientInfo);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.MinimumSize = new System.Drawing.Size(719, 306);
            this.Name = "AddClientUserControl";
            this.Size = new System.Drawing.Size(719, 306);
            this.Load += new System.EventHandler(this.AddClientUserControl_Load);
            this.gbClientInfo.ResumeLayout(false);
            this.gbClientInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.GroupBox gbClientInfo;
        private System.Windows.Forms.TextBox txtEmailId;
        private System.Windows.Forms.Label lblEmailId;
        private System.Windows.Forms.TextBox txtMobileNumber;
        private System.Windows.Forms.Label lblMobileNumber;
        private System.Windows.Forms.TextBox txtFatherOrHusbandName;
        private System.Windows.Forms.Label lblFatherOrHusbandName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPanNumber;
        private System.Windows.Forms.DateTimePicker dtDateOfBirth;
        private System.Windows.Forms.Label lblPanNumber;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
    }
}
