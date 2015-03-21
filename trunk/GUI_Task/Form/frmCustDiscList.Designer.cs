namespace GUI_Task
{
    partial class frmCustDiscList
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.optItemCharRate = new System.Windows.Forms.RadioButton();
            this.optRatePair = new System.Windows.Forms.RadioButton();
            this.optRateDozen = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(26, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 127);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(21, 66);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(232, 41);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "[Esc] = Exit From Option";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(21, 19);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(232, 41);
            this.btnStart.TabIndex = 0;
            this.btnStart.Tag = "";
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // optItemCharRate
            // 
            this.optItemCharRate.AutoSize = true;
            this.optItemCharRate.Location = new System.Drawing.Point(47, 73);
            this.optItemCharRate.Name = "optItemCharRate";
            this.optItemCharRate.Size = new System.Drawing.Size(113, 17);
            this.optItemCharRate.TabIndex = 6;
            this.optItemCharRate.TabStop = true;
            this.optItemCharRate.Text = "Item Charges Rate";
            this.optItemCharRate.UseVisualStyleBackColor = true;
            // 
            // optRatePair
            // 
            this.optRatePair.AutoSize = true;
            this.optRatePair.Location = new System.Drawing.Point(47, 50);
            this.optRatePair.Name = "optRatePair";
            this.optRatePair.Size = new System.Drawing.Size(69, 17);
            this.optRatePair.TabIndex = 5;
            this.optRatePair.TabStop = true;
            this.optRatePair.Text = "Rate Pair";
            this.optRatePair.UseVisualStyleBackColor = true;
            // 
            // optRateDozen
            // 
            this.optRateDozen.AutoSize = true;
            this.optRateDozen.Checked = true;
            this.optRateDozen.Location = new System.Drawing.Point(47, 27);
            this.optRateDozen.Name = "optRateDozen";
            this.optRateDozen.Size = new System.Drawing.Size(82, 17);
            this.optRateDozen.TabIndex = 4;
            this.optRateDozen.TabStop = true;
            this.optRateDozen.Text = "Rate Dozen";
            this.optRateDozen.UseVisualStyleBackColor = true;
            // 
            // frmCustDiscList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 260);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.optItemCharRate);
            this.Controls.Add(this.optRatePair);
            this.Controls.Add(this.optRateDozen);
            this.KeyPreview = true;
            this.Name = "frmCustDiscList";
            this.Text = "Customer Discount list";
            this.Load += new System.EventHandler(this.customer_Discount_list_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCustDiscList_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RadioButton optItemCharRate;
        private System.Windows.Forms.RadioButton optRatePair;
        private System.Windows.Forms.RadioButton optRateDozen;
    }
}