using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI_Task.StringFun01;
using GUI_Task.PrintReport;
using GUI_Task.PrintVw6;

namespace GUI_Task
{
    public partial class frmCustAging : Form
    {
        public frmCustAging()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LookUp_GL();
        }

        private void frm_customer_Wise_Aging_Load(object sender, EventArgs e)
        {

        }

        private void frmCustAging_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void mskAccCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                LookUp_GL();
        }

        private void mskAccCode_DoubleClick(object sender, EventArgs e)
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
            mskAccCode.Mask = "";
            mskAccCode.Text = ((TextBox)sender).Text;
            mskAccCode.Mask = clsGVar.maskGLCode;
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
            tSQL += " where Code ='" + mskAccCode.Text.ToString() + "';";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Heads");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    lblAccountName.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());
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
            if(optWithDishChq.Checked == true)
            {
            string fRptTitle = this.Text;
            string plstField = "@Para_Code,@Para_No,@PDate";
            string plstType = "18,8,18"; // {"8, 8, 8, 8, 8, 8"};
            string plstValue = this.mskAccCode.Text + "," + 9 + "," + DateTime.Today.ToString("yyyy-MM-dd");
               // +"," + StrF01.D2Str(this.dtpToDate.Value);

            //dsLedgerNew pDs = new dsLedgerNew();

            DataSet pDs = new DataSet();
            CrDue_Rep rpt1 = new CrDue_Rep();

            frmPrintVw6 rptLedger2 = new frmPrintVw6(
               fRptTitle,
               "9",
               DateTime.Today.ToString("yyyy-MM-dd"),
               //StrF01.D2Str(this.dtpFromDate.Value),
               //StrF01.D2Str(this.dtpToDate.Value),
               "Due_Rep",
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
            else if(optWithoutDishChq.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@Para_Code,@Para_No,@PDate";
                string plstType = "18,8,18"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = this.mskAccCode.Text + "," + 9 + "," + DateTime.Today.ToString("yyyy-MM-dd");
                // +"," + StrF01.D2Str(this.dtpToDate.Value);

                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrDue_RepCheqNew rpt1 = new CrDue_RepCheqNew();

                frmPrintVw6 rptLedger2 = new frmPrintVw6(
                   fRptTitle,
                   "9",
                   DateTime.Today.ToString("yyyy-MM-dd"),
                    //StrF01.D2Str(this.dtpFromDate.Value),
                    //StrF01.D2Str(this.dtpToDate.Value),
                   "Due_RepCheqNew",
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
            else if(optCrDaysWithDishChq.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@Para_Code,@Para_No,@PDate";
                string plstType = "18,8,18"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = this.mskAccCode.Text + "," + 9 + "," + DateTime.Today.ToString("yyyy-MM-dd");
                // +"," + StrF01.D2Str(this.dtpToDate.Value);

                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrDue_RepCrDaysCust rpt1 = new CrDue_RepCrDaysCust();

                frmPrintVw6 rptLedger2 = new frmPrintVw6(
                   fRptTitle,
                   "9",
                   DateTime.Today.ToString("yyyy-MM-dd"),
                    //StrF01.D2Str(this.dtpFromDate.Value),
                    //StrF01.D2Str(this.dtpToDate.Value),
                   "Due_RepCrDayCust",
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
        }
    }
}
