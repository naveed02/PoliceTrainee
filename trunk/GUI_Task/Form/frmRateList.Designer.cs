namespace GUI_Task
{
    partial class frmRateList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRateList));
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.optItemChargesRate = new System.Windows.Forms.RadioButton();
            this.optRatePair = new System.Windows.Forms.RadioButton();
            this.optRateDozen = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cboItemGrp = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(21, 33);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(232, 41);
            this.btnStart.TabIndex = 0;
            this.btnStart.Tag = "";
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(26, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 127);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(21, 80);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(232, 41);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "[Esc] = Exit From Option";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // optItemChargesRate
            // 
            this.optItemChargesRate.AutoSize = true;
            this.optItemChargesRate.Location = new System.Drawing.Point(47, 126);
            this.optItemChargesRate.Name = "optItemChargesRate";
            this.optItemChargesRate.Size = new System.Drawing.Size(113, 17);
            this.optItemChargesRate.TabIndex = 22;
            this.optItemChargesRate.Text = "Item Charges Rate";
            this.optItemChargesRate.UseVisualStyleBackColor = true;
            // 
            // optRatePair
            // 
            this.optRatePair.AutoSize = true;
            this.optRatePair.Location = new System.Drawing.Point(47, 103);
            this.optRatePair.Name = "optRatePair";
            this.optRatePair.Size = new System.Drawing.Size(69, 17);
            this.optRatePair.TabIndex = 21;
            this.optRatePair.Text = "Rate Pair";
            this.optRatePair.UseVisualStyleBackColor = true;
            // 
            // optRateDozen
            // 
            this.optRateDozen.AutoSize = true;
            this.optRateDozen.Checked = true;
            this.optRateDozen.Location = new System.Drawing.Point(47, 80);
            this.optRateDozen.Name = "optRateDozen";
            this.optRateDozen.Size = new System.Drawing.Size(82, 17);
            this.optRateDozen.TabIndex = 20;
            this.optRateDozen.TabStop = true;
            this.optRateDozen.Text = "Rate Dozen";
            this.optRateDozen.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 22);
            this.label1.TabIndex = 23;
            this.label1.Text = "Item Group";
            // 
            // cboItemGrp
            // 
            this.cboItemGrp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItemGrp.FormattingEnabled = true;
            this.cboItemGrp.Location = new System.Drawing.Point(26, 41);
            this.cboItemGrp.Name = "cboItemGrp";
            this.cboItemGrp.Size = new System.Drawing.Size(279, 23);
            this.cboItemGrp.TabIndex = 24;
            // 
            // frmRateList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 296);
            this.Controls.Add(this.cboItemGrp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.optItemChargesRate);
            this.Controls.Add(this.optRatePair);
            this.Controls.Add(this.optRateDozen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmRateList";
            this.Text = "Items Rate List";
            this.Load += new System.EventHandler(this.frm_items_Rate_List_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRateList_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton optItemChargesRate;
        private System.Windows.Forms.RadioButton optRatePair;
        private System.Windows.Forms.RadioButton optRateDozen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboItemGrp;
    }
}