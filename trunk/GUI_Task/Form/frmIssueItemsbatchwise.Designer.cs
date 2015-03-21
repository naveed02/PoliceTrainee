namespace GUI_Task
{
    partial class frmIssueItemsBatchWise
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
            this.optQuantity = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.optSingleItem = new System.Windows.Forms.RadioButton();
            this.optMultiItem = new System.Windows.Forms.RadioButton();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.lblUOM = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBatchQty = new System.Windows.Forms.TextBox();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.tctItemCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.optQuantityBags = new System.Windows.Forms.RadioButton();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.optInProcess = new System.Windows.Forms.RadioButton();
            this.optApprovedVerified = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExitSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.cboformula = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnEffFormula = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.grdIssueItemBatchWise = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtnote = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMachine = new System.Windows.Forms.ComboBox();
            this.cboPurpose = new System.Windows.Forms.ComboBox();
            this.cboContractor = new System.Windows.Forms.ComboBox();
            this.cboItemGroup = new System.Windows.Forms.ComboBox();
            this.cboEmployee = new System.Windows.Forms.ComboBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIssueNo = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIssueItemBatchWise)).BeginInit();
            this.SuspendLayout();
            // 
            // optQuantity
            // 
            this.optQuantity.AutoSize = true;
            this.optQuantity.Checked = true;
            this.optQuantity.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optQuantity.Location = new System.Drawing.Point(146, 502);
            this.optQuantity.Name = "optQuantity";
            this.optQuantity.Size = new System.Drawing.Size(69, 19);
            this.optQuantity.TabIndex = 438;
            this.optQuantity.TabStop = true;
            this.optQuantity.Text = "Quantity";
            this.optQuantity.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.optSingleItem);
            this.groupBox4.Controls.Add(this.optMultiItem);
            this.groupBox4.Location = new System.Drawing.Point(475, 34);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(235, 65);
            this.groupBox4.TabIndex = 425;
            this.groupBox4.TabStop = false;
            // 
            // optSingleItem
            // 
            this.optSingleItem.AutoSize = true;
            this.optSingleItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSingleItem.Location = new System.Drawing.Point(6, 36);
            this.optSingleItem.Name = "optSingleItem";
            this.optSingleItem.Size = new System.Drawing.Size(198, 19);
            this.optSingleItem.TabIndex = 61;
            this.optSingleItem.Text = "Single Item Group {Size/Colour}";
            this.optSingleItem.UseVisualStyleBackColor = true;
            // 
            // optMultiItem
            // 
            this.optMultiItem.AutoSize = true;
            this.optMultiItem.Checked = true;
            this.optMultiItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optMultiItem.Location = new System.Drawing.Point(6, 10);
            this.optMultiItem.Name = "optMultiItem";
            this.optMultiItem.Size = new System.Drawing.Size(188, 19);
            this.optMultiItem.TabIndex = 60;
            this.optMultiItem.TabStop = true;
            this.optMultiItem.Text = "Multi Item Group {Size/Colour}";
            this.optMultiItem.UseVisualStyleBackColor = true;
            // 
            // cboColor
            // 
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Items.AddRange(new object[] {
            "Buckle",
            "Chemical PU",
            "Eva Shoes",
            "General ",
            "Leather And Rexine",
            "PCU Shoes",
            "PPC Patawa Cutting"});
            this.cboColor.Location = new System.Drawing.Point(575, 214);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(137, 21);
            this.cboColor.TabIndex = 424;
            this.cboColor.Text = "-";
            // 
            // lblUOM
            // 
            this.lblUOM.AllowDrop = true;
            this.lblUOM.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblUOM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUOM.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUOM.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUOM.Location = new System.Drawing.Point(577, 240);
            this.lblUOM.Name = "lblUOM";
            this.lblUOM.Size = new System.Drawing.Size(135, 17);
            this.lblUOM.TabIndex = 423;
            this.lblUOM.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblName
            // 
            this.lblName.AllowDrop = true;
            this.lblName.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblName.Location = new System.Drawing.Point(575, 188);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(135, 17);
            this.lblName.TabIndex = 422;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label16
            // 
            this.label16.AllowDrop = true;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(455, 188);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 17);
            this.label16.TabIndex = 421;
            this.label16.Text = "Name";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label15
            // 
            this.label15.AllowDrop = true;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(455, 214);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(114, 17);
            this.label15.TabIndex = 420;
            this.label15.Text = "Color";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label14
            // 
            this.label14.AllowDrop = true;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(455, 240);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 17);
            this.label14.TabIndex = 419;
            this.label14.Text = "UOM";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtBatchQty
            // 
            this.txtBatchQty.Location = new System.Drawing.Point(122, 237);
            this.txtBatchQty.Name = "txtBatchQty";
            this.txtBatchQty.Size = new System.Drawing.Size(167, 20);
            this.txtBatchQty.TabIndex = 418;
            // 
            // cboSize
            // 
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Items.AddRange(new object[] {
            "Buckle",
            "Chemical PU",
            "Eva Shoes",
            "General ",
            "Leather And Rexine",
            "PCU Shoes",
            "PPC Patawa Cutting"});
            this.cboSize.Location = new System.Drawing.Point(122, 214);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(327, 21);
            this.cboSize.TabIndex = 417;
            this.cboSize.Text = "-";
            // 
            // lblItemCode
            // 
            this.lblItemCode.AllowDrop = true;
            this.lblItemCode.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblItemCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemCode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblItemCode.Location = new System.Drawing.Point(304, 191);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(135, 17);
            this.lblItemCode.TabIndex = 416;
            this.lblItemCode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tctItemCode
            // 
            this.tctItemCode.Location = new System.Drawing.Point(122, 188);
            this.tctItemCode.Name = "tctItemCode";
            this.tctItemCode.Size = new System.Drawing.Size(167, 20);
            this.tctItemCode.TabIndex = 415;
            // 
            // label12
            // 
            this.label12.AllowDrop = true;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(2, 188);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 17);
            this.label12.TabIndex = 414;
            this.label12.Text = "Item Code";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AllowDrop = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(2, 240);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 17);
            this.label11.TabIndex = 413;
            this.label11.Text = "Batch Qty";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // optQuantityBags
            // 
            this.optQuantityBags.AutoSize = true;
            this.optQuantityBags.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optQuantityBags.Location = new System.Drawing.Point(146, 530);
            this.optQuantityBags.Name = "optQuantityBags";
            this.optQuantityBags.Size = new System.Drawing.Size(109, 19);
            this.optQuantityBags.TabIndex = 437;
            this.optQuantityBags.Text = "Quantity (Bags)";
            this.optQuantityBags.UseVisualStyleBackColor = true;
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AllowDrop = true;
            this.lblTotalQty.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalQty.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotalQty.Location = new System.Drawing.Point(616, 498);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(96, 17);
            this.lblTotalQty.TabIndex = 436;
            this.lblTotalQty.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label22
            // 
            this.label22.AllowDrop = true;
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label22.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(524, 498);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(86, 17);
            this.label22.TabIndex = 435;
            this.label22.Text = "   Total Qty";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // optInProcess
            // 
            this.optInProcess.AutoSize = true;
            this.optInProcess.Checked = true;
            this.optInProcess.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optInProcess.Location = new System.Drawing.Point(304, 497);
            this.optInProcess.Name = "optInProcess";
            this.optInProcess.Size = new System.Drawing.Size(84, 19);
            this.optInProcess.TabIndex = 433;
            this.optInProcess.TabStop = true;
            this.optInProcess.Text = "In Process";
            this.optInProcess.UseVisualStyleBackColor = true;
            // 
            // optApprovedVerified
            // 
            this.optApprovedVerified.AutoSize = true;
            this.optApprovedVerified.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optApprovedVerified.Location = new System.Drawing.Point(399, 497);
            this.optApprovedVerified.Name = "optApprovedVerified";
            this.optApprovedVerified.Size = new System.Drawing.Size(119, 19);
            this.optApprovedVerified.TabIndex = 434;
            this.optApprovedVerified.Text = "Approved/Verified";
            this.optApprovedVerified.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(232, 498);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(57, 26);
            this.btnExit.TabIndex = 432;
            this.btnExit.Text = "Esc=Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnExitSave
            // 
            this.btnExitSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExitSave.Location = new System.Drawing.Point(5, 493);
            this.btnExitSave.Name = "btnExitSave";
            this.btnExitSave.Size = new System.Drawing.Size(66, 26);
            this.btnExitSave.TabIndex = 430;
            this.btnExitSave.Text = "Exit+Save";
            this.btnExitSave.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(77, 494);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(63, 26);
            this.btnPrint.TabIndex = 431;
            this.btnPrint.Text = "Printing";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(581, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 22);
            this.btnAdd.TabIndex = 429;
            this.btnAdd.Text = "Add new";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(501, 6);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(74, 22);
            this.btnHelp.TabIndex = 428;
            this.btnHelp.Text = "F1=Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // cboformula
            // 
            this.cboformula.FormattingEnabled = true;
            this.cboformula.Items.AddRange(new object[] {
            "Buckle",
            "Chemical PU",
            "Eva Shoes",
            "General ",
            "Leather And Rexine",
            "PCU Shoes",
            "PPC Patawa Cutting"});
            this.cboformula.Location = new System.Drawing.Point(576, 109);
            this.cboformula.Name = "cboformula";
            this.cboformula.Size = new System.Drawing.Size(137, 21);
            this.cboformula.TabIndex = 427;
            this.cboformula.Text = "-";
            // 
            // label20
            // 
            this.label20.AllowDrop = true;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label20.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(455, 111);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(114, 17);
            this.label20.TabIndex = 426;
            this.label20.Text = "Formula";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnEffFormula
            // 
            this.btnEffFormula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEffFormula.Location = new System.Drawing.Point(616, 135);
            this.btnEffFormula.Name = "btnEffFormula";
            this.btnEffFormula.Size = new System.Drawing.Size(97, 22);
            this.btnEffFormula.TabIndex = 439;
            this.btnEffFormula.Text = "Effect Formula";
            this.btnEffFormula.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AllowDrop = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(2, 214);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 17);
            this.label10.TabIndex = 412;
            this.label10.Text = "Size";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdIssueItemBatchWise
            // 
            this.grdIssueItemBatchWise.AllowUserToOrderColumns = true;
            this.grdIssueItemBatchWise.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdIssueItemBatchWise.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdIssueItemBatchWise.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.grdIssueItemBatchWise.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column5,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column12,
            this.Column4,
            this.Column10,
            this.Column1});
            this.grdIssueItemBatchWise.Location = new System.Drawing.Point(2, 263);
            this.grdIssueItemBatchWise.Name = "grdIssueItemBatchWise";
            this.grdIssueItemBatchWise.Size = new System.Drawing.Size(695, 228);
            this.grdIssueItemBatchWise.TabIndex = 411;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Item Code";
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "Name";
            this.Column3.Name = "Column3";
            this.Column3.Width = 60;
            // 
            // Column5
            // 
            this.Column5.Frozen = true;
            this.Column5.HeaderText = "Size";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 52;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Colour ";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 65;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "UOM";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 57;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "Godown";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 72;
            // 
            // Column12
            // 
            this.Column12.Frozen = true;
            this.Column12.HeaderText = "Stock";
            this.Column12.Name = "Column12";
            this.Column12.Width = 60;
            // 
            // Column4
            // 
            this.Column4.Frozen = true;
            this.Column4.HeaderText = "WIP Qty";
            this.Column4.Name = "Column4";
            this.Column4.Width = 72;
            // 
            // Column10
            // 
            this.Column10.Frozen = true;
            this.Column10.HeaderText = "Qty";
            this.Column10.Name = "Column10";
            this.Column10.Width = 48;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "New Stock";
            this.Column1.Name = "Column1";
            this.Column1.Width = 85;
            // 
            // txtnote
            // 
            this.txtnote.Location = new System.Drawing.Point(575, 160);
            this.txtnote.Name = "txtnote";
            this.txtnote.Size = new System.Drawing.Size(137, 20);
            this.txtnote.TabIndex = 410;
            // 
            // label9
            // 
            this.label9.AllowDrop = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(455, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 17);
            this.label9.TabIndex = 409;
            this.label9.Text = "Note";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AllowDrop = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(2, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 17);
            this.label7.TabIndex = 408;
            this.label7.Text = "Employee";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AllowDrop = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(2, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 17);
            this.label6.TabIndex = 407;
            this.label6.Text = "Department";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AllowDrop = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(2, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 17);
            this.label5.TabIndex = 406;
            this.label5.Text = "Purpose";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AllowDrop = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(2, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 405;
            this.label3.Text = "Machine#";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(2, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 404;
            this.label2.Text = "Contractor";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AllowDrop = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(2, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 17);
            this.label4.TabIndex = 403;
            this.label4.Text = "Item Group";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboMachine
            // 
            this.cboMachine.FormattingEnabled = true;
            this.cboMachine.Items.AddRange(new object[] {
            "AAAA",
            "BBBB",
            "CCCC",
            "DDDD",
            "Machine#1",
            "Machine#2",
            "Machine#3"});
            this.cboMachine.Location = new System.Drawing.Point(122, 105);
            this.cboMachine.Name = "cboMachine";
            this.cboMachine.Size = new System.Drawing.Size(327, 21);
            this.cboMachine.TabIndex = 402;
            // 
            // cboPurpose
            // 
            this.cboPurpose.FormattingEnabled = true;
            this.cboPurpose.Items.AddRange(new object[] {
            "Buckle",
            "Chemical PU",
            "Eva Shoes",
            "General ",
            "Leather And Rexine",
            "PCU Shoes",
            "PPC Patawa Cutting"});
            this.cboPurpose.Location = new System.Drawing.Point(122, 78);
            this.cboPurpose.Name = "cboPurpose";
            this.cboPurpose.Size = new System.Drawing.Size(327, 21);
            this.cboPurpose.TabIndex = 401;
            // 
            // cboContractor
            // 
            this.cboContractor.FormattingEnabled = true;
            this.cboContractor.Items.AddRange(new object[] {
            "ABCD",
            "XYZ",
            "XXXX",
            "SSSSS"});
            this.cboContractor.Location = new System.Drawing.Point(122, 131);
            this.cboContractor.Name = "cboContractor";
            this.cboContractor.Size = new System.Drawing.Size(327, 21);
            this.cboContractor.TabIndex = 400;
            // 
            // cboItemGroup
            // 
            this.cboItemGroup.FormattingEnabled = true;
            this.cboItemGroup.Items.AddRange(new object[] {
            "Buckle",
            "Chemical PU",
            "Eva Shoes",
            "General ",
            "Leather And Rexine",
            "PCU Shoes",
            "PPC Patawa Cutting"});
            this.cboItemGroup.Location = new System.Drawing.Point(122, 159);
            this.cboItemGroup.Name = "cboItemGroup";
            this.cboItemGroup.Size = new System.Drawing.Size(327, 21);
            this.cboItemGroup.TabIndex = 399;
            this.cboItemGroup.Text = "-";
            // 
            // cboEmployee
            // 
            this.cboEmployee.FormattingEnabled = true;
            this.cboEmployee.Items.AddRange(new object[] {
            "Junaid Shamsi"});
            this.cboEmployee.Location = new System.Drawing.Point(122, 24);
            this.cboEmployee.Name = "cboEmployee";
            this.cboEmployee.Size = new System.Drawing.Size(327, 21);
            this.cboEmployee.TabIndex = 398;
            // 
            // cboDepartment
            // 
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Items.AddRange(new object[] {
            "PU Department"});
            this.cboDepartment.Location = new System.Drawing.Point(122, 51);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(327, 21);
            this.cboDepartment.TabIndex = 397;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(373, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(122, 21);
            this.dateTimePicker1.TabIndex = 396;
            // 
            // label8
            // 
            this.label8.AllowDrop = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(285, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 17);
            this.label8.TabIndex = 395;
            this.label8.Text = " Date";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(2, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 394;
            this.label1.Text = "Issue #";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblIssueNo
            // 
            this.lblIssueNo.AllowDrop = true;
            this.lblIssueNo.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblIssueNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIssueNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblIssueNo.Location = new System.Drawing.Point(122, 3);
            this.lblIssueNo.Name = "lblIssueNo";
            this.lblIssueNo.Size = new System.Drawing.Size(149, 17);
            this.lblIssueNo.TabIndex = 393;
            this.lblIssueNo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmIssueItemsBatchWise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 560);
            this.Controls.Add(this.optQuantity);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cboColor);
            this.Controls.Add(this.lblUOM);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtBatchQty);
            this.Controls.Add(this.cboSize);
            this.Controls.Add(this.lblItemCode);
            this.Controls.Add(this.tctItemCode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.optQuantityBags);
            this.Controls.Add(this.lblTotalQty);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.optInProcess);
            this.Controls.Add(this.optApprovedVerified);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExitSave);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cboformula);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnEffFormula);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grdIssueItemBatchWise);
            this.Controls.Add(this.txtnote);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboMachine);
            this.Controls.Add(this.cboPurpose);
            this.Controls.Add(this.cboContractor);
            this.Controls.Add(this.cboItemGroup);
            this.Controls.Add(this.cboEmployee);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblIssueNo);
            this.KeyPreview = true;
            this.Name = "frmIssueItemsBatchWise";
            this.Text = "Issue Items Batch Wise";
            this.Load += new System.EventHandler(this.frmIssueItemsBatchWise_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmIssueItemsBatchWise_KeyDown);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIssueItemBatchWise)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton optQuantity;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton optSingleItem;
        private System.Windows.Forms.RadioButton optMultiItem;
        private System.Windows.Forms.ComboBox cboColor;
        private System.Windows.Forms.Label lblUOM;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBatchQty;
        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.TextBox tctItemCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton optQuantityBags;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.RadioButton optInProcess;
        private System.Windows.Forms.RadioButton optApprovedVerified;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExitSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.ComboBox cboformula;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnEffFormula;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView grdIssueItemBatchWise;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewLinkColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.TextBox txtnote;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMachine;
        private System.Windows.Forms.ComboBox cboPurpose;
        private System.Windows.Forms.ComboBox cboContractor;
        private System.Windows.Forms.ComboBox cboItemGroup;
        private System.Windows.Forms.ComboBox cboEmployee;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIssueNo;
    }
}