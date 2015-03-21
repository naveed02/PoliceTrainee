namespace GUI_Task
{
    partial class frmContractorChargesTmp
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.dt = new System.Windows.Forms.DateTimePicker();
            this.label27 = new System.Windows.Forms.Label();
            this.lblProdProcNo = new System.Windows.Forms.Label();
            this.grdContCharTmp = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.optActive = new System.Windows.Forms.RadioButton();
            this.optInActive = new System.Windows.Forms.RadioButton();
            this.btnExitSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblItemCode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdContCharTmp)).BeginInit();
            this.SuspendLayout();
            // 
            // label25
            // 
            this.label25.AllowDrop = true;
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label25.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(2, 36);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(100, 17);
            this.label25.TabIndex = 896;
            this.label25.Text = "Item Code";
            this.label25.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label26
            // 
            this.label26.AllowDrop = true;
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label26.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(2, 13);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(100, 17);
            this.label26.TabIndex = 895;
            this.label26.Text = "Prod. Proc #";
            this.label26.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dt
            // 
            this.dt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt.Location = new System.Drawing.Point(366, 9);
            this.dt.Name = "dt";
            this.dt.Size = new System.Drawing.Size(122, 21);
            this.dt.TabIndex = 894;
            // 
            // label27
            // 
            this.label27.AllowDrop = true;
            this.label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label27.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label27.Location = new System.Drawing.Point(272, 13);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(88, 17);
            this.label27.TabIndex = 893;
            this.label27.Text = " Date";
            this.label27.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblProdProcNo
            // 
            this.lblProdProcNo.AllowDrop = true;
            this.lblProdProcNo.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblProdProcNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProdProcNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdProcNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProdProcNo.Location = new System.Drawing.Point(108, 13);
            this.lblProdProcNo.Name = "lblProdProcNo";
            this.lblProdProcNo.Size = new System.Drawing.Size(158, 17);
            this.lblProdProcNo.TabIndex = 891;
            this.lblProdProcNo.Text = " 01-14-1 ";
            this.lblProdProcNo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdContCharTmp
            // 
            this.grdContCharTmp.AllowUserToDeleteRows = false;
            this.grdContCharTmp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdContCharTmp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdContCharTmp.BackgroundColor = System.Drawing.Color.Gray;
            this.grdContCharTmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdContCharTmp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.grdContCharTmp.Location = new System.Drawing.Point(2, 56);
            this.grdContCharTmp.Name = "grdContCharTmp";
            this.grdContCharTmp.ReadOnly = true;
            this.grdContCharTmp.Size = new System.Drawing.Size(611, 218);
            this.grdContCharTmp.TabIndex = 899;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.HeaderText = "Machine #";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.HeaderText = "Contractor";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column10.HeaderText = "Shift";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column11.HeaderText = "Charges Type";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(183, 280);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(83, 19);
            this.btnPrint.TabIndex = 904;
            this.btnPrint.Text = "Printing";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // optActive
            // 
            this.optActive.AutoSize = true;
            this.optActive.Checked = true;
            this.optActive.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optActive.Location = new System.Drawing.Point(281, 280);
            this.optActive.Name = "optActive";
            this.optActive.Size = new System.Drawing.Size(56, 19);
            this.optActive.TabIndex = 903;
            this.optActive.TabStop = true;
            this.optActive.Text = "Active";
            this.optActive.UseVisualStyleBackColor = true;
            // 
            // optInActive
            // 
            this.optInActive.AutoSize = true;
            this.optInActive.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optInActive.Location = new System.Drawing.Point(343, 280);
            this.optInActive.Name = "optInActive";
            this.optInActive.Size = new System.Drawing.Size(66, 19);
            this.optInActive.TabIndex = 902;
            this.optInActive.Text = "InActive";
            this.optInActive.UseVisualStyleBackColor = true;
            // 
            // btnExitSave
            // 
            this.btnExitSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitSave.Location = new System.Drawing.Point(2, 280);
            this.btnExitSave.Name = "btnExitSave";
            this.btnExitSave.Size = new System.Drawing.Size(85, 19);
            this.btnExitSave.TabIndex = 900;
            this.btnExitSave.Text = "Exit+Save";
            this.btnExitSave.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(92, 280);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 19);
            this.btnExit.TabIndex = 901;
            this.btnExit.Text = "Esc=Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button12_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(494, 11);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(89, 19);
            this.btnHelp.TabIndex = 905;
            this.btnHelp.Text = "F1=Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(494, 36);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(89, 19);
            this.btnAdd.TabIndex = 906;
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.BackColor = System.Drawing.SystemColors.Window;
            this.lblItemCode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCode.Location = new System.Drawing.Point(108, 37);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(379, 15);
            this.lblItemCode.TabIndex = 907;
            this.lblItemCode.Text = "                                                                                 " +
                "                                           ";
            this.lblItemCode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmContractorChargesTmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 300);
            this.Controls.Add(this.lblItemCode);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.optActive);
            this.Controls.Add(this.optInActive);
            this.Controls.Add(this.btnExitSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.grdContCharTmp);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.dt);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.lblProdProcNo);
            this.Name = "frmContractorChargesTmp";
            this.Text = "Contractor Charges Template";
            ((System.ComponentModel.ISupportInitialize)(this.grdContCharTmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.DateTimePicker dt;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lblProdProcNo;
        private System.Windows.Forms.DataGridView grdContCharTmp;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.RadioButton optActive;
        private System.Windows.Forms.RadioButton optInActive;
        private System.Windows.Forms.Button btnExitSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblItemCode;
    }
}