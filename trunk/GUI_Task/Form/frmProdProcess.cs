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
    public partial class frmProdProcess : Form
    {
        int fcboDefaultValue = 0;
        public frmProdProcess()
        {
            InitializeComponent();
        }

        private void production_Process_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            AtFormLoad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AtFormLoad()
        {
            string lSQL = string.Empty;

            this.KeyPreview = true;

            //Status Combo Fill
            lSQL = "Select 1,'Running' Union Select 2,'Complete'";

            clsFillCombo.FillCombo(cboStatus, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboStatus.SelectedValue);
            
            //Godown Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmProdProc);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboProcess, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboProcess.SelectedValue);

        }
    }
}
