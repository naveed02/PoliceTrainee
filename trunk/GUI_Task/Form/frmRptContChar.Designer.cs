namespace GUI_Task
{
    partial class frmContractorCharges
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.optArticleWiseCashPaid = new System.Windows.Forms.RadioButton();
            this.optClaimCashSummary = new System.Windows.Forms.RadioButton();
            this.optProd = new System.Windows.Forms.RadioButton();
            this.optProdSummary = new System.Windows.Forms.RadioButton();
            this.optProdSummaryCE = new System.Windows.Forms.RadioButton();
            this.optClaimCharSummary = new System.Windows.Forms.RadioButton();
            this.optArticleWise = new System.Windows.Forms.RadioButton();
            this.optCharSummary = new System.Windows.Forms.RadioButton();
            this.optSizeWise = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.optDet = new System.Windows.Forms.RadioButton();
            this.cboCharType = new System.Windows.Forms.ComboBox();
            this.cboItemCat = new System.Windows.Forms.ComboBox();
            this.cboCont = new System.Windows.Forms.ComboBox();
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
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cboCharType);
            this.groupBox1.Controls.Add(this.cboItemCat);
            this.groupBox1.Controls.Add(this.cboCont);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 407);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(145, 377);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 24);
            this.btnOK.TabIndex = 80;
            this.btnOK.Text = "O.K";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(270, 377);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 24);
            this.btnExit.TabIndex = 79;
            this.btnExit.Text = "[Esc] = Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpToDate);
            this.groupBox2.Controls.Add(this.dtpFromDate);
            this.groupBox2.Controls.Add(this.optArticleWiseCashPaid);
            this.groupBox2.Controls.Add(this.optClaimCashSummary);
            this.groupBox2.Controls.Add(this.optProd);
            this.groupBox2.Controls.Add(this.optProdSummary);
            this.groupBox2.Controls.Add(this.optProdSummaryCE);
            this.groupBox2.Controls.Add(this.optClaimCharSummary);
            this.groupBox2.Controls.Add(this.optArticleWise);
            this.groupBox2.Controls.Add(this.optCharSummary);
            this.groupBox2.Controls.Add(this.optSizeWise);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.optDet);
            this.groupBox2.Location = new System.Drawing.Point(17, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(482, 239);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(112, 117);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(90, 20);
            this.dtpToDate.TabIndex = 90;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(112, 76);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(90, 20);
            this.dtpFromDate.TabIndex = 81;
            // 
            // optArticleWiseCashPaid
            // 
            this.optArticleWiseCashPaid.AutoSize = true;
            this.optArticleWiseCashPaid.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optArticleWiseCashPaid.Location = new System.Drawing.Point(253, 214);
            this.optArticleWiseCashPaid.Name = "optArticleWiseCashPaid";
            this.optArticleWiseCashPaid.Size = new System.Drawing.Size(156, 19);
            this.optArticleWiseCashPaid.TabIndex = 89;
            this.optArticleWiseCashPaid.TabStop = true;
            this.optArticleWiseCashPaid.Text = "Article Wise [Cash Paid]";
            this.optArticleWiseCashPaid.UseVisualStyleBackColor = true;
            // 
            // optClaimCashSummary
            // 
            this.optClaimCashSummary.AutoSize = true;
            this.optClaimCashSummary.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optClaimCashSummary.Location = new System.Drawing.Point(253, 192);
            this.optClaimCashSummary.Name = "optClaimCashSummary";
            this.optClaimCashSummary.Size = new System.Drawing.Size(224, 19);
            this.optClaimCashSummary.TabIndex = 87;
            this.optClaimCashSummary.TabStop = true;
            this.optClaimCashSummary.Text = "Claim + Charges - Cash  [Summary]";
            this.optClaimCashSummary.UseVisualStyleBackColor = true;
            // 
            // optProd
            // 
            this.optProd.AutoSize = true;
            this.optProd.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optProd.Location = new System.Drawing.Point(253, 117);
            this.optProd.Name = "optProd";
            this.optProd.Size = new System.Drawing.Size(84, 19);
            this.optProd.TabIndex = 86;
            this.optProd.TabStop = true;
            this.optProd.Text = "Production";
            this.optProd.UseVisualStyleBackColor = true;
            // 
            // optProdSummary
            // 
            this.optProdSummary.AutoSize = true;
            this.optProdSummary.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optProdSummary.Location = new System.Drawing.Point(253, 142);
            this.optProdSummary.Name = "optProdSummary";
            this.optProdSummary.Size = new System.Drawing.Size(146, 19);
            this.optProdSummary.TabIndex = 85;
            this.optProdSummary.TabStop = true;
            this.optProdSummary.Text = "Production [Summary]";
            this.optProdSummary.UseVisualStyleBackColor = true;
            // 
            // optProdSummaryCE
            // 
            this.optProdSummaryCE.AutoSize = true;
            this.optProdSummaryCE.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optProdSummaryCE.Location = new System.Drawing.Point(253, 167);
            this.optProdSummaryCE.Name = "optProdSummaryCE";
            this.optProdSummaryCE.Size = new System.Drawing.Size(166, 19);
            this.optProdSummaryCE.TabIndex = 88;
            this.optProdSummaryCE.TabStop = true;
            this.optProdSummaryCE.Text = "Production [Summary] CE";
            this.optProdSummaryCE.UseVisualStyleBackColor = true;
            // 
            // optClaimCharSummary
            // 
            this.optClaimCharSummary.AutoSize = true;
            this.optClaimCharSummary.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optClaimCharSummary.Location = new System.Drawing.Point(253, 93);
            this.optClaimCharSummary.Name = "optClaimCharSummary";
            this.optClaimCharSummary.Size = new System.Drawing.Size(181, 19);
            this.optClaimCharSummary.TabIndex = 84;
            this.optClaimCharSummary.TabStop = true;
            this.optClaimCharSummary.Text = "Claim + Charges [Summary]";
            this.optClaimCharSummary.UseVisualStyleBackColor = true;
            // 
            // optArticleWise
            // 
            this.optArticleWise.AutoSize = true;
            this.optArticleWise.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optArticleWise.Location = new System.Drawing.Point(253, 52);
            this.optArticleWise.Name = "optArticleWise";
            this.optArticleWise.Size = new System.Drawing.Size(89, 19);
            this.optArticleWise.TabIndex = 83;
            this.optArticleWise.TabStop = true;
            this.optArticleWise.Text = "Article Wise";
            this.optArticleWise.UseVisualStyleBackColor = true;
            // 
            // optCharSummary
            // 
            this.optCharSummary.AutoSize = true;
            this.optCharSummary.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optCharSummary.Location = new System.Drawing.Point(253, 77);
            this.optCharSummary.Name = "optCharSummary";
            this.optCharSummary.Size = new System.Drawing.Size(135, 19);
            this.optCharSummary.TabIndex = 82;
            this.optCharSummary.TabStop = true;
            this.optCharSummary.Text = "Charges [Summary]";
            this.optCharSummary.UseVisualStyleBackColor = true;
            // 
            // optSizeWise
            // 
            this.optSizeWise.AutoSize = true;
            this.optSizeWise.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSizeWise.Location = new System.Drawing.Point(253, 30);
            this.optSizeWise.Name = "optSizeWise";
            this.optSizeWise.Size = new System.Drawing.Size(79, 19);
            this.optSizeWise.TabIndex = 81;
            this.optSizeWise.TabStop = true;
            this.optSizeWise.Text = "Size Wise";
            this.optSizeWise.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AllowDrop = true;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(25, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 17);
            this.label9.TabIndex = 80;
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
            this.label10.Location = new System.Drawing.Point(27, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 17);
            this.label10.TabIndex = 79;
            this.label10.Text = "  From Date  ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // optDet
            // 
            this.optDet.AutoSize = true;
            this.optDet.Checked = true;
            this.optDet.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDet.Location = new System.Drawing.Point(253, 13);
            this.optDet.Name = "optDet";
            this.optDet.Size = new System.Drawing.Size(57, 19);
            this.optDet.TabIndex = 76;
            this.optDet.TabStop = true;
            this.optDet.Text = "Detail";
            this.optDet.UseVisualStyleBackColor = true;
            // 
            // cboCharType
            // 
            this.cboCharType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCharType.FormattingEnabled = true;
            this.cboCharType.Location = new System.Drawing.Point(145, 83);
            this.cboCharType.Name = "cboCharType";
            this.cboCharType.Size = new System.Drawing.Size(279, 23);
            this.cboCharType.TabIndex = 59;
            // 
            // cboItemCat
            // 
            this.cboItemCat.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItemCat.FormattingEnabled = true;
            this.cboItemCat.Location = new System.Drawing.Point(145, 54);
            this.cboItemCat.Name = "cboItemCat";
            this.cboItemCat.Size = new System.Drawing.Size(279, 23);
            this.cboItemCat.TabIndex = 58;
            // 
            // cboCont
            // 
            this.cboCont.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCont.FormattingEnabled = true;
            this.cboCont.Location = new System.Drawing.Point(146, 25);
            this.cboCont.Name = "cboCont";
            this.cboCont.Size = new System.Drawing.Size(279, 23);
            this.cboCont.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(29, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 56;
            this.label2.Text = "   Charges Type   ";
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
            this.label1.Location = new System.Drawing.Point(30, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 55;
            this.label1.Text = "  Item Category   ";
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
            this.label4.Location = new System.Drawing.Point(30, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 54;
            this.label4.Text = "      Contractor     ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmContractorCharges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 430);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frmContractorCharges";
            this.Text = "Contractor Charges Report";
            this.Load += new System.EventHandler(this.contractor_Charges_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmContractorCharges_KeyDown);
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
        private System.Windows.Forms.ComboBox cboCont;
        private System.Windows.Forms.ComboBox cboCharType;
        private System.Windows.Forms.ComboBox cboItemCat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton optDet;
        private System.Windows.Forms.RadioButton optArticleWiseCashPaid;
        private System.Windows.Forms.RadioButton optClaimCashSummary;
        private System.Windows.Forms.RadioButton optProd;
        private System.Windows.Forms.RadioButton optProdSummary;
        private System.Windows.Forms.RadioButton optProdSummaryCE;
        private System.Windows.Forms.RadioButton optClaimCharSummary;
        private System.Windows.Forms.RadioButton optArticleWise;
        private System.Windows.Forms.RadioButton optCharSummary;
        private System.Windows.Forms.RadioButton optSizeWise;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
    }
}