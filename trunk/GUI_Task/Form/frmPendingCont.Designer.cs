namespace GUI_Task
{
    partial class frmPendingCont
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
            this.cboMainGrp = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.optPendingOrdCatSummary = new System.Windows.Forms.RadioButton();
            this.optPendingOrdCatDet = new System.Windows.Forms.RadioButton();
            this.optPendingOrdSummary = new System.Windows.Forms.RadioButton();
            this.optPendingOrdDet = new System.Windows.Forms.RadioButton();
            this.cboItemGrp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboMainGrp
            // 
            this.cboMainGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMainGrp.FormattingEnabled = true;
            this.cboMainGrp.Location = new System.Drawing.Point(95, 30);
            this.cboMainGrp.Name = "cboMainGrp";
            this.cboMainGrp.Size = new System.Drawing.Size(308, 21);
            this.cboMainGrp.TabIndex = 10;
            this.cboMainGrp.Text = "<<ALL>>";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtFrom);
            this.groupBox1.Controls.Add(this.dtTo);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.optPendingOrdCatSummary);
            this.groupBox1.Controls.Add(this.optPendingOrdCatDet);
            this.groupBox1.Controls.Add(this.optPendingOrdSummary);
            this.groupBox1.Controls.Add(this.optPendingOrdDet);
            this.groupBox1.Controls.Add(this.cboItemGrp);
            this.groupBox1.Controls.Add(this.cboMainGrp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 313);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(96, 106);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(150, 20);
            this.dtFrom.TabIndex = 68;
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(96, 80);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(150, 20);
            this.dtTo.TabIndex = 67;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(256, 269);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(99, 23);
            this.btnExit.TabIndex = 43;
            this.btnExit.Text = "[Esc] = Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(142, 269);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 42;
            this.btnOK.Text = "O.K";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // optPendingOrdCatSummary
            // 
            this.optPendingOrdCatSummary.AutoSize = true;
            this.optPendingOrdCatSummary.Location = new System.Drawing.Point(78, 222);
            this.optPendingOrdCatSummary.Name = "optPendingOrdCatSummary";
            this.optPendingOrdCatSummary.Size = new System.Drawing.Size(184, 17);
            this.optPendingOrdCatSummary.TabIndex = 41;
            this.optPendingOrdCatSummary.Text = "Pending Order Category Summary";
            this.optPendingOrdCatSummary.UseVisualStyleBackColor = true;
            // 
            // optPendingOrdCatDet
            // 
            this.optPendingOrdCatDet.AutoSize = true;
            this.optPendingOrdCatDet.Location = new System.Drawing.Point(78, 199);
            this.optPendingOrdCatDet.Name = "optPendingOrdCatDet";
            this.optPendingOrdCatDet.Size = new System.Drawing.Size(168, 17);
            this.optPendingOrdCatDet.TabIndex = 40;
            this.optPendingOrdCatDet.Text = "Pending Order Category Detail";
            this.optPendingOrdCatDet.UseVisualStyleBackColor = true;
            // 
            // optPendingOrdSummary
            // 
            this.optPendingOrdSummary.AutoSize = true;
            this.optPendingOrdSummary.Location = new System.Drawing.Point(78, 176);
            this.optPendingOrdSummary.Name = "optPendingOrdSummary";
            this.optPendingOrdSummary.Size = new System.Drawing.Size(139, 17);
            this.optPendingOrdSummary.TabIndex = 39;
            this.optPendingOrdSummary.Text = "Pending Order Summary";
            this.optPendingOrdSummary.UseVisualStyleBackColor = true;
            // 
            // optPendingOrdDet
            // 
            this.optPendingOrdDet.AutoSize = true;
            this.optPendingOrdDet.Checked = true;
            this.optPendingOrdDet.Location = new System.Drawing.Point(78, 153);
            this.optPendingOrdDet.Name = "optPendingOrdDet";
            this.optPendingOrdDet.Size = new System.Drawing.Size(123, 17);
            this.optPendingOrdDet.TabIndex = 38;
            this.optPendingOrdDet.TabStop = true;
            this.optPendingOrdDet.Text = "Pending Order Detail";
            this.optPendingOrdDet.UseVisualStyleBackColor = true;
            // 
            // cboItemGrp
            // 
            this.cboItemGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItemGrp.FormattingEnabled = true;
            this.cboItemGrp.Location = new System.Drawing.Point(96, 56);
            this.cboItemGrp.Name = "cboItemGrp";
            this.cboItemGrp.Size = new System.Drawing.Size(308, 21);
            this.cboItemGrp.TabIndex = 11;
            this.cboItemGrp.Text = "<<ALL>>";
            // 
            // label3
            // 
            this.label3.AllowDrop = true;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(16, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "  From Date ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(16, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "    To Date    ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(16, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = " Item Group ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AllowDrop = true;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(16, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Main Group";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmPendingCont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 338);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frmPendingCont";
            this.Text = "Pending Contracts";
            this.Load += new System.EventHandler(this.frm_pending_Contracts_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPendingCont_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMainGrp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton optPendingOrdCatSummary;
        private System.Windows.Forms.RadioButton optPendingOrdCatDet;
        private System.Windows.Forms.RadioButton optPendingOrdSummary;
        private System.Windows.Forms.RadioButton optPendingOrdDet;
        private System.Windows.Forms.ComboBox cboItemGrp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtTo;

    }
}