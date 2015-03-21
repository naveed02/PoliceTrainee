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
    public partial class frmOrderStatus : Form
    {
        int fcboDefaultValue = 0;
        public frmOrderStatus()
        {
            InitializeComponent();
        }

        private void order_Delivery_Invoice_Status_Load(object sender, EventArgs e)
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

            //Status Combo Fill
            lSQL = "Select 1,'Running' Union Select 2,'Complete'";

            clsFillCombo.FillCombo(cboStatus, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboStatus.SelectedValue);
        }

        private void frmOrderStatus_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void mskStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                LookUp_GL();
        }

        private void mskStatus_DoubleClick(object sender, EventArgs e)
        {
            LookUp_GL();
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

            mskStatus.Mask = "";
            mskStatus.Text = string.Empty;
            mskStatus.Mask = clsGVar.maskGLCode;

            sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
            sForm.ShowDialog();
            if (mskStatus.Text != null)
            {

                if (mskStatus.Text != null)
                {
                    if (mskStatus.Text.ToString() == "" || mskStatus.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (mskStatus.Text.ToString().Trim().Length > 0)
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
        private void PassData(object sender)
        {
            mskStatus.Mask = "";
            mskStatus.Text = ((TextBox)sender).Text;
            mskStatus.Mask = clsGVar.maskGLCode;
            //mskCustomerCode.Text = ((MaskedTextBox)sender).Text;
            //mskCustomerCode.Mask = clsGVar.maskGLCode;



            //        clsFillCombo.FillCombo(cboItemGroup, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            //        fcboDefaultValue = Convert.ToInt16(cboItemGroup.SelectedValue);

        }

        #region Populate GL Record
        private void PopulateRecordsGL()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  

            tSQL = "SELECT Name ";
            tSQL += " from Heads ";
            tSQL += " where Code ='" + mskStatus.Text.ToString() + "';";

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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (optRemainOrd.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@Status,@FromDate,@ToDate";
                string plstType = "18,18,18"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = this.cboStatus.SelectedValue.ToString() + "," +
                    StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value);
                    //this.mskStatus.Text;


                DataSet pDs = new DataSet();
                CrOrdDelStatus rpt1 = new CrOrdDelStatus();

                frmPrintVw6 rptOrdDelStatus = new frmPrintVw6(
                   fRptTitle,
                   this.dtpFromDate.Value.ToString(),
                   this.dtpToDate.Value.ToString(),
                   "sp_OrdDel",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptOrdDelStatus.Show();
            }
            else if (optOrdDelivery.Checked == true)
            {

                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@CustCode";
                string plstType = "18,18,18"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," +
                    this.mskStatus.Text;
                //this.mskStatus.Text;


                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrDo_Smry rpt1 = new CrDo_Smry();

                frmPrintVw6 rptDo_Smry = new frmPrintVw6(
                   fRptTitle,
                   this.dtpFromDate.Value.ToString(),
                   this.dtpToDate.Value.ToString(),
                   "sp_DoSmry",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptDo_Smry.Show();
            }
            else if (optDeliveryOrd.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@CustCode,@Status,@FromDate,@ToDate";
                string plstType = "18,18,18,18"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = this.cboStatus.SelectedValue.ToString() + "," +
                    this.mskStatus.Text + "," +
                    StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value);
                    
                //this.mskStatus.Text;


                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrOrd_PrnRemCust rpt1 = new CrOrd_PrnRemCust();

                frmPrintVw6 rptOrd_PrnRemCust = new frmPrintVw6(
                   fRptTitle,
                   this.dtpFromDate.Value.ToString(),
                   this.dtpToDate.Value.ToString(),
                   "sp_OrdRemCust",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptOrd_PrnRemCust.Show();
            }
            else if (optInv.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@CustCode";
                string plstType = "18,18,18"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," +
                    this.mskStatus.Text;

                //this.mskStatus.Text;


                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrInv_Smry rpt1 = new CrInv_Smry();

                frmPrintVw6 rptInv_Smry = new frmPrintVw6(
                   fRptTitle,
                   this.dtpFromDate.Value.ToString(),
                   this.dtpToDate.Value.ToString(),
                   "sp_InvSmry",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptInv_Smry.Show();
            }
        }

    }
}
