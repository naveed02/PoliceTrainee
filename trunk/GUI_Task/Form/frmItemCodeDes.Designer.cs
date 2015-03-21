
namespace GUI_Task
{
    partial class frmItemCodeDes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemCodeDes));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.btnDuplicateItems = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnNewCode = new System.Windows.Forms.Button();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.dtpCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.txtGLCode = new System.Windows.Forms.TextBox();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.txtUrduItemUnit = new System.Windows.Forms.TextBox();
            this.txtUrduItemName = new System.Windows.Forms.TextBox();
            this.txtMinLevel = new System.Windows.Forms.TextBox();
            this.txtMaxLevel = new System.Windows.Forms.TextBox();
            this.txtStockLevel = new System.Windows.Forms.TextBox();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.cboItemGroup = new System.Windows.Forms.ComboBox();
            this.lblGLCode = new System.Windows.Forms.Label();
            this.lblItemCode1 = new System.Windows.Forms.Label();
            this.lblItemName1 = new System.Windows.Forms.Label();
            this.lblItemUnit = new System.Windows.Forms.Label();
            this.lblMinLevel = new System.Windows.Forms.Label();
            this.lblMaxLevel = new System.Windows.Forms.Label();
            this.lblStockLevel = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.lblUrduItemName = new System.Windows.Forms.Label();
            this.lblUrduItemUnit = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUnselectAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnResetForm = new System.Windows.Forms.Button();
            this.sSMaster = new System.Windows.Forms.StatusStrip();
            this.tSlblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStextUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSlblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStextStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSlblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStextTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSlblAlert = new System.Windows.Forms.ToolStripStatusLabel();
            this.textAlert = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.sSMaster.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(518, 337);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.txtCategory);
            this.tabPage1.Controls.Add(this.txtItemName);
            this.tabPage1.Controls.Add(this.txtItemCode);
            this.tabPage1.Controls.Add(this.btnDuplicateItems);
            this.tabPage1.Controls.Add(this.btnAddNew);
            this.tabPage1.Controls.Add(this.btnReset);
            this.tabPage1.Controls.Add(this.btnHelp);
            this.tabPage1.Controls.Add(this.btnNewCode);
            this.tabPage1.Controls.Add(this.txtItemID);
            this.tabPage1.Controls.Add(this.dtpCreatedDate);
            this.tabPage1.Controls.Add(this.txtGLCode);
            this.tabPage1.Controls.Add(this.txtAccountName);
            this.tabPage1.Controls.Add(this.txtUrduItemUnit);
            this.tabPage1.Controls.Add(this.txtUrduItemName);
            this.tabPage1.Controls.Add(this.txtMinLevel);
            this.tabPage1.Controls.Add(this.txtMaxLevel);
            this.tabPage1.Controls.Add(this.txtStockLevel);
            this.tabPage1.Controls.Add(this.cboUnit);
            this.tabPage1.Controls.Add(this.cboItemGroup);
            this.tabPage1.Controls.Add(this.lblGLCode);
            this.tabPage1.Controls.Add(this.lblItemCode1);
            this.tabPage1.Controls.Add(this.lblItemName1);
            this.tabPage1.Controls.Add(this.lblItemUnit);
            this.tabPage1.Controls.Add(this.lblMinLevel);
            this.tabPage1.Controls.Add(this.lblMaxLevel);
            this.tabPage1.Controls.Add(this.lblStockLevel);
            this.tabPage1.Controls.Add(this.lblCreatedDate);
            this.tabPage1.Controls.Add(this.lblUrduItemName);
            this.tabPage1.Controls.Add(this.lblUrduItemUnit);
            this.tabPage1.Controls.Add(this.lblGroup);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(510, 311);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Item Information";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtItemName.Location = new System.Drawing.Point(115, 59);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(280, 20);
            this.txtItemName.TabIndex = 7;
            this.txtItemName.Text = "Item Name";
            // 
            // txtItemCode
            // 
            this.txtItemCode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtItemCode.Location = new System.Drawing.Point(115, 33);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(123, 20);
            this.txtItemCode.TabIndex = 4;
            this.txtItemCode.Text = "Item Code";
            // 
            // btnDuplicateItems
            // 
            this.btnDuplicateItems.Enabled = false;
            this.btnDuplicateItems.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDuplicateItems.Location = new System.Drawing.Point(305, 85);
            this.btnDuplicateItems.Name = "btnDuplicateItems";
            this.btnDuplicateItems.Size = new System.Drawing.Size(143, 22);
            this.btnDuplicateItems.TabIndex = 305;
            this.btnDuplicateItems.Text = "Duplicat Items A/B/C";
            this.btnDuplicateItems.UseVisualStyleBackColor = true;
            this.btnDuplicateItems.Click += new System.EventHandler(this.btnDuplicateItems_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Location = new System.Drawing.Point(401, 8);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(90, 22);
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.Text = "Add New ";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(401, 59);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(90, 22);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(301, 8);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(94, 22);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.Text = "F1=Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnNewCode
            // 
            this.btnNewCode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCode.Location = new System.Drawing.Point(401, 33);
            this.btnNewCode.Name = "btnNewCode";
            this.btnNewCode.Size = new System.Drawing.Size(90, 22);
            this.btnNewCode.TabIndex = 301;
            this.btnNewCode.Text = "New Code";
            this.btnNewCode.UseVisualStyleBackColor = true;
            this.btnNewCode.Click += new System.EventHandler(this.btnNewCode_Click);
            // 
            // txtItemID
            // 
            this.txtItemID.Location = new System.Drawing.Point(288, 33);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(107, 20);
            this.txtItemID.TabIndex = 5;
            this.txtItemID.DoubleClick += new System.EventHandler(this.txtItemID_DoubleClick);
            this.txtItemID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemID_KeyDown);
            // 
            // dtpCreatedDate
            // 
            this.dtpCreatedDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCreatedDate.Location = new System.Drawing.Point(115, 192);
            this.dtpCreatedDate.Name = "dtpCreatedDate";
            this.dtpCreatedDate.Size = new System.Drawing.Size(131, 21);
            this.dtpCreatedDate.TabIndex = 12;
            // 
            // txtGLCode
            // 
            this.txtGLCode.Location = new System.Drawing.Point(115, 275);
            this.txtGLCode.Name = "txtGLCode";
            this.txtGLCode.Size = new System.Drawing.Size(113, 20);
            this.txtGLCode.TabIndex = 15;
            this.txtGLCode.DoubleClick += new System.EventHandler(this.txtGLCode_DoubleClick);
            this.txtGLCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGLCode_KeyDown);
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(234, 275);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(270, 20);
            this.txtAccountName.TabIndex = 16;
            // 
            // txtUrduItemUnit
            // 
            this.txtUrduItemUnit.Location = new System.Drawing.Point(115, 248);
            this.txtUrduItemUnit.Name = "txtUrduItemUnit";
            this.txtUrduItemUnit.Size = new System.Drawing.Size(180, 20);
            this.txtUrduItemUnit.TabIndex = 14;
            // 
            // txtUrduItemName
            // 
            this.txtUrduItemName.Location = new System.Drawing.Point(115, 220);
            this.txtUrduItemName.Name = "txtUrduItemName";
            this.txtUrduItemName.Size = new System.Drawing.Size(180, 20);
            this.txtUrduItemName.TabIndex = 13;
            // 
            // txtMinLevel
            // 
            this.txtMinLevel.Location = new System.Drawing.Point(115, 111);
            this.txtMinLevel.Name = "txtMinLevel";
            this.txtMinLevel.Size = new System.Drawing.Size(131, 20);
            this.txtMinLevel.TabIndex = 9;
            // 
            // txtMaxLevel
            // 
            this.txtMaxLevel.Location = new System.Drawing.Point(115, 140);
            this.txtMaxLevel.Name = "txtMaxLevel";
            this.txtMaxLevel.Size = new System.Drawing.Size(131, 20);
            this.txtMaxLevel.TabIndex = 10;
            // 
            // txtStockLevel
            // 
            this.txtStockLevel.Location = new System.Drawing.Point(115, 166);
            this.txtStockLevel.Name = "txtStockLevel";
            this.txtStockLevel.Size = new System.Drawing.Size(131, 20);
            this.txtStockLevel.TabIndex = 11;
            // 
            // cboUnit
            // 
            this.cboUnit.BackColor = System.Drawing.SystemColors.Window;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(115, 84);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(180, 21);
            this.cboUnit.TabIndex = 8;
            // 
            // cboItemGroup
            // 
            this.cboItemGroup.BackColor = System.Drawing.SystemColors.Window;
            this.cboItemGroup.FormattingEnabled = true;
            this.cboItemGroup.Location = new System.Drawing.Point(115, 6);
            this.cboItemGroup.Name = "cboItemGroup";
            this.cboItemGroup.Size = new System.Drawing.Size(180, 21);
            this.cboItemGroup.TabIndex = 1;
            // 
            // lblGLCode
            // 
            this.lblGLCode.AllowDrop = true;
            this.lblGLCode.BackColor = System.Drawing.SystemColors.Control;
            this.lblGLCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGLCode.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGLCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGLCode.Location = new System.Drawing.Point(6, 278);
            this.lblGLCode.Name = "lblGLCode";
            this.lblGLCode.Size = new System.Drawing.Size(103, 17);
            this.lblGLCode.TabIndex = 75;
            this.lblGLCode.Text = "GL Code";
            this.lblGLCode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblItemCode1
            // 
            this.lblItemCode1.AllowDrop = true;
            this.lblItemCode1.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblItemCode1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemCode1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCode1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblItemCode1.Location = new System.Drawing.Point(6, 35);
            this.lblItemCode1.Name = "lblItemCode1";
            this.lblItemCode1.Size = new System.Drawing.Size(103, 17);
            this.lblItemCode1.TabIndex = 74;
            this.lblItemCode1.Text = "Item Code  ";
            this.lblItemCode1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblItemName1
            // 
            this.lblItemName1.AllowDrop = true;
            this.lblItemName1.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblItemName1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemName1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblItemName1.Location = new System.Drawing.Point(6, 62);
            this.lblItemName1.Name = "lblItemName1";
            this.lblItemName1.Size = new System.Drawing.Size(103, 17);
            this.lblItemName1.TabIndex = 73;
            this.lblItemName1.Text = "Item Name";
            this.lblItemName1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblItemUnit
            // 
            this.lblItemUnit.AllowDrop = true;
            this.lblItemUnit.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblItemUnit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemUnit.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblItemUnit.Location = new System.Drawing.Point(6, 88);
            this.lblItemUnit.Name = "lblItemUnit";
            this.lblItemUnit.Size = new System.Drawing.Size(103, 17);
            this.lblItemUnit.TabIndex = 72;
            this.lblItemUnit.Text = "Item Unit";
            this.lblItemUnit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMinLevel
            // 
            this.lblMinLevel.AllowDrop = true;
            this.lblMinLevel.BackColor = System.Drawing.SystemColors.Control;
            this.lblMinLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMinLevel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinLevel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMinLevel.Location = new System.Drawing.Point(6, 116);
            this.lblMinLevel.Name = "lblMinLevel";
            this.lblMinLevel.Size = new System.Drawing.Size(103, 17);
            this.lblMinLevel.TabIndex = 71;
            this.lblMinLevel.Text = "Min. Level";
            this.lblMinLevel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMaxLevel
            // 
            this.lblMaxLevel.AllowDrop = true;
            this.lblMaxLevel.BackColor = System.Drawing.SystemColors.Control;
            this.lblMaxLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMaxLevel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxLevel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaxLevel.Location = new System.Drawing.Point(6, 143);
            this.lblMaxLevel.Name = "lblMaxLevel";
            this.lblMaxLevel.Size = new System.Drawing.Size(103, 17);
            this.lblMaxLevel.TabIndex = 70;
            this.lblMaxLevel.Text = "Max. Level";
            this.lblMaxLevel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStockLevel
            // 
            this.lblStockLevel.AllowDrop = true;
            this.lblStockLevel.BackColor = System.Drawing.SystemColors.Control;
            this.lblStockLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStockLevel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockLevel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStockLevel.Location = new System.Drawing.Point(6, 169);
            this.lblStockLevel.Name = "lblStockLevel";
            this.lblStockLevel.Size = new System.Drawing.Size(103, 17);
            this.lblStockLevel.TabIndex = 69;
            this.lblStockLevel.Text = "Stock Level";
            this.lblStockLevel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AllowDrop = true;
            this.lblCreatedDate.BackColor = System.Drawing.SystemColors.Control;
            this.lblCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCreatedDate.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreatedDate.Location = new System.Drawing.Point(6, 196);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(103, 17);
            this.lblCreatedDate.TabIndex = 68;
            this.lblCreatedDate.Text = "Created Date";
            this.lblCreatedDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUrduItemName
            // 
            this.lblUrduItemName.AllowDrop = true;
            this.lblUrduItemName.BackColor = System.Drawing.SystemColors.Control;
            this.lblUrduItemName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUrduItemName.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUrduItemName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUrduItemName.Location = new System.Drawing.Point(6, 223);
            this.lblUrduItemName.Name = "lblUrduItemName";
            this.lblUrduItemName.Size = new System.Drawing.Size(103, 17);
            this.lblUrduItemName.TabIndex = 67;
            this.lblUrduItemName.Text = "Urdu Item Name";
            this.lblUrduItemName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUrduItemUnit
            // 
            this.lblUrduItemUnit.AllowDrop = true;
            this.lblUrduItemUnit.BackColor = System.Drawing.SystemColors.Control;
            this.lblUrduItemUnit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUrduItemUnit.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUrduItemUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUrduItemUnit.Location = new System.Drawing.Point(6, 251);
            this.lblUrduItemUnit.Name = "lblUrduItemUnit";
            this.lblUrduItemUnit.Size = new System.Drawing.Size(103, 17);
            this.lblUrduItemUnit.TabIndex = 66;
            this.lblUrduItemUnit.Text = "Urdu Item Unit";
            this.lblUrduItemUnit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblGroup
            // 
            this.lblGroup.AllowDrop = true;
            this.lblGroup.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGroup.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup.Location = new System.Drawing.Point(6, 8);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(103, 17);
            this.lblGroup.TabIndex = 65;
            this.lblGroup.Text = "Group";
            this.lblGroup.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(352, 383);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(67, 22);
            this.btnDelete.TabIndex = 306;
            this.btnDelete.Text = "Delete ";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(454, 355);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(66, 22);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "Esc=Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(304, 355);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 22);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnselectAll.Location = new System.Drawing.Point(205, 355);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(93, 22);
            this.btnUnselectAll.TabIndex = 310;
            this.btnUnselectAll.Text = "UnSelect All";
            this.btnUnselectAll.UseVisualStyleBackColor = true;
            this.btnUnselectAll.Visible = false;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.Location = new System.Drawing.Point(121, 355);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(81, 22);
            this.btnSelectAll.TabIndex = 311;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Visible = false;
            // 
            // btnResetForm
            // 
            this.btnResetForm.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetForm.Location = new System.Drawing.Point(2, 355);
            this.btnResetForm.Name = "btnResetForm";
            this.btnResetForm.Size = new System.Drawing.Size(113, 22);
            this.btnResetForm.TabIndex = 312;
            this.btnResetForm.Text = "Reset Form";
            this.btnResetForm.UseVisualStyleBackColor = true;
            this.btnResetForm.Visible = false;
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
            this.sSMaster.Location = new System.Drawing.Point(0, 409);
            this.sSMaster.Name = "sSMaster";
            this.sSMaster.Size = new System.Drawing.Size(546, 22);
            this.sSMaster.TabIndex = 611;
            this.sSMaster.Text = "statusStrip1";
            // 
            // tSlblUser
            // 
            this.tSlblUser.Name = "tSlblUser";
            this.tSlblUser.Size = new System.Drawing.Size(33, 17);
            this.tSlblUser.Text = "User:";
            // 
            // tStextUser
            // 
            this.tStextUser.AutoSize = false;
            this.tStextUser.Name = "tStextUser";
            this.tStextUser.Size = new System.Drawing.Size(70, 17);
            this.tStextUser.Text = "User...";
            this.tStextUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tSlblStatus
            // 
            this.tSlblStatus.Name = "tSlblStatus";
            this.tSlblStatus.Size = new System.Drawing.Size(42, 17);
            this.tSlblStatus.Text = "Status:";
            this.tSlblStatus.ToolTipText = "Status of this form: Read = Ready to Accept ID, New = ID is new, Modify = Updatin" +
                "g/Modifying an existing ID\' s data";
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
            // tSlblTotal
            // 
            this.tSlblTotal.Name = "tSlblTotal";
            this.tSlblTotal.Size = new System.Drawing.Size(40, 17);
            this.tSlblTotal.Text = "Total :";
            this.tSlblTotal.ToolTipText = "Total Number of Records already saved";
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
            // tSlblAlert
            // 
            this.tSlblAlert.AutoSize = false;
            this.tSlblAlert.Name = "tSlblAlert";
            this.tSlblAlert.Size = new System.Drawing.Size(40, 17);
            this.tSlblAlert.Text = "Alert :";
            this.tSlblAlert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(246, 34);
            this.txtCategory.MaxLength = 1;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(36, 20);
            this.txtCategory.TabIndex = 306;
            // 
            // frmItemCodeDes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 431);
            this.Controls.Add(this.sSMaster);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUnselectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnResetForm);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmItemCodeDes";
            this.Text = "Item Code Description";
            this.Load += new System.EventHandler(this.frmItemCodeDes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmItemCodeDes_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.sSMaster.ResumeLayout(false);
            this.sSMaster.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblGLCode;
        private System.Windows.Forms.Label lblItemCode1;
        private System.Windows.Forms.Label lblItemName1;
        private System.Windows.Forms.Label lblItemUnit;
        private System.Windows.Forms.Label lblMinLevel;
        private System.Windows.Forms.Label lblMaxLevel;
        private System.Windows.Forms.Label lblStockLevel;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.Label lblUrduItemName;
        private System.Windows.Forms.Label lblUrduItemUnit;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.ComboBox cboItemGroup;
        private System.Windows.Forms.TextBox txtGLCode;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.TextBox txtUrduItemUnit;
        private System.Windows.Forms.TextBox txtUrduItemName;
        private System.Windows.Forms.TextBox txtMinLevel;
        private System.Windows.Forms.TextBox txtMaxLevel;
        private System.Windows.Forms.TextBox txtStockLevel;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.DateTimePicker dtpCreatedDate;
        private System.Windows.Forms.Button btnDuplicateItems;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnNewCode;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUnselectAll;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnResetForm;
        private System.Windows.Forms.StatusStrip sSMaster;
        private System.Windows.Forms.ToolStripStatusLabel tSlblUser;
        private System.Windows.Forms.ToolStripStatusLabel tStextUser;
        private System.Windows.Forms.ToolStripStatusLabel tSlblStatus;
        private System.Windows.Forms.ToolStripStatusLabel tStextStatus;
        private System.Windows.Forms.ToolStripStatusLabel tSlblTotal;
        private System.Windows.Forms.ToolStripStatusLabel tStextTotal;
        private System.Windows.Forms.ToolStripStatusLabel tSlblAlert;
        private System.Windows.Forms.ToolStripStatusLabel textAlert;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.TextBox txtCategory;
    }
}
