namespace GUI_Task
{
    partial class frmSalesReturn
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
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.optSalesRetSmryItemGrpCat = new System.Windows.Forms.RadioButton();
            this.optItemGrpCatWise = new System.Windows.Forms.RadioButton();
            this.optSmryItemGrpCat = new System.Windows.Forms.RadioButton();
            this.optItemWiseDetailSale = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.mskCustCode = new System.Windows.Forms.MaskedTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.optSalesRetItemSmry = new System.Windows.Forms.RadioButton();
            this.optSalesRetSmryItemGrp = new System.Windows.Forms.RadioButton();
            this.cboItemGrp = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AllowDrop = true;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(17, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 53;
            this.label4.Text = "       Item Group       ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AllowDrop = true;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(25, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 17);
            this.label9.TabIndex = 75;
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
            this.label10.Location = new System.Drawing.Point(25, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 17);
            this.label10.TabIndex = 74;
            this.label10.Text = "  From Date  ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // optSalesRetSmryItemGrpCat
            // 
            this.optSalesRetSmryItemGrpCat.AutoSize = true;
            this.optSalesRetSmryItemGrpCat.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSalesRetSmryItemGrpCat.Location = new System.Drawing.Point(264, 93);
            this.optSalesRetSmryItemGrpCat.Name = "optSalesRetSmryItemGrpCat";
            this.optSalesRetSmryItemGrpCat.Size = new System.Drawing.Size(269, 19);
            this.optSalesRetSmryItemGrpCat.TabIndex = 73;
            this.optSalesRetSmryItemGrpCat.Text = "Sales Return Summary Item Group Category";
            this.optSalesRetSmryItemGrpCat.UseVisualStyleBackColor = true;
            // 
            // optItemGrpCatWise
            // 
            this.optItemGrpCatWise.AutoSize = true;
            this.optItemGrpCatWise.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optItemGrpCatWise.Location = new System.Drawing.Point(264, 69);
            this.optItemGrpCatWise.Name = "optItemGrpCatWise";
            this.optItemGrpCatWise.Size = new System.Drawing.Size(169, 19);
            this.optItemGrpCatWise.TabIndex = 72;
            this.optItemGrpCatWise.Text = "Item Group Category Wise";
            this.optItemGrpCatWise.UseVisualStyleBackColor = true;
            // 
            // optSmryItemGrpCat
            // 
            this.optSmryItemGrpCat.AutoSize = true;
            this.optSmryItemGrpCat.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSmryItemGrpCat.Location = new System.Drawing.Point(264, 44);
            this.optSmryItemGrpCat.Name = "optSmryItemGrpCat";
            this.optSmryItemGrpCat.Size = new System.Drawing.Size(194, 19);
            this.optSmryItemGrpCat.TabIndex = 71;
            this.optSmryItemGrpCat.Text = "Summary Item Group Category";
            this.optSmryItemGrpCat.UseVisualStyleBackColor = true;
            // 
            // optItemWiseDetailSale
            // 
            this.optItemWiseDetailSale.AutoSize = true;
            this.optItemWiseDetailSale.Checked = true;
            this.optItemWiseDetailSale.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optItemWiseDetailSale.Location = new System.Drawing.Point(264, 19);
            this.optItemWiseDetailSale.Name = "optItemWiseDetailSale";
            this.optItemWiseDetailSale.Size = new System.Drawing.Size(143, 19);
            this.optItemWiseDetailSale.TabIndex = 67;
            this.optItemWiseDetailSale.TabStop = true;
            this.optItemWiseDetailSale.Text = "Item Wise Detail Sale";
            this.optItemWiseDetailSale.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCustomerName);
            this.groupBox1.Controls.Add(this.mskCustCode);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cboItemGrp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 319);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblCustomerName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCustomerName.Location = new System.Drawing.Point(142, 71);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(283, 15);
            this.lblCustomerName.TabIndex = 85;
            this.lblCustomerName.Text = "                                                                                 " +
                "           ";
            // 
            // mskCustCode
            // 
            this.mskCustCode.Location = new System.Drawing.Point(145, 40);
            this.mskCustCode.Mask = "00-0-00-00-00";
            this.mskCustCode.Name = "mskCustCode";
            this.mskCustCode.Size = new System.Drawing.Size(113, 20);
            this.mskCustCode.TabIndex = 84;
            this.mskCustCode.DoubleClick += new System.EventHandler(this.mskCustCode_DoubleClick);
            this.mskCustCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox1_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(314, 289);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 24);
            this.btnOK.TabIndex = 83;
            this.btnOK.Text = "O.K";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(439, 289);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 24);
            this.btnExit.TabIndex = 82;
            this.btnExit.Text = "[Esc] = Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(15, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 81;
            this.label2.Text = "   Customer Name  ";
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
            this.label1.Location = new System.Drawing.Point(15, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 80;
            this.label1.Text = "   Customer Code   ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpToDate);
            this.groupBox2.Controls.Add(this.dtpFromDate);
            this.groupBox2.Controls.Add(this.optSalesRetItemSmry);
            this.groupBox2.Controls.Add(this.optSalesRetSmryItemGrp);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.optSalesRetSmryItemGrpCat);
            this.groupBox2.Controls.Add(this.optItemGrpCatWise);
            this.groupBox2.Controls.Add(this.optSmryItemGrpCat);
            this.groupBox2.Controls.Add(this.optItemWiseDetailSale);
            this.groupBox2.Location = new System.Drawing.Point(21, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(551, 173);
            this.groupBox2.TabIndex = 66;
            this.groupBox2.TabStop = false;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(124, 65);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(90, 20);
            this.dtpToDate.TabIndex = 79;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(124, 26);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(90, 20);
            this.dtpFromDate.TabIndex = 78;
            // 
            // optSalesRetItemSmry
            // 
            this.optSalesRetItemSmry.AutoSize = true;
            this.optSalesRetItemSmry.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSalesRetItemSmry.Location = new System.Drawing.Point(264, 143);
            this.optSalesRetItemSmry.Name = "optSalesRetItemSmry";
            this.optSalesRetItemSmry.Size = new System.Drawing.Size(180, 19);
            this.optSalesRetItemSmry.TabIndex = 77;
            this.optSalesRetItemSmry.Text = "Sales Return Item Summary";
            this.optSalesRetItemSmry.UseVisualStyleBackColor = true;
            // 
            // optSalesRetSmryItemGrp
            // 
            this.optSalesRetSmryItemGrp.AutoSize = true;
            this.optSalesRetSmryItemGrp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSalesRetSmryItemGrp.Location = new System.Drawing.Point(264, 118);
            this.optSalesRetSmryItemGrp.Name = "optSalesRetSmryItemGrp";
            this.optSalesRetSmryItemGrp.Size = new System.Drawing.Size(217, 19);
            this.optSalesRetSmryItemGrp.TabIndex = 76;
            this.optSalesRetSmryItemGrp.Text = "Sales Return Summary Item Group";
            this.optSalesRetSmryItemGrp.UseVisualStyleBackColor = true;
            // 
            // cboItemGrp
            // 
            this.cboItemGrp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItemGrp.FormattingEnabled = true;
            this.cboItemGrp.Location = new System.Drawing.Point(145, 10);
            this.cboItemGrp.Name = "cboItemGrp";
            this.cboItemGrp.Size = new System.Drawing.Size(279, 23);
            this.cboItemGrp.TabIndex = 54;
            // 
            // frmSalesReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 344);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSalesReturn";
            this.Text = "Sales / Sales Return Report";
            this.Load += new System.EventHandler(this.sales_Sales_Return_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSalesReturn_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton optSalesRetSmryItemGrpCat;
        private System.Windows.Forms.RadioButton optItemGrpCatWise;
        private System.Windows.Forms.RadioButton optSmryItemGrpCat;
        private System.Windows.Forms.RadioButton optItemWiseDetailSale;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboItemGrp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton optSalesRetSmryItemGrp;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton optSalesRetItemSmry;
        private System.Windows.Forms.MaskedTextBox mskCustCode;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblCustomerName;
    }
}