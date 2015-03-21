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
    public partial class frmPrivilages : Form
    {
        public frmPrivilages()
        {
            InitializeComponent();
        }

        private void form_Privilages_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPrivilages_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
