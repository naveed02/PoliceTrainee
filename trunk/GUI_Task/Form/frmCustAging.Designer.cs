namespace GUI_Task
{
    partial class frmCustAging
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustAging));
            this.mskAccCode = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.optWithDishChq = new System.Windows.Forms.RadioButton();
            this.optCrDaysWithDishChq = new System.Windows.Forms.RadioButton();
            this.optWithoutDishChq = new System.Windows.Forms.RadioButton();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mskAccCode
            // 
            this.mskAccCode.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskAccCode.Location = new System.Drawing.Point(146, 17);
            this.mskAccCode.Mask = "0-0-00-00-0000";
            this.mskAccCode.Name = "mskAccCode";
            this.mskAccCode.Size = new System.Drawing.Size(150, 22);
            this.mskAccCode.TabIndex = 53;
            this.mskAccCode.DoubleClick += new System.EventHandler(this.mskAccCode_DoubleClick);
            this.mskAccCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskAccCode_KeyDown);
            // 
            // label6
            // 
            this.label6.AllowDrop = true;
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(25, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 17);
            this.label6.TabIndex = 51;
            this.label6.Text = "  Account Name   ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 50;
            this.label1.Text = "  Account Code    ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // optWithDishChq
            // 
            this.optWithDishChq.AutoSize = true;
            this.optWithDishChq.Checked = true;
            this.optWithDishChq.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optWithDishChq.Location = new System.Drawing.Point(25, 85);
            this.optWithDishChq.Name = "optWithDishChq";
            this.optWithDishChq.Size = new System.Drawing.Size(158, 19);
            this.optWithDishChq.TabIndex = 54;
            this.optWithDishChq.TabStop = true;
            this.optWithDishChq.Text = "With Dishonoured Cheques";
            this.optWithDishChq.UseVisualStyleBackColor = true;
            // 
            // optCrDaysWithDishChq
            // 
            this.optCrDaysWithDishChq.AutoSize = true;
            this.optCrDaysWithDishChq.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optCrDaysWithDishChq.Location = new System.Drawing.Point(25, 110);
            this.optCrDaysWithDishChq.Name = "optCrDaysWithDishChq";
            this.optCrDaysWithDishChq.Size = new System.Drawing.Size(204, 19);
            this.optCrDaysWithDishChq.TabIndex = 55;
            this.optCrDaysWithDishChq.Text = "Cr. Days With Dishonoured Cheques";
            this.optCrDaysWithDishChq.UseVisualStyleBackColor = true;
            // 
            // optWithoutDishChq
            // 
            this.optWithoutDishChq.AutoSize = true;
            this.optWithoutDishChq.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optWithoutDishChq.Location = new System.Drawing.Point(253, 85);
            this.optWithoutDishChq.Name = "optWithoutDishChq";
            this.optWithoutDishChq.Size = new System.Drawing.Size(174, 19);
            this.optWithoutDishChq.TabIndex = 56;
            this.optWithoutDishChq.Text = "Without Dishonoured Cheques";
            this.optWithoutDishChq.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHelp.Location = new System.Drawing.Point(274, 147);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(113, 27);
            this.btnHelp.TabIndex = 59;
            this.btnHelp.Text = "[F1] = Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(183, 147);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(73, 27);
            this.btnExit.TabIndex = 58;
            this.btnExit.Text = "[Esc] = Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(94, 147);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(60, 27);
            this.btnOK.TabIndex = 57;
            this.btnOK.Text = "O.K";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblAccountName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountName.Location = new System.Drawing.Point(143, 54);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(274, 15);
            this.lblAccountName.TabIndex = 151;
            this.lblAccountName.Text = "                                                                                 " +
                "        ";
            this.lblAccountName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmCustAging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 186);
            this.Controls.Add(this.lblAccountName);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.optWithoutDishChq);
            this.Controls.Add(this.optCrDaysWithDishChq);
            this.Controls.Add(this.optWithDishChq);
            this.Controls.Add(this.mskAccCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmCustAging";
            this.Text = "Due Receivables";
            this.Load += new System.EventHandler(this.frm_customer_Wise_Aging_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCustAging_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mskAccCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton optWithDishChq;
        private System.Windows.Forms.RadioButton optCrDaysWithDishChq;
        private System.Windows.Forms.RadioButton optWithoutDishChq;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblAccountName;
    }
}