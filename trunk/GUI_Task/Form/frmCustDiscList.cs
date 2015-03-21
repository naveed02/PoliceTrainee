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
    public partial class frmCustDiscList : Form
    {
        public frmCustDiscList()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customer_Discount_list_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void frmCustDiscList_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            this.Close();
        }
    }
}
