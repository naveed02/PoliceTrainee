
﻿namespace GUI_Task
{
    partial class frmItemRateChange
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpItemRateChange = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblItemRate = new System.Windows.Forms.Label();
            this.lblItemRateNumber = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.cboItemGroup = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPrinting = new System.Windows.Forms.Button();
            this.btnExitSave = new System.Windows.Forms.Button();
            this.btnGetItems = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.chkEdit = new System.Windows.Forms.CheckBox();
            this.ItmItemRateChange = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ItmItemRateChange)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 295;
            this.label2.Text = "Note";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(132, 58);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(365, 20);
            this.txtNote.TabIndex = 294;
            // 
            // label5
            // 
            this.label5.AllowDrop = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(12, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 17);
            this.label5.TabIndex = 293;
            this.label5.Text = "Item Group";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtpItemRateChange
            // 
            this.dtpItemRateChange.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpItemRateChange.Location = new System.Drawing.Point(375, 5);
            this.dtpItemRateChange.Name = "dtpItemRateChange";
            this.dtpItemRateChange.Size = new System.Drawing.Size(122, 21);
            this.dtpItemRateChange.TabIndex = 292;
            // 
            // lblDate
            // 
            this.lblDate.AllowDrop = true;
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDate.Location = new System.Drawing.Point(287, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(82, 17);
            this.lblDate.TabIndex = 291;
            this.lblDate.Text = " Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblItemRate
            // 
            this.lblItemRate.AllowDrop = true;
            this.lblItemRate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemRate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemRate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblItemRate.Location = new System.Drawing.Point(12, 9);
            this.lblItemRate.Name = "lblItemRate";
            this.lblItemRate.Size = new System.Drawing.Size(114, 17);
            this.lblItemRate.TabIndex = 290;
            this.lblItemRate.Text = "Item Rate #";
            this.lblItemRate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblItemRateNumber
            // 
            this.lblItemRateNumber.AllowDrop = true;
            this.lblItemRateNumber.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblItemRateNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemRateNumber.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemRateNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblItemRateNumber.Location = new System.Drawing.Point(132, 9);
            this.lblItemRateNumber.Name = "lblItemRateNumber";
            this.lblItemRateNumber.Size = new System.Drawing.Size(149, 17);
            this.lblItemRateNumber.TabIndex = 289;
            this.lblItemRateNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(352, 32);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(145, 21);
            this.cboCategory.TabIndex = 297;
            // 
            // cboItemGroup
            // 
            this.cboItemGroup.FormattingEnabled = true;
            this.cboItemGroup.Location = new System.Drawing.Point(132, 31);
            this.cboItemGroup.Name = "cboItemGroup";
            this.cboItemGroup.Size = new System.Drawing.Size(214, 21);
            this.cboItemGroup.TabIndex = 298;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(196, 323);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 22);
            this.btnExit.TabIndex = 308;
            this.btnExit.Text = "Esc=Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnPrinting
            // 
            this.btnPrinting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrinting.Location = new System.Drawing.Point(100, 323);
            this.btnPrinting.Name = "btnPrinting";
            this.btnPrinting.Size = new System.Drawing.Size(90, 22);
            this.btnPrinting.TabIndex = 309;
            this.btnPrinting.Text = "Printing";
            this.btnPrinting.UseVisualStyleBackColor = true;
            // 
            // btnExitSave
            // 
            this.btnExitSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitSave.Location = new System.Drawing.Point(4, 323);
            this.btnExitSave.Name = "btnExitSave";
            this.btnExitSave.Size = new System.Drawing.Size(90, 22);
            this.btnExitSave.TabIndex = 310;
            this.btnExitSave.Text = "Exit+Save";
            this.btnExitSave.UseVisualStyleBackColor = true;
            // 
            // btnGetItems
            // 
            this.btnGetItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetItems.Location = new System.Drawing.Point(503, 56);
            this.btnGetItems.Name = "btnGetItems";
            this.btnGetItems.Size = new System.Drawing.Size(90, 22);
            this.btnGetItems.TabIndex = 311;
            this.btnGetItems.Text = "Get Items";
            this.btnGetItems.UseVisualStyleBackColor = true;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Location = new System.Drawing.Point(503, 31);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(90, 22);
            this.btnAddNew.TabIndex = 312;
            this.btnAddNew.Text = "AddNew";
            this.btnAddNew.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(503, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(90, 22);
            this.btnHelp.TabIndex = 313;
            this.btnHelp.Text = "F1=Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // chkEdit
            // 
            this.chkEdit.AutoSize = true;
            this.chkEdit.Checked = true;
            this.chkEdit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEdit.Location = new System.Drawing.Point(514, 329);
            this.chkEdit.Name = "chkEdit";
            this.chkEdit.Size = new System.Drawing.Size(44, 17);
            this.chkEdit.TabIndex = 314;
            this.chkEdit.Text = "Edit";
            this.chkEdit.UseVisualStyleBackColor = true;
            // 
            // ItmItemRateChange
            // 
            this.ItmItemRateChange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItmItemRateChange.Location = new System.Drawing.Point(12, 84);
            this.ItmItemRateChange.Name = "ItmItemRateChange";
            this.ItmItemRateChange.Size = new System.Drawing.Size(581, 219);
            this.ItmItemRateChange.TabIndex = 315;
            // 
            // frmItemRateChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 347);
            this.Controls.Add(this.ItmItemRateChange);
            this.Controls.Add(this.chkEdit);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnGetItems);
            this.Controls.Add(this.btnExitSave);
            this.Controls.Add(this.btnPrinting);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cboItemGroup);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpItemRateChange);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblItemRate);
            this.Controls.Add(this.lblItemRateNumber);
            this.Name = "frmItemRateChange";
            this.Text = "Item Rate Change";
            this.Load += new System.EventHandler(this.frmItemrateChangeopt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ItmItemRateChange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpItemRateChange;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblItemRate;
        private System.Windows.Forms.Label lblItemRateNumber;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.ComboBox cboItemGroup;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrinting;
        private System.Windows.Forms.Button btnExitSave;
        private System.Windows.Forms.Button btnGetItems;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.CheckBox chkEdit;
        private System.Windows.Forms.DataGridView ItmItemRateChange;
    }
}
