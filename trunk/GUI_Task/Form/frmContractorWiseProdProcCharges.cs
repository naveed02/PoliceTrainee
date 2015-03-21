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
    public partial class frmContractorWiseProdProcCharges : Form
    {
        int fcboDefaultValue = 0;
        public frmContractorWiseProdProcCharges()
        {
            InitializeComponent();
        }

        private void contractor_Wise_Production_Process_Charges_Load(object sender, EventArgs e)
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


            //Contractor Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmContractor);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboContractor, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboContractor.SelectedValue);

            //Status Combo Fill
            lSQL = "Select 1,'Running' Union Select 2,'Complete'";

            clsFillCombo.FillCombo(cboStatus, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboStatus.SelectedValue);

            //Prod Proc Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmProdProc);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboProdProc, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboProdProc.SelectedValue);

            //Item Group Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmItemGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGrp, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGrp.SelectedValue);
        }

        private void frmContractorWiseProdProcCharges_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
