using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI_Task
{
    public partial class frmRptPendingOrd1 : Form
    {
        public frmRptPendingOrd1()
        {
            InitializeComponent();
        }

        private void pending_Orders_Report_1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptPendingOrd1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
