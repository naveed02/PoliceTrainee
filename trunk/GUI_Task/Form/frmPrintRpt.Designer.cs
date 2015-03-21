namespace GUI_Task
{
    partial class frmPrintRpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintRpt));
            this.cboCourseSelection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDetailedReport = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboBatchName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboCourseSelection
            // 
            this.cboCourseSelection.DisplayMember = "1";
            this.cboCourseSelection.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCourseSelection.FormattingEnabled = true;
            this.cboCourseSelection.Location = new System.Drawing.Point(147, 22);
            this.cboCourseSelection.Name = "cboCourseSelection";
            this.cboCourseSelection.Size = new System.Drawing.Size(272, 23);
            this.cboCourseSelection.TabIndex = 0;
            this.cboCourseSelection.DropDownClosed += new System.EventHandler(this.cboCourseSelection_DropDownClosed);
            this.cboCourseSelection.Click += new System.EventHandler(this.cboCourseSelection_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Course Selection";
            // 
            // btnDetailedReport
            // 
            this.btnDetailedReport.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetailedReport.Location = new System.Drawing.Point(124, 149);
            this.btnDetailedReport.Name = "btnDetailedReport";
            this.btnDetailedReport.Size = new System.Drawing.Size(118, 23);
            this.btnDetailedReport.TabIndex = 2;
            this.btnDetailedReport.Text = "Print Detailed Report";
            this.btnDetailedReport.UseVisualStyleBackColor = true;
            this.btnDetailedReport.Click += new System.EventHandler(this.btnDetailedReport_Click);
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(384, 104);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(47, 21);
            this.txtID.TabIndex = 4;
            this.txtID.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(260, 149);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(118, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "[Esc] = Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(124, 102);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(254, 23);
            this.btnHelp.TabIndex = 1;
            this.btnHelp.Text = "Find Record";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Batch Selection";
            // 
            // cboBatchName
            // 
            this.cboBatchName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBatchName.FormattingEnabled = true;
            this.cboBatchName.Location = new System.Drawing.Point(147, 60);
            this.cboBatchName.Name = "cboBatchName";
            this.cboBatchName.Size = new System.Drawing.Size(272, 23);
            this.cboBatchName.TabIndex = 5;
            // 
            // frmPrintRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 200);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboBatchName);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnDetailedReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCourseSelection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmPrintRpt";
            this.Text = "Report Printing";
            this.Load += new System.EventHandler(this.frmPrintRpt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrintRpt_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCourseSelection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDetailedReport;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboBatchName;
    }
}