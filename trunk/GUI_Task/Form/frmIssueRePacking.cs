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
    public partial class frmIssueRePacking : Form
    {
        int fcboDefaultValue = 0;
        public frmIssueRePacking()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIssueRePacking_Load(object sender, EventArgs e)
        {
            AtFormLoad();
        }

        private void AtFormLoad()
        {
            string lSQL = string.Empty;

            this.KeyPreview = true;

            ////Emp Code Combo Fill
            //lSQL = "SELECT employeeid, first_name +' '+ last_name AS EmpName FROM PR_Employee ";
            ////lSQL += " order by cgdDesc";

            //clsFillCombo.FillCombo(cboEmpCode, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            //fcboDefaultValue = Convert.ToInt16(cboEmpCode.SelectedValue);


            ////Gate cOMBO
            //lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmShift);
            //lSQL += " order by cgdDesc";

            //clsFillCombo.FillCombo(cboShift, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            //fcboDefaultValue = Convert.ToInt16(cboShift.SelectedValue);

            //Category Combo Fill
            lSQL = "SELECT DISTINCT 1,RIGHT(Itemcode,1) FROM Item ";
            //lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboCategory, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboCategory.SelectedValue);

            //Item group cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmItemGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGroup, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGroup.SelectedValue);

        }

        private void frmIssueRePacking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
