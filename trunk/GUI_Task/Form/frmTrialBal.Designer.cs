namespace GUI_Task
{
    partial class frmTrialBal
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
            this.grpTrial = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.optSortByName = new System.Windows.Forms.RadioButton();
            this.optSortByCode = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.grpTrial.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTrial
            // 
            this.grpTrial.Controls.Add(this.dtpToDate);
            this.grpTrial.Controls.Add(this.dtpFromDate);
            this.grpTrial.Controls.Add(this.optSortByName);
            this.grpTrial.Controls.Add(this.optSortByCode);
            this.grpTrial.Controls.Add(this.radioButton2);
            this.grpTrial.Controls.Add(this.radioButton1);
            this.grpTrial.Controls.Add(this.label2);
            this.grpTrial.Controls.Add(this.btnExit);
            this.grpTrial.Controls.Add(this.label3);
            this.grpTrial.Controls.Add(this.btnOK);
            this.grpTrial.Location = new System.Drawing.Point(12, 12);
            this.grpTrial.Name = "grpTrial";
            this.grpTrial.Size = new System.Drawing.Size(288, 181);
            this.grpTrial.TabIndex = 0;
            this.grpTrial.TabStop = false;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(148, 64);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(113, 20);
            this.dtpToDate.TabIndex = 68;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(148, 27);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(113, 20);
            this.dtpFromDate.TabIndex = 67;
            // 
            // optSortByName
            // 
            this.optSortByName.AutoSize = true;
            this.optSortByName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSortByName.Location = new System.Drawing.Point(112, 116);
            this.optSortByName.Name = "optSortByName";
            this.optSortByName.Size = new System.Drawing.Size(89, 17);
            this.optSortByName.TabIndex = 36;
            this.optSortByName.Text = "Sort By Name";
            this.optSortByName.UseVisualStyleBackColor = true;
            this.optSortByName.Visible = false;
            // 
            // optSortByCode
            // 
            this.optSortByCode.AutoSize = true;
            this.optSortByCode.Checked = true;
            this.optSortByCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSortByCode.Location = new System.Drawing.Point(112, 93);
            this.optSortByCode.Name = "optSortByCode";
            this.optSortByCode.Size = new System.Drawing.Size(87, 17);
            this.optSortByCode.TabIndex = 35;
            this.optSortByCode.TabStop = true;
            this.optSortByCode.Text = "Sort By Code";
            this.optSortByCode.UseVisualStyleBackColor = true;
            this.optSortByCode.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(456, 134);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 17);
            this.radioButton2.TabIndex = 34;
            this.radioButton2.Text = "Urdu";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(456, 118);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 17);
            this.radioButton1.TabIndex = 33;
            this.radioButton1.Text = "English";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(18, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "    From Report Date   ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(148, 145);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(81, 30);
            this.btnExit.TabIndex = 32;
            this.btnExit.Text = "[Esc] = Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button8_Click);
            // 
            // label3
            // 
            this.label3.AllowDrop = true;
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(18, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "     To Report Date       ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(56, 145);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(65, 30);
            this.btnOK.TabIndex = 31;
            this.btnOK.Text = "O.K";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmTrialBal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 213);
            this.Controls.Add(this.grpTrial);
            this.KeyPreview = true;
            this.Name = "frmTrialBal";
            this.Text = "Trial Balance";
            this.Load += new System.EventHandler(this.trail_Balance_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTrailBal_KeyDown);
            this.grpTrial.ResumeLayout(false);
            this.grpTrial.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTrial;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton optSortByName;
        private System.Windows.Forms.RadioButton optSortByCode;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
    }
}