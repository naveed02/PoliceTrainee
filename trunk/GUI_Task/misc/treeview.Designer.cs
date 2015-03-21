namespace GUI_Task
{
    partial class treeview
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
            System.Windows.Forms.TreeNode treeNode77 = new System.Windows.Forms.TreeNode("Credit Invoice");
            System.Windows.Forms.TreeNode treeNode78 = new System.Windows.Forms.TreeNode("Cash Invoice");
            System.Windows.Forms.TreeNode treeNode79 = new System.Windows.Forms.TreeNode("Cash Receipts");
            System.Windows.Forms.TreeNode treeNode80 = new System.Windows.Forms.TreeNode("Cash Payment");
            System.Windows.Forms.TreeNode treeNode81 = new System.Windows.Forms.TreeNode("Journel Voucher");
            System.Windows.Forms.TreeNode treeNode82 = new System.Windows.Forms.TreeNode("Bank Payments");
            System.Windows.Forms.TreeNode treeNode83 = new System.Windows.Forms.TreeNode("Bank Receipts");
            System.Windows.Forms.TreeNode treeNode84 = new System.Windows.Forms.TreeNode("Purchase Orders");
            System.Windows.Forms.TreeNode treeNode85 = new System.Windows.Forms.TreeNode("Local Purchase");
            System.Windows.Forms.TreeNode treeNode86 = new System.Windows.Forms.TreeNode("Credit Sale Return");
            System.Windows.Forms.TreeNode treeNode87 = new System.Windows.Forms.TreeNode("Cash Sale Return");
            System.Windows.Forms.TreeNode treeNode88 = new System.Windows.Forms.TreeNode("Purchase Return");
            System.Windows.Forms.TreeNode treeNode89 = new System.Windows.Forms.TreeNode("Import Inquiry");
            System.Windows.Forms.TreeNode treeNode90 = new System.Windows.Forms.TreeNode("Import Final Order");
            System.Windows.Forms.TreeNode treeNode91 = new System.Windows.Forms.TreeNode("Import Shipment");
            System.Windows.Forms.TreeNode treeNode92 = new System.Windows.Forms.TreeNode("Import GRN");
            System.Windows.Forms.TreeNode treeNode93 = new System.Windows.Forms.TreeNode("Account Ledger");
            System.Windows.Forms.TreeNode treeNode94 = new System.Windows.Forms.TreeNode("Item Transaction");
            System.Windows.Forms.TreeNode treeNode95 = new System.Windows.Forms.TreeNode("Exit");
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView2
            // 
            this.treeView2.BackColor = System.Drawing.SystemColors.Window;
            this.treeView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView2.CausesValidation = false;
            this.treeView2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.treeView2.Location = new System.Drawing.Point(1, 1);
            this.treeView2.Name = "treeView2";
            treeNode77.Name = "creditinvoice";
            treeNode77.Text = "Credit Invoice";
            treeNode78.Name = "Cash Invoice";
            treeNode78.Text = "Cash Invoice";
            treeNode79.Name = "Cash Receipts";
            treeNode79.Text = "Cash Receipts";
            treeNode80.Name = "Cash Payment";
            treeNode80.Text = "Cash Payment";
            treeNode81.Name = "Journel Voucher";
            treeNode81.Text = "Journel Voucher";
            treeNode82.Name = "Bank Payments";
            treeNode82.Text = "Bank Payments";
            treeNode83.Name = "Bank Receipts";
            treeNode83.Text = "Bank Receipts";
            treeNode84.Name = "Purchase Orders";
            treeNode84.Text = "Purchase Orders";
            treeNode85.Name = "Local Purchase";
            treeNode85.Text = "Local Purchase";
            treeNode86.Name = "Credit Sale Return";
            treeNode86.Text = "Credit Sale Return";
            treeNode87.Name = "Cash Sale Return";
            treeNode87.Text = "Cash Sale Return";
            treeNode88.Name = "Purchase Return";
            treeNode88.Text = "Purchase Return";
            treeNode89.Name = "Import Inquiry";
            treeNode89.Text = "Import Inquiry";
            treeNode90.Name = "Import Final Order";
            treeNode90.Text = "Import Final Order";
            treeNode91.Name = "Import Shipment";
            treeNode91.Text = "Import Shipment";
            treeNode92.Name = "Import GRN";
            treeNode92.Text = "Import GRN";
            treeNode93.Name = "Account Ledger";
            treeNode93.Text = "Account Ledger";
            treeNode94.Name = "Item Transaction";
            treeNode94.Text = "Item Transaction";
            treeNode95.Name = "Exit";
            treeNode95.Text = "Exit";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode77,
            treeNode78,
            treeNode79,
            treeNode80,
            treeNode81,
            treeNode82,
            treeNode83,
            treeNode84,
            treeNode85,
            treeNode86,
            treeNode87,
            treeNode88,
            treeNode89,
            treeNode90,
            treeNode91,
            treeNode92,
            treeNode93,
            treeNode94,
            treeNode95});
            this.treeView2.ShowNodeToolTips = true;
            this.treeView2.Size = new System.Drawing.Size(134, 333);
            this.treeView2.TabIndex = 26;
            this.treeView2.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView2_NodeMouseClick);
            // 
            // treeview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(136, 313);
            this.Controls.Add(this.treeView2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "treeview";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "         Options";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView2;
    }
}