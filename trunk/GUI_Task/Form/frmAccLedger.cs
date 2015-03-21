using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI_Task.PrintDataSets;
using GUI_Task.PrintReport;
using GUI_Task.PrintViewer;
using GUI_Task.StringFun01;
using GUI_Task.PrintVw6;

namespace GUI_Task
{
    public partial class frmAccLedger : Form
    {
        bool blnValidGLCode = false;

        public frmAccLedger()
        {
            InitializeComponent();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void account_Leger_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmOrderChem frm = new frmOrderChem();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LookUp_GL();
        }

        private void button5Click(object sender, EventArgs e)
        {
            MessageBox.Show("Run-time error '13':\nType Mismatch","ProjComfit");
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

            mskAccCode.Mask = "";
            mskAccCode.Text = string.Empty;
            mskAccCode.Mask = clsGVar.maskGLCode;

            sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
            sForm.ShowDialog();
            if (mskAccCode.Text != null)
            {

                if (mskAccCode.Text != null)
                {
                    if (mskAccCode.Text.ToString() == "" || mskAccCode.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (mskAccCode.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecordsGL();
                        btnOK.Enabled = true;
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
            mskAccCode.Mask = "";
            mskAccCode.Text = ((TextBox)sender).Text;
            mskAccCode.Mask = clsGVar.maskGLCode;
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
            tSQL += " where Code ='" + mskAccCode.Text.ToString() + "';";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Heads");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    lblName.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());
                    blnValidGLCode = true;

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

        private void mskAccCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_GL();
            }
        }

        private void mskPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_GL();
            }
        }

        private void mskPhone_DoubleClick(object sender, EventArgs e)
        {
            LookUp_GL();
        }

        private void frmAccLedger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string fRptTitle = this.Text;
            string plstField = "@Code,@FromDate,@ToDate";
            string plstType = "18,18,18"; // {"8, 8, 8, 8, 8, 8"};
            string plstValue = this.mskAccCode.Text + "," + StrF01.D2Str(this.dtpFromDate.Value) + "," +
                StrF01.D2Str(this.dtpToDate.Value);

            //dsLedgerNew pDs = new dsLedgerNew();

            DataSet pDs = new DataSet();
            CrLedger rpt1 = new CrLedger();
            
            frmPrintVw6 rptLedger2 = new frmPrintVw6(
               fRptTitle,
               StrF01.D2Str(this.dtpFromDate.Value),
               StrF01.D2Str(this.dtpToDate.Value),
               "sp_Ac_Ledger",
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

        private void mskAccCode_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void mskAccCode_TextChanged(object sender, EventArgs e)
        {
            if (blnValidGLCode==true)
            {
                btnOK.Enabled = true;
            }
            else
            {
                btnOK.Enabled = false;
            }
        }

        private void mskAccCode_DoubleClick(object sender, EventArgs e)
        {
            LookUp_GL();
        }

    }
}
