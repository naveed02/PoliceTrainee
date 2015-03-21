namespace GUI_Task
{
    partial class frmProdPlan
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.optSaleOrdDelStatus = new System.Windows.Forms.RadioButton();
            this.optForProd = new System.Windows.Forms.RadioButton();
            this.optReqShow = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.optAllRecordShow = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OptWOOrd = new System.Windows.Forms.RadioButton();
            this.optWDO = new System.Windows.Forms.RadioButton();
            this.cboItemGrp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cboItemGrp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 324);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(206, 285);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 24);
            this.btnOK.TabIndex = 85;
            this.btnOK.Text = "O.K";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(331, 285);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 24);
            this.btnExit.TabIndex = 84;
            this.btnExit.Text = "[Esc] = Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpToDate);
            this.groupBox3.Controls.Add(this.dtpFromDate);
            this.groupBox3.Controls.Add(this.optSaleOrdDelStatus);
            this.groupBox3.Controls.Add(this.optForProd);
            this.groupBox3.Controls.Add(this.optReqShow);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.optAllRecordShow);
            this.groupBox3.Location = new System.Drawing.Point(28, 133);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(474, 134);
            this.groupBox3.TabIndex = 58;
            this.groupBox3.TabStop = false;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(141, 70);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(90, 20);
            this.dtpToDate.TabIndex = 93;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(141, 31);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(90, 20);
            this.dtpFromDate.TabIndex = 92;
            // 
            // optSaleOrdDelStatus
            // 
            this.optSaleOrdDelStatus.AutoSize = true;
            this.optSaleOrdDelStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSaleOrdDelStatus.Location = new System.Drawing.Point(285, 97);
            this.optSaleOrdDelStatus.Name = "optSaleOrdDelStatus";
            this.optSaleOrdDelStatus.Size = new System.Drawing.Size(122, 19);
            this.optSaleOrdDelStatus.TabIndex = 91;
            this.optSaleOrdDelStatus.Text = "Sale Order Status";
            this.optSaleOrdDelStatus.UseVisualStyleBackColor = true;
            // 
            // optForProd
            // 
            this.optForProd.AutoSize = true;
            this.optForProd.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optForProd.Location = new System.Drawing.Point(285, 74);
            this.optForProd.Name = "optForProd";
            this.optForProd.Size = new System.Drawing.Size(105, 19);
            this.optForProd.TabIndex = 90;
            this.optForProd.Text = "For Production";
            this.optForProd.UseVisualStyleBackColor = true;
            // 
            // optReqShow
            // 
            this.optReqShow.AutoSize = true;
            this.optReqShow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optReqShow.Location = new System.Drawing.Point(285, 49);
            this.optReqShow.Name = "optReqShow";
            this.optReqShow.Size = new System.Drawing.Size(110, 19);
            this.optReqShow.TabIndex = 89;
            this.optReqShow.Text = "Required Show";
            this.optReqShow.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AllowDrop = true;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(46, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 17);
            this.label9.TabIndex = 88;
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
            this.label10.Location = new System.Drawing.Point(46, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 17);
            this.label10.TabIndex = 87;
            this.label10.Text = "  From Date  ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // optAllRecordShow
            // 
            this.optAllRecordShow.AutoSize = true;
            this.optAllRecordShow.Checked = true;
            this.optAllRecordShow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optAllRecordShow.Location = new System.Drawing.Point(285, 24);
            this.optAllRecordShow.Name = "optAllRecordShow";
            this.optAllRecordShow.Size = new System.Drawing.Size(115, 19);
            this.optAllRecordShow.TabIndex = 84;
            this.optAllRecordShow.TabStop = true;
            this.optAllRecordShow.Text = "All Record Show";
            this.optAllRecordShow.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.OptWOOrd);
            this.groupBox2.Controls.Add(this.optWDO);
            this.groupBox2.Location = new System.Drawing.Point(28, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(474, 49);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            // 
            // OptWOOrd
            // 
            this.OptWOOrd.AutoSize = true;
            this.OptWOOrd.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptWOOrd.Location = new System.Drawing.Point(298, 19);
            this.OptWOOrd.Name = "OptWOOrd";
            this.OptWOOrd.Size = new System.Drawing.Size(153, 19);
            this.OptWOOrd.TabIndex = 69;
            this.OptWOOrd.Text = "Without Delivery Order";
            this.OptWOOrd.UseVisualStyleBackColor = true;
            // 
            // optWDO
            // 
            this.optWDO.AutoSize = true;
            this.optWDO.Checked = true;
            this.optWDO.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optWDO.Location = new System.Drawing.Point(37, 19);
            this.optWDO.Name = "optWDO";
            this.optWDO.Size = new System.Drawing.Size(135, 19);
            this.optWDO.TabIndex = 68;
            this.optWDO.TabStop = true;
            this.optWDO.Text = "With Delivery Order";
            this.optWDO.UseVisualStyleBackColor = true;
            // 
            // cboItemGrp
            // 
            this.cboItemGrp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItemGrp.FormattingEnabled = true;
            this.cboItemGrp.Location = new System.Drawing.Point(156, 24);
            this.cboItemGrp.Name = "cboItemGrp";
            this.cboItemGrp.Size = new System.Drawing.Size(279, 23);
            this.cboItemGrp.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AllowDrop = true;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(28, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 55;
            this.label4.Text = "       Item Group       ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmProdPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 360);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frmProdPlan";
            this.Text = "Production Plan Report";
            this.Load += new System.EventHandler(this.production_Plan_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProdPlan_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboItemGrp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton OptWOOrd;
        private System.Windows.Forms.RadioButton optWDO;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton optSaleOrdDelStatus;
        private System.Windows.Forms.RadioButton optForProd;
        private System.Windows.Forms.RadioButton optReqShow;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton optAllRecordShow;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
    }
}