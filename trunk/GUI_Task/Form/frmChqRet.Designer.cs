namespace GUI_Task
{
    partial class frmChqRet
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblNameBottom = new System.Windows.Forms.Label();
            this.lblVoucherNumber = new System.Windows.Forms.Label();
            this.btnChqHelp = new System.Windows.Forms.Button();
            this.btnVocHelp = new System.Windows.Forms.Button();
            this.dt = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mskCustomerCode = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdChqRet = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPChq = new System.Windows.Forms.Button();
            this.chkPrinter = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExitSave = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChqRet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBalance);
            this.groupBox1.Controls.Add(this.lblNameBottom);
            this.groupBox1.Controls.Add(this.lblVoucherNumber);
            this.groupBox1.Controls.Add(this.btnChqHelp);
            this.groupBox1.Controls.Add(this.btnVocHelp);
            this.groupBox1.Controls.Add(this.dt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.mskCustomerCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(719, 101);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblBalance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(141, 73);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(127, 15);
            this.lblBalance.TabIndex = 141;
            this.lblBalance.Text = "                                        ";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblNameBottom
            // 
            this.lblNameBottom.AutoSize = true;
            this.lblNameBottom.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblNameBottom.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameBottom.Location = new System.Drawing.Point(478, 45);
            this.lblNameBottom.Name = "lblNameBottom";
            this.lblNameBottom.Size = new System.Drawing.Size(232, 15);
            this.lblNameBottom.TabIndex = 140;
            this.lblNameBottom.Text = "                                                                           ";
            this.lblNameBottom.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblVoucherNumber
            // 
            this.lblVoucherNumber.AutoSize = true;
            this.lblVoucherNumber.BackColor = System.Drawing.SystemColors.Window;
            this.lblVoucherNumber.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucherNumber.Location = new System.Drawing.Point(141, 16);
            this.lblVoucherNumber.Name = "lblVoucherNumber";
            this.lblVoucherNumber.Size = new System.Drawing.Size(142, 15);
            this.lblVoucherNumber.TabIndex = 139;
            this.lblVoucherNumber.Text = "                                             ";
            this.lblVoucherNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnChqHelp
            // 
            this.btnChqHelp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnChqHelp.Location = new System.Drawing.Point(578, 70);
            this.btnChqHelp.Name = "btnChqHelp";
            this.btnChqHelp.Size = new System.Drawing.Size(124, 20);
            this.btnChqHelp.TabIndex = 79;
            this.btnChqHelp.Text = "[F1] = Cheques Help";
            this.btnChqHelp.UseVisualStyleBackColor = true;
            this.btnChqHelp.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnVocHelp
            // 
            this.btnVocHelp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnVocHelp.Location = new System.Drawing.Point(400, 70);
            this.btnVocHelp.Name = "btnVocHelp";
            this.btnVocHelp.Size = new System.Drawing.Size(124, 20);
            this.btnVocHelp.TabIndex = 21;
            this.btnVocHelp.Text = "[F1] = Unposted Voc.";
            this.btnVocHelp.UseVisualStyleBackColor = true;
            this.btnVocHelp.Click += new System.EventHandler(this.button4_Click);
            // 
            // dt
            // 
            this.dt.Location = new System.Drawing.Point(478, 16);
            this.dt.Name = "dt";
            this.dt.Size = new System.Drawing.Size(106, 20);
            this.dt.TabIndex = 69;
            // 
            // label5
            // 
            this.label5.AllowDrop = true;
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(400, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 77;
            this.label5.Text = "     Name     ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AllowDrop = true;
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(400, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 76;
            this.label4.Text = "      Date      ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mskCustomerCode
            // 
            this.mskCustomerCode.Location = new System.Drawing.Point(144, 42);
            this.mskCustomerCode.Mask = "0-0-00-00-0000";
            this.mskCustomerCode.Name = "mskCustomerCode";
            this.mskCustomerCode.Size = new System.Drawing.Size(127, 20);
            this.mskCustomerCode.TabIndex = 5;
            this.mskCustomerCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskCustomerCode_KeyDown);
            this.mskCustomerCode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mskCustomerCode_MouseDoubleClick);
            // 
            // label3
            // 
            this.label3.AllowDrop = true;
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(6, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "            Balance           ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Customer Code         ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "   Voucher Number   ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdChqRet
            // 
            this.grdChqRet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdChqRet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6});
            this.grdChqRet.Location = new System.Drawing.Point(6, 119);
            this.grdChqRet.Name = "grdChqRet";
            this.grdChqRet.Size = new System.Drawing.Size(725, 239);
            this.grdChqRet.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Account No.";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Account Name";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Voucher Details";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Amount";
            this.Column4.Name = "Column4";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Cheq #";
            this.Column6.Name = "Column6";
            // 
            // label6
            // 
            this.label6.AllowDrop = true;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.NavajoWhite;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(561, 375);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 120;
            this.label6.Text = "    Total    ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPChq
            // 
            this.btnPChq.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPChq.Location = new System.Drawing.Point(654, 439);
            this.btnPChq.Name = "btnPChq";
            this.btnPChq.Size = new System.Drawing.Size(75, 20);
            this.btnPChq.TabIndex = 137;
            this.btnPChq.Text = "P.Cheq";
            this.btnPChq.UseVisualStyleBackColor = true;
            // 
            // chkPrinter
            // 
            this.chkPrinter.AutoSize = true;
            this.chkPrinter.Checked = true;
            this.chkPrinter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrinter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrinter.Location = new System.Drawing.Point(561, 441);
            this.chkPrinter.Name = "chkPrinter";
            this.chkPrinter.Size = new System.Drawing.Size(62, 19);
            this.chkPrinter.TabIndex = 136;
            this.chkPrinter.Text = "Printer";
            this.chkPrinter.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(654, 466);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 20);
            this.btnCancel.TabIndex = 139;
            this.btnCancel.Text = "Cancel Ent";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(561, 466);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 20);
            this.btnPrint.TabIndex = 138;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHelp.Location = new System.Drawing.Point(461, 466);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 20);
            this.btnHelp.TabIndex = 140;
            this.btnHelp.Text = "[F1] = Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(362, 466);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 20);
            this.btnExit.TabIndex = 142;
            this.btnExit.Text = "[Esc] = Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button8_Click);
            // 
            // btnExitSave
            // 
            this.btnExitSave.Enabled = false;
            this.btnExitSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExitSave.Location = new System.Drawing.Point(264, 466);
            this.btnExitSave.Name = "btnExitSave";
            this.btnExitSave.Size = new System.Drawing.Size(75, 20);
            this.btnExitSave.TabIndex = 141;
            this.btnExitSave.Text = "Exit + Save";
            this.btnExitSave.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDel.Location = new System.Drawing.Point(67, 464);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 20);
            this.btnDel.TabIndex = 143;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.SystemColors.Window;
            this.lblTotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(635, 375);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(94, 15);
            this.lblTotal.TabIndex = 149;
            this.lblTotal.Text = "                             ";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmChqRet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 496);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExitSave);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPChq);
            this.Controls.Add(this.chkPrinter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.grdChqRet);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmChqRet";
            this.Text = "Cheque Return";
            this.Load += new System.EventHandler(this.cheque_Return_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChqRet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChqHelp;
        private System.Windows.Forms.Button btnVocHelp;
        private System.Windows.Forms.DateTimePicker dt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mskCustomerCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdChqRet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPChq;
        private System.Windows.Forms.CheckBox chkPrinter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExitSave;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblNameBottom;
        private System.Windows.Forms.Label lblVoucherNumber;
        private System.Windows.Forms.Label lblTotal;
    }
}