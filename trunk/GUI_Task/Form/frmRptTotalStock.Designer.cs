namespace GUI_Task
{
    partial class frmRptTotalStock
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.optGodownWise = new System.Windows.Forms.RadioButton();
            this.optAllGodown = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.optDetailCT = new System.Windows.Forms.RadioButton();
            this.optPUS = new System.Windows.Forms.RadioButton();
            this.optPUSRemainingOrder = new System.Windows.Forms.RadioButton();
            this.optSummaryNegative = new System.Windows.Forms.RadioButton();
            this.optSummary = new System.Windows.Forms.RadioButton();
            this.optDetailSize = new System.Windows.Forms.RadioButton();
            this.optDetailAll = new System.Windows.Forms.RadioButton();
            this.chkIsZeroBalance = new System.Windows.Forms.CheckBox();
            this.optDetail = new System.Windows.Forms.RadioButton();
            this.chkDateWise = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.cboGodown = new System.Windows.Forms.ComboBox();
            this.cboItemGrp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.optGodownWise);
            this.groupBox1.Controls.Add(this.optAllGodown);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cboCategory);
            this.groupBox1.Controls.Add(this.cboGodown);
            this.groupBox1.Controls.Add(this.cboItemGrp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 475);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(203, 437);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 24);
            this.btnOK.TabIndex = 72;
            this.btnOK.Text = "O.K";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(325, 437);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 24);
            this.btnExit.TabIndex = 71;
            this.btnExit.Text = "[Esc] = Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // optGodownWise
            // 
            this.optGodownWise.AutoSize = true;
            this.optGodownWise.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optGodownWise.Location = new System.Drawing.Point(203, 400);
            this.optGodownWise.Name = "optGodownWise";
            this.optGodownWise.Size = new System.Drawing.Size(102, 19);
            this.optGodownWise.TabIndex = 70;
            this.optGodownWise.Text = "Godown Wise";
            this.optGodownWise.UseVisualStyleBackColor = true;
            // 
            // optAllGodown
            // 
            this.optAllGodown.AutoSize = true;
            this.optAllGodown.Checked = true;
            this.optAllGodown.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optAllGodown.Location = new System.Drawing.Point(39, 400);
            this.optAllGodown.Name = "optAllGodown";
            this.optAllGodown.Size = new System.Drawing.Size(87, 19);
            this.optAllGodown.TabIndex = 69;
            this.optAllGodown.TabStop = true;
            this.optAllGodown.Text = "All Godown";
            this.optAllGodown.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpToDate);
            this.groupBox2.Controls.Add(this.dtpFromDate);
            this.groupBox2.Controls.Add(this.optDetailCT);
            this.groupBox2.Controls.Add(this.optPUS);
            this.groupBox2.Controls.Add(this.optPUSRemainingOrder);
            this.groupBox2.Controls.Add(this.optSummaryNegative);
            this.groupBox2.Controls.Add(this.optSummary);
            this.groupBox2.Controls.Add(this.optDetailSize);
            this.groupBox2.Controls.Add(this.optDetailAll);
            this.groupBox2.Controls.Add(this.chkIsZeroBalance);
            this.groupBox2.Controls.Add(this.optDetail);
            this.groupBox2.Controls.Add(this.chkDateWise);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(21, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 252);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(103, 50);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(114, 20);
            this.dtpToDate.TabIndex = 70;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(103, 23);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(114, 20);
            this.dtpFromDate.TabIndex = 69;
            // 
            // optDetailCT
            // 
            this.optDetailCT.AutoSize = true;
            this.optDetailCT.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDetailCT.Location = new System.Drawing.Point(250, 218);
            this.optDetailCT.Name = "optDetailCT";
            this.optDetailCT.Size = new System.Drawing.Size(76, 19);
            this.optDetailCT.TabIndex = 68;
            this.optDetailCT.Text = "Detail CT";
            this.optDetailCT.UseVisualStyleBackColor = true;
            // 
            // optPUS
            // 
            this.optPUS.AutoSize = true;
            this.optPUS.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optPUS.Location = new System.Drawing.Point(250, 153);
            this.optPUS.Name = "optPUS";
            this.optPUS.Size = new System.Drawing.Size(119, 19);
            this.optPUS.TabIndex = 67;
            this.optPUS.Text = "PUS / PPU / UPU";
            this.optPUS.UseVisualStyleBackColor = true;
            // 
            // optPUSRemainingOrder
            // 
            this.optPUSRemainingOrder.AutoSize = true;
            this.optPUSRemainingOrder.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optPUSRemainingOrder.Location = new System.Drawing.Point(250, 178);
            this.optPUSRemainingOrder.Name = "optPUSRemainingOrder";
            this.optPUSRemainingOrder.Size = new System.Drawing.Size(120, 34);
            this.optPUSRemainingOrder.TabIndex = 66;
            this.optPUSRemainingOrder.Text = "PUS / PPU / UPU\r\nRemaining Order";
            this.optPUSRemainingOrder.UseVisualStyleBackColor = true;
            // 
            // optSummaryNegative
            // 
            this.optSummaryNegative.AutoSize = true;
            this.optSummaryNegative.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSummaryNegative.Location = new System.Drawing.Point(250, 128);
            this.optSummaryNegative.Name = "optSummaryNegative";
            this.optSummaryNegative.Size = new System.Drawing.Size(103, 19);
            this.optSummaryNegative.TabIndex = 64;
            this.optSummaryNegative.Text = "Summary [-ve]";
            this.optSummaryNegative.UseVisualStyleBackColor = true;
            // 
            // optSummary
            // 
            this.optSummary.AutoSize = true;
            this.optSummary.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSummary.Location = new System.Drawing.Point(250, 103);
            this.optSummary.Name = "optSummary";
            this.optSummary.Size = new System.Drawing.Size(78, 19);
            this.optSummary.TabIndex = 63;
            this.optSummary.Text = "Summary";
            this.optSummary.UseVisualStyleBackColor = true;
            // 
            // optDetailSize
            // 
            this.optDetailSize.AutoSize = true;
            this.optDetailSize.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDetailSize.Location = new System.Drawing.Point(250, 78);
            this.optDetailSize.Name = "optDetailSize";
            this.optDetailSize.Size = new System.Drawing.Size(89, 19);
            this.optDetailSize.TabIndex = 62;
            this.optDetailSize.Text = "Detail [Size]";
            this.optDetailSize.UseVisualStyleBackColor = true;
           // this.optDetailSize.CheckedChanged += new System.EventHandler(this.optDetailSize_CheckedChanged);
            // 
            // optDetailAll
            // 
            this.optDetailAll.AutoSize = true;
            this.optDetailAll.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDetailAll.Location = new System.Drawing.Point(250, 53);
            this.optDetailAll.Name = "optDetailAll";
            this.optDetailAll.Size = new System.Drawing.Size(79, 19);
            this.optDetailAll.TabIndex = 61;
            this.optDetailAll.Text = "Detail [All]";
            this.optDetailAll.UseVisualStyleBackColor = true;
            // 
            // chkIsZeroBalance
            // 
            this.chkIsZeroBalance.AutoSize = true;
            this.chkIsZeroBalance.Checked = true;
            this.chkIsZeroBalance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsZeroBalance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsZeroBalance.Location = new System.Drawing.Point(18, 108);
            this.chkIsZeroBalance.Name = "chkIsZeroBalance";
            this.chkIsZeroBalance.Size = new System.Drawing.Size(133, 19);
            this.chkIsZeroBalance.TabIndex = 60;
            this.chkIsZeroBalance.Text = "Show Zero Balance";
            this.chkIsZeroBalance.UseVisualStyleBackColor = true;
            // 
            // optDetail
            // 
            this.optDetail.AutoSize = true;
            this.optDetail.Checked = true;
            this.optDetail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDetail.Location = new System.Drawing.Point(250, 26);
            this.optDetail.Name = "optDetail";
            this.optDetail.Size = new System.Drawing.Size(57, 19);
            this.optDetail.TabIndex = 59;
            this.optDetail.TabStop = true;
            this.optDetail.Text = "Detail";
            this.optDetail.UseVisualStyleBackColor = true;
            // 
            // chkDateWise
            // 
            this.chkDateWise.AutoSize = true;
            this.chkDateWise.Checked = true;
            this.chkDateWise.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDateWise.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDateWise.Location = new System.Drawing.Point(6, 0);
            this.chkDateWise.Name = "chkDateWise";
            this.chkDateWise.Size = new System.Drawing.Size(83, 19);
            this.chkDateWise.TabIndex = 56;
            this.chkDateWise.Text = "Date Wise";
            this.chkDateWise.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AllowDrop = true;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(18, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 55;
            this.label5.Text = "     To Date     ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AllowDrop = true;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(18, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 54;
            this.label3.Text = "  From Date  ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboCategory
            // 
            this.cboCategory.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(124, 84);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(279, 23);
            this.cboCategory.TabIndex = 52;
            // 
            // cboGodown
            // 
            this.cboGodown.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGodown.FormattingEnabled = true;
            this.cboGodown.Location = new System.Drawing.Point(124, 55);
            this.cboGodown.Name = "cboGodown";
            this.cboGodown.Size = new System.Drawing.Size(279, 23);
            this.cboGodown.TabIndex = 51;
            // 
            // cboItemGrp
            // 
            this.cboItemGrp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItemGrp.FormattingEnabled = true;
            this.cboItemGrp.Location = new System.Drawing.Point(124, 27);
            this.cboItemGrp.Name = "cboItemGrp";
            this.cboItemGrp.Size = new System.Drawing.Size(279, 23);
            this.cboItemGrp.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(21, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 49;
            this.label2.Text = "     Category    ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(21, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "     Godown     ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AllowDrop = true;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(21, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 47;
            this.label4.Text = "  Item Group  ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmRptTotalStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 510);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frmRptTotalStock";
            this.Text = "Total Stock Report";
            this.Load += new System.EventHandler(this.total_Stock_Report_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRptTotalStock_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.ComboBox cboGodown;
        private System.Windows.Forms.ComboBox cboItemGrp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkDateWise;
        private System.Windows.Forms.CheckBox chkIsZeroBalance;
        private System.Windows.Forms.RadioButton optDetail;
        private System.Windows.Forms.RadioButton optDetailCT;
        private System.Windows.Forms.RadioButton optPUS;
        private System.Windows.Forms.RadioButton optPUSRemainingOrder;
        private System.Windows.Forms.RadioButton optSummaryNegative;
        private System.Windows.Forms.RadioButton optSummary;
        private System.Windows.Forms.RadioButton optDetailSize;
        private System.Windows.Forms.RadioButton optDetailAll;
        private System.Windows.Forms.RadioButton optGodownWise;
        private System.Windows.Forms.RadioButton optAllGodown;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
    }
}