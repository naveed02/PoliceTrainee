using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI_Task.Class;
using JThomas.Controls;
using GUI_Task.StringFun01;

namespace GUI_Task
{
    enum GColSaleRet
    {
        ItemID = 0,       // 0 - ItemID
        ItemCode = 1,     // 1 - ItemCode 
        ItemName = 2,     // 2 - ItemName
        SizeName = 3,     // 3 - SizeName
        ColorName = 4,    // 4 - ColorName
        GodownName = 5,   // 5 - GodownName
        Discount = 6,     // 6 - Discount
        InvQty = 7,       // 7 - OrdQty
        RetQty = 8,       // 8 - RetQty
        RemQty = 9,       // 9 - RemQty
        Rate = 10,        // 10- Rate
        SizeID = 11,      // 11- SizeID
        ColorID = 12,     // 12- ColorID
        GodownID = 13     // 13- GodownID
    }

    public partial class frmSalesRtnEntry : Form
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
        
        public frmSalesRtnEntry()
        {
            InitializeComponent();
        }

        private void frmSalesRtnEntry_Load(object sender, EventArgs e)
        {
            AtFormLoad();
            blnFormLoad = false;
            this.MaximizeBox = false;
            Cursor.Current = Cursors.Arrow;
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



            //Main Group Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmMainGroup);
            lSQL += " order by cgdDesc";


            clsFillCombo.FillCombo(cboMainGroup, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboMainGroup.SelectedValue);

            //ItemGroup Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmItemGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGroup, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGroup.SelectedValue);

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

            //FromGodown cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmGodown);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboGodown, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboGodown.SelectedValue);
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
                14,
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
            lSQL += " clr.cgdDesc AS ColorName, gd.cgdDesc AS GodownName, h.Discount, ";
            lSQL += " h.Ord_Qty AS InvQty, h.Qty AS RetQty, (isnull(h.Ord_Qty,0)-h.Qty) AS RemQty, h.Rate, (h.Qty*h.Rate) AS Amount, h.SizeId, h.ColorID, h.GodownID ";
			lSQL += " from InvR_Hist h INNER JOIN Item i ON h.Code=i.ItemId ";
            lSQL += " INNER JOIN CatDtl sz ON h.SizeId=sz.cgdCode AND sz.cgCode=5 ";
            lSQL += " INNER JOIN CatDtl clr ON h.ColorID=clr.cgdCode AND clr.cgCode = 3 ";
            lSQL += " INNER JOIN IMS_UOM u ON u.UOMID=u.UOMID ";
            lSQL += " INNER JOIN CatDtl gd ON gd.cgdCode=h.GodownID AND gd.cgCode = 2 ";
            lSQL += " INNER JOIN Inv_Det inv ON inv.Ord_No = h.Ord_No ";
            lSQL += " where h.Ret_No = '" + txtInvRetNo.Text.ToString() + "'; ";

            clsDbManager.FillDataGrid(
                grd,
                lSQL,
                fFieldList,
                fColFormat);
        }

        private void LoadGridData1()
        {
            string lSQL = "";
            lSQL += " select h.Code, i.ItemCode, i.Name AS ItemName, sz.cgdDesc AS SizeName, ";
            lSQL += " clr.cgdDesc AS ColorName, '' AS GodownName, h.Discount, ";
            lSQL += " h.Ord_Qty AS InvQty, h.Qty AS RetQty, (isnull(h.Ord_Qty,0)-h.Qty) AS RemQty, ";
            lSQL += " h.Rate, (h.Qty*h.Rate) AS Amount, h.SizeId, h.ColorID, 0 AS GodownID ";
            lSQL += " from Inv_Hist h ";
            lSQL += " INNER JOIN Item i ON h.Code=i.ItemId ";
            lSQL += " INNER JOIN CatDtl sz ON h.SizeId=sz.cgdCode AND sz.cgCode=5 ";
            lSQL += " INNER JOIN CatDtl clr ON h.ColorID=clr.cgdCode AND clr.cgCode = 3 ";
            lSQL += " INNER JOIN IMS_UOM u ON u.UOMID=u.UOMID ";
            lSQL += " INNER JOIN Inv_Det inv ON inv.Ord_No = h.Ord_No ";
            lSQL += " where h.Inv_No = '" + txtInvNo.Text.ToString() + "'; ";

            clsDbManager.FillDataGrid(
                grd,
                lSQL,
                fFieldList,
                fColFormat);
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
                }

            }
        }

        private void PassData1(object sender)
        {
            mskCustomerCode.Mask = "";
            mskCustomerCode.Text = ((TextBox)sender).Text;
            mskCustomerCode.Mask = clsGVar.maskGLCode; 
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
                    lblCustName.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                    }
                    LoadGridData();
                    SumVoc();
                    //txtManualDoc.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
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
            //txtPassDataVocID.Text = ((TextBox)sender).Text;
            txtInvNo.Text = ((TextBox)sender).Text;
            //msk_VocCode.Text = ((MaskedTextBox)sender).Text;
        }

        #region PopulateRecords
        //Populate Recordset 
        private void PopulateRecords()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin 

            tSQL += " select inv.Inv_No, inv.Inv_Date, inv.SaleType, inv.Adda, inv.Do_No, inv.Customer, ";
			tSQL += " c.Name AS CustName, inv.Do_Date, inv.Ord_Date, inv.Detail, d.Qty AS DelQty, inv.Bilty_Date, ";
			tSQL += " inv.Bilty_No, cd.cgdDesc AS ItemGroupName ";		 
            tSQL += " from Inv_Det inv "; 
            tSQL += " INNER JOIN CustGroup c ON c.Code = inv.Customer ";
            tSQL += " INNER JOIN DO_Hist d ON d.DO_No = inv.Do_No ";
            tSQL += " INNER JOIN CatDtl cd ON inv.ItemGroupID = cd.cgdCode AND cd.cgCode = 6 ";
             
            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Heads");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    lblInvDate.Text = (ds.Tables[0].Rows[0]["Inv_Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Inv_Date"].ToString());
                    txtSaleType.Text = (ds.Tables[0].Rows[0]["SaleType"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["SaleType"].ToString());
                    txtDONo.Text = (ds.Tables[0].Rows[0]["Do_No"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Do_No"].ToString());
                    cboAdda.Text = (ds.Tables[0].Rows[0]["Adda"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Adda"].ToString());
                    mskCustomerCode.Text = (ds.Tables[0].Rows[0]["Customer"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Customer"].ToString());
                    lblDODate.Text = (ds.Tables[0].Rows[0]["Do_Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Do_Date"].ToString());
                    lblCustName.Text = (ds.Tables[0].Rows[0]["CustName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CustName"].ToString());
                    lblOrdDate.Text = (ds.Tables[0].Rows[0]["Ord_Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ord_Date"].ToString());
                    txtDetails.Text = (ds.Tables[0].Rows[0]["Detail"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Detail"].ToString());
                    lblDelQty.Text = (ds.Tables[0].Rows[0]["DelQty"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DelQty"].ToString());
                    dtpBuilty.Text = (ds.Tables[0].Rows[0]["Bilty_Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Bilty_Date"].ToString());
                    txtBulityNo.Text = (ds.Tables[0].Rows[0]["Bilty_No"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Bilty_No"].ToString());
                    cboItemGroup.Text = (ds.Tables[0].Rows[0]["ItemGroupName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemGroupName"].ToString());
                    
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                    }
                    //lblBillNo.Text = (ds.Tables[0].Rows[0]["BillNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BillNo"].ToString());
                    LoadGridData1();
                    SumVoc();
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }

        #endregion

        #region LookUp_Voc1

        private void LookUp_Voc1()
        {
            frmLookUp sForm = new frmLookUp(
                    "id.Ret_No",
                    "id.Ret_Date, id.Detail, id.Qty, id.Amount",
                    " InvR_Det id",
                    this.Text.ToString(),
                    1,
                    "Invoice No.,Date,Detail,Qty,Amount ",
                    "10,8,15,8,8",
                    " T, T, T, T, T",
                    true,
                    "",
                    "",
                    "TextBox"
                    );

            txtInvRetNo.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID1);
            sForm.ShowDialog();

            if (txtInvRetNo.Text != null)
            {
                if (txtInvRetNo.Text != null)
                {
                    if (txtInvRetNo.Text.ToString() == "" || txtInvRetNo.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtInvRetNo.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecords1();
                    }

                }

            }
        }
        #endregion

        private void PassDataVocID1(object sender)
        {
            //txtPassDataVocID.Text = ((TextBox)sender).Text;
            txtInvRetNo.Text = ((TextBox)sender).Text;
            //msk_VocCode.Text = ((MaskedTextBox)sender).Text;
        }

        #region PopulateRecords1
        //Populate Recordset 
        private void PopulateRecords1()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

           tSQL += " select id.Ret_No, id.Ret_Date, i.Inv_No, id.SaleType, id.Do_No, id.Adda, ";
		   tSQL += " i.Inv_Date, id.Customer, c.Name AS CustName, id.Do_Date, id.Ord_Date, ";
		   tSQL += " id.Detail, i.Qty, id.Bilty_Date, id.Bilty_No, cd.cgdDesc AS ItemGroupName, ";
		   tSQL += " id.Qty AS RetQty, (ih.Rate*id.Qty) AS Amount ";
           tSQL += " from InvR_Det id INNER JOIN Inv_Det i ON id.Customer = i.Customer ";
           tSQL += " INNER JOIN Customer c ON RIGHT(id.Customer, 10)= c.Code ";
           tSQL += " INNER JOIN CatDtl cd ON id.ItemGroupID = cd.cgdCode AND cd.cgCode = 6 ";
           tSQL += " INNER JOIN Inv_Hist ih ON id.Customer = ih.Customer ";
          
            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Heads");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    dtpInvRetDate.Text = (ds.Tables[0].Rows[0]["Ret_Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ret_Date"].ToString());
                    txtInvNo.Text = (ds.Tables[0].Rows[0]["Inv_No"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Inv_No"].ToString());
                    txtSaleType.Text = (ds.Tables[0].Rows[0]["SaleType"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["SaleType"].ToString());
                    txtDONo.Text = (ds.Tables[0].Rows[0]["Do_No"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Do_No"].ToString());
                    cboAdda.Text = (ds.Tables[0].Rows[0]["Adda"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Adda"].ToString());
                    lblInvDate.Text = (ds.Tables[0].Rows[0]["Inv_Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Inv_Date"].ToString());
                    mskCustomerCode.Text = (ds.Tables[0].Rows[0]["Customer"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Customer"].ToString());
                    lblCustName.Text = (ds.Tables[0].Rows[0]["CustName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CustName"].ToString());
                    lblDODate.Text = (ds.Tables[0].Rows[0]["Do_Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Do_Date"].ToString());
                    lblOrdDate.Text = (ds.Tables[0].Rows[0]["Ord_Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ord_Date"].ToString());
                    txtDetails.Text = (ds.Tables[0].Rows[0]["Detail"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Detail"].ToString());
                    lblDelQty.Text = (ds.Tables[0].Rows[0]["Qty"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Qty"].ToString());
                    dtpBuilty.Text = (ds.Tables[0].Rows[0]["Bilty_Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Bilty_Date"].ToString());
                    txtBulityNo.Text = (ds.Tables[0].Rows[0]["Bilty_No"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Bilty_No"].ToString());
                    cboItemGroup.Text = (ds.Tables[0].Rows[0]["ItemGroupName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemGroupName"].ToString());
                    lblRetVal.Text = (ds.Tables[0].Rows[0]["Amount"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Amount"].ToString());
                    lblRetQty.Text = (ds.Tables[0].Rows[0]["RetQty"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["RetQty"].ToString());

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                    }
                    
                     LoadGridData();
                     LoadGridData1();
                     SumVoc();
                    
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grd.Rows.Add(txt_I_ItemID.Text.ToString(),   // 0 - ItemID
               lbl_I_ItemCode.Text.ToString(),           // 1 - ItemCode 
               lbl_I_ItemName.Text.ToString(),           // 2 - ItemName
               cbo_I_Size.Text.ToString(),               // 3 - SizeName
               cbo_I_Color.Text.ToString(),              // 4 - ColorName
               cboGodown.Text.ToString(),                // 5 - GodownName
               "0",                                      // 6 - Discount
               lblDelQty.Text.ToString(),                // 7 - OrdQty
               txtRetQty.Text.ToString(),                // 8 - RetQty
               "0",                                     // 9 - RemQty
               "0",                                       // 10- Rate
   cbo_I_Size.SelectedValue.ToString(),                  // 11- SizeID
   cbo_I_Color.SelectedValue.ToString(),                 // 12- ColorID
   cboGodown.SelectedValue.ToString());                  // 13- GodownID

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
            lFieldList = "Code";             // 0 - ItemID
            lFieldList += ",ItemCode";       // 1 - ItemCode    
            lFieldList += ",ItemName";       // 2 - ItemName
            lFieldList += ",SizeName";       // 3 - SizeName
            lFieldList += ",ColorName";      // 4 - ColorName      
            lFieldList += ",GodownName";       // 6 - GodownName
            lFieldList += ",Discount";       // 7 - Discount
            lFieldList += ",InvQty";         // 8 - OrdQty
            lFieldList += ",RetQty";         // 9 - RetQty
            lFieldList += ",RemQty";         // 10- RemQty
            lFieldList += ",Rate";         // 11- Rate
            lFieldList += ",SizeID";        // 12- SizeID
            lFieldList += ",ColorID";         // 13- ColorID
            lFieldList += ",GodownID";      // 15- GodownID


            lHDR += "Item ID";             // 0 - ItemID
            lHDR += ",Item Code";          // 1 - ItemCode  
            lHDR += ",Item Name";          // 2 - ItemName
            lHDR += ",Size";               // 3 - SizeName
            lHDR += ",Color";              // 4 - ColorName 
            lHDR += ",Godown";           // 6 - GodownName
            lHDR += ",Discount";           // 7 - Discount
            lHDR += ",InvQty";             // 8 - OrdQty
            lHDR += ",RetQty";             // 9 - RetQty
            lHDR += ",RemQty";             // 10- RemQty
            lHDR += ",Rate";             // 11- Rate
            lHDR += ",SizeID";            // 12- SizeID
            lHDR += ",ColorID";              // 13- ColorID
            lHDR += ",GodownID";    // 15- GodownID


            // Col Visible Width
            lColWidth = "   5";                 // 0 - ItemID
            lColWidth += ",12";                 // 1 - ItemCode 
            lColWidth += ",20";                 // 2 - ItemName
            lColWidth += ",10";                 // 3 - SizeName
            lColWidth += ", 10";                 // 4 - ColorName
            lColWidth += ", 10";                 // 6 - GodownName
            lColWidth += ", 7";                 // 7 - Discount
            lColWidth += ", 5";                 // 8 - OrdQty
            lColWidth += ", 5";                 // 9 - RetQty
            lColWidth += ", 5";                 // 10- RemQty
            lColWidth += ", 5";                 // 11- Rate
            lColWidth += ", 5";                 // 12- SizeID
            lColWidth += ", 5";                 // 13- ColorID
            lColWidth += ", 5";                 // 15- GodownID


            // Column Input Length/Width
            lColMaxInputLen = "  0";                 // 0 - ItemID
            lColMaxInputLen += ", 0";                // 1 - ItemCode 
            lColMaxInputLen += ", 0";                // 2 - ItemName
            lColMaxInputLen += ", 0";                // 3 - SizeName
            lColMaxInputLen += ", 0";                // 4 - ColorName
            lColMaxInputLen += ", 0";                // 6 - GodownName
            lColMaxInputLen += ", 0";                // 7 - Discount
            lColMaxInputLen += ", 0";                // 8 - OrdQty
            lColMaxInputLen += ", 0";                // 9 - RetQty
            lColMaxInputLen += ", 0";                // 10- RemQty
            lColMaxInputLen += ", 0";                // 11- Rate
            lColMaxInputLen += ", 0";                // 12- SizeID
            lColMaxInputLen += ", 0";                // 13- ColorID
            lColMaxInputLen += ", 0";                // 15- GodownID

            // Column Min Width
            lColMinWidth = "   0";                       // 0 - ItemID  
            lColMinWidth += ", 0";                       // 1 - ItemCode      
            lColMinWidth += ", 0";                       // 2 - ItemName
            lColMinWidth += ", 0";                       // 3 - SizeName
            lColMinWidth += ", 0";                       // 4 - ColorName     
            lColMinWidth += ", 0";                       // 6 - GodownName
            lColMinWidth += ", 0";                       // 7 - Discount
            lColMinWidth += ", 0";                       // 8 - OrdQty
            lColMinWidth += ", 0";                       // 9 - RetQty
            lColMinWidth += ", 0";                       // 10- RemQty 
            lColMinWidth += ", 0";                       // 11- Rate
            lColMinWidth += ", 0";                       // 12- SizeID
            lColMinWidth += ", 0";                       // 13- ColorID
            lColMinWidth += ", 0";                       // 15- GodownID
            
            // Column Format
            lColFormat = "   T";                        // 0 - ItemID
            lColFormat += ", T";                        // 1 - ItemCode  
            lColFormat += ", T";                        // 2 - ItemName
            lColFormat += ", T";                        // 3 - SizeName
            lColFormat += ", T";                        // 4 - ColorName 
            lColFormat += ", T";                        // 6 - GodownName
            lColFormat += ", T";                        // 7 - Discount
            lColFormat += ", T";                        // 8 - OrdQty
            lColFormat += ", T";                        // 9 - RetQty
            lColFormat += ", T";                        // 10- RemQty
            lColFormat += ", T";                        // 11- Rate
            lColFormat += ", H";                        // 12- SizeID
            lColFormat += ", H";                        // 13- ColorID
            lColFormat += ", H";                        // 15- GodownID


            // Column ReadOnly 1= readonly, 0 = read-write
            lColReadOnly = "  0";                         // 0 - ItemID 
            lColReadOnly += ",1";                         // 1 - ItemCode      
            lColReadOnly += ",1";                         // 2 - ItemName
            lColReadOnly += ",0";                         // 3 - SizeName
            lColReadOnly += ",0";                         // 4 - ColorName     
            lColReadOnly += ",0";                         // 6 - GodownName
            lColReadOnly += ",0";                         // 7 - Discount
            lColReadOnly += ",0";                         // 8 - OrdQty
            lColReadOnly += ",0";                         // 9 - RetQty
            lColReadOnly += ",0";                         // 10- RemQty
            lColReadOnly += ",0";                         // 11- Rate
            lColReadOnly += ",1";                         // 12- SizeID
            lColReadOnly += ",1";                         // 13- ColorID
            lColReadOnly += ",1";                         // 15- GodownID


            // For Saving Time
            tColType += "  N0";               // 0 - ItemID
            tColType += ",SKP";               // 1 - ItemCode  
            tColType += ",SKP";               // 2 - ItemName
            tColType += ",SKP";               // 3 - SizeName
            tColType += ",SKP";               // 4 - ColorName 
            tColType += ",SKP";               // 6 - GodownName
            tColType += ", N0";               // 7 - Discount
            tColType += ", N0";               // 8 - OrdQty
            tColType += ", N0";               // 9 - RetQty
            tColType += ", N0";               // 10- RemQty
            tColType += ", N0";               // 11- Rate
            tColType += ", N0";               // 12- SizeID
            tColType += ", N0";               // 13- ColorID
            tColType += ", N0";               // 15- GodownID


            tFieldName += "Code";           // 0 - ItemID
            tFieldName += ",ItemCode";      // 1 - ItemCode  
            tFieldName += ",ItemName";      // 2 - ItemName
            tFieldName += ",SizeName";      // 3 - SizeName
            tFieldName += ",ColorName";     // 4 - ColorName 
            tFieldName += ",GodownName";    // 6 - GodownName
            tFieldName += ",Discount";      // 7 - Discount
            tFieldName += ",InvQty";        // 8 - OrdQty
            tFieldName += ",RetQty";        // 9 - RetQty
            tFieldName += ",RemQty";        // 10- RemQty
            tFieldName += ",Rate";          // 11- Rate
            tFieldName += ",SizeID";        // 12- SizeID
            tFieldName += ",ColorID";       // 13- ColorID
            tFieldName += ",GodownID";      // 15- GodownID

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

        private void txtInvNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
        }

        private void txtInvNo_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        private void frmSalesRtnEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtInvRetNo_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc1();
        }

        private void txtInvRetNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc1();
            }
        }

       
        #region LookUp_Voc2

        private void LookUp_Voc2()
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
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID2);
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
                        PopulateRecords2();
                    }

                }

            }
        }
        #endregion

        private void PopulateRecords2()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin 

            tSQL += " select d.Do_No, d.Do_Date, d.BillNo, c.Code, c.Name, d.Detail, d.Qty, d.Amount ";
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


                    mskCustomerCode.Text = (ds.Tables[0].Rows[0]["Code"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Code"].ToString());
                    lblCustName.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                    }
                    //LoadGridData();
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }

        private void PassDataVocID2(object sender)
        {
            txtDONo.Text = ((TextBox)sender).Text;
        }

        private void txtDONo_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc2();
        }

        private void txtDONo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc2();
            }
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
                if (txtInvRetNo.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    fDocID = clsDbManager.GetNextValDocID("InvR_Det", "DocId", fDocWhere, "");
                    fDocID = fDocID + 1;
                    strDocId = "1-" + DateTime.Now.Year.ToString() + "-" + fDocID.ToString();
                    txtDONo.Text = strDocId;

                    lSQL = "insert into InvR_Det (";
                    lSQL += " DocId ";
                    lSQL += ", Ret_No ";                              //  0-    ItemID";   
                    lSQL += ", Ret_Date ";                                //  1-    ItemCod  
                    lSQL += ", Customer ";                                        //  2-    ItemNam 
                    lSQL += ", Amount ";                                      // 3- Descripti
                    lSQL += ", Qty ";                                        //  4-    SizeNam  
                    lSQL += ", Discount ";                                 //  5-    ColorNa  
                    lSQL += ", AddaID ";                                      //  6-    UOMName
                    lSQL += ", Detail ";                                      // 7- GodownName
                    lSQL += ", Category ";                                         // 8- Qty
                    lSQL += ", ItemGroupID ";                                      // 9    SizeID";   
                    lSQL += " ) values (";
                    // 

                    lSQL += "" + fDocID.ToString() + "";                  //  0-    ItemID";   
                    lSQL += ",'" + strDocId.ToString() + "'";          //  1-    ItemCod  
                    lSQL += ", " + StrF01.D2Str(dtpInvRetDate) + "";          //  2-    ItemName
                    lSQL += ",'" + mskCustomerCode.Text.ToString() + "'";  //  4-    SizeNam 
                    lSQL += ", 0";
                    lSQL += ", 0";
                    lSQL += ", 0";
                    lSQL += ", " + cboAdda.SelectedValue.ToString() + "";
                    lSQL += ",''";
                    lSQL += ", " + cboCategory.SelectedValue.ToString() + "";
                    lSQL += ", " + cboItemGroup.SelectedValue.ToString() + "";
                    lSQL += ")";                                              
                }                                                             
                else
                {
                    fDocWhere = " Ret_No = '" + txtInvRetNo.Text.ToString() + "'";
                    if (clsDbManager.IDAlreadyExistWw("InvR_Det", "Ret_No", fDocWhere))
                    {

                        fDocAlreadyExists = true;
                        lSQL = "delete from InvR_Hist ";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);
                        //
                    }

                    lSQL = "update InvR_Det set";
                    lSQL += "  Ret_Date = '" + StrF01.D2Str(dtpInvRetDate.Value) + "'";
                    lSQL += ", Customer = '" + mskCustomerCode.Text.ToString() + "'";
                    lSQL += ", Amount = 0";
                    lSQL += ", Qty = 0";
                    lSQL += ", Discount = 0";
                    lSQL += ", AddaID = '" + cboAdda.Text.ToString() + "'";
                    lSQL += ", Detail = '" + txtDetails.Text.ToString() + "'";
                    lSQL += ", Category = '" + cboCategory.SelectedValue.ToString() + "'";
                    lSQL += ", ItemGroupID = '" + cboItemGroup.SelectedValue.ToString() + "'";
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
                    // 6 - GodownName
                    // 7 - Discount
                    // 8 - OrdQty
                    // 9 - RetQty
                    // 10- RemQty
                    // 11- Rate
                    // 12- SizeID
                    // 13- ColorID
                    // 14- UOMID
                    // 15- GodownID

                    lSQL = "INSERT INTO InvR_Hist (DocId";
                    lSQL += ",Ret_No,Code,ColorID,SizeId,Discount,Rate,Qty)";
                    lSQL += " VALUES (";
                    lSQL += "" + fDocID + "";
                    lSQL += ", '" + strDocId.ToString() + "'";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColSaleRet.ItemID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColSaleRet.ColorID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColSaleRet.SizeID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColSaleRet.Discount].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColSaleRet.Rate].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColSaleRet.RetQty].Value.ToString() + "";
                    lSQL += ")";
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageBox.Show("Data Saved Successfullly");
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

        private void btnInvHelp_Click(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        private void SumVoc()
        {
            bool bcheck;
            decimal fQty = 0;
            decimal fAmount = 0;
            decimal rtnVal = 0;
            decimal outValue = 0;

            for (int i = 0; i < grd.RowCount; i++)
            {
                if (grd.Rows[i].Cells[(int)GColSaleRet.Rate].Value != null)
                {
                    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GColSaleRet.Rate].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fAmount = fAmount + outValue;
                    }
                }

                if (grd.Rows[i].Cells[(int)GColSaleRet.RetQty].Value != null)
                {
                    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GColSaleRet.RetQty].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fQty = fQty + outValue;
                    }
                } // if != null
                //grdVoucher[2, i].Value = (i + 1).ToString();
            }

            lblRetVal.Text = String.Format("{0:0,0.00}", fAmount);
            lblRetQty.Text = String.Format("{0:0,0.00}", fQty);
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
    }                                                       
}                                                           
