using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI_Task.temp3
{
    public partial class frmGroup : Form
    {
        public frmGroup()
        {
            InitializeComponent();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Group_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmGrpUser frm = new frmGrpUser();
            frm.Show();
        }
    }
}
