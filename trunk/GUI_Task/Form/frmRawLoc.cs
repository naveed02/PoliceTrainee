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
using GUI_Task.PrintVw6;
using GUI_Task.PrintReport;

namespace GUI_Task
{
    public partial class frmRawLoc : Form
    {
        int fcboDefaultValue = 0;
        public frmRawLoc()
        {
            InitializeComponent();
        }

        private void raw_Local_Load(object sender, EventArgs e)
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

            //Godown Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmGodown);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboGodown, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboGodown.SelectedValue);

            //Category Combo Fill
            lSQL = "SELECT distinct 1, RIGHT(ItemCode,1) FROM Item";

            clsFillCombo.FillCombo(cboCategory, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboCategory.SelectedValue);
        }

        private void frmRawLoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (optDetail.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@ItemGroupID,@ItemCategory,@FromDate,@ToDate";
                string plstType = "8,18,18,18"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = this.cboItemGrp.SelectedValue + "," + "S" + "," + StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) ;


                DataSet pDs = new DataSet();
                CrRawLocal rpt1 = new CrRawLocal();

                frmPrintVw6 rptLedger2 = new frmPrintVw6(
                   fRptTitle,
                   StrF01.D2Str(this.dtpFromDate.Value),
                   StrF01.D2Str(this.dtpToDate.Value),
                   "sp_RawLocal",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptLedger2.Show();
             }
            else if (optdetailBag.Checked == true )
            {
                string fRptTitle = this.Text;
                string plstField = "@ItemGroupID,@ItemCategory,@FromDate,@ToDate";
                string plstType = "8,18,18,18"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = this.cboItemGrp.SelectedValue + "," + this.cboCategory.SelectedValue + "," + StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value);


                DataSet pDs = new DataSet();
                CrRawImp rpt1 = new CrRawImp();

                frmPrintVw6 rptLedger2 = new frmPrintVw6(
                   fRptTitle,
                   StrF01.D2Str(this.dtpFromDate.Value),
                   StrF01.D2Str(this.dtpToDate.Value),
                   "sp_RawImp",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                rptLedger2.Show();
            }

            else if (optSmry.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@ItemGroupID,@ItemCategory,@FromDate,@ToDate";
                string plstType = "8,18,18,18"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = this.cboItemGrp.SelectedValue + "," + this.cboCategory.SelectedValue + "," + StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value);


                DataSet pDs = new DataSet();
                CrRawLocalSmry rpt1 = new CrRawLocalSmry();

                frmPrintVw6 rptLedger2 = new frmPrintVw6(
                   fRptTitle,
                   StrF01.D2Str(this.dtpFromDate.Value),
                   StrF01.D2Str(this.dtpToDate.Value),
                   "sp_RawLocalSmry",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                rptLedger2.Show();

            }


           
        }

    }
}