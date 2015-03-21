using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI_Task.Class;
using GUI_Task.StringFun01;
using GUI_Task.PrintReport;
using GUI_Task.PrintVw6;

namespace GUI_Task
{
    public partial class frmRptDelivery : Form
    {
        int fcboDefaultValue = 0;
        public frmRptDelivery()
        {
            InitializeComponent();
        }

        private void gate_Outward_Delivery_Report_Load(object sender, EventArgs e)
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

            //Item Group Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmItemGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGrp, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGrp.SelectedValue);

            //Category Combo Fill
            lSQL = "SELECT distinct 1, RIGHT (ItemCode,1) FROM Item";

            clsFillCombo.FillCombo(cboCategory, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboCategory.SelectedValue);
        
        }

        private void frmRptDelivery_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            string fRptTitle = this.Text;
            string plstField = "@FromDate,@ToDate,@ItemGroupID,@ItemCategory";
            string plstType = "18,18,8,18"; // {"8, 8, 8, 8, 8, 8"};
            string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                StrF01.D2Str(this.dtpToDate.Value) + "," +
                this.cboItemGrp.SelectedValue.ToString() + "," +
                this.cboCategory.SelectedValue.ToString();

            DataSet pDs = new DataSet();
            CrGOWDel rpt1 = new CrGOWDel();

            frmPrintVw6 rptGOWDel = new frmPrintVw6(
               fRptTitle,
               this.dtpFromDate.Value.ToString(),
               this.dtpToDate.Value.ToString(),
               "sp_GOW_Del",
               plstField,
               plstType,
               plstValue,
               pDs,
               rpt1,
               "SP"
               );

            rptGOWDel.Show();
        }
    }
}