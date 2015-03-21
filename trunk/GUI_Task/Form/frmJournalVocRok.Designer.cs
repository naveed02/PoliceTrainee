namespace GUI_Task
{
    partial class frmJournalVocRok
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
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.optJournalVoc = new System.Windows.Forms.RadioButton();
            this.optDishChqSummary = new System.Windows.Forms.RadioButton();
            this.optDishChqDet = new System.Windows.Forms.RadioButton();
            this.optCashPaySummary = new System.Windows.Forms.RadioButton();
            this.optCashPayDet = new System.Windows.Forms.RadioButton();
            this.optCashReceSummary = new System.Windows.Forms.RadioButton();
            this.optCashReceDet = new System.Windows.Forms.RadioButton();
            this.optBankRok = new System.Windows.Forms.RadioButton();
            this.optJournalVocRok = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtFrom);
            this.groupBox1.Controls.Add(this.dtTo);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.optJournalVoc);
            this.groupBox1.Controls.Add(this.optDishChqSummary);
            this.groupBox1.Controls.Add(this.optDishChqDet);
            this.groupBox1.Controls.Add(this.optCashPaySummary);
            this.groupBox1.Controls.Add(this.optCashPayDet);
            this.groupBox1.Controls.Add(this.optCashReceSummary);
            this.groupBox1.Controls.Add(this.optCashReceDet);
            this.groupBox1.Controls.Add(this.optBankRok);
            this.groupBox1.Controls.Add(this.optJournalVocRok);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 358);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtFrom
            // 
            this.dtFrom.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrom.Location = new System.Drawing.Point(120, 59);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(122, 21);
            this.dtFrom.TabIndex = 89;
            // 
            // dtTo
            // 
            this.dtTo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTo.Location = new System.Drawing.Point(120, 32);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(122, 21);
            this.dtTo.TabIndex = 88;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(81, 323);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 24);
            this.btnOK.TabIndex = 87;
            this.btnOK.Text = "O.K";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(206, 323);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 24);
            this.btnExit.TabIndex = 86;
            this.btnExit.Text = "[Esc] = Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // optJournalVoc
            // 
            this.optJournalVoc.AutoSize = true;
            this.optJournalVoc.Location = new System.Drawing.Point(55, 283);
            this.optJournalVoc.Name = "optJournalVoc";
            this.optJournalVoc.Size = new System.Drawing.Size(102, 17);
            this.optJournalVoc.TabIndex = 20;
            this.optJournalVoc.Text = "Journal Voucher";
            this.optJournalVoc.UseVisualStyleBackColor = true;
            // 
            // optDishChqSummary
            // 
            this.optDishChqSummary.AutoSize = true;
            this.optDishChqSummary.Location = new System.Drawing.Point(55, 260);
            this.optDishChqSummary.Name = "optDishChqSummary";
            this.optDishChqSummary.Size = new System.Drawing.Size(164, 17);
            this.optDishChqSummary.TabIndex = 19;
            this.optDishChqSummary.Text = "Dishonour Cheques Summary";
            this.optDishChqSummary.UseVisualStyleBackColor = true;
            // 
            // optDishChqDet
            // 
            this.optDishChqDet.AutoSize = true;
            this.optDishChqDet.Location = new System.Drawing.Point(55, 237);
            this.optDishChqDet.Name = "optDishChqDet";
            this.optDishChqDet.Size = new System.Drawing.Size(148, 17);
            this.optDishChqDet.TabIndex = 18;
            this.optDishChqDet.Text = "Dishonour Cheques Detail";
            this.optDishChqDet.UseVisualStyleBackColor = true;
            // 
            // optCashPaySummary
            // 
            this.optCashPaySummary.AutoSize = true;
            this.optCashPaySummary.Location = new System.Drawing.Point(55, 214);
            this.optCashPaySummary.Name = "optCashPaySummary";
            this.optCashPaySummary.Size = new System.Drawing.Size(181, 17);
            this.optCashPaySummary.TabIndex = 17;
            this.optCashPaySummary.Text = "Cash/Cheque Payment Summary";
            this.optCashPaySummary.UseVisualStyleBackColor = true;
            // 
            // optCashPayDet
            // 
            this.optCashPayDet.AutoSize = true;
            this.optCashPayDet.Location = new System.Drawing.Point(55, 191);
            this.optCashPayDet.Name = "optCashPayDet";
            this.optCashPayDet.Size = new System.Drawing.Size(165, 17);
            this.optCashPayDet.TabIndex = 16;
            this.optCashPayDet.Text = "Cash/Cheque Payment Detail";
            this.optCashPayDet.UseVisualStyleBackColor = true;
            // 
            // optCashReceSummary
            // 
            this.optCashReceSummary.AutoSize = true;
            this.optCashReceSummary.Location = new System.Drawing.Point(55, 168);
            this.optCashReceSummary.Name = "optCashReceSummary";
            this.optCashReceSummary.Size = new System.Drawing.Size(177, 17);
            this.optCashReceSummary.TabIndex = 15;
            this.optCashReceSummary.Text = "Cash/Cheque Receipt Summary";
            this.optCashReceSummary.UseVisualStyleBackColor = true;
            // 
            // optCashReceDet
            // 
            this.optCashReceDet.AutoSize = true;
            this.optCashReceDet.Location = new System.Drawing.Point(55, 145);
            this.optCashReceDet.Name = "optCashReceDet";
            this.optCashReceDet.Size = new System.Drawing.Size(161, 17);
            this.optCashReceDet.TabIndex = 14;
            this.optCashReceDet.Text = "Cash/Cheque Receipt Detail";
            this.optCashReceDet.UseVisualStyleBackColor = true;
            // 
            // optBankRok
            // 
            this.optBankRok.AutoSize = true;
            this.optBankRok.Location = new System.Drawing.Point(55, 122);
            this.optBankRok.Name = "optBankRok";
            this.optBankRok.Size = new System.Drawing.Size(82, 17);
            this.optBankRok.TabIndex = 13;
            this.optBankRok.Text = "Bank Roker";
            this.optBankRok.UseVisualStyleBackColor = true;
            // 
            // optJournalVocRok
            // 
            this.optJournalVocRok.AutoSize = true;
            this.optJournalVocRok.Checked = true;
            this.optJournalVocRok.Location = new System.Drawing.Point(55, 99);
            this.optJournalVocRok.Name = "optJournalVocRok";
            this.optJournalVocRok.Size = new System.Drawing.Size(134, 17);
            this.optJournalVocRok.TabIndex = 12;
            this.optJournalVocRok.TabStop = true;
            this.optJournalVocRok.Text = "Journal Voucher Roker";
            this.optJournalVocRok.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AllowDrop = true;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(28, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "      To Date      ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(28, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "    From Date   ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmJournalVocRok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 383);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frmJournalVocRok";
            this.Text = "Bank/Journal Voucher Roker";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmJournalVocRok_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton optJournalVocRok;
        private System.Windows.Forms.RadioButton optJournalVoc;
        private System.Windows.Forms.RadioButton optDishChqSummary;
        private System.Windows.Forms.RadioButton optDishChqDet;
        private System.Windows.Forms.RadioButton optCashPaySummary;
        private System.Windows.Forms.RadioButton optCashPayDet;
        private System.Windows.Forms.RadioButton optCashReceSummary;
        private System.Windows.Forms.RadioButton optCashReceDet;
        private System.Windows.Forms.RadioButton optBankRok;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
    }
}