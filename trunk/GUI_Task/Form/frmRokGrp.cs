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
    public partial class frmRokGrp : Form
    {
        int fcboDefaultValue = 0;
        public frmRokGrp()
        {
            InitializeComponent();
        }

        private void roker_Group_Wise_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            AtFormLoad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmRokGrp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private void AtFormLoad()
        {
            string lSQL = string.Empty;

            this.KeyPreview = true;

            //Main Group Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmMainGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboMainGrp, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboMainGrp.SelectedValue);
        }
    }
}
