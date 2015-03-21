namespace GUI_Task
{
    partial class frmItemTrans
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboItemGrp = new System.Windows.Forms.ComboBox();
            this.txtItmCodeColor = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.optRptStock = new System.Windows.Forms.RadioButton();
            this.optRptWIP = new System.Windows.Forms.RadioButton();
            this.optBagsStock = new System.Windows.Forms.RadioButton();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.cboGodown = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblItemUnit = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.lblQtyIn = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblQtyOut = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.grdItemTrans = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemTrans)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "   Item Group   ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.NavajoWhite;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "   Item Code     ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AllowDrop = true;
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "   Item Name    ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AllowDrop = true;
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(12, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "          Size          ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AllowDrop = true;
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(12, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "          Color        ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AllowDrop = true;
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(12, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "    Item Unit       ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboItemGrp
            // 
            this.cboItemGrp.BackColor = System.Drawing.SystemColors.Window;
            this.cboItemGrp.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cboItemGrp.FormattingEnabled = true;
            this.cboItemGrp.Location = new System.Drawing.Point(126, 10);
            this.cboItemGrp.Name = "cboItemGrp";
            this.cboItemGrp.Size = new System.Drawing.Size(356, 23);
            this.cboItemGrp.TabIndex = 8;
            this.cboItemGrp.Text = "-";
            // 
            // txtItmCodeColor
            // 
            this.txtItmCodeColor.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtItmCodeColor.ForeColor = System.Drawing.SystemColors.Window;
            this.txtItmCodeColor.Location = new System.Drawing.Point(290, 42);
            this.txtItmCodeColor.Name = "txtItmCodeColor";
            this.txtItmCodeColor.Size = new System.Drawing.Size(161, 21);
            this.txtItmCodeColor.TabIndex = 10;
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(457, 40);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(146, 27);
            this.btnHelp.TabIndex = 11;
            this.btnHelp.Text = "[F1] = Name Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.button1_Click);
            // 
            // optRptStock
            // 
            this.optRptStock.AutoSize = true;
            this.optRptStock.Checked = true;
            this.optRptStock.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optRptStock.Location = new System.Drawing.Point(504, 12);
            this.optRptStock.Name = "optRptStock";
            this.optRptStock.Size = new System.Drawing.Size(99, 19);
            this.optRptStock.TabIndex = 12;
            this.optRptStock.TabStop = true;
            this.optRptStock.Text = "Stock Report";
            this.optRptStock.UseVisualStyleBackColor = true;
            // 
            // optRptWIP
            // 
            this.optRptWIP.AutoSize = true;
            this.optRptWIP.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optRptWIP.Location = new System.Drawing.Point(620, 12);
            this.optRptWIP.Name = "optRptWIP";
            this.optRptWIP.Size = new System.Drawing.Size(128, 19);
            this.optRptWIP.TabIndex = 13;
            this.optRptWIP.Text = "WIP Report {Dept}";
            this.optRptWIP.UseVisualStyleBackColor = true;
            // 
            // optBagsStock
            // 
            this.optBagsStock.AutoSize = true;
            this.optBagsStock.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optBagsStock.Location = new System.Drawing.Point(774, 12);
            this.optBagsStock.Name = "optBagsStock";
            this.optBagsStock.Size = new System.Drawing.Size(100, 19);
            this.optBagsStock.TabIndex = 14;
            this.optBagsStock.Text = "Stock {Bags}";
            this.optBagsStock.UseVisualStyleBackColor = true;
            // 
            // cboSize
            // 
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Location = new System.Drawing.Point(127, 104);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(327, 23);
            this.cboSize.TabIndex = 16;
            this.cboSize.Text = "<<All>>";
            // 
            // cboColor
            // 
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(127, 134);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(327, 23);
            this.cboColor.TabIndex = 17;
            this.cboColor.Text = "<<All>>";
            // 
            // cboGodown
            // 
            this.cboGodown.FormattingEnabled = true;
            this.cboGodown.Location = new System.Drawing.Point(127, 166);
            this.cboGodown.Name = "cboGodown";
            this.cboGodown.Size = new System.Drawing.Size(327, 23);
            this.cboGodown.TabIndex = 18;
            this.cboGodown.Text = "<<All>>";
            // 
            // label8
            // 
            this.label8.AllowDrop = true;
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(14, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "      Godown      ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblItemUnit
            // 
            this.lblItemUnit.AllowDrop = true;
            this.lblItemUnit.AutoSize = true;
            this.lblItemUnit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemUnit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblItemUnit.Location = new System.Drawing.Point(126, 194);
            this.lblItemUnit.Name = "lblItemUnit";
            this.lblItemUnit.Size = new System.Drawing.Size(213, 17);
            this.lblItemUnit.TabIndex = 20;
            this.lblItemUnit.Text = "                                                                    ";
            this.lblItemUnit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.AllowDrop = true;
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(361, 194);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "      Balance      ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AllowDrop = true;
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(459, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "     From Date     ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            this.label12.AllowDrop = true;
            this.label12.AutoSize = true;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(459, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 17);
            this.label12.TabIndex = 23;
            this.label12.Text = "        To Date       ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label13
            // 
            this.label13.AllowDrop = true;
            this.label13.AutoSize = true;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(459, 169);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 17);
            this.label13.TabIndex = 24;
            this.label13.Text = "   Department    ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboDept
            // 
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(563, 169);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(286, 23);
            this.cboDept.TabIndex = 27;
            // 
            // lblBalance
            // 
            this.lblBalance.AllowDrop = true;
            this.lblBalance.AutoSize = true;
            this.lblBalance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBalance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBalance.Location = new System.Drawing.Point(458, 195);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(99, 17);
            this.lblBalance.TabIndex = 28;
            this.lblBalance.Text = "                              ";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(822, 198);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(65, 24);
            this.btnExit.TabIndex = 29;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(737, 198);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(79, 24);
            this.btnPrint.TabIndex = 30;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(652, 198);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(79, 24);
            this.btnOK.TabIndex = 31;
            this.btnOK.Text = "O.K";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AllowDrop = true;
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(341, 521);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 17);
            this.label15.TabIndex = 33;
            this.label15.Text = "   Quantity In   ";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblQtyIn
            // 
            this.lblQtyIn.AllowDrop = true;
            this.lblQtyIn.AutoSize = true;
            this.lblQtyIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblQtyIn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblQtyIn.Location = new System.Drawing.Point(434, 521);
            this.lblQtyIn.Name = "lblQtyIn";
            this.lblQtyIn.Size = new System.Drawing.Size(123, 17);
            this.lblQtyIn.TabIndex = 34;
            this.lblQtyIn.Text = "                                      ";
            this.lblQtyIn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label17
            // 
            this.label17.AllowDrop = true;
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(637, 521);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 17);
            this.label17.TabIndex = 35;
            this.label17.Text = "   Quantity Out  ";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblQtyOut
            // 
            this.lblQtyOut.AllowDrop = true;
            this.lblQtyOut.AutoSize = true;
            this.lblQtyOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblQtyOut.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyOut.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblQtyOut.Location = new System.Drawing.Point(740, 521);
            this.lblQtyOut.Name = "lblQtyOut";
            this.lblQtyOut.Size = new System.Drawing.Size(138, 17);
            this.lblQtyOut.TabIndex = 36;
            this.lblQtyOut.Text = "                                           ";
            this.lblQtyOut.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Location = new System.Drawing.Point(563, 106);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(122, 21);
            this.dtpFromDate.TabIndex = 99;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Location = new System.Drawing.Point(563, 136);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(122, 21);
            this.dtpToDate.TabIndex = 100;
            // 
            // grdItemTrans
            // 
            this.grdItemTrans.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.grdItemTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdItemTrans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.grdItemTrans.Location = new System.Drawing.Point(12, 228);
            this.grdItemTrans.Name = "grdItemTrans";
            this.grdItemTrans.Size = new System.Drawing.Size(875, 290);
            this.grdItemTrans.TabIndex = 101;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Date";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Details";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Size";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Color Name";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Godown";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Rate";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Qty.In";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Qty.Out";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Balance";
            this.Column9.Name = "Column9";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.BackColor = System.Drawing.SystemColors.Control;
            this.lblItemName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(124, 75);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(274, 15);
            this.lblItemName.TabIndex = 152;
            this.lblItemName.Text = "                                                                                 " +
                "        ";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(126, 43);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(144, 21);
            this.txtItemCode.TabIndex = 153;
            this.txtItemCode.DoubleClick += new System.EventHandler(this.txtItemCode_DoubleClick);
            this.txtItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemCode_KeyDown);
            // 
            // lblName
            // 
            this.lblName.AllowDrop = true;
            this.lblName.AutoSize = true;
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblName.Location = new System.Drawing.Point(128, 75);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(351, 17);
            this.lblName.TabIndex = 154;
            this.lblName.Text = "                                                                                 " +
                "                                 ";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmItemTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 547);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtItemCode);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.grdItemTrans);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.lblQtyOut);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblQtyIn);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.cboDept);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblItemUnit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboGodown);
            this.Controls.Add(this.cboColor);
            this.Controls.Add(this.cboSize);
            this.Controls.Add(this.optBagsStock);
            this.Controls.Add(this.optRptWIP);
            this.Controls.Add(this.optRptStock);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.txtItmCodeColor);
            this.Controls.Add(this.cboItemGrp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "frmItemTrans";
            this.Text = "Item Wise Transaction";
            this.Load += new System.EventHandler(this.frmItemTrans_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmItemTrans_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdItemTrans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboItemGrp;
        private System.Windows.Forms.TextBox txtItmCodeColor;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.RadioButton optRptStock;
        private System.Windows.Forms.RadioButton optRptWIP;
        private System.Windows.Forms.RadioButton optBagsStock;
        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.ComboBox cboColor;
        private System.Windows.Forms.ComboBox cboGodown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblItemUnit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblQtyIn;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblQtyOut;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DataGridView grdItemTrans;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Label lblName;
    }
}