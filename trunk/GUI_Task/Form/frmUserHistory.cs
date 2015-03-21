using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI_Task.Class;

namespace GUI_Task
{
    public partial class frmUserHistory : Form
    {
        int fcboDefaultValue = 0;
        public frmUserHistory()
        {
            InitializeComponent();
        }

        private void user_Login_History_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            AtFormLoad();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AtFormLoad()
        {
            string lSQL = string.Empty;

            this.KeyPreview = true;


            //User Combo Fill
            //lSQL = "SELECT pe.first_name + ' ' + pe.last_name AS [UserName] FROM PR_Employee pe";
            //lSQL += " order by cgdDesc";

            //clsFillCombo.FillCombo(cboUser, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            //fcboDefaultValue = Convert.ToInt16(cboUser.SelectedValue);

        }
    }
}
