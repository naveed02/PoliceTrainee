namespace GUI_Task
{
    partial class frmRptStock
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
            this.lblItemName = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.optWIPAllItemDeptBal = new System.Windows.Forms.RadioButton();
            this.optWIPAllItemBal = new System.Windows.Forms.RadioButton();
            this.optWIPDeptBalance = new System.Windows.Forms.RadioButton();
            this.optWIPItemGroup = new System.Windows.Forms.RadioButton();
            this.optStockValue = new System.Windows.Forms.RadioButton();
            this.optStockSummary = new System.Windows.Forms.RadioButton();
            this.optStockDetail = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.chkDateWise = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.optGodownWise = new System.Windows.Forms.RadioButton();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.optAllGowdown = new System.Windows.Forms.RadioButton();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.cboGodown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboItemGrp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optSingleItemGroup = new System.Windows.Forms.RadioButton();
            this.optMultiItemGroup = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblItemName);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.optGodownWise);
            this.groupBox1.Controls.Add(this.cboDept);
            this.groupBox1.Controls.Add(this.cboColor);
            this.groupBox1.Controls.Add(this.optAllGowdown);
            this.groupBox1.Controls.Add(this.cboSize);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.txtItemCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboCategory);
            this.groupBox1.Controls.Add(this.cboGodown);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboItemGrp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 587);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblItemName.Location = new System.Drawing.Point(117, 213);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(271, 13);
            this.lblItemName.TabIndex = 77;
            this.lblItemName.Text = "                                                                                 " +
                "       ";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(158, 557);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 24);
            this.btnOK.TabIndex = 76;
            this.btnOK.Text = "O.K";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(283, 557);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 24);
            this.btnExit.TabIndex = 75;
            this.btnExit.Text = "[Esc] = Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.optWIPAllItemDeptBal);
            this.groupBox4.Controls.Add(this.optWIPAllItemBal);
            this.groupBox4.Controls.Add(this.optWIPDeptBalance);
            this.groupBox4.Controls.Add(this.optWIPItemGroup);
            this.groupBox4.Controls.Add(this.optStockValue);
            this.groupBox4.Controls.Add(this.optStockSummary);
            this.groupBox4.Controls.Add(this.optStockDetail);
            this.groupBox4.Location = new System.Drawing.Point(312, 337);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 207);
            this.groupBox4.TabIndex = 70;
            this.groupBox4.TabStop = false;
            // 
            // optWIPAllItemDeptBal
            // 
            this.optWIPAllItemDeptBal.AutoSize = true;
            this.optWIPAllItemDeptBal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optWIPAllItemDeptBal.Location = new System.Drawing.Point(6, 168);
            this.optWIPAllItemDeptBal.Name = "optWIPAllItemDeptBal";
            this.optWIPAllItemDeptBal.Size = new System.Drawing.Size(142, 19);
            this.optWIPAllItemDeptBal.TabIndex = 66;
            this.optWIPAllItemDeptBal.Text = "WIP All Item Dept.Bal.";
            this.optWIPAllItemDeptBal.UseVisualStyleBackColor = true;
            // 
            // optWIPAllItemBal
            // 
            this.optWIPAllItemBal.AutoSize = true;
            this.optWIPAllItemBal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optWIPAllItemBal.Location = new System.Drawing.Point(6, 143);
            this.optWIPAllItemBal.Name = "optWIPAllItemBal";
            this.optWIPAllItemBal.Size = new System.Drawing.Size(113, 19);
            this.optWIPAllItemBal.TabIndex = 65;
            this.optWIPAllItemBal.Text = "WIP All Item Bal.";
            this.optWIPAllItemBal.UseVisualStyleBackColor = true;
            // 
            // optWIPDeptBalance
            // 
            this.optWIPDeptBalance.AutoSize = true;
            this.optWIPDeptBalance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optWIPDeptBalance.Location = new System.Drawing.Point(6, 118);
            this.optWIPDeptBalance.Name = "optWIPDeptBalance";
            this.optWIPDeptBalance.Size = new System.Drawing.Size(124, 19);
            this.optWIPDeptBalance.TabIndex = 64;
            this.optWIPDeptBalance.Text = "WIP Dept.Balance";
            this.optWIPDeptBalance.UseVisualStyleBackColor = true;
            // 
            // optWIPItemGroup
            // 
            this.optWIPItemGroup.AutoSize = true;
            this.optWIPItemGroup.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optWIPItemGroup.Location = new System.Drawing.Point(6, 93);
            this.optWIPItemGroup.Name = "optWIPItemGroup";
            this.optWIPItemGroup.Size = new System.Drawing.Size(111, 19);
            this.optWIPItemGroup.TabIndex = 63;
            this.optWIPItemGroup.Text = "WIP Item Group";
            this.optWIPItemGroup.UseVisualStyleBackColor = true;
            // 
            // optStockValue
            // 
            this.optStockValue.AutoSize = true;
            this.optStockValue.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optStockValue.Location = new System.Drawing.Point(6, 68);
            this.optStockValue.Name = "optStockValue";
            this.optStockValue.Size = new System.Drawing.Size(88, 19);
            this.optStockValue.TabIndex = 62;
            this.optStockValue.Text = "Stock Value";
            this.optStockValue.UseVisualStyleBackColor = true;
            // 
            // optStockSummary
            // 
            this.optStockSummary.AutoSize = true;
            this.optStockSummary.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optStockSummary.Location = new System.Drawing.Point(6, 44);
            this.optStockSummary.Name = "optStockSummary";
            this.optStockSummary.Size = new System.Drawing.Size(111, 19);
            this.optStockSummary.TabIndex = 61;
            this.optStockSummary.Text = "Stock Summary";
            this.optStockSummary.UseVisualStyleBackColor = true;
            // 
            // optStockDetail
            // 
            this.optStockDetail.AutoSize = true;
            this.optStockDetail.Checked = true;
            this.optStockDetail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optStockDetail.Location = new System.Drawing.Point(6, 19);
            this.optStockDetail.Name = "optStockDetail";
            this.optStockDetail.Size = new System.Drawing.Size(90, 19);
            this.optStockDetail.TabIndex = 60;
            this.optStockDetail.TabStop = true;
            this.optStockDetail.Text = "Stock Detail";
            this.optStockDetail.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpToDate);
            this.groupBox3.Controls.Add(this.dtpFromDate);
            this.groupBox3.Controls.Add(this.chkDateWise);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(20, 337);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 105);
            this.groupBox3.TabIndex = 69;
            this.groupBox3.TabStop = false;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(107, 67);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(114, 20);
            this.dtpToDate.TabIndex = 70;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(107, 28);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(114, 20);
            this.dtpFromDate.TabIndex = 69;
            // 
            // chkDateWise
            // 
            this.chkDateWise.AutoSize = true;
            this.chkDateWise.Checked = true;
            this.chkDateWise.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDateWise.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDateWise.Location = new System.Drawing.Point(8, 0);
            this.chkDateWise.Name = "chkDateWise";
            this.chkDateWise.Size = new System.Drawing.Size(83, 19);
            this.chkDateWise.TabIndex = 61;
            this.chkDateWise.Text = "Date Wise";
            this.chkDateWise.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AllowDrop = true;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(12, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 17);
            this.label9.TabIndex = 60;
            this.label9.Text = "     To Date     ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.AllowDrop = true;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(12, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 17);
            this.label10.TabIndex = 59;
            this.label10.Text = "  From Date  ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // optGodownWise
            // 
            this.optGodownWise.AutoSize = true;
            this.optGodownWise.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optGodownWise.Location = new System.Drawing.Point(185, 480);
            this.optGodownWise.Name = "optGodownWise";
            this.optGodownWise.Size = new System.Drawing.Size(102, 19);
            this.optGodownWise.TabIndex = 74;
            this.optGodownWise.Text = "Godown Wise";
            this.optGodownWise.UseVisualStyleBackColor = true;
            // 
            // cboDept
            // 
            this.cboDept.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(117, 294);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(279, 23);
            this.cboDept.TabIndex = 67;
            this.cboDept.Text = "<<ALL>>";
            // 
            // cboColor
            // 
            this.cboColor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(116, 268);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(279, 23);
            this.cboColor.TabIndex = 66;
            this.cboColor.Text = "<<ALL>>";
            // 
            // optAllGowdown
            // 
            this.optAllGowdown.AutoSize = true;
            this.optAllGowdown.Checked = true;
            this.optAllGowdown.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optAllGowdown.Location = new System.Drawing.Point(66, 480);
            this.optAllGowdown.Name = "optAllGowdown";
            this.optAllGowdown.Size = new System.Drawing.Size(87, 19);
            this.optAllGowdown.TabIndex = 73;
            this.optAllGowdown.TabStop = true;
            this.optAllGowdown.Text = "All Godown";
            this.optAllGowdown.UseVisualStyleBackColor = true;
            // 
            // cboSize
            // 
            this.cboSize.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Location = new System.Drawing.Point(116, 239);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(279, 23);
            this.cboSize.TabIndex = 65;
            this.cboSize.Text = "<<ALL>>";
            // 
            // label8
            // 
            this.label8.AllowDrop = true;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(20, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 17);
            this.label8.TabIndex = 64;
            this.label8.Text = "   Department  ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AllowDrop = true;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(20, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 17);
            this.label7.TabIndex = 63;
            this.label7.Text = "        Color         ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AllowDrop = true;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(20, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 17);
            this.label6.TabIndex = 62;
            this.label6.Text = "         Size          ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AllowDrop = true;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(20, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 60;
            this.label5.Text = "   Item Name   ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(216, 184);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(172, 17);
            this.listBox1.TabIndex = 59;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.Location = new System.Drawing.Point(113, 181);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(84, 20);
            this.txtItemCode.TabIndex = 58;
            this.txtItemCode.DoubleClick += new System.EventHandler(this.txtItemCode_DoubleClick);
            this.txtItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemCode_KeyDown);
            // 
            // label3
            // 
            this.label3.AllowDrop = true;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.NavajoWhite;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(20, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 57;
            this.label3.Text = "    Item Code   ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboCategory
            // 
            this.cboCategory.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(109, 146);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(279, 23);
            this.cboCategory.TabIndex = 56;
            this.cboCategory.Text = "<<ALL>>";
            // 
            // cboGodown
            // 
            this.cboGodown.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGodown.FormattingEnabled = true;
            this.cboGodown.Location = new System.Drawing.Point(109, 117);
            this.cboGodown.Name = "cboGodown";
            this.cboGodown.Size = new System.Drawing.Size(279, 23);
            this.cboGodown.TabIndex = 55;
            this.cboGodown.Text = "<<ALL>>";
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(20, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 54;
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
            this.label1.Location = new System.Drawing.Point(20, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 53;
            this.label1.Text = "     Godown     ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboItemGrp
            // 
            this.cboItemGrp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItemGrp.FormattingEnabled = true;
            this.cboItemGrp.Location = new System.Drawing.Point(109, 86);
            this.cboItemGrp.Name = "cboItemGrp";
            this.cboItemGrp.Size = new System.Drawing.Size(279, 23);
            this.cboItemGrp.TabIndex = 52;
            this.cboItemGrp.Text = "<<ALL>>";
            // 
            // label4
            // 
            this.label4.AllowDrop = true;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(20, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 51;
            this.label4.Text = "  Item Group  ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.optSingleItemGroup);
            this.groupBox2.Controls.Add(this.optMultiItemGroup);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(439, 51);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // optSingleItemGroup
            // 
            this.optSingleItemGroup.AutoSize = true;
            this.optSingleItemGroup.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSingleItemGroup.Location = new System.Drawing.Point(240, 19);
            this.optSingleItemGroup.Name = "optSingleItemGroup";
            this.optSingleItemGroup.Size = new System.Drawing.Size(193, 19);
            this.optSingleItemGroup.TabIndex = 61;
            this.optSingleItemGroup.Text = "Single Item Group [Size/Color]";
            this.optSingleItemGroup.UseVisualStyleBackColor = true;
            // 
            // optMultiItemGroup
            // 
            this.optMultiItemGroup.AutoSize = true;
            this.optMultiItemGroup.Checked = true;
            this.optMultiItemGroup.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optMultiItemGroup.Location = new System.Drawing.Point(6, 19);
            this.optMultiItemGroup.Name = "optMultiItemGroup";
            this.optMultiItemGroup.Size = new System.Drawing.Size(185, 19);
            this.optMultiItemGroup.TabIndex = 60;
            this.optMultiItemGroup.TabStop = true;
            this.optMultiItemGroup.Text = "Multi Item Group [Size/Color]";
            this.optMultiItemGroup.UseVisualStyleBackColor = true;
            // 
            // frmRptStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 611);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frmRptStock";
            this.Text = "Total Stock Report";
            this.Load += new System.EventHandler(this.stock_Report_Item_Wise_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRptStock_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton optSingleItemGroup;
        private System.Windows.Forms.RadioButton optMultiItemGroup;
        private System.Windows.Forms.ComboBox cboItemGrp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.ComboBox cboGodown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.ComboBox cboColor;
        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkDateWise;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton optStockDetail;
        private System.Windows.Forms.RadioButton optWIPAllItemDeptBal;
        private System.Windows.Forms.RadioButton optWIPAllItemBal;
        private System.Windows.Forms.RadioButton optWIPDeptBalance;
        private System.Windows.Forms.RadioButton optWIPItemGroup;
        private System.Windows.Forms.RadioButton optStockValue;
        private System.Windows.Forms.RadioButton optStockSummary;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton optGodownWise;
        private System.Windows.Forms.RadioButton optAllGowdown;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblItemName;
    }
}