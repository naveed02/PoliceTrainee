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

namespace GUI_Task
{
    enum GColInv
    {
        ItemID = 0,       // 0 - ItemID
        ItemCode = 1,     // 1 - ItemCode 
        ItemName = 2,     // 2 - ItemName
        SizeName = 3,     // 3 - SizeName
        ColorName = 4,    // 4 - ColorName
        Discount = 5,     // 5 - Discount
        DelQty = 6,       // 6 - DelQty
        DzRate = 7,       // 7 - DzRate
        PrRate = 8,       // 8 - PrRate
        Amount = 9,       // 9 - Amount
        SizeID = 10,      //10 - SizeID
        ColorID = 11      //11 - ColorID
    }

    public partial class frmInvoiceEntry : Form
    {
        //******* Grid Variable Setting -- Begin ******
        string fHDR = string.Empty;                       // Column Header
        string fColWidth = string.Empty;                  // Column Width (Input)
        string fColMinWidth = string.Empty;               // Column Minimum Width
        string fColMaxInputLen = string.Empty;            // Column Visible Length/Width 
        string fColFormat = string.Empty;                 // Column Format  
        string fColReadOnly = string.Empty;               // Column ReadOnly 1 = ReadOnly, 0 = Read-Write  
        string fFieldList = string.Empty;

        string fColType = string.Empty;
        string fFieldName = string.Empty;
        //******* Grid Variable Setting -- End ******

        string[] a_Color = new string[0];
        int[] a_ColorInt = new int[0];

        string[] a_Size = new string[0];
        int[] a_SizeInt = new int[0];
        List<string> fManySQL = null;                      // List string for storing Multiple Queri
        string fRptTitle = string.Empty;
        //bool fFormClosing = false;

        bool ftTIsBalloon = true;
        bool fEditMod = false;
        int fEditRow = 0;
        //bool fFrmLoading = true;                    // Form is Loading Controls (to accomodate Load event so that first time loading requirement is done)
        int fTErr = 0;                              // Total Errors while Saving or other operation.
        string ErrrMsg = string.Empty;              // To display error message if any.
        string fLastID = string.Empty;              // Last Voucher/Doc ID (Saved new or modified)
        //
        //int fDocTypeID = 1;                         // Voucher/Doc Type ID
        int fDocFiscal = 1;                         // Accounting / Fiscal Period    
        //int fTNOA = 0;                              // Total Number of Attachments.    
        int fTNOT = 0;                              // Total Number of Grid Transactions.
        decimal fDocAmt = 0;                        // Document Amount Debit or Credit for DocMaster Field.
        string fDocWhere = string.Empty;            // Where string to build where clause for Voucher level
        int fLastRow = 0;                           // Last row number of the grid.
        Int64 fDocID = 1;
        bool fGridControl = false;                  // To overcome Grid's tabing

        bool fSingleEntryAllowed = true;            // for the time being later set to false.
        bool fDocAlreadyExists = false;             // Check if Doc/voucher already exists (Edit Mode = True, New Mode = false)
        bool fIDConfirmed = false;                  // Account ID is valid and existance in Table is confirmed.
        bool fCellEditMode = false;                 // Cell Edit Mode

        int fcboDefaultValue = 0;
        bool blnFormLoad = true;

        string strDocId = string.Empty;
        
        public frmInvoiceEntry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInvoiceEntry_Load(object sender, EventArgs e)
        {
            AtFormLoad();
            this.MaximizeBox = false;
            blnFormLoad = false;
        }

        private void AtFormLoad()
        {
            string lSQL = string.Empty;

            SettingGridVariable();
            LoadInitialControls();

            this.KeyPreview = true;


            //Category Combo Fill
            lSQL = "SELECT DISTINCT 1,RIGHT(Itemcode,1) FROM Item ";
            //lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboCategory, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboCategory.SelectedValue);


            //Transport Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmAdda);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboAdda, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboAdda.SelectedValue);

            //ItemGroup Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmItemGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGroup, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGroup.SelectedValue);
         

            //Main Group Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmMainGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboMainGroup, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboMainGroup.SelectedValue);

            //Size Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmSize);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cbo_I_Size, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cbo_I_Size.SelectedValue);

            DataSet ds = new DataSet();
            ds = clsDbManager.GetData_Set(lSQL, "CatDtl");
            SizeColumn.DataSource = ds.Tables[0];
            SizeColumn.ValueMember = ds.Tables[0].Columns[0].ToString();
            SizeColumn.DisplayMember = ds.Tables[0].Columns[1].ToString();
            ds.Clear();

            //Color Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmColor);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cbo_I_Color, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cbo_I_Color.SelectedValue);

            ds = clsDbManager.GetData_Set(lSQL, "CatDtl");
            ColorColumn.DataSource = ds.Tables[0];
            ColorColumn.ValueMember = ds.Tables[0].Columns[0].ToString();
            ColorColumn.DisplayMember = ds.Tables[0].Columns[1].ToString();
            ds.Clear();

            ////UOM Combo Fill
            //lSQL = "select UOMID, UnitName from IMS_UOM order by UnitName";

            //clsFillCombo.FillCombo(cbo_I_UOM, clsGVar.ConString1, "IMS_UOM" + "," + "UnitName" + "," + "False", lSQL);
            //fcboDefaultValue = Convert.ToInt16(cbo_I_UOM.SelectedValue);

            //ds = clsDbManager.GetData_Set(lSQL, "IMS_UOM");
            //UnitColumn.DataSource = ds.Tables[0];
            //UnitColumn.ValueMember = ds.Tables[0].Columns[0].ToString();
            //UnitColumn.DisplayMember = ds.Tables[0].Columns[1].ToString();
            //ds.Clear();

        }

        private void LoadInitialControls()
        {
            // 1 = dGV Grid Control
            // 2 = Column Total (Total number of Columns for cross verification with other parameters like width, format)
            // 3 = Column Header
            // 4 = Column Width to be displayed on Grid
            // 5 = Column MaxInputLen   // 0 = unlimited, 
            // 6 = Column Format        // T = Text, N = Numeric, H = Hiden
            // 7 = Column ReadOnly      // 1 = ReadOnly, 0 = Not ReadOnly
            // 8 = Grid Color Scheme    // Default = 1
            // RO 
            grd.Rows.Clear();
            grd.Columns.Clear();

            List<string> lMask = null; //new List<string>;
            List<string> lCboFillType = null; //new List<string>;
            List<string> lCboTableKeyField = null; //new List<string>;
            List<string> lCboQry = null; //new List<string>;

            clsDbManager.SetGridHeaderCmb(
                grd,
                12,
                fHDR,
                fColWidth,
                fColMaxInputLen,
                fColMinWidth,
                fColFormat,
                fColReadOnly,
                "DATA",
                lMask,
                lCboFillType,
                lCboTableKeyField,
                lCboQry,
                false,
                2);

        }

        private void LoadGridData()
        {
            string lSQL = "";
            lSQL += " select h.Code, i.ItemCode, i.Name AS ItemName, sz.cgdDesc AS SizeName, ";
            lSQL += " clr.cgdDesc AS ColorName, h.Discount, h.Qty AS DelQty, ";
            lSQL += " (Rate*12) AS DzRate, Rate AS PrRate, ((h.Qty*h.Rate)-h.Discount) AS Amount, h.SizeId, h.ColorID ";
            lSQL += " from Inv_Hist h INNER JOIN Item i ON h.Code=i.ItemId INNER JOIN CatDtl sz ON h.SizeId=sz.cgdCode AND sz.cgCode=5 ";
            lSQL += " INNER JOIN CatDtl clr ON h.ColorID=clr.cgdCode AND clr.cgCode = 3 ";
            lSQL += " where h.Inv_No = '" + txtInvNo.Text.ToString() + "'; ";

            clsDbManager.FillDataGrid(
                grd,
                lSQL,
                fFieldList,
                fColFormat);
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


        private void mskCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_GL1();
            }

        }

        private void mskCustomerCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LookUp_GL1();
        }



        private void LookUp_GL1()
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

            sForm.lupassControl = new frmLookUp.LUPassControl(PassData1);
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
                        PopulateRecordsGL1();
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

        private void PassData1(object sender)
        {
            mskCustomerCode.Mask = "";
            mskCustomerCode.Text = ((TextBox)sender).Text;
            mskCustomerCode.Mask = clsGVar.maskGLCode;
            //mskCustomerCode.Text = ((MaskedTextBox)sender).Text;
            //mskCustomerCode.Mask = clsGVar.maskGLCode;

        }

        //Populate Recordset 
        private void PopulateRecordsGL1()
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
                    lblNameBottom.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());
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

        private void frmInvoiceEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        #region LookUp_Voc

        private void LookUp_Voc()
        {
            frmLookUp sForm = new frmLookUp(
                    "inv.Inv_No",
                    "inv.Inv_Date, inv.BillNo, c.Name, inv.Detail, inv.Qty, inv.Amount",
                    " Inv_Det inv INNER JOIN CustGroup c ON c.Code = inv.Customer",
                    this.Text.ToString(),
                    1,
                    "Invoice No.,Date,Bill No.,Customer,Detail,Qty,Amount ",
                    "10,8,12,12,15,8,8",
                    " T, T, T, T, T, T, T",
                    true,
                    "",
                    "",
                    "TextBox"
                    );

            txtInvNo.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID);
            sForm.ShowDialog();

            if (txtInvNo.Text != null)
            {
                if (txtInvNo.Text != null)
                {
                    if (txtInvNo.Text.ToString() == "" || txtInvNo.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtInvNo.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecords();
                    }

                }

            }
        }
        #endregion

        private void PassDataVocID(object sender)
        {
            txtInvNo.Text = ((TextBox)sender).Text;
        }

        private void PopulateRecords()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin 

            tSQL += " select DISTINCT RIGHT(Itemcode,1) AS Category, inv.Inv_No, inv.Inv_Date, inv.Do_No, inv.Adda, inv.Detail, inv.Ord_Date, inv.Do_Date, inv.SaleType,";
            tSQL += " inv.BillNo, inv.Customer, c.Name, inv.Detail, inv.Qty, inv.Amount, inv.Bilty_Date, inv.Bilty_No,";
            tSQL += " i.cgdDesc AS ItemGroupName, inv.Cont_No ";
            tSQL += " from Inv_Det inv ";
            tSQL += " INNER JOIN CustGroup c ON c.Code = inv.Customer ";
            tSQL += " INNER JOIN CatDtl i ON inv.ItemGroupID = i.cgdCode AND i.cgCode = 6 ";
            tSQL += " INNER JOIN Item it ON inv.Category = it.ItemId ";
            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Heads");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    dtpInv.Text = (ds.Tables[0].Rows[0]["Inv_Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Inv_Date"].ToString());
                    txtDONo.Text = (ds.Tables[0].Rows[0]["Do_No"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Do_No"].ToString());
                    dtpDO.Text = (ds.Tables[0].Rows[0]["Do_Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Do_Date"].ToString());
                   // txtSaleType.Text = (ds.Tables[0].Rows[0]["SaleType"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["SaleType"].ToString());
                    mskCustomerCode.Text = (ds.Tables[0].Rows[0]["Customer"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Customer"].ToString());
                    lblNameBottom.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());
                    lblBillNo.Text = (ds.Tables[0].Rows[0]["BillNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BillNo"].ToString());
                    lblOrderDate.Text = (ds.Tables[0].Rows[0]["Ord_Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ord_Date"].ToString());
                    cboAdda.Text = (ds.Tables[0].Rows[0]["Adda"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Adda"].ToString());
                    lblSaleType.Text = (ds.Tables[0].Rows[0]["SaleType"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["SaleType"].ToString());
                    txtDetail.Text = (ds.Tables[0].Rows[0]["Detail"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Detail"].ToString());
                    dtpBuilty.Text = (ds.Tables[0].Rows[0]["Bilty_Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Bilty_Date"].ToString());
                    txtBuiltyNo.Text = (ds.Tables[0].Rows[0]["Bilty_No"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Bilty_No"].ToString());
                    cboItemGroup.Text = (ds.Tables[0].Rows[0]["ItemGroupName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemGroupName"].ToString());
                    lblContractNo.Text = (ds.Tables[0].Rows[0]["Cont_No"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Cont_No"].ToString());
                    cboCategory.Text = (ds.Tables[0].Rows[0]["Category"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Category"].ToString());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                    }
                    LoadGridData();
                    SumVoc();
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }

        private void txtDONo_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        private void txtDONo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
        }

        // Order No. Lookup

        #region LookUp_Voc1



        private void LookUp_Voc1()
        {
            frmLookUp sForm = new frmLookUp(

                    "d.Do_No",
                    "d.Do_Date, d.BillNo, c.Name, d.Detail, d.Qty, d.Amount",
                    " DO_Det d INNER JOIN CustGroup c ON c.Code=d.Customer",
                    this.Text.ToString(),
                    1,
                    "D.O. No.,Date,Bill #, Customer Name,Details,Quantity,Amount",
                    "8,8,8,12,20,8,8",
                    " T, T, T, T, T, T, T",
                    true,
                    "",
                    "",
                    "TextBox"
                    );

            mskCustomerCode.Mask = "";
            mskCustomerCode.Text = string.Empty;
            mskCustomerCode.Mask = clsGVar.maskGLCode;

            txtDONo.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID1);
            sForm.ShowDialog();

            if (txtDONo.Text != null)
            {
                if (txtDONo.Text != null)
                {
                    if (txtDONo.Text.ToString() == "" || txtDONo.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtDONo.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecords1();
                    }

                }

            }
        }
        #endregion

        private void PopulateRecords1()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin 

            tSQL += " select d.Do_No, d.Do_Date, d.BillNo, c.Code, c.Name, d.Ord_Date, d.SaleType, d.Detail, d.Qty, d.Amount ";
            tSQL += " from DO_Det d ";
            tSQL += " INNER JOIN CustGroup c ON c.Code=d.Customer ";
            tSQL += " where d.Do_No = '" + txtDONo.Text.ToString() + "';";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "DO_Det");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0

                    dtpDO.Text = (ds.Tables[0].Rows[0]["Do_Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Do_Date"].ToString());
                    lblOrderDate.Text = (ds.Tables[0].Rows[0]["Ord_Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ord_Date"].ToString());
                    mskCustomerCode.Text = (ds.Tables[0].Rows[0]["Code"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Code"].ToString());
                    lblNameBottom.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());
                    lblSaleType.Text = (ds.Tables[0].Rows[0]["SaleType"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["SaleType"].ToString());
                    lblBillNo.Text = (ds.Tables[0].Rows[0]["BillNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BillNo"].ToString());

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                    }
                    LoadGridData();
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }

        private void PassDataVocID1(object sender)
        {
            txtDONo.Text = ((TextBox)sender).Text;
        }

        private void txtOrderNo_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc1();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grd.Rows.Add(txt_I_ItemID.Text.ToString(),              // 0 - ItemID
               lbl_I_ItemCode.Text.ToString(),                      // 1 - ItemCode 
               lbl_I_ItemName.Text.ToString(),                      // 2 - ItemName
               cbo_I_Size.Text.ToString(),                          // 3 - SizeName
               cbo_I_Color.Text.ToString(),                          // 4 - ColorName
               "0",                                                  // 5 - Discount                       
               txtDelQty.Text.ToString(),                            // 6 - DelQty
               (Convert.ToInt32(txtPairRate.Text) * 12).ToString(),   // 7 - DzRate
               txtPairRate.Text.ToString(),                          // 8 - PrRate
               (Convert.ToInt32(txtDelQty.Text) * Convert.ToInt32(txtPairRate.Text)).ToString(),  // 9 - Amount
   cbo_I_Size.SelectedValue.ToString(),                              //10 - SizeID
   cbo_I_Color.SelectedValue.ToString()                              //11 - ColorID
   );                                                               
            SumVoc();
        }



        private void SettingGridVariable()
        {
            string lHDR = "";                       // Column Header
            string lColWidth = "";                  // Column Width (Input)
            string lColMinWidth = "";               // Column Minimum Width
            string lColMaxInputLen = "";            // Column Visible Length/Width 
            string lColFormat = "";                 // Column Format  
            string lColReadOnly = "";               // Column ReadOnly 1 = ReadOnly, 0 = Read-Write  
            string lFieldList = "";
            string tColType = "";
            string tFieldName = "";

            //
            lFieldList = "Code";                // 0 - ItemID  
            lFieldList += ",ItemCode";          // 1 - ItemCode     
            lFieldList += ",ItemName";          // 2 - ItemName
            lFieldList += ",SizeName";       // 3 - SizeName
            lFieldList += ",ColorName";          // 4 - ColorName      
            //lFieldList += ",UnitName";         // 5 - UnitName      
            lFieldList += ",Discount";          // 6 - Discount
            //lFieldList += ",OrdQty";        // 7 - OrdQty
            lFieldList += ",DelQty";               // 8 - DelQty
            lFieldList += ",DzRate";            // 9 - DzRate
            lFieldList += ",PrRate";           //10 - PrRate 
            lFieldList += ",Amount";
            lFieldList += ",SizeID";             //11 - SizeID
            lFieldList += ",ColorID";          //12 - ColorID
           // lFieldList += ",UOMID";         //13 - UOMID


            lHDR += "Item ID";             // 0 - ItemID   
            lHDR += ",Item Code";          // 1 - ItemCode    
            lHDR += ",Item Name";          // 2 - ItemName
            lHDR += ",Size";               // 3 - SizeName   
            lHDR += ",Color";              // 4 - ColorName   
            //lHDR += ",UOM Name";           // 5 - UnitName
            lHDR += ",Discount";           // 6 - Discount
            //lHDR += ",OrdQty";             // 7 - OrdQty
            lHDR += ",DelQty";             // 8 - DelQty 
            lHDR += ",DzRate";             // 9 - DzRate  
            lHDR += ",PrRate";              //10 - PrRate
            lHDR += ",Amount";
            lHDR += ",SizeID";              //11 - SizeID
            lHDR += ",ColorID";             //12 - ColorID
           // lHDR += ",UOMID";               //13 - UOMID

            // Col Visible Width
            lColWidth = "   5";                  // 0 - ItemID    
            lColWidth += ",12";                  // 1 - ItemCode     
            lColWidth += ",20";                  // 2 - ItemName
            lColWidth += ",10";                  // 3 - SizeName
            lColWidth += ", 7";                  // 4 - ColorName    
           // lColWidth += ", 7";                  // 5 - UnitName    
            lColWidth += ", 7";                  // 6 - Discount
            //lColWidth += ", 7";                  // 7 - OrdQty
            lColWidth += ", 5";                  // 8 - DelQty
            lColWidth += ", 5";                  // 9 - DzRate  
            lColWidth += ", 5";                  //10 - PrRate 
            lColWidth += ", 5";
            lColWidth += ", 5";                  //11 - SizeID
            lColWidth += ", 5";                  //12 - ColorID
           // lColWidth += ", 5";                 //13 - UOMID


            // Column Input Length/Width
            lColMaxInputLen = "  0";                  // 0 - ItemID  
            lColMaxInputLen += ", 0";                 // 1 - ItemCode   
            lColMaxInputLen += ", 0";                 // 2 - ItemName
            lColMaxInputLen += ", 0";                 // 3 - SizeName
            lColMaxInputLen += ", 0";                 // 4 - ColorName  
            //lColMaxInputLen += ", 0";                 // 5 - UnitName  
            lColMaxInputLen += ", 0";                 // 6 - Discount
            //lColMaxInputLen += ", 0";                 // 7 - OrdQty
            lColMaxInputLen += ", 0";                 // 8 - DelQty
            lColMaxInputLen += ", 0";                 // 9 - DzRate
            lColMaxInputLen += ", 0";                 //10 - PrRate 
            lColMaxInputLen += ", 0";
            lColMaxInputLen += ", 0";                 //11 - SizeID
            lColMaxInputLen += ", 0";                 //12 - ColorID
           // lColMaxInputLen += ", 0";                 //13 - UOMID


            // Column Min Width
            lColMinWidth = "   0";                       // 0 - ItemID     
            lColMinWidth += ", 0";                       // 1 - ItemCode      
            lColMinWidth += ", 0";                       // 2 - ItemName 
            lColMinWidth += ", 0";                       // 3 - SizeName
            lColMinWidth += ", 0";                       // 4 - ColorName     
           // lColMinWidth += ", 0";                       // 5 - UnitName     
            lColMinWidth += ", 0";                       // 6 - Discount
            //lColMinWidth += ", 0";                       // 7 - OrdQty
            lColMinWidth += ", 0";                       // 8 - DelQty
            lColMinWidth += ", 0";                       // 9 - DzRate   
            lColMinWidth += ", 0";                       //10 - PrRate 
            lColMinWidth += ", 0";
            lColMinWidth += ", 0";                       //11 - SizeID
            lColMinWidth += ", 0";                       //12 - ColorID
           // lColMinWidth += ", 0";                       //13 - UOMID
           
            
            // Column Format
            lColFormat = "   T";                        // 0 - ItemID   
            lColFormat += ", T";                        // 1 - ItemCode   
            lColFormat += ", T";                        // 2 - ItemName
            lColFormat += ", T";                        // 3 - SizeName
            lColFormat += ", T";                        // 4 - ColorName  
           // lColFormat += ", T";                        // 5 - UnitName  
            lColFormat += ", T";                        // 6 - Discount
            //lColFormat += ", T";                        // 7 - OrdQty
            lColFormat += ", T";                        // 8 - DelQty
            lColFormat += ", T";                        // 9 - DzRate
            lColFormat += ", T";                        //10 - PrRate 
            lColFormat += ", T";
            lColFormat += ", H";                        //11 - SizeID
            lColFormat += ", H";                        //12 - ColorID
           // lColFormat += ", H";                        //13 - UOMID


            // Column ReadOnly 1= readonly, 0 = read-write
            lColReadOnly = "  0";                        // 0 - ItemID     
            lColReadOnly += ",1";                        // 1 - ItemCode      
            lColReadOnly += ",1";                        // 2 - ItemName
            lColReadOnly += ",0";                        // 3 - SizeName
            lColReadOnly += ",0";                        // 4 - ColorName     
      //      lColReadOnly += ",0";                        // 5 - UnitName     
            lColReadOnly += ",0";                        // 6 - Discount
            //lColReadOnly += ",0";                        // 7 - OrdQty
            lColReadOnly += ",0";                        // 8 - DelQty
            lColReadOnly += ",0";                        // 9 - DzRate   
            lColReadOnly += ",0";                        //10 - PrRate  
            lColReadOnly += ",0";
            lColReadOnly += ",1";                        //11 - SizeID
            lColReadOnly += ",1";                        //12 - ColorID
         //   lColReadOnly += ",1";                        //13 - UOMID
//

            // For Saving Time
            tColType += "  N0";              // 0 - ItemID
            tColType += ",SKP";              // 1 - ItemCode 
            tColType += ",SKP";              // 2 - ItemName
            tColType += ",SKP";              // 3 - SizeName
            tColType += ",SKP";              // 4 - ColorName
          //  tColType += ",SKP";              // 5 - UnitName
            tColType += ", N0";              // 6 - Discount
            //tColType += ", N0";              // 7 - OrdQty
            tColType += ", N0";              // 8 - DelQty
            tColType += ", N0";              // 9 - DzRate
            tColType += ", N0";              //10 - PrRate
            tColType += ", N0";
            tColType += ", N0";              //11 - SizeID
            tColType += ", N0";              //12 - ColorID
        //    tColType += ", N0";              //13 - UOMID


            tFieldName += "Code";                 // 0 - ItemID
            tFieldName += ",ItemCode";            // 1 - ItemCode   
            tFieldName += ",ItemName";            // 2 - ItemName
            tFieldName += ",SizeName";         // 3 - SizeName
            tFieldName += ",ColorName";            // 4 - ColorName    
       //     tFieldName += ",UnitName";           // 5 - UnitName    
            tFieldName += ",Discount";            // 6 - Discount
            //tFieldName += ",OrdQty";          // 7 - OrdQty
            tFieldName += ",DelQty";                 // 8 - DelQty
            tFieldName += ",DzRate";              // 9 - DzRate
            tFieldName += ",PrRate";             //10 - PrRate
            tFieldName += ",Amount";
            tFieldName += ",SizeID";               //11 - SizeID
            tFieldName += ",ColorID";            //12 - ColorID
      //      tFieldName += ",UOMID";        //13 - UOMID

            fHDR = lHDR;
            fColWidth = lColWidth;
            fColMaxInputLen = lColMaxInputLen;
            fColMinWidth = lColMinWidth;
            fColFormat = lColFormat;
            fColReadOnly = lColReadOnly;
            fFieldList = lFieldList;

            fColType = tColType;
            fFieldName = tFieldName;

        }

        private int GridTNOT(DataGridView pdGv)
        {
            int rtnValue = 0;
            try
            {
                //
                for (int dGVRow = 0; dGVRow < pdGv.Rows.Count; dGVRow++)
                {
                    if (pdGv.Rows[dGVRow].Cells[(int)GCol.ItemID].Value == null)
                    {
                        if (dGVRow == fLastRow)
                        {
                            break;
                        }
                    }
                    else
                    {
                        if ((pdGv.Rows[dGVRow].Cells[(int)GCol.ItemID].Value.ToString()).Trim(' ', '-') == "")
                        {
                            if (dGVRow == fLastRow)
                            {
                                break;
                            }
                        }
                    }

                    rtnValue++;
                } // End For loopo
                return rtnValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Grid TNOT: " + ex.Message, this.Text.ToString());
                return rtnValue;
            }
        }
        private void ClearThisForm()
        {
            if (grd.Rows.Count > 0)
            {
                grd.Rows.Clear();
            }
            ResetFields();
        }

        private void ResetFields()
        {
            // Reset Form Level Variables/Fields
            fEditMod = false;
            fTNOT = 0;
            fDocAmt = 0;
            fDocWhere = string.Empty;
            fLastRow = 0;
        }


        private void txtDONo_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc1();
            }
        }

        private void txt_I_ItemID_DoubleClick(object sender, EventArgs e)
        {
            frmItemsHelpAuto frm = new frmItemsHelpAuto();
            frm.ShowDialog();

            txt_I_ItemID.Text = frm.Ret_ItemID.ToString();
            lbl_I_ItemCode.Text = frm.Ret_ItemCode.ToString();
            lbl_I_ItemName.Text = frm.Ret_ItemName.ToString();
        }

        private void txt_I_ItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmItemsHelpAuto frm = new frmItemsHelpAuto();
                frm.ShowDialog();

                txt_I_ItemID.Text = frm.Ret_ItemID.ToString();
                lbl_I_ItemCode.Text = frm.Ret_ItemCode.ToString();
                lbl_I_ItemName.Text = frm.Ret_ItemName.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageBox.Show("Data Saved Successfullly");
        }

        private bool FormValidation()
        {
            bool lRtnValue = true;
            DateTime lNow = DateTime.Now;
            decimal lDebit = 0;
            decimal lCredit = 0;
            fDocAmt = 0;
            try
            {
                //SumVoc();

                return lRtnValue;

            }
            catch (Exception ex)
            {
                fTErr++;
                ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "Exception: FormValidation -> " + ex.Message.ToString());
                return false;
            }
        }

        private bool SaveData()
        {
            bool rtnValue = true;
            fTErr = 0;
            if (fManySQL != null)
            {
                if (fManySQL.Count() > 0)
                {
                    fManySQL.Clear();
                }
            }
            string lSQL = string.Empty;
            DateTime lNow = DateTime.Now;
            try
            {
                ErrrMsg = "";
                if (grd.Rows.Count < 1)
                {
                    fTErr++;
                    MessageBox.Show("No transaction in grid to Save", "Save: " + this.Text.ToString());
                    return false;
                }
                fLastRow = grd.Rows.Count - 1;
                if (!FormValidation())
                {
                    textAlert.Text = "Form Validation Error: Not Saved." + "  " + lNow.ToString();
                    MessageBox.Show(ErrrMsg, "Save: " + this.Text.ToString());
                    return false;
                }

                fManySQL = new List<string>();

                // Prepare Master Doc Query List
                fTNOT = GridTNOT(grd);
                if (!PrepareDocMaster())
                {
                    textAlert.Text = "DocMaster: Modifying Doc/Voucher not available for updation.'  ...." + "  " + lNow.ToString();
                    //tabMDtl.SelectedTab = tabError;
                    return false;
                }
                //
                if (grd.Rows.Count > 0)
                {
                    // Prepare Detail Doc Query List
                    if (!PrepareDocDetail())
                    {
                        return false;
                    }
                }
                else
                {
                    DateTime now = DateTime.Now;
                    textAlert.Text = "selected Box Empty... " + now.ToString("T");
                    // pending return false;
                }
                // Execute Query
                if (fManySQL.Count > 0)
                {
                    if (!clsDbManager.ExeMany(fManySQL))
                    {
                        MessageBox.Show("Not Saved see log...", this.Text.ToString());
                        return false;
                    }
                    else
                    {
                        fLastID = txtInvNo.Text.ToString();
                        ClearThisForm();
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Data Preparation list empty, Not Saved...", this.Text.ToString());
                    return false;
                } // End Execute Query
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Processing Save: " + ex.Message, "Save Data: " + this.Text.ToString());
                return false;
            }

        } // End Save

        private bool PrepareDocMaster()
        {
            bool rtnValue = true;
            string lSQL = string.Empty;

            try
            {
                if (txtInvNo.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    fDocID = clsDbManager.GetNextValDocID("Inv_Det", "DocId", fDocWhere, "");
                    fDocID = fDocID + 1;
                    strDocId = "1-" + DateTime.Now.Year.ToString() + "-" + fDocID.ToString();
                    txtInvNo.Text = strDocId;

                    lSQL = "insert into Inv_Det (";
                    lSQL += "  DocId ";
                    lSQL += ", Inv_No ";                              //  0-    ItemID";   
                    lSQL += ", Inv_Date ";                                //  1-    ItemCod  
                    lSQL += ", Customer ";                                        //  2-    ItemNam 
                    lSQL += ", Amount ";                                      // 3- Descripti
                    lSQL += ", Ord_No ";                                        //  4-    SizeNam  
                    lSQL += ", Ord_Date ";                                 //  5-    ColorNa  
                    lSQL += ", Qty ";                                      //  6-    UOMName
                    //lSQL += ", ItemGroupID ";                                      // 7- GodownName
                    lSQL += ", BillNo ";                                         // 8- Qty
                    lSQL += ", AddaID ";                                      // 9    SizeID";   
                    lSQL += " ) values (";
                    // 
               
                    lSQL += "" + fDocID.ToString() + "";                  //  0-    ItemID";   
                    lSQL += ",'" + txtInvNo.Text.ToString() + "'";        //  1-    ItemCod  
                    lSQL += ", " + StrF01.D2Str(dtpInv) + "";          //  2-    ItemName
                    lSQL += ",'" + mskCustomerCode.Text.ToString() + "'";  //  4-    SizeNam 
                    lSQL += ", 0";
                    lSQL += ", '" + txtDONo.Text.ToString() + "'";
                    lSQL += ", " + StrF01.D2Str(dtpDO) + "";
                    lSQL += ", 0";
                   // lSQL += ", '" + cboItemGroup.SelectedValue.ToString() + "'";
                    lSQL += ", '" + lblBillNo.Text.ToString() + "'";
                    lSQL += ", " + cboAdda.SelectedValue.ToString() + "";
                    lSQL += ")";                                              // 11    UOMID"; 
                }                                                               // 12- GodownID
                else
                {
                    fDocWhere = " Inv_No = '" + txtInvNo.Text.ToString() + "'";
                    if (clsDbManager.IDAlreadyExistWw("Inv_Det", "Inv_No", fDocWhere))
                    {

                        fDocAlreadyExists = true;
                        lSQL = "delete from Inv_Hist ";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);
                        //
                    }

                    lSQL = "update Inv_Det set";
                    //lSQL += ", Inv_Date ";                                //  1-    ItemCod  
                    //lSQL += ", Customer ";                                        //  2-    ItemNam 
                    //lSQL += ", Amount ";                                      // 3- Descripti
                    //lSQL += ", Ord_No ";                                        //  4-    SizeNam  
                    //lSQL += ", Ord_Date ";                                 //  5-    ColorNa  
                    //lSQL += ", Qty ";                                      //  6-    UOMName
                    //lSQL += ", ItemGroupID ";                                      // 7- GodownName
                    //lSQL += ", BillNo ";                                         // 8- Qty
                    //lSQL += ", AddaID ";                                      // 9    SizeID";   
                    //lSQL += " ) values (";

                    lSQL += "  Inv_Date = '" + StrF01.D2Str(dtpInv.Value) + "'";
                    lSQL += ", Customer = '" + mskCustomerCode.Text.ToString() + "'";
                    lSQL += ", Amount = 0";
                    lSQL += ", Ord_No = '" + txtDONo.Text.ToString() + "'";
                    lSQL += ", Ord_Date = " + StrF01.D2Str(dtpDO) + "";
                    lSQL += ", Qty = 0";
                    //lSQL += ", ItemGroupID = '" + cboItemGroup.Text.ToString() + "'";
                    lSQL += ", BillNo = '" + lblBillNo.Text.ToString() + "'";
                    lSQL += ", AddaID = " + cboAdda.SelectedValue.ToString() + "";
                    lSQL += " where ";
                    lSQL += fDocWhere;

                }
                fManySQL.Add(lSQL);


                return rtnValue;
            }
            catch (Exception ex)
            {
                rtnValue = false;
                MessageBox.Show("Save Master Doc: " + ex.Message, this.Text.ToString());
                return false;
            }
        }

        private bool PrepareDocDetail()
        {
            bool rtnValue = true;
            string lSQL = "";
            try
            {
                for (int dGVRow = 0; dGVRow < grd.Rows.Count; dGVRow++)
                {
                    if (grd.Rows[dGVRow].Cells[(int)GCol.ItemID].Value == null)
                    {
                        if (dGVRow == fLastRow)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if ((grd.Rows[dGVRow].Cells[(int)GCol.ItemID].Value.ToString()).Trim(' ', '-') == "")
                        {
                            //lBlank = true;
                            if (dGVRow == fLastRow)
                            {
                                continue;
                            }
                        }
                    }

                    // 0 - ItemID
                    // 1 - ItemCode 
                    // 2 - ItemName
                    // 3 - SizeName
                    // 4 - ColorName
                    // 5 - UnitName
                    // 6 - Discount
                    // 7 - OrdQty
                    // 8 - DelQty
                    // 9 - DzRate
                    //10 - PrRate
                    //11 - SizeID
                    //12 - ColorID
                    //13 - UOMID
                                                                                                           
                                                                                                            //  lSQL = "INSERT INTO DO_Hist (DocId";
                    lSQL = "INSERT INTO Inv_Hist (DocId";                                                  //  lSQL += ",DO_No,Code,SizeId,ColorID,Rate,Qty,FromDelivery)";
                    lSQL += ",Inv_No,Code,SizeID,ColorID,Discount,Rate,Qty)";                              //  lSQL += " VALUES (";
                    lSQL += " VALUES (";                                                                   //  lSQL += "" + fDocID + "";
                    lSQL += "" + fDocID + "";                                                              //  lSQL += ", '" + strDocId.ToString() + "'";
                    lSQL += ", '" + strDocId.ToString() + "'";                                             //  lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColDO.ItemID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColInv.ItemID].Value.ToString() + "";     //   lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColDO.SizeID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColInv.SizeID].Value.ToString() + "";    //   lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColDO.ColorID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColInv.ColorID].Value.ToString() + "";      //  lSQL += ", 100";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColInv.Discount].Value.ToString() + "";    //  lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColDO.OrdQty].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColInv.PrRate].Value.ToString() + "";      //  lSQL += ", 0";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColInv.DelQty].Value.ToString() + "";      //  lSQL += ")";
                    lSQL += ")";                                                                           //  fManySQL.Add(lSQL);
                    fManySQL.Add(lSQL);
                } // End For loopo
                return rtnValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Detail Doc: " + ex.Message, this.Text.ToString());
                return false;
            }

        }

        private void SumVoc()
        {
            bool bcheck;
            decimal fQty = 0;
            decimal fAmount = 0;
            decimal rtnVal = 0;
            decimal outValue = 0;

            decimal InvTotal1 = 0;
            decimal InvTotal2 = 0;
            decimal InvTotal = 0;

            for (int i = 0; i < grd.RowCount; i++)
            {
                InvTotal1 = decimal.Parse(grd.Rows[i].Cells[(int)GColInv.PrRate].Value.ToString());
                InvTotal2 = decimal.Parse(grd.Rows[i].Cells[(int)GColInv.DelQty].Value.ToString());
                InvTotal = InvTotal1 * InvTotal2;

                //if (grd.Rows[i].Cells[(int)GColInv.InvTotal].Value != null)
                //if (InvTotal != null)
                //{
                //    //bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GColInv.InvTotal].Value.ToString(), out outValue);
                //    //if (bcheck)
                //    //{
                //    //    rtnVal += outValue;
                fAmount += InvTotal;
                //   // fAmount = fAmount + outValue;
                //    //}
                //}

                if (grd.Rows[i].Cells[(int)GColInv.DelQty].Value != null)
                {
                    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GColInv.DelQty].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fQty = fQty + outValue;
                    }
                } // if != null
                //grdVoucher[2, i].Value = (i + 1).ToString();
            }

            lblInvTotal.Text = String.Format("{0:0,0.00}", fAmount);
            lblInvQty.Text = String.Format("{0:0,0.00}", fQty);
        }

        //private void SumVoc()
        //{
        //    bool bcheck;
        //    decimal fQty = 0;
        //    decimal fAmount = 0;
        //    decimal rtnVal = 0;
        //    decimal outValue = 0;

        //    for (int i = 0; i < grd.RowCount; i++)
        //    {
        //        if (grd.Rows[i].Cells[(int)GColInv.Amount].Value != null)
        //        {
        //            bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GColInv.Amount].Value.ToString(), out outValue);
        //            if (bcheck)
        //            {
        //                rtnVal += outValue;
        //                fAmount = fAmount + outValue;
        //            }
        //        }
        //        //if (grd.Rows[i].Cells[(int)GColDO.DelQty].Value != null)
        //        //{
        //        //    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GColDO.DelQty].Value.ToString(), out outValue);
        //        //    if (bcheck)
        //        //    {
        //        //        rtnVal += outValue;
        //        //        fQty = fQty + outValue;
        //        //    }
        //        //} // if != null
        //        //grdVoucher[2, i].Value = (i + 1).ToString();
        //    }

        //    lblInvTotal.Text = String.Format("{0:0,0.00}", fAmount);
        //    //lblInvQty.Text = String.Format("{0:0,0.00}", fQty);
        //}


        private void btnIrnHelp_Click(object sender, EventArgs e)
        {
            LookUp_Voc();
        }
        
        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void btnNewInv_Click(object sender, EventArgs e)
        {
            grd.Rows.Clear();
            ClearTextBoxes();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            frmEmail frm = new frmEmail();
            frm.ShowDialog();
        }
    }
}
