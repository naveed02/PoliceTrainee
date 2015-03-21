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
    public partial class frmRptPendingOrd2 : Form
    {
        public frmRptPendingOrd2()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_pending_Orders_Report_2_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void frmRptPendingOrd2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
