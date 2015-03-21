using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI_Task.Class;
using GUI_Task.PrintVw6;
using GUI_Task.StringFun01;
using GUI_Task.PrintReport;

namespace GUI_Task
{
    public partial class frmProdPlan : Form
    {
        int fcboDefaultValue = 0;
        public frmProdPlan()
        {
            InitializeComponent();
        }

        private void production_Plan_Load(object sender, EventArgs e)
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

            //Item Group Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmItemGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGrp, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGrp.SelectedValue);

        }

        private void frmProdPlan_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (optWDO.Checked == true)
            {
                if (optAllRecordShow.Checked == true)
                {
                    string fRptTitle = this.Text;
                    string plstField = "@p_ItemGroupID,@FromDate,@ToDate";
                    string plstType = "8,18,18"; // {"8, 8, 8, 8, 8, 8"};
                    string plstValue = "1" + "," + StrF01.D2Str(this.dtpFromDate.Value) + "," +
                        StrF01.D2Str(this.dtpFromDate.Value);

                    //dsLedgerNew pDs = new dsLedgerNew();

                    DataSet pDs = new DataSet();
                    CrProdPlanAll rpt1 = new CrProdPlanAll();

                    frmPrintVw6 rptProdPlanAll = new frmPrintVw6(
                       fRptTitle,
                       StrF01.D2Str(this.dtpFromDate.Value),
                       StrF01.D2Str(this.dtpFromDate.Value),
                       "sp_Prod_Prn_All",
                       plstField,
                       plstType,
                       plstValue,
                       pDs,
                       rpt1,
                       "SP"
                       );

                    //rptLedger2.ShowDialog();
                    rptProdPlanAll.Show();
                }
                else if (optReqShow.Checked == true)
                {
                    string fRptTitle = this.Text;
                    string plstField = "@p_ItemGroupID,@FromDate,@ToDate";
                    string plstType = "8,18,18"; // {"8, 8, 8, 8, 8, 8"};
                    string plstValue = "1" + "," + StrF01.D2Str(this.dtpFromDate.Value) + "," +
                        StrF01.D2Str(this.dtpFromDate.Value);

                    //dsLedgerNew pDs = new dsLedgerNew();

                    DataSet pDs = new DataSet();
                    CrProdPlanAll rpt1 = new CrProdPlanAll();

                    frmPrintVw6 rptProdPlanReq = new frmPrintVw6(
                       fRptTitle,
                       StrF01.D2Str(this.dtpFromDate.Value),
                       StrF01.D2Str(this.dtpFromDate.Value),
                       "sp_Prod_Prn_Req",
                       plstField,
                       plstType,
                       plstValue,
                       pDs,
                       rpt1,
                       "SP"
                       );

                    //rptLedger2.ShowDialog();
                    rptProdPlanReq.Show();
                }
                else if (optForProd.Checked == true)
                {
                    string fRptTitle = this.Text;
                    string plstField = "@p_ItemGroupID,@FromDate,@ToDate";
                    string plstType = "8,18,18"; // {"8, 8, 8, 8, 8, 8"};
                    string plstValue = "1" + "," + StrF01.D2Str(this.dtpFromDate.Value) + "," +
                        StrF01.D2Str(this.dtpFromDate.Value);

                    //dsLedgerNew pDs = new dsLedgerNew();

                    DataSet pDs = new DataSet();
                    CrProdPlanAll rpt1 = new CrProdPlanAll();

                    frmPrintVw6 rptProdPlan = new frmPrintVw6(
                       fRptTitle,
                       StrF01.D2Str(this.dtpFromDate.Value),
                       StrF01.D2Str(this.dtpFromDate.Value),
                       "sp_Prod_Prn_Req",
                       plstField,
                       plstType,
                       plstValue,
                       pDs,
                       rpt1,
                       "SP"
                       );

                    //rptLedger2.ShowDialog();
                    rptProdPlan.Show();
                }
                else if (optSaleOrdDelStatus.Checked == true)
                {
                    string fRptTitle = this.Text;
                    string plstField = "@p_ItemGroupID,@FromDate,@ToDate";
                    string plstType = "8,18,18"; // {"8, 8, 8, 8, 8, 8"};
                    string plstValue = "1" + "," + StrF01.D2Str(this.dtpFromDate.Value) + "," +
                        StrF01.D2Str(this.dtpFromDate.Value);

                    //dsLedgerNew pDs = new dsLedgerNew();

                    DataSet pDs = new DataSet();
                    CrProdPlanAll rpt1 = new CrProdPlanAll();

                    frmPrintVw6 rptSaleOrdDelStatus = new frmPrintVw6(
                       fRptTitle,
                       StrF01.D2Str(this.dtpFromDate.Value),
                       StrF01.D2Str(this.dtpFromDate.Value),
                       "sp_SaleOrdDelStatus",
                       plstField,
                       plstType,
                       plstValue,
                       pDs,
                       rpt1,
                       "SP"
                       );

                    //rptLedger2.ShowDialog();
                    rptSaleOrdDelStatus.Show();
                }

            }
            else
            { 
                if (OptWOOrd.Checked == true)
                {
            if (optAllRecordShow.Checked == true)
                {
                    string fRptTitle = this.Text;
                    string plstField = "@p_ItemGroupID,@FromDate,@ToDate";
                    string plstType = "8,18,18"; // {"8, 8, 8, 8, 8, 8"};
                    string plstValue = "1" + "," + StrF01.D2Str(this.dtpFromDate.Value) + "," +
                        StrF01.D2Str(this.dtpFromDate.Value);

                    //dsLedgerNew pDs = new dsLedgerNew();

                    DataSet pDs = new DataSet();
                    CrProdPlanAllWOOrd rpt1 = new CrProdPlanAllWOOrd();

                    frmPrintVw6 rptAllRecordShow = new frmPrintVw6(
                       fRptTitle,
                       StrF01.D2Str(this.dtpFromDate.Value),
                       StrF01.D2Str(this.dtpFromDate.Value),
                       "sp_Prod_Prn_ALLWOOrd",
                       plstField,
                       plstType,
                       plstValue,
                       pDs,
                       rpt1,
                       "SP"
                       );

                    //rptLedger2.ShowDialog();
                    rptAllRecordShow.Show();
                }
            else if (optReqShow.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@p_ItemGroupID,@FromDate,@ToDate";
                string plstType = "8,18,18"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = "1" + "," + StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpFromDate.Value);

                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrProdPlanWOOrd rpt1 = new CrProdPlanWOOrd();

                frmPrintVw6 rptReqShow = new frmPrintVw6(
                   fRptTitle,
                   StrF01.D2Str(this.dtpFromDate.Value),
                   StrF01.D2Str(this.dtpFromDate.Value),
                   "sp_Prod_Prn_WOOrd",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptReqShow.Show();
            }
            else if (optForProd.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@p_ItemGroupID,@FromDate,@ToDate";
                string plstType = "8,18,18"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = "1" + "," + StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpFromDate.Value);

                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrProdPlanProd rpt1 = new CrProdPlanProd();

                frmPrintVw6 rptForProd = new frmPrintVw6(
                   fRptTitle,
                   StrF01.D2Str(this.dtpFromDate.Value),
                   StrF01.D2Str(this.dtpFromDate.Value),
                   "sp_Prod_Prn_WOOrd",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptForProd.Show();
            }
            else if (optSaleOrdDelStatus.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@p_ItemGroupID,@FromDate,@ToDate";
                string plstType = "8,18,18"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = "1" + "," + StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpFromDate.Value);

                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrProdPlanAll rpt1 = new CrProdPlanAll();

                frmPrintVw6 rptSaleOrdDelStatus = new frmPrintVw6(
                   fRptTitle,
                   StrF01.D2Str(this.dtpFromDate.Value),
                   StrF01.D2Str(this.dtpFromDate.Value),
                   "sp_SaleOrdDelStatus",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptSaleOrdDelStatus.Show();
            }
                }

            }
        }
    }
}