namespace GUI_Task
{
    partial class frmContractorProd
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
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.optDetGodown = new System.Windows.Forms.RadioButton();
            this.optDetContPlan = new System.Windows.Forms.RadioButton();
            this.optProdProcCont = new System.Windows.Forms.RadioButton();
            this.optProdProcCost = new System.Windows.Forms.RadioButton();
            this.optProdProcSumaary = new System.Windows.Forms.RadioButton();
            this.optSummary = new System.Windows.Forms.RadioButton();
            this.optContSummary = new System.Windows.Forms.RadioButton();
            this.optDet = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.optDetGodownInProc = new System.Windows.Forms.RadioButton();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.cboStatus2 = new System.Windows.Forms.ComboBox();
            this.optDetStatus2 = new System.Windows.Forms.RadioButton();
            this.cboGodown = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lstItemCode = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboProdProc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCont = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboItemGrp = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboProdPart = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optSingleItemGrp = new System.Windows.Forms.RadioButton();
            this.optMultiItemGrp = new System.Windows.Forms.RadioButton();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboSize
            // 
            this.cboSize.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Location = new System.Drawing.Point(117, 297);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(279, 23);
            this.cboSize.TabIndex = 78;
            // 
            // label11
            // 
            this.label11.AllowDrop = true;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(20, 363);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 17);
            this.label11.TabIndex = 77;
            this.label11.Text = "   2nd Status   ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(161, 648);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 24);
            this.btnOK.TabIndex = 76;
            this.btnOK.Text = "O.K";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(289, 648);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 24);
            this.btnExit.TabIndex = 75;
            this.btnExit.Text = "[Esc] = Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.optDetGodown);
            this.groupBox4.Controls.Add(this.optDetContPlan);
            this.groupBox4.Controls.Add(this.optProdProcCont);
            this.groupBox4.Controls.Add(this.optProdProcCost);
            this.groupBox4.Controls.Add(this.optProdProcSumaary);
            this.groupBox4.Controls.Add(this.optSummary);
            this.groupBox4.Controls.Add(this.optContSummary);
            this.groupBox4.Controls.Add(this.optDet);
            this.groupBox4.Location = new System.Drawing.Point(301, 415);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(208, 218);
            this.groupBox4.TabIndex = 70;
            this.groupBox4.TabStop = false;
            // 
            // optDetGodown
            // 
            this.optDetGodown.AutoSize = true;
            this.optDetGodown.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDetGodown.Location = new System.Drawing.Point(6, 193);
            this.optDetGodown.Name = "optDetGodown";
            this.optDetGodown.Size = new System.Drawing.Size(174, 19);
            this.optDetGodown.TabIndex = 67;
            this.optDetGodown.Text = "Detail [In Process] Godown";
            this.optDetGodown.UseVisualStyleBackColor = true;
            // 
            // optDetContPlan
            // 
            this.optDetContPlan.AutoSize = true;
            this.optDetContPlan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDetContPlan.Location = new System.Drawing.Point(6, 168);
            this.optDetContPlan.Name = "optDetContPlan";
            this.optDetContPlan.Size = new System.Drawing.Size(175, 19);
            this.optDetContPlan.TabIndex = 66;
            this.optDetContPlan.Text = "Detail [Contractor Planning]";
            this.optDetContPlan.UseVisualStyleBackColor = true;
            // 
            // optProdProcCont
            // 
            this.optProdProcCont.AutoSize = true;
            this.optProdProcCont.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optProdProcCont.Location = new System.Drawing.Point(6, 118);
            this.optProdProcCont.Name = "optProdProcCont";
            this.optProdProcCont.Size = new System.Drawing.Size(193, 19);
            this.optProdProcCont.TabIndex = 65;
            this.optProdProcCont.Text = "Production Process Contractor";
            this.optProdProcCont.UseVisualStyleBackColor = true;
            // 
            // optProdProcCost
            // 
            this.optProdProcCost.AutoSize = true;
            this.optProdProcCost.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optProdProcCost.Location = new System.Drawing.Point(6, 93);
            this.optProdProcCost.Name = "optProdProcCost";
            this.optProdProcCost.Size = new System.Drawing.Size(162, 19);
            this.optProdProcCost.TabIndex = 64;
            this.optProdProcCost.Text = "Production Process Cost";
            this.optProdProcCost.UseVisualStyleBackColor = true;
            // 
            // optProdProcSumaary
            // 
            this.optProdProcSumaary.AutoSize = true;
            this.optProdProcSumaary.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optProdProcSumaary.Location = new System.Drawing.Point(6, 143);
            this.optProdProcSumaary.Name = "optProdProcSumaary";
            this.optProdProcSumaary.Size = new System.Drawing.Size(189, 19);
            this.optProdProcSumaary.TabIndex = 63;
            this.optProdProcSumaary.Text = "Production Process Summary";
            this.optProdProcSumaary.UseVisualStyleBackColor = true;
            // 
            // optSummary
            // 
            this.optSummary.AutoSize = true;
            this.optSummary.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSummary.Location = new System.Drawing.Point(6, 68);
            this.optSummary.Name = "optSummary";
            this.optSummary.Size = new System.Drawing.Size(78, 19);
            this.optSummary.TabIndex = 62;
            this.optSummary.Text = "Summary";
            this.optSummary.UseVisualStyleBackColor = true;
            // 
            // optContSummary
            // 
            this.optContSummary.AutoSize = true;
            this.optContSummary.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optContSummary.Location = new System.Drawing.Point(6, 44);
            this.optContSummary.Name = "optContSummary";
            this.optContSummary.Size = new System.Drawing.Size(138, 19);
            this.optContSummary.TabIndex = 61;
            this.optContSummary.Text = "Contractor Summary";
            this.optContSummary.UseVisualStyleBackColor = true;
            // 
            // optDet
            // 
            this.optDet.AutoSize = true;
            this.optDet.Checked = true;
            this.optDet.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDet.Location = new System.Drawing.Point(6, 19);
            this.optDet.Name = "optDet";
            this.optDet.Size = new System.Drawing.Size(125, 19);
            this.optDet.TabIndex = 60;
            this.optDet.TabStop = true;
            this.optDet.Text = "Detail [In Process]";
            this.optDet.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtTo);
            this.groupBox3.Controls.Add(this.dtFrom);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(21, 415);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 105);
            this.groupBox3.TabIndex = 69;
            this.groupBox3.TabStop = false;
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(109, 70);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(90, 20);
            this.dtTo.TabIndex = 80;
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(109, 31);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(90, 20);
            this.dtFrom.TabIndex = 79;
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
            // optDetGodownInProc
            // 
            this.optDetGodownInProc.AutoSize = true;
            this.optDetGodownInProc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDetGodownInProc.Location = new System.Drawing.Point(33, 558);
            this.optDetGodownInProc.Name = "optDetGodownInProc";
            this.optDetGodownInProc.Size = new System.Drawing.Size(174, 19);
            this.optDetGodownInProc.TabIndex = 74;
            this.optDetGodownInProc.Text = "Detail [In Process] Godown";
            this.optDetGodownInProc.UseVisualStyleBackColor = true;
            // 
            // cboColor
            // 
            this.cboColor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(117, 326);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(279, 23);
            this.cboColor.TabIndex = 67;
            // 
            // cboStatus2
            // 
            this.cboStatus2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus2.FormattingEnabled = true;
            this.cboStatus2.Location = new System.Drawing.Point(117, 360);
            this.cboStatus2.Name = "cboStatus2";
            this.cboStatus2.Size = new System.Drawing.Size(279, 23);
            this.cboStatus2.TabIndex = 66;
            // 
            // optDetStatus2
            // 
            this.optDetStatus2.AutoSize = true;
            this.optDetStatus2.Checked = true;
            this.optDetStatus2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDetStatus2.Location = new System.Drawing.Point(33, 533);
            this.optDetStatus2.Name = "optDetStatus2";
            this.optDetStatus2.Size = new System.Drawing.Size(187, 19);
            this.optDetStatus2.TabIndex = 73;
            this.optDetStatus2.TabStop = true;
            this.optDetStatus2.Text = "Detail [In Process] 2nd Status";
            this.optDetStatus2.UseVisualStyleBackColor = true;
            // 
            // cboGodown
            // 
            this.cboGodown.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGodown.FormattingEnabled = true;
            this.cboGodown.Location = new System.Drawing.Point(117, 223);
            this.cboGodown.Name = "cboGodown";
            this.cboGodown.Size = new System.Drawing.Size(279, 23);
            this.cboGodown.TabIndex = 65;
            // 
            // label7
            // 
            this.label7.AllowDrop = true;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(21, 329);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 17);
            this.label7.TabIndex = 63;
            this.label7.Text = "       Color        ";
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
            this.label6.Location = new System.Drawing.Point(21, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 62;
            this.label6.Text = "        Size          ";
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
            this.label5.Location = new System.Drawing.Point(20, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 60;
            this.label5.Text = "   Item Name   ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lstItemCode
            // 
            this.lstItemCode.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lstItemCode.FormattingEnabled = true;
            this.lstItemCode.Location = new System.Drawing.Point(224, 252);
            this.lstItemCode.Name = "lstItemCode";
            this.lstItemCode.Size = new System.Drawing.Size(172, 17);
            this.lstItemCode.TabIndex = 59;
            // 
            // label3
            // 
            this.label3.AllowDrop = true;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.NavajoWhite;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(20, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 57;
            this.label3.Text = "    Item Code   ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboProdProc
            // 
            this.cboProdProc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProdProc.FormattingEnabled = true;
            this.cboProdProc.Location = new System.Drawing.Point(117, 139);
            this.cboProdProc.Name = "cboProdProc";
            this.cboProdProc.Size = new System.Drawing.Size(279, 23);
            this.cboProdProc.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(21, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 54;
            this.label2.Text = "    Prod.Proc   ";
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
            this.label1.Location = new System.Drawing.Point(21, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 53;
            this.label1.Text = "    Prod.Part    ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboCont
            // 
            this.cboCont.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCont.FormattingEnabled = true;
            this.cboCont.Location = new System.Drawing.Point(117, 86);
            this.cboCont.Name = "cboCont";
            this.cboCont.Size = new System.Drawing.Size(279, 23);
            this.cboCont.TabIndex = 52;
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
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 51;
            this.label4.Text = "   Contractor   ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblItemName);
            this.groupBox1.Controls.Add(this.lblItemCode);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cboItemGrp);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cboStatus);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cboSize);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.optDetGodownInProc);
            this.groupBox1.Controls.Add(this.cboColor);
            this.groupBox1.Controls.Add(this.cboStatus2);
            this.groupBox1.Controls.Add(this.optDetStatus2);
            this.groupBox1.Controls.Add(this.cboGodown);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lstItemCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboProdPart);
            this.groupBox1.Controls.Add(this.cboProdProc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboCont);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 707);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.BackColor = System.Drawing.SystemColors.Control;
            this.lblItemName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(114, 276);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(274, 15);
            this.lblItemName.TabIndex = 151;
            this.lblItemName.Text = "                                                                                 " +
                "        ";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.BackColor = System.Drawing.SystemColors.Window;
            this.lblItemCode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCode.Location = new System.Drawing.Point(119, 252);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(94, 15);
            this.lblItemCode.TabIndex = 150;
            this.lblItemCode.Text = "                             ";
            this.lblItemCode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label14
            // 
            this.label14.AllowDrop = true;
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(21, 223);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 17);
            this.label14.TabIndex = 83;
            this.label14.Text = "      Godown     ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboItemGrp
            // 
            this.cboItemGrp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItemGrp.FormattingEnabled = true;
            this.cboItemGrp.Location = new System.Drawing.Point(117, 194);
            this.cboItemGrp.Name = "cboItemGrp";
            this.cboItemGrp.Size = new System.Drawing.Size(279, 23);
            this.cboItemGrp.TabIndex = 82;
            // 
            // label13
            // 
            this.label13.AllowDrop = true;
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(20, 194);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 17);
            this.label13.TabIndex = 81;
            this.label13.Text = "   Item Group   ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboStatus
            // 
            this.cboStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(117, 166);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(279, 23);
            this.cboStatus.TabIndex = 80;
            // 
            // label12
            // 
            this.label12.AllowDrop = true;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(21, 166);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 17);
            this.label12.TabIndex = 79;
            this.label12.Text = "       Status       ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboProdPart
            // 
            this.cboProdPart.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProdPart.FormattingEnabled = true;
            this.cboProdPart.Location = new System.Drawing.Point(117, 112);
            this.cboProdPart.Name = "cboProdPart";
            this.cboProdPart.Size = new System.Drawing.Size(279, 23);
            this.cboProdPart.TabIndex = 56;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.optSingleItemGrp);
            this.groupBox2.Controls.Add(this.optMultiItemGrp);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(439, 51);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // optSingleItemGrp
            // 
            this.optSingleItemGrp.AutoSize = true;
            this.optSingleItemGrp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSingleItemGrp.Location = new System.Drawing.Point(240, 19);
            this.optSingleItemGrp.Name = "optSingleItemGrp";
            this.optSingleItemGrp.Size = new System.Drawing.Size(193, 19);
            this.optSingleItemGrp.TabIndex = 61;
            this.optSingleItemGrp.Text = "Single Item Group [Size/Color]";
            this.optSingleItemGrp.UseVisualStyleBackColor = true;
            // 
            // optMultiItemGrp
            // 
            this.optMultiItemGrp.AutoSize = true;
            this.optMultiItemGrp.Checked = true;
            this.optMultiItemGrp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optMultiItemGrp.Location = new System.Drawing.Point(6, 19);
            this.optMultiItemGrp.Name = "optMultiItemGrp";
            this.optMultiItemGrp.Size = new System.Drawing.Size(185, 19);
            this.optMultiItemGrp.TabIndex = 60;
            this.optMultiItemGrp.TabStop = true;
            this.optMultiItemGrp.Text = "Multi Item Group [Size/Color]";
            this.optMultiItemGrp.UseVisualStyleBackColor = true;
            // 
            // frmContractorProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 731);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmContractorProd";
            this.Text = "Contractor Wise Production Process";
            this.Load += new System.EventHandler(this.contractor_Wise_Production_Process_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton optProdProcCont;
        private System.Windows.Forms.RadioButton optProdProcCost;
        private System.Windows.Forms.RadioButton optProdProcSumaary;
        private System.Windows.Forms.RadioButton optSummary;
        private System.Windows.Forms.RadioButton optContSummary;
        private System.Windows.Forms.RadioButton optDet;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton optDetGodownInProc;
        private System.Windows.Forms.ComboBox cboColor;
        private System.Windows.Forms.ComboBox cboStatus2;
        private System.Windows.Forms.RadioButton optDetStatus2;
        private System.Windows.Forms.ComboBox cboGodown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstItemCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboProdProc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCont;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboProdPart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton optSingleItemGrp;
        private System.Windows.Forms.RadioButton optMultiItemGrp;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboItemGrp;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton optDetGodown;
        private System.Windows.Forms.RadioButton optDetContPlan;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.Label lblItemName;
    }
}