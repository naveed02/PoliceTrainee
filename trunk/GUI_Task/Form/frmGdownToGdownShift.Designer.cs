namespace GUI_Task
{
    partial class frmGdownToGdownShift
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
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.cboFromGodown = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboToGodown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboItemGroup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grdGodownToGodown = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalVal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.optInProcess = new System.Windows.Forms.RadioButton();
            this.optApproved = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPrinting = new System.Windows.Forms.Button();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.txtFinishReceNo = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdGtoG = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdGodownToGodown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGtoG)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(374, 10);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(122, 21);
            this.dtpDate.TabIndex = 287;
            // 
            // label8
            // 
            this.label8.AllowDrop = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(286, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 17);
            this.label8.TabIndex = 286;
            this.label8.Text = " Date";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 285;
            this.label1.Text = "Finish Recieve #";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Location = new System.Drawing.Point(602, 10);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(101, 22);
            this.btnAddNew.TabIndex = 291;
            this.btnAddNew.Text = "Add new";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(502, 10);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(94, 22);
            this.btnHelp.TabIndex = 290;
            this.btnHelp.Text = "F1=Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // cboFromGodown
            // 
            this.cboFromGodown.FormattingEnabled = true;
            this.cboFromGodown.Items.AddRange(new object[] {
            "Buckle",
            "Chemical PU",
            "Eva Shoes",
            "General ",
            "Leather And Rexine",
            "PCU Shoes",
            "PPC Patawa Cutting"});
            this.cboFromGodown.Location = new System.Drawing.Point(123, 38);
            this.cboFromGodown.Name = "cboFromGodown";
            this.cboFromGodown.Size = new System.Drawing.Size(373, 21);
            this.cboFromGodown.TabIndex = 293;
            this.cboFromGodown.Text = "-";
            // 
            // label4
            // 
            this.label4.AllowDrop = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(3, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 17);
            this.label4.TabIndex = 292;
            this.label4.Text = "From Godown";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboToGodown
            // 
            this.cboToGodown.FormattingEnabled = true;
            this.cboToGodown.Items.AddRange(new object[] {
            "Buckle",
            "Chemical PU",
            "Eva Shoes",
            "General ",
            "Leather And Rexine",
            "PCU Shoes",
            "PPC Patawa Cutting"});
            this.cboToGodown.Location = new System.Drawing.Point(123, 65);
            this.cboToGodown.Name = "cboToGodown";
            this.cboToGodown.Size = new System.Drawing.Size(373, 21);
            this.cboToGodown.TabIndex = 295;
            this.cboToGodown.Text = "-";
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(3, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 294;
            this.label2.Text = "To Godown";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboItemGroup
            // 
            this.cboItemGroup.FormattingEnabled = true;
            this.cboItemGroup.Items.AddRange(new object[] {
            "Buckle",
            "Chemical PU",
            "Eva Shoes",
            "General ",
            "Leather And Rexine",
            "PCU Shoes",
            "PPC Patawa Cutting"});
            this.cboItemGroup.Location = new System.Drawing.Point(122, 120);
            this.cboItemGroup.Name = "cboItemGroup";
            this.cboItemGroup.Size = new System.Drawing.Size(322, 21);
            this.cboItemGroup.TabIndex = 297;
            this.cboItemGroup.Text = "-";
            // 
            // label3
            // 
            this.label3.AllowDrop = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(2, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 296;
            this.label3.Text = "Item Group";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(123, 92);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(473, 20);
            this.txtNote.TabIndex = 299;
            // 
            // label5
            // 
            this.label5.AllowDrop = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(2, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 17);
            this.label5.TabIndex = 298;
            this.label5.Text = "Note";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grdGodownToGodown
            // 
            this.grdGodownToGodown.AllowUserToOrderColumns = true;
            this.grdGodownToGodown.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdGodownToGodown.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdGodownToGodown.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.grdGodownToGodown.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column10,
            this.Column12});
            this.grdGodownToGodown.Location = new System.Drawing.Point(3, 147);
            this.grdGodownToGodown.Name = "grdGodownToGodown";
            this.grdGodownToGodown.Size = new System.Drawing.Size(711, 53);
            this.grdGodownToGodown.TabIndex = 300;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Code";
            this.Column1.Name = "Column1";
            this.Column1.Width = 57;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Item Code";
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "Name";
            this.Column3.Name = "Column3";
            this.Column3.Width = 60;
            // 
            // Column5
            // 
            this.Column5.Frozen = true;
            this.Column5.HeaderText = "Size";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 52;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Colour ";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 65;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "UOM";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 57;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "From Godown Stock";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 129;
            // 
            // Column10
            // 
            this.Column10.Frozen = true;
            this.Column10.HeaderText = "Qty";
            this.Column10.Name = "Column10";
            this.Column10.Width = 48;
            // 
            // Column12
            // 
            this.Column12.Frozen = true;
            this.Column12.HeaderText = "To Godown Stock";
            this.Column12.Name = "Column12";
            this.Column12.Width = 119;
            // 
            // lblTotalVal
            // 
            this.lblTotalVal.AllowDrop = true;
            this.lblTotalVal.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblTotalVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalVal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotalVal.Location = new System.Drawing.Point(588, 385);
            this.lblTotalVal.Name = "lblTotalVal";
            this.lblTotalVal.Size = new System.Drawing.Size(126, 17);
            this.lblTotalVal.TabIndex = 307;
            this.lblTotalVal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AllowDrop = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(496, 385);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 17);
            this.label9.TabIndex = 306;
            this.label9.Text = "   Total Value";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // optInProcess
            // 
            this.optInProcess.AutoSize = true;
            this.optInProcess.Checked = true;
            this.optInProcess.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optInProcess.Location = new System.Drawing.Point(281, 384);
            this.optInProcess.Name = "optInProcess";
            this.optInProcess.Size = new System.Drawing.Size(84, 19);
            this.optInProcess.TabIndex = 304;
            this.optInProcess.TabStop = true;
            this.optInProcess.Text = "In Process";
            this.optInProcess.UseVisualStyleBackColor = true;
            // 
            // optApproved
            // 
            this.optApproved.AutoSize = true;
            this.optApproved.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optApproved.Location = new System.Drawing.Point(371, 385);
            this.optApproved.Name = "optApproved";
            this.optApproved.Size = new System.Drawing.Size(119, 19);
            this.optApproved.TabIndex = 305;
            this.optApproved.Text = "Approved/Verified";
            this.optApproved.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(150, 381);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(57, 26);
            this.btnExit.TabIndex = 303;
            this.btnExit.Text = "Esc=Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnPrinting
            // 
            this.btnPrinting.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrinting.Location = new System.Drawing.Point(81, 381);
            this.btnPrinting.Name = "btnPrinting";
            this.btnPrinting.Size = new System.Drawing.Size(63, 26);
            this.btnPrinting.TabIndex = 302;
            this.btnPrinting.Text = "Printing";
            this.btnPrinting.UseVisualStyleBackColor = true;
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSaveExit.Location = new System.Drawing.Point(9, 380);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(66, 26);
            this.btnSaveExit.TabIndex = 301;
            this.btnSaveExit.Text = "Exit+Save";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            // 
            // txtFinishReceNo
            // 
            this.txtFinishReceNo.Location = new System.Drawing.Point(123, 8);
            this.txtFinishReceNo.Name = "txtFinishReceNo";
            this.txtFinishReceNo.Size = new System.Drawing.Size(130, 20);
            this.txtFinishReceNo.TabIndex = 308;
            this.txtFinishReceNo.DoubleClick += new System.EventHandler(this.txtFinishReceNo_DoubleClick);
            this.txtFinishReceNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFinishReceNo_KeyDown);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "Colour ";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 65;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "UOM";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 57;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.Frozen = true;
            this.dataGridViewTextBoxColumn6.HeaderText = "From Godown Stock";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 129;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.Frozen = true;
            this.dataGridViewTextBoxColumn7.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 48;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.Frozen = true;
            this.dataGridViewTextBoxColumn8.HeaderText = "To Godown Stock";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 119;
            // 
            // grdGtoG
            // 
            this.grdGtoG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdGtoG.Location = new System.Drawing.Point(9, 206);
            this.grdGtoG.Name = "grdGtoG";
            this.grdGtoG.Size = new System.Drawing.Size(694, 129);
            this.grdGtoG.TabIndex = 309;
            // 
            // frmGdownToGdownShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 414);
            this.Controls.Add(this.grdGtoG);
            this.Controls.Add(this.txtFinishReceNo);
            this.Controls.Add(this.lblTotalVal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.optInProcess);
            this.Controls.Add(this.optApproved);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrinting);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.grdGodownToGodown);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboItemGroup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboToGodown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboFromGodown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Name = "frmGdownToGdownShift";
            this.Text = "Godown To Godown";
            this.Load += new System.EventHandler(this.frmGdownToGdownShift_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGdownToGdownShift_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdGodownToGodown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGtoG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.ComboBox cboFromGodown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboToGodown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboItemGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView grdGodownToGodown;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewLinkColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.Label lblTotalVal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton optInProcess;
        private System.Windows.Forms.RadioButton optApproved;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrinting;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.TextBox txtFinishReceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridView grdGtoG;
    }
}