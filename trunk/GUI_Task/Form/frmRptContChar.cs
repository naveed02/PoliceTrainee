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
    public partial class frmContractorCharges : Form
    {
        int fcboDefaultValue = 0;
        public frmContractorCharges()
        {
            InitializeComponent();
        }

        private void contractor_Charges_Load(object sender, EventArgs e)
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

            clsFillCombo.FillCombo(cboCont, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboCont.SelectedValue);
            
            //Category Combo Fill
            lSQL = "SELECT distinct 1, RIGHT(ItemCode,1) FROM Item";

            clsFillCombo.FillCombo(cboItemCat, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemCat.SelectedValue);

            //Charges Type Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmCharges);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboCharType, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboCharType.SelectedValue);
        }

        private void frmContractorCharges_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (optDet.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@ContractID,@ItemCategory,@ChargesType";
                string plstType = "18,18,8,18,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," +
                    this.cboCont.SelectedValue.ToString() + "," +
                    this.cboItemCat.SelectedValue.ToString() + "," +
                    this.cboCharType.SelectedValue.ToString();

                //this.mskStatus.Text;

                DataSet pDs = new DataSet();
                CrContCharges rpt1 = new CrContCharges();

                frmPrintVw6 rptContCharges = new frmPrintVw6(
                   fRptTitle,
                   this.dtpFromDate.Value.ToString(),
                   this.dtpToDate.Value.ToString(),
                   "sp_Cont_Charges",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptContCharges.Show();
            }
            else if (optSizeWise.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@ContractID,@ItemCategory,@ChargesType";
                string plstType = "18,18,8,18,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," +
                    this.cboCont.SelectedValue.ToString() + "," +
                    this.cboItemCat.SelectedValue.ToString() + "," +
                    this.cboCharType.SelectedValue.ToString();

                //this.mskStatus.Text;

                DataSet pDs = new DataSet();
                CrContChargesSize rpt1 = new CrContChargesSize();

                frmPrintVw6 rptContChargesSize = new frmPrintVw6(
                   fRptTitle,
                   this.dtpFromDate.Value.ToString(),
                   this.dtpToDate.Value.ToString(),
                   "sp_Cont_Charges",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptContChargesSize.Show();
            }
            else if (optArticleWise.Checked == true)
            {

                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@ContractID,@ItemCategory,@ChargesType";
                string plstType = "18,18,8,18,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," +
                    this.cboCont.SelectedValue.ToString() + "," +
                    this.cboItemCat.SelectedValue.ToString() + "," +
                    this.cboCharType.SelectedValue.ToString();

                //this.mskStatus.Text;


                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrContChargesItem rpt1 = new CrContChargesItem();

                frmPrintVw6 rptContChargesItem = new frmPrintVw6(
                   fRptTitle,
                   this.dtpFromDate.Value.ToString(),
                   this.dtpToDate.Value.ToString(),
                   "sp_Cont_Charges",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptContChargesItem.Show();
            }
            else if (optCharSummary.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@ContractID,@ItemCategory,@ChargesType";
                string plstType = "18,18,8,18,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," +
                    this.cboCont.SelectedValue.ToString() + "," +
                    this.cboItemCat.SelectedValue.ToString() + "," +
                    this.cboCharType.SelectedValue.ToString();

                //this.mskStatus.Text;


                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrContChargesSmry rpt1 = new CrContChargesSmry();

                frmPrintVw6 rptContCharSmry = new frmPrintVw6(
                   fRptTitle,
                   this.dtpFromDate.Value.ToString(),
                   this.dtpToDate.Value.ToString(),
                   "sp_Cont_Charges",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptContCharSmry.Show();
            }
            else if (optClaimCharSummary.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@ContractID,@ItemCategory,@ChargesType";
                string plstType = "18,18,8,18,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," +
                    this.cboCont.SelectedValue.ToString() + "," +
                    this.cboItemCat.SelectedValue.ToString() + "," +
                    this.cboCharType.SelectedValue.ToString();
                //this.mskStatus.Text;


                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrClaimContSmry rpt1 = new CrClaimContSmry();

                frmPrintVw6 rptClaimContSmry = new frmPrintVw6(
                   fRptTitle,
                   this.dtpFromDate.Value.ToString(),
                   this.dtpToDate.Value.ToString(),
                   "sp_Cont_Claim",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptClaimContSmry.Show();
            }
            else if (optProd.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@ContractID,@ItemCategory,@ChargesType";
                string plstType = "18,18,8,18,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," +
                    this.cboCont.SelectedValue.ToString() + "," +
                    this.cboItemCat.SelectedValue.ToString() + "," +
                    this.cboCharType.SelectedValue.ToString();
                //this.mskStatus.Text;

                DataSet pDs = new DataSet();
                CrContProd rpt1 = new CrContProd();

                frmPrintVw6 rptContProd = new frmPrintVw6(
                   fRptTitle,
                   this.dtpFromDate.Value.ToString(),
                   this.dtpToDate.Value.ToString(),
                   "sp_ContProd",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptContProd.Show();
            }
            else if (optProdSummary.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@ContractID,@ItemCategory,@ChargesType";
                string plstType = "18,18,8,18,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," +
                    this.cboCont.SelectedValue.ToString() + "," +
                    this.cboItemCat.SelectedValue.ToString() + "," +
                    this.cboCharType.SelectedValue.ToString();
                //this.mskStatus.Text;


                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrContProdSmry rpt1 = new CrContProdSmry();

                frmPrintVw6 rptContProdSmry = new frmPrintVw6(
                   fRptTitle,
                   this.dtpFromDate.Value.ToString(),
                   this.dtpToDate.Value.ToString(),
                   "sp_ContProdSmry",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptContProdSmry.Show();
            }
            else if (optProdSummaryCE.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@ContractID,@ItemCategory,@ChargesType";
                string plstType = "18,18,8,18,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," +
                    this.cboCont.SelectedValue.ToString() + "," +
                    this.cboItemCat.SelectedValue.ToString() + "," +
                    this.cboCharType.SelectedValue.ToString();
                //this.mskStatus.Text;

                DataSet pDs = new DataSet();
                CrContProdSmryCE rpt1 = new CrContProdSmryCE();

                frmPrintVw6 rptContProdSmryCE = new frmPrintVw6(
                   fRptTitle,
                   this.dtpFromDate.Value.ToString(),
                   this.dtpToDate.Value.ToString(),
                   "sp_ContProdSmryCE",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptContProdSmryCE.Show();
            }
            else if (optClaimCashSummary.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@ContractID";
                string plstType = "18,18,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," +
                    this.cboCont.SelectedValue.ToString();
                //this.mskStatus.Text;


                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrClaimContSmryCash rpt1 = new CrClaimContSmryCash();

                frmPrintVw6 rptClaimContSmryCash = new frmPrintVw6(
                   fRptTitle,
                   this.dtpFromDate.Value.ToString(),
                   this.dtpToDate.Value.ToString(),
                   "sp_Cont_ClaimCash",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptClaimContSmryCash.Show();
            }
            else if (optArticleWiseCashPaid.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@ContractID";
                string plstType = "18,18,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," +
                    this.cboCont.SelectedValue.ToString();
                //this.mskStatus.Text;


                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrContChargesItemCash rpt1 = new CrContChargesItemCash();

                frmPrintVw6 rptChargesItemCash = new frmPrintVw6(
                   fRptTitle,
                   this.dtpFromDate.Value.ToString(),
                   this.dtpToDate.Value.ToString(),
                   "sp_Cont_ChargesCash",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptChargesItemCash.Show();
            }
        }
    }
}
