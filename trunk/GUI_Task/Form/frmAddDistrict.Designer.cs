﻿namespace GUI_Task
{
    partial class frmAddDistrict
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddDistrict));
            this.textAlert = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSlblAlert = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStextTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSlblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStextStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSlblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStextUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.sSMaster = new System.Windows.Forms.StatusStrip();
            this.tSlblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.txtCourseID = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.optInActive = new System.Windows.Forms.RadioButton();
            this.optActive = new System.Windows.Forms.RadioButton();
            this.sSMaster.SuspendLayout();
            this.SuspendLayout();
            // 
            // textAlert
            // 
            this.textAlert.AutoSize = false;
            this.textAlert.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAlert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(94)))), ((int)(((byte)(129)))));
            this.textAlert.Name = "textAlert";
            this.textAlert.Size = new System.Drawing.Size(500, 17);
            this.textAlert.Text = "Ready";
            this.textAlert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tSlblAlert
            // 
            this.tSlblAlert.AutoSize = false;
            this.tSlblAlert.Name = "tSlblAlert";
            this.tSlblAlert.Size = new System.Drawing.Size(40, 17);
            this.tSlblAlert.Text = "Alert :";
            this.tSlblAlert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tStextTotal
            // 
            this.tStextTotal.AutoSize = false;
            this.tStextTotal.ForeColor = System.Drawing.Color.Teal;
            this.tStextTotal.Name = "tStextTotal";
            this.tStextTotal.Size = new System.Drawing.Size(50, 17);
            this.tStextTotal.Text = "0";
            this.tStextTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tSlblTotal
            // 
            this.tSlblTotal.Name = "tSlblTotal";
            this.tSlblTotal.Size = new System.Drawing.Size(40, 17);
            this.tSlblTotal.Text = "Total :";
            this.tSlblTotal.ToolTipText = "Total Number of Records already saved";
            // 
            // tStextStatus
            // 
            this.tStextStatus.AutoSize = false;
            this.tStextStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tStextStatus.ForeColor = System.Drawing.Color.Teal;
            this.tStextStatus.Name = "tStextStatus";
            this.tStextStatus.Size = new System.Drawing.Size(75, 17);
            this.tStextStatus.Text = "Ready";
            this.tStextStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tSlblStatus
            // 
            this.tSlblStatus.Name = "tSlblStatus";
            this.tSlblStatus.Size = new System.Drawing.Size(42, 17);
            this.tSlblStatus.Text = "Status:";
            this.tSlblStatus.ToolTipText = "Status of this form: Read = Ready to Accept ID, New = ID is new, Modify = Updatin" +
                "g/Modifying an existing ID\' s data";
            // 
            // tStextUser
            // 
            this.tStextUser.AutoSize = false;
            this.tStextUser.Name = "tStextUser";
            this.tStextUser.Size = new System.Drawing.Size(70, 17);
            this.tStextUser.Text = "User...";
            this.tStextUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sSMaster
            // 
            this.sSMaster.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSlblUser,
            this.tStextUser,
            this.tSlblStatus,
            this.tStextStatus,
            this.tSlblTotal,
            this.tStextTotal,
            this.tSlblAlert,
            this.textAlert});
            this.sSMaster.Location = new System.Drawing.Point(0, 171);
            this.sSMaster.Name = "sSMaster";
            this.sSMaster.Size = new System.Drawing.Size(405, 22);
            this.sSMaster.TabIndex = 638;
            this.sSMaster.Text = "statusStrip1";
            // 
            // tSlblUser
            // 
            this.tSlblUser.Name = "tSlblUser";
            this.tSlblUser.Size = new System.Drawing.Size(33, 17);
            this.tSlblUser.Text = "User:";
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(263, 124);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(109, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "[Esc] = &Exit";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(117, 124);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(109, 23);
            this.btnInsert.TabIndex = 4;
            this.btnInsert.Text = "&Add";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtCourseName
            // 
            this.txtCourseName.Location = new System.Drawing.Point(160, 51);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(223, 20);
            this.txtCourseName.TabIndex = 1;
            this.txtCourseName.DoubleClick += new System.EventHandler(this.txtCourseName_DoubleClick);
            this.txtCourseName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCourseName_KeyDown);
            // 
            // txtCourseID
            // 
            this.txtCourseID.Location = new System.Drawing.Point(160, 7);
            this.txtCourseID.Name = "txtCourseID";
            this.txtCourseID.Size = new System.Drawing.Size(223, 20);
            this.txtCourseID.TabIndex = 633;
            this.txtCourseID.Visible = false;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(28, 7);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(62, 15);
            this.lbl.TabIndex = 634;
            this.lbl.Text = "District ID";
            this.lbl.Visible = false;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(28, 53);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(84, 15);
            this.label36.TabIndex = 632;
            this.label36.Text = "District Name";
            // 
            // optInActive
            // 
            this.optInActive.AutoSize = true;
            this.optInActive.Location = new System.Drawing.Point(259, 90);
            this.optInActive.Name = "optInActive";
            this.optInActive.Size = new System.Drawing.Size(64, 17);
            this.optInActive.TabIndex = 3;
            this.optInActive.Text = "InActive";
            this.optInActive.UseVisualStyleBackColor = true;
            // 
            // optActive
            // 
            this.optActive.AutoSize = true;
            this.optActive.Checked = true;
            this.optActive.Location = new System.Drawing.Point(160, 91);
            this.optActive.Name = "optActive";
            this.optActive.Size = new System.Drawing.Size(55, 17);
            this.optActive.TabIndex = 2;
            this.optActive.TabStop = true;
            this.optActive.Text = "Active";
            this.optActive.UseVisualStyleBackColor = true;
            // 
            // frmAddDistrict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 193);
            this.Controls.Add(this.optInActive);
            this.Controls.Add(this.optActive);
            this.Controls.Add(this.sSMaster);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.txtCourseName);
            this.Controls.Add(this.txtCourseID);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.label36);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmAddDistrict";
            this.Text = "Add New District";
            this.Load += new System.EventHandler(this.frmAddDistrict_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAddDistrict_KeyDown);
            this.sSMaster.ResumeLayout(false);
            this.sSMaster.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel textAlert;
        private System.Windows.Forms.ToolStripStatusLabel tSlblAlert;
        private System.Windows.Forms.ToolStripStatusLabel tStextTotal;
        private System.Windows.Forms.ToolStripStatusLabel tSlblTotal;
        private System.Windows.Forms.ToolStripStatusLabel tStextStatus;
        private System.Windows.Forms.ToolStripStatusLabel tSlblStatus;
        private System.Windows.Forms.ToolStripStatusLabel tStextUser;
        private System.Windows.Forms.StatusStrip sSMaster;
        private System.Windows.Forms.ToolStripStatusLabel tSlblUser;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.TextBox txtCourseID;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.RadioButton optInActive;
        private System.Windows.Forms.RadioButton optActive;
    }
}