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
    public partial class frmSaleOdrEntryQout : Form
    {
        int fcboDefaultValue = 0;
        bool blnFormLoad = true;
        public frmSaleOdrEntryQout()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSaleOdrEntryQout_Load(object sender, EventArgs e)
        {
            AtFormLoad();
            blnFormLoad = false;
           // SourceGrid_Fill();
        }

        private void AtFormLoad()
        {
            string lSQL = string.Empty;

            this.KeyPreview = true;
            //Main Group Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmMainGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboMainGroup, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboMainGroup.SelectedValue);

            //Transport Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmAdda);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboTransport, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboTransport.SelectedValue);
        }



        private void cboMainGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blnFormLoad == true)
            {
                return;
            }

            string lSQL = string.Empty;
            //Item Group Combo Fill

            lSQL = "SELECT cgdCode AS GroupID, cgdDesc AS GroupName ";
            lSQL += " FROM CatDtl ";
            lSQL += " WHERE cgCode= " + Convert.ToString((int)Category.enmItemGroup);
            lSQL += " AND cgdCode IN (select GroupId From MainGroup ";
            lSQL += " Where MGroupId = " + cboMainGroup.SelectedValue.ToString() + ") ORDER BY cgdCode; ";

            clsFillCombo.FillCombo(cboItemGroup, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGroup.SelectedValue);

        }

        private void txtOrderNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOrderNo_Click(object sender, EventArgs e)
        {

        }

       

        private void mskCustomerCode_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        //private void mskCustomerCode_DoubleClick(object sender, EventArgs e)
        //{
        //    LookUp_GL();
        //}

        //private void LookUp_GL()
        //{
        //    //SELECT Code, Name FROM Heads WHERE TYPE = 'A'
        //    frmLookUp sForm = new frmLookUp(
        //            "Code",
        //            "Name",
        //            "Heads",
        //            this.Text.ToString(),
        //            1,
        //            "Account Code, Account Name",
        //            "16,40",
        //            " T, T",
        //            true,
        //            "",
        //            " Type='A'",
        //            "TextBox"
        //            );

        //    mskCustomerCode.Mask = "";
        //    mskCustomerCode.Text = string.Empty;
        //    mskCustomerCode.Mask = clsGVar.maskGLCode;

        //    sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
        //    sForm.ShowDialog();
        //    if (mskCustomerCode.Text != null)
        //    {
        //        if (mskCustomerCode.Text != null)
        //        {
        //            if (mskCustomerCode.Text.ToString() == "" || mskCustomerCode.Text.ToString() == string.Empty)
        //            {
        //                return;
        //            }
        //            if (mskCustomerCode.Text.ToString().Trim().Length > 0)
        //            {
        //                PopulateRecordsGL();
        //                //LoadSampleData();
        //                //SumVoc();
        //            }

        //            //txtOrderNo.Text = txtPassDataVocID.Text.ToString();
        //            //grdVoucher[pCol, pRow].Value = tmtext.Text.ToString();
        //            //System.Windows.Forms.SendKeys.Send("{TAB}");
        //        }

        //        //if (msk_AccountID.Text.ToString() == "" || msk_AccountID.Text.ToString() == string.Empty)
        //        //{
        //        //    return;
        //        //}
        //        //msk_AccountID.Text = sForm.lupassControl.ToString();
        //        ////grdVoucher[pCol, pRow].Value = msk_AccountID.Text.ToString();
        //        //System.Windows.Forms.SendKeys.Send("{TAB}");
        //    }
        //}

        //private void PassData(object sender)
        //{
        //    mskCustomerCode.Mask = "";
        //    mskCustomerCode.Text = ((TextBox)sender).Text;
        //    mskCustomerCode.Mask = clsGVar.maskGLCode;
        //    //mskCustomerCode.Text = ((MaskedTextBox)sender).Text;
        //    //mskCustomerCode.Mask = clsGVar.maskGLCode;

        //}

        ////Populate Recordset 
        //private void PopulateRecordsGL()
        //{
        //    DataSet ds = new DataSet();
        //    DataRow dRow;
        //    string tSQL = string.Empty;

        //    // Fields 0,1,2,3 are Begin  

        //    tSQL = "SELECT Name ";
        //    tSQL += " from Heads ";
        //    tSQL += " where Code ='" + mskCustomerCode.Text.ToString() + "';";

        //    try
        //    {
        //        ds = clsDbManager.GetData_Set(tSQL, "Heads");
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            //fAlreadyExists = true;
        //            dRow = ds.Tables[0].Rows[0];
        //            // Starting title as 0
        //            lblName.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                ds.Clear();
        //                //btn_EnableDisable(true);
        //            }
        //            //LoadGridData();
        //            //txtManualDoc.Enabled = false;
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
        //    }
        //}

        private void txtOrderNo_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        private void LookUp_Voc()
        {

            //string pSource,
            //int pRow,
            //int pCol

            // MessageBox.Show("Lookup Source: " + pSource);

            // 1- KeyField
            // 2- Field List
            // 3- Table Name
            // 4- Form Title
            // 5- Default Find Field (Int) 0,1,2,3 etc Default = 1 = title field
            // 6- Grid Title List
            // 7- Grid Title Width
            // 8- Grid Title format T = Text, N = Numeric etc
            // 9- Bool One Table = True, More Then One = False
            // 10 Join String Otherwise Empty String.
            // 11 Optional Where
            // 11 Return Control Type TextBox or MaskedTextBox Default mtextBox
            //
            //select doc_id, doc_strid, doc_date, doc_remarks, doc_amt 
            //from gl_tran
            //where doc_vt_id=1 and doc_fiscal_id=1

            //SELECT d.Ord_No, d.Cont_No, d.Ord_Date, h.Name AS CustName, d.Qty, d.Amount, d.Category
            //FROM Ord_Det d INNER JOIN Heads h ON d.Customer=h.Code
            //WHERE d.Category = 1


            frmLookUp sForm = new frmLookUp(
                    "d.Ord_No",
                    "d.Cont_No, d.Ord_Date, h.Name, d.Qty, d.Amount",
                    "Ord_Det d INNER JOIN Heads h ON d.Customer=h.Code",
                    this.Text.ToString(),
                    1,
                    "Order ID, Contract ID,Date,Customer Name,Qty,Amount",
                    "12,8,8,20,10,12",
                    " T, T, T, T,N2,N2",
                    true,
                    "",
                //"d.Category = " + cboMainGroup.SelectedValue.ToString(), 
                    "",
                    "TextBox"
                    );
            txtOrderNo.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID);
            sForm.ShowDialog();
            if (txtOrderNo.Text != null)
            {
                if (txtOrderNo.Text != null)
                {
                    if (txtOrderNo.Text.ToString() == "" || txtOrderNo.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtOrderNo.Text.ToString().Trim().Length > 0)
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

        private void PassDataVocID(object sender)
        {
            //txtPassDataVocID.Text = ((TextBox)sender).Text;
            txtOrderNo.Text = ((TextBox)sender).Text;
            //msk_VocCode.Text = ((MaskedTextBox)sender).Text;
        }

        //Populate Recordset 
        private void PopulateRecords()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  

            tSQL = "SELECT d.Ord_No, d.Ord_Date, d.Cont_No, d.Customer, h.Name AS CustName, ";
            tSQL += " d.BillNo, d.Status, d.Type, d.Adda, d.AddaId, d.ItemCategory,d.Cash_Pay, ";
            tSQL += " d.Qty, d.Amount, d.Category, d.Detail, d.ItemGroupID ";
            tSQL += " from Ord_Det d INNER JOIN Heads h ON d.Customer=h.Code ";
            tSQL += " where d.Ord_No='" + txtOrderNo.Text.ToString() + "';";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Ord_Det");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    txtOrderNo.Text = (ds.Tables[0].Rows[0]["Ord_No"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ord_No"].ToString());
                    //dtpOrder.Value = (ds.Tables[0].Rows[0]["doc_date"] == DBNull.Value ? DateTime.Now.ToString("T") : ds.Tables[0].Rows[0]["doc_date"]);
                    txtContractNo.Text = (ds.Tables[0].Rows[0]["Cont_No"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Cont_No"].ToString());
                    mskCustomerCode.Text = (ds.Tables[0].Rows[0]["Customer"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Customer"].ToString());
                    lblName.Text = (ds.Tables[0].Rows[0]["CustName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CustName"].ToString());
                    txtBillNo.Text = (ds.Tables[0].Rows[0]["BillNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BillNo"].ToString());
                    txtOrderStatus.Text = (ds.Tables[0].Rows[0]["Status"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Status"].ToString());
                    txtSaleType.Text = (ds.Tables[0].Rows[0]["Type"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Type"].ToString());
                    txtDetail.Text = (ds.Tables[0].Rows[0]["Detail"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Detail"].ToString());

                    //cboTransport.Text = (ds.Tables[0].Rows[0]["AddaId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["AddaId"].ToString());
                    clsSetCombo.Set_ComboBox(cboTransport, Convert.ToInt32(ds.Tables[0].Rows[0]["AddaId"]));
                    clsSetCombo.Set_ComboBox(cboItemGroup, Convert.ToInt32(ds.Tables[0].Rows[0]["ItemGroupID"]));


                    //msk_AccountID.Tag = (ds.Tables[0].Rows[0]["GLID"] == DBNull.Value ? "0" : ds.Tables[0].Rows[0]["GLID"].ToString());
                    //if (ds.Tables[0].Rows[0]["Doc_Status"] != DBNull.Value)
                    //{
                    //    chkComplete.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Doc_Status"]);
                    //    //chkIsDisabled.Checked = Convert.ToBoolean(dRow.ItemArray.GetValue(3).ToString());
                    //}
                    //else
                    //{
                    //    chkComplete.Checked = false;
                    //}

                    //fEditMod = true;

                    //chkComplete.Checked = (ds.Tables[0].Rows[0]["Doc_Status"]==DBNull.Value ? "0" : ds.Tables[0].Rows[0]["Doc_Status"].ToString());
                    //txtContract.Text = (ds.Tables[0].Rows[0]["ContractNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ContractNo"].ToString());

                    //txtBiltyNo.Text = (ds.Tables[0].Rows[0]["BiltyNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BiltyNo"].ToString());
                    //txtBiltyDate.Text = (ds.Tables[0].Rows[0]["BiltyDate"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BiltyDate"].ToString());
                    //txtVehicleNo.Text = (ds.Tables[0].Rows[0]["VehicleNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["VehicleNo"].ToString());
                    //txtDriverName.Text = (ds.Tables[0].Rows[0]["DriverName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DriverName"].ToString());

                    //int tcboTransportID = 0;
                    //tcboTransportID = Convert.ToInt16(ds.Tables[0].Rows[0]["TransportID"].ToString());
                    //cboTransport.SelectedIndex = ClassSetCombo.Set_ComboBox(cboTransport, tcboTransportID);

                    //tFirstID = Convert.ToInt16(dRow.ItemArray.GetValue(3).ToString());
                    //cboFirstID.SelectedIndex = ClassSetCombo.Set_ComboBox(cboFirstID, tFirstID);

                    //cboTransport.Text = (ds.Tables[0].Rows[0]["TransportID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["TransportID"].ToString());

                    //grdVoucher.DataSource = ds.Tables[1];
                    //grdVoucher.Visible = true;
                    //lblAccountName.Text = dRow.ItemArray.GetValue(0).ToString();
                    //lblAcID.Text = dRow.ItemArray.GetValue(1).ToString();

                    //if (grdVoucher.RowCount > 1)
                    //{
                    //    grdVoucher.Rows.Clear();
                    //    grdVoucher.Columns.Clear();
                    //}
                    //grdVoucher.Visible = false;
                    //grdVoucher.Rows.Clear();
                    //grdVoucher.Columns.Clear();

                    //grdVoucher.DataSource = ds.Tables[1];
                    //grdVoucher.Visible = true;

                    //grdVoucher.Rows.Clear();
                    //grdVoucher.Columns.Clear();
                    ////
                    //for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    //{
                    //    dRow = ds.Tables[1].Rows[i];
                    //    // **** Following Two Rows may get data one time *****
                    //    //         dGvDetail.DataSource = Zdtset.Tables[0];
                    //    //         dGvDetail.Visible = true;
                    //    // **** Following Two Rows may get data one time *****
                    //    //grdVoucher.Columns = 17;

                    //    grdVoucher.Rows.Add(
                    //        (dRow.ItemArray.GetValue((int)GColInv.ItemID) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColInv.ItemID).ToString()),                       // 0-
                    //        (dRow.ItemArray.GetValue((int)GColInv.ItemName) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColInv.ItemName).ToString()),                           // 1-
                    //        (dRow.ItemArray.GetValue((int)GColInv.UOMID) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColInv.UOMID).ToString()),                           // 1-
                    //        (dRow.ItemArray.GetValue((int)GColInv.UOMName) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColInv.UOMName).ToString()),                             // 3-
                    //        (dRow.ItemArray.GetValue((int)GColInv.GodownID) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColInv.GodownID).ToString()),                          // 4-
                    //        (dRow.ItemArray.GetValue((int)GColInv.GodownName) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColInv.GodownName).ToString()),                          // 5-
                    //        (dRow.ItemArray.GetValue((int)GColInv.Qty) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.Qty).ToString()),                            // 6-
                    //        (dRow.ItemArray.GetValue((int)GColInv.Rate) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.Rate).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColInv.Bundle) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.Bundle).ToString()),                           // 10-
                    //        (dRow.ItemArray.GetValue((int)GColInv.MeshTotal) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.MeshTotal).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColInv.Amount) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.Amount).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColInv.isBundle) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.isBundle).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColInv.isMesh) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.isMesh).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColInv.Length) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.Length).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColInv.LenDec) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.LenDec).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColInv.Width) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.Width).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColInv.WidDec) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.WidDec).ToString())                            // 9-
                    //        );
                    //    //dGvDetail.Columns[1].ReadOnly = true;  // working
                    //}
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
                MessageBox.Show("Unable to Get Order No...", this.Text.ToString());
            }
        }

        private void txtOrderNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
        }

        private void mskCustomerCode_DoubleClick_1(object sender, EventArgs e)
        {
            LookUp_GL();
        }

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

            mskCustomerCode.Mask = "";
            mskCustomerCode.Text = string.Empty;
            mskCustomerCode.Mask = clsGVar.maskGLCode;

            sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
            sForm.ShowDialog();
            if (mskCustomerCode.Text != null)
            {
                if (mskCustomerCode.Text != null)
                {
                    if (mskCustomerCode.Text.ToString() == "" || mskCustomerCode.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (mskCustomerCode.Text.ToString().Trim().Length > 0)
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

        private void PassData(object sender)
        {
            mskCustomerCode.Mask = "";
            mskCustomerCode.Text = ((TextBox)sender).Text;
            mskCustomerCode.Mask = clsGVar.maskGLCode;
            //mskCustomerCode.Text = ((MaskedTextBox)sender).Text;
            //mskCustomerCode.Mask = clsGVar.maskGLCode;

        }

        //Populate Recordset 
        private void PopulateRecordsGL()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  

            tSQL = "SELECT Name ";
            tSQL += " from Heads ";
            tSQL += " where Code ='" + mskCustomerCode.Text.ToString() + "';";

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

        private void mskCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
        }
    }
}
