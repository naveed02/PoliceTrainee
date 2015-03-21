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
    public partial class frmRptGateInwardGRN : Form
    {
        int fcboDefaultValue = 0;
        public frmRptGateInwardGRN()
        {
            InitializeComponent();
        }

        private void gate_Inward_GRN_Report_Load(object sender, EventArgs e)
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
        }

        private void frmRptGateInwardGRN_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (optGateInward.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@ItemGroupID,@GodownId";
                string plstType = "18,18,8,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," +
                    this.cboItemGrp.SelectedValue.ToString() + "," +
                    this.cboGodown.SelectedValue.ToString();


                DataSet pDs = new DataSet();
                CrGIWDate rpt1 = new CrGIWDate();

                frmPrintVw6 rptGateInwardGRN = new frmPrintVw6(
                   fRptTitle,
                   StrF01.D2Str(this.dtpFromDate.Value),
                   StrF01.D2Str(this.dtpToDate.Value),
                   "sp_GIWTotal",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                rptGateInwardGRN.Show();
            }
            else if (optGRN.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@ItemGroupID,@GodownId";
                string plstType = "18,18,8,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," +
                    this.cboItemGrp.SelectedValue.ToString() + "," +
                    this.cboGodown.SelectedValue.ToString();


                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrGRNDate rpt1 = new CrGRNDate();

                frmPrintVw6 rptGateInwardGRN = new frmPrintVw6(
                   fRptTitle,
                   this.dtpFromDate.Value.ToString(),
                   this.dtpToDate.Value.ToString(),
                   "sp_GRNTotal",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                rptGateInwardGRN.Show();
            }
            else if (optGRNSumry.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@ItemGroupID,@GodownId";
                string plstType = "18,18,8,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," +
                    this.cboItemGrp.SelectedValue.ToString() + "," +
                    this.cboGodown.SelectedValue.ToString();


                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrGRNSmry rpt1 = new CrGRNSmry();

                frmPrintVw6 rptGRNSmry = new frmPrintVw6(
                   fRptTitle,
                   this.dtpFromDate.Value.ToString(),
                   this.dtpToDate.Value.ToString(),
                   "sp_GRNSmry",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                rptGRNSmry.Show();
            }
            else if (optGRNDiscSumry.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@ItemGroupID,@GodownId";
                string plstType = "18,18,8,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," +
                    this.cboItemGrp.SelectedValue.ToString() + "," +
                    this.cboGodown.SelectedValue.ToString();


                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrGRNDiscSmry rpt1 = new CrGRNDiscSmry();

                frmPrintVw6 rptGRNDiscSmry = new frmPrintVw6(
                   fRptTitle,
                   this.dtpFromDate.Value.ToString(),
                   this.dtpToDate.Value.ToString(),
                   "sp_GRNDiscSmry",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                rptGRNDiscSmry.Show();
            }
            else if (optGRNReturn.Checked == true)
            {

                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@ItemGroupID,@GodownId";
                string plstType = "18,18,8,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," +
                    this.cboItemGrp.SelectedValue.ToString() + "," +
                    this.cboGodown.SelectedValue.ToString();

                DataSet pDs = new DataSet();
                CrGRNRetDate rpt1 = new CrGRNRetDate();

                frmPrintVw6 rptGRNReturn = new frmPrintVw6(
                   fRptTitle,
                   this.dtpFromDate.Value.ToString(),
                   this.dtpToDate.Value.ToString(),
                   "sp_GRNRet",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                rptGRNReturn.Show();
            }
        }
    }
}