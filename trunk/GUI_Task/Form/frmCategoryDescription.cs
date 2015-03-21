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
    public partial class frmCategoryDescription : Form
    {
        int fcboDefaultValue = 0;
        bool blnFormLoad = false;
        public frmCategoryDescription()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void frmCategoryDescription_Load(object sender, EventArgs e)
        {
            blnFormLoad = false;
            AtFormLoad();
            blnFormLoad = true;
            this.MaximizeBox = false;

        }

        private void AtFormLoad()
        {
            string lSQL = string.Empty;
            //dtpOrder.Value = now.;
            //msk_VocDate.Text = now.Date.ToString();

            this.KeyPreview = true;

            //Item group cOMBO
            //lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmCategory);
            //lSQL += " order by cgdDesc";
            lSQL = "SELECT cgCode, CAST(cgCode AS VARCHAR(3)) + ' : ' + cgDesc ";
            lSQL += " FROM Category ORDER BY cgCode";

            clsFillCombo.FillCombo(cboCategory, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboCategory.SelectedValue); ;
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCode_DoubleClick(object sender, EventArgs e)
        {
            Lookup_Category();
        }

        private void Lookup_Category()
        { 
            //string lSQL = string.Empty;

            //lSQL = "SELECT cgdCode, cgdDesc";
            //lSQL += " FROM CatDtl WHERE cgCode= " + cboCategory.SelectedValue.ToString();
            //lSQL += " ORDER BY cgdCode";

            frmLookUp sForm = new frmLookUp(
                "cgdCode",
                "cgdDesc,UName",
                "CatDtl",
                this.Text.ToString(),
                1,
                "Code, Name, Urdu Name",
                "5,25,10",
                " T, T, T",
                true,
                "",
                "cgCode = " + cboCategory.SelectedValue.ToString(), 
                "TextBox"
                );

                    txtCode.Text = string.Empty;
                    sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
                    sForm.ShowDialog();

                    if (txtCode.Text != null)
                    {
                        if (txtCode.Text != null)
                        {
                            if (txtCode.Text.ToString() == "" || txtCode.Text.ToString() == string.Empty)
                            {
                                return;
                            }
                            if (txtCode.Text.ToString().Trim().Length > 0)
                            {
                                PopulateRecords();
                                //LoadSampleData();
                                //SumVoc();
                            }

                            //txtOrderNo.Text = txtPassDataVocID.Text.ToString();
                            //grdVoucher[pCol, pRow].Value = tmtext.Text.ToString();
                            //System.Windows.Forms.SendKeys.Send("{TAB}");
                        }

                        //if (msk_AccountID.Text.ToString() == "" || msk_AccountID.Text.ToString() == string.Empty)
                        //{
                        //    return;
                        //}
                        //msk_AccountID.Text = sForm.lupassControl.ToString();
                        ////grdVoucher[pCol, pRow].Value = msk_AccountID.Text.ToString();
                        //System.Windows.Forms.SendKeys.Send("{TAB}");
                    }

        }

        #region PopulateRecords
        //Populate Recordset 
        private void PopulateRecords()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  

            tSQL = "SELECT * ";
            tSQL += " FROM CatDtl WHERE cgCode= " + cboCategory.SelectedValue.ToString();
            tSQL += " AND cgdCode= " + txtCode.Text.ToString();

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "CatDtl");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    txtName.Text = (ds.Tables[0].Rows[0]["cgdDesc"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["cgdDesc"].ToString());
                    //dtpOrder.Value = (ds.Tables[0].Rows[0]["doc_date"] == DBNull.Value ? DateTime.Now.ToString("T") : ds.Tables[0].Rows[0]["doc_date"]);
                    txtUrduName.Text = (ds.Tables[0].Rows[0]["UName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["UName"].ToString());
                    //mskCustomerCode.Text = (ds.Tables[0].Rows[0]["Customer"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Customer"].ToString());
                    //lblName.Text = (ds.Tables[0].Rows[0]["CustName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CustName"].ToString());
                    //txtBillNo.Text = (ds.Tables[0].Rows[0]["BillNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BillNo"].ToString());
                    //txtOrderStatus.Text = (ds.Tables[0].Rows[0]["Status"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Status"].ToString());
                    //txtSaleType.Text = (ds.Tables[0].Rows[0]["Type"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Type"].ToString());
                    //txtDetail.Text = (ds.Tables[0].Rows[0]["Detail"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Detail"].ToString());

                    //cboTransport.Text = (ds.Tables[0].Rows[0]["AddaId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["AddaId"].ToString());
                    //clsSetCombo.Set_ComboBox(cboTransport, Convert.ToInt32(ds.Tables[0].Rows[0]["AddaId"]));
                    //clsSetCombo.Set_ComboBox(cboItemGroup, Convert.ToInt32(ds.Tables[0].Rows[0]["ItemGroupID"]));


                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Order No...", this.Text.ToString());
            }
        }
        #endregion

        private void PassData(object sender)
        {
            txtCode.Text = ((TextBox)sender).Text;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) 
            {
                Lookup_Category();
            }
        }

        private void btn_Help_Click(object sender, EventArgs e)
        {
            Lookup_Category();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            //DataSet ds = new DataSet();
            //DataRow dRow;
            string tSQL = string.Empty;
            string strSaveQry = string.Empty;
            // Fields 0,1,2,3 are Begin  

            tSQL = "SELECT * ";
            tSQL += " FROM CatDtl WHERE cgCode= " + cboCategory.SelectedValue.ToString();
            tSQL += " AND cgdCode= " + txtCode.Text.ToString();

            try
            {
                if (clsDbManager.IDAlreadyExistQry(tSQL) == true)
                {
                    //fAlreadyExists = true;
                    strSaveQry = " UPDATE CatDtl ";
                    strSaveQry += " SET cgdDesc = '" + txtName.Text.ToString() + "'";
                    strSaveQry += ", UName = N'" + txtUrduName.Text.ToString() + "'";
                    strSaveQry += " WHERE cgCode = " + cboCategory.SelectedValue.ToString();
                    strSaveQry += " AND cgdCode=" + txtCode.Text.ToString();

                }
                else
                {
                    //Insert New Record;
                    strSaveQry = " INSERT INTO CatDtl (cgCode, cgdCode, cgdDesc, UName) ";
                    strSaveQry += " VALUES (" + cboCategory.SelectedValue.ToString() + ", ";
                    strSaveQry += txtCode.Text.ToString() + ",";
                    strSaveQry += "'" + txtName.Text.ToString() + "',";
                    strSaveQry += "N'" + txtUrduName.Text.ToString() + "')";
                }

                if (!clsDbManager.ExeOne(strSaveQry))
                {
                    MessageBox.Show("Not Saved see log...", this.Text.ToString());
                    return;
                }
                else
                {
                    MessageBox.Show("Saved Successfully...", this.Text.ToString());
                    //ClearThisForm();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Unable Save Query...", this.Text.ToString());
            }        
        }

        private void txtCode_Enter(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataRow dRow; 
            string tSQL = string.Empty;

            tSQL = "SELECT Max(cgdCode)+1 AS MaxCode ";
            tSQL += " FROM CatDtl WHERE cgCode= " + cboCategory.SelectedValue.ToString();
            //tSQL += " AND cgdCode= " + txtCode.Text.ToString();

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "CatDtl");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    txtCode.Text = (ds.Tables[0].Rows[0]["MaxCode"] == DBNull.Value ? "1" : ds.Tables[0].Rows[0]["MaxCode"].ToString());

                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Order No...", this.Text.ToString());
            }
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            PopulateRecords();
        }

        // private void cboCategory_Click(object sender, EventArgs e)
        //{
        //    int cboValue = 0;
        //    cboValue = Convert.ToInt32(cboCategory.SelectedValue.ToString());

        //    if (cboValue == 6 || cboValue == 12)
        //    {
        //        lblGLCode.Visible = true;
        //        lblGLName.Visible = true;
        //        lblName.Visible = true;
        //        mskGLCode.Visible = true;
        //    }
        //    else
        //    {
        //        lblGLCode.Visible = false;
        //        lblGLName.Visible = false;
        //        lblName.Visible = false;
        //        mskGLCode.Visible = false;
        //    }
        //}

         private void cboCategory_SelectedValueChanged(object sender, EventArgs e)
         {
             if (blnFormLoad == false)
             {
                 return;
             }

             HideUnHide();
         }

         private void HideUnHide()
         {
             int cboValue = 0;
             cboValue = Convert.ToInt16(cboCategory.SelectedValue.ToString());

             if (cboValue == 6 || cboValue == 12)
             {
                 lblGLCode.Visible = true;
                 lblGLName.Visible = true;
                 lblName.Visible = true;
                 mskGLCode.Visible = true;
             }
             else
             {
                 lblGLCode.Visible = false;
                 lblGLName.Visible = false;
                 lblName.Visible = false;
                 mskGLCode.Visible = false;
             }
         }

         private void mskGLCode_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
         {

         }

        private void mskGLCode_DoubleClick(object sender, EventArgs e)
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

            mskGLCode.Mask="";
            mskGLCode.Text= string.Empty;
            mskGLCode.Mask = clsGVar.maskGLCode;

            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataGL);
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

                    //txtOrderNo.Text = txtPassDataVocID.Text.ToString();
                    //grdVoucher[pCol, pRow].Value = tmtext.Text.ToString();
                    //System.Windows.Forms.SendKeys.Send("{TAB}");
                }

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

        private void PassDataGL(object sender)
        {
            mskGLCode.Mask = "";
            mskGLCode.Text = ((TextBox)sender).Text;
            mskGLCode.Mask = clsGVar.maskGLCode;
            //mskCustomerCode.Text = ((MaskedTextBox)sender).Text;
            //mskCustomerCode.Mask = clsGVar.maskGLCode;

        }

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


        //private void cboMainGroup_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    {

        //        if (blnFormLoad == true)
        //        {
        //            return;
        //        }

        //        string lSQL = string.Empty;

        //        //Item Group Combo Fill
        //        lSQL = "SELECT cgdCode AS GroupID, cgdDesc AS GroupName ";
        //        lSQL += " FROM CatDtl ";
        //        lSQL += " WHERE cgCode= " + Convert.ToString((int)Category.enmItemGroup);
        //        lSQL += " AND cgdCode IN (select GroupId From MainGroup ";
        //        lSQL += " Where MGroupId = " + cboMainGroup.SelectedValue.ToString() + ") ORDER BY cgdCode; ";

        //        clsFillCombo.FillCombo(cboItemGroup, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
        //        fcboDefaultValue = Convert.ToInt16(cboItemGroup.SelectedValue);

        //    }
        //}
    }
}