using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI_Task.StringFun01;
using GUI_Task.PrintVw6;
using GUI_Task.PrintReport;

namespace GUI_Task
{
    public partial class frmCashStatAll : Form
    {
        public frmCashStatAll()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cash_Statement_All_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mskGLCode_DoubleClick(object sender, EventArgs e)
        {
            LookUp_GL();
        }

        private void mskGLCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_GL();
            }
        }

        #region Lookup_GL
        private void LookUp_GL()
        {
            //SELECT Code, Name FROM Heads WHERE TYPE = 'A'
            frmLookUp sForm = new frmLookUp(
                    "Code",
                    "Name",
                    "Heads",
                    this.Text.ToString(),
                    1,
                    "Account Code, Account Name",
                    "16,40",
                    " T, T",
                    true,
                    "",
                    " Type='A'",
                    "TextBox"
                    );

            mskGLCode.Mask = "";
            mskGLCode.Text = string.Empty;
            mskGLCode.Mask = clsGVar.maskGLCode;

            sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
            sForm.ShowDialog();
            if (mskGLCode.Text != null)
            {

                if (mskGLCode.Text != null)
                {
                    if (mskGLCode.Text.ToString() == "" || mskGLCode.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (mskGLCode.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecordsGL();
                        //LoadSampleData();
                        //SumVoc();
                    }

                    //        if (blnFormLoad == true)
                    //        {
                    //            return;
                    //        }
                    //txtOrderNo.Text = txtPassDataVocID.Text.ToString();
                    //grdVoucher[pCol, pRow].Value = tmtext.Text.ToString();
                    //System.Windows.Forms.SendKeys.Send("{TAB}");
                }
                //        string lSQL = string.Empty;

                //if (msk_AccountID.Text.ToString() == "" || msk_AccountID.Text.ToString() == string.Empty)
                //{
                //    return;
                //}
                //msk_AccountID.Text = sForm.lupassControl.ToString();
                ////grdVoucher[pCol, pRow].Value = msk_AccountID.Text.ToString();
                //System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }
        #endregion

        //        //Item Group Combo Fill
        //        lSQL = "SELECT cgdCode AS GroupID, cgdDesc AS GroupName ";
        //        lSQL += " FROM CatDtl ";
        //        lSQL += " WHERE cgCode= " + Convert.ToString((int)Category.enmItemGroup);
        //        lSQL += " AND cgdCode IN (select GroupId From MainGroup ";
        //        lSQL += " Where MGroupId = " + cboMainGroup.SelectedValue.ToString() + ") ORDER BY cgdCode; ";

        private void PassData(object sender)
        {
            mskGLCode.Mask = "";
            mskGLCode.Text = ((TextBox)sender).Text;
            mskGLCode.Mask = clsGVar.maskGLCode;
            //mskCustomerCode.Text = ((MaskedTextBox)sender).Text;
            //mskCustomerCode.Mask = clsGVar.maskGLCode;



            //        clsFillCombo.FillCombo(cboItemGroup, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            //        fcboDefaultValue = Convert.ToInt16(cboItemGroup.SelectedValue);

        }




        //    }


        #region Populate GL Record

        //Populate Recordset 
        private void PopulateRecordsGL()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  

            tSQL = "SELECT Name ";
            tSQL += " from Heads ";
            tSQL += " where Code ='" + mskGLCode.Text.ToString() + "';";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Heads");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    lblName.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                        //btn_EnableDisable(true);
                    }
                    //LoadGridData();
                    //txtManualDoc.Enabled = false;
                }
            }

            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }
        #endregion

        private void mskAccCode_DoubleClick(object sender, EventArgs e)
        {
            LookUp_GL();
        }

        private void frmCashStatAll_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (optCashStat.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@Code,@FromDate,@ToDate";
                string plstType = "18,18,18"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = "1-2-01-01-0000" + "," + StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value);

                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrCashStat rpt1 = new CrCashStat();

                frmPrintVw6 rptCashStat = new frmPrintVw6(
                   fRptTitle,
                   StrF01.D2Str(this.dtpFromDate.Value),
                   StrF01.D2Str(this.dtpToDate.Value),
                   "sp_CashStat",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptCashStat.Show();
            }
            else if (optBankStat.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@Cash_Code,@Bank_Code";
                string plstType = "18,18"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = "" + "," + "1-2-01-01-0002";

                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrCashBankStat rpt1 = new CrCashBankStat();

                frmPrintVw6 rptCashBank = new frmPrintVw6(
                   fRptTitle,
                   StrF01.D2Str(this.dtpFromDate.Value),
                   StrF01.D2Str(this.dtpToDate.Value),
                   "sp_CashBank",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptCashBank.Show();
            }
        }
    }
}