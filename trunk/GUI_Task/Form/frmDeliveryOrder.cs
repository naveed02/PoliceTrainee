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
using System.Net.Mail;

namespace GUI_Task
{
    enum GColDO
    {
        ItemID = 0,
        ItemCode = 1,
        ItemName = 2,
        SizeName = 3,
        ColorName = 4,
        UnitName = 5,
        AvailBal = 6,
        OrdQty = 7,
        PrevDel = 8,
        DelQty = 9,
        RemQty = 10,
        AfterBal = 11,
        SizeID = 12,
        ColorID = 13,
        UOMID = 14,
       
    }

    public partial class frmDeliveryOrder : Form
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

        bool blnFormLoad = true;
        int fcboDefaultValue = 0;

        string strDocId = string.Empty;



        public frmDeliveryOrder()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDeliveryOrder_Load(object sender, EventArgs e)
        {
            AtFormLoad();
            blnFormLoad = false;
            this.MaximizeBox = false;
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

            //ItemGroup Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmItemGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGroup, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGroup.SelectedValue);


            //Transport Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmAdda);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboAdda, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboAdda.SelectedValue);

            //FromGodown cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmGodown);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboGodown, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboGodown.SelectedValue);

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

            //UOM Combo Fill
            lSQL = "select UOMID, UnitName from IMS_UOM order by UnitName";

            clsFillCombo.FillCombo(cbo_I_UOM, clsGVar.ConString1, "IMS_UOM" + "," + "UnitName" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cbo_I_UOM.SelectedValue);

            ds = clsDbManager.GetData_Set(lSQL, "IMS_UOM");
            UnitColumn.DataSource = ds.Tables[0];
            UnitColumn.ValueMember = ds.Tables[0].Columns[0].ToString();
            UnitColumn.DisplayMember = ds.Tables[0].Columns[1].ToString();
            ds.Clear();

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
                15,
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
            lSQL += " SELECT h.Code, i.ItemCode, i.Name AS ItemName, sz.cgdDesc AS SizeName, ";
            lSQL += " clr.cgdDesc AS ColorName, ";
            lSQL += " u.UnitName, 0 AS AvailBal, 0 AS OrdQty, 0 AS PrevDel, 0 AS DelQty, 0 AS RemQty, ";
            lSQL += " 0 AS AfterBal, h.SizeID, h.ColorID, i.UOMID ";
            lSQL += " from DO_Hist h INNER JOIN Item i ON h.Code=i.ItemId ";
            lSQL += " JOIN CatDtl clr ON h.ColorID=clr.cgdCode AND clr.cgCode=3 ";
            lSQL += " INNER JOIN CatDtl sz ON h.sizeid=sz.cgdCode AND sz.cgCode=5 ";
            lSQL += " INNER JOIN IMS_UOM u ON i.UOMID=u.UOMID ";
            lSQL += " where h.Do_No = '" + txtDONo.Text.ToString() + "'; ";

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
                    //LoadGridData();
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
                    "dt.DO_No",
                    "dt.Do_Date, dt.BillNo, dt.Customer, dt.Detail, dt.Qty",
                    " DO_Det dt",
                    this.Text.ToString(),
                    1,
                    "DO No.,Date,Bill No.,Customer,Detail,Qty ",
                    "10,8,12,12,15,8",
                    " T, T, T, T, T, T",
                    true,
                    "",
                    "",
                    "TextBox"
                    );

            txtDONo.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID);
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
                        PopulateRecords();
                    }

                }

            }
        }
        #endregion

        private void PassDataVocID(object sender)
        {
            txtDONo.Text = ((TextBox)sender).Text;
        }
        
        private void PopulateRecords()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin 

            tSQL+= " Select dh.Do_No, dt.Do_Date, dt.BillNo, dh.Customer, dt.Detail, dh.Qty ";
            tSQL+= " FROM DO_Hist dh ";
            tSQL += " INNER JOIN DO_Det dt on dh.Do_No = dt.DO_No ";
            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Do_Det");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    dtpDO.Text = (ds.Tables[0].Rows[0]["Do_Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Do_Date"].ToString());
                    //dtpOrd.Text = (ds.Tables[0].Rows[0]["Ord_Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ord_Date"].ToString());

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                    }
                   // LoadGridData();
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }

        private void frmDeliveryOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
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
                    "dd.Ord_No",
                    "dd.Do_Date, h.Name, dd.Detail, i.cgdDesc AS ItemGroupName, dd.Category, dd.Qty, dd.Amount",
                    " DO_Det dd LEFT OUTER JOIN Heads h ON dd.Customer = h.Name INNER JOIN CatDtl i on dd.ItemGroupID = i.cgdCode AND cgCode = 6",
                    this.Text.ToString(),
                    1,
                    "Order No.,Date,Account Name,Details,ItemgroupName,Category,Quantity,Amount",
                    "10,8,20,12,12,8,8,8",
                    " T, T, T, T, T, T, T, T",
                    true,
                    "",
                    "",
                    "TextBox"
                    );
            
            mskCustomerCode.Mask = "";
            mskCustomerCode.Text = string.Empty;
            mskCustomerCode.Mask = clsGVar.maskGLCode;

            txtOrderNo.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID1);
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
 
            //tSQL += " select dd.Ord_No, dd.Do_Date, dd.Ord_Date, dd.Adda, dd.Customer, h.Name, dd.SaleType ,dd.Detail, ";
            //tSQL += " i.cgdDesc AS ItemGroupName, dd.Category, dd.Qty, dd.Amount ";
            //tSQL += " from DO_Det dd ";
            //tSQL += " INNER JOIN CatDtl i on dd.ItemGroupID = i.cgdCode AND cgCode = 6 ";
            //tSQL += " LEFT OUTER JOIN Heads h ON dd.Customer = h.Code ";

            tSQL += " select DISTINCT RIGHT(Itemcode,1) AS Category, dd.Ord_No, gd.cgdDesc AS GodownName, dd.Adda, dd.Do_Date, dd.Ord_Date, dd.Customer, h.Name, dd.SaleType ,dd.Detail, ";
			tSQL += " i.cgdDesc AS ItemGroupName, dd.Category, dd.Qty, dd.Amount ";
            tSQL += " from DO_Det dd ";
            tSQL += " INNER JOIN CatDtl i on dd.ItemGroupID = i.cgdCode AND cgCode = 6 ";
            tSQL += " LEFT OUTER JOIN Heads h ON dd.Customer = h.Code ";
            tSQL += " INNER JOIN CatDtl gd ON dd.Godown = gd.cgdCode AND gd.cgCode = 2 ";
            tSQL += " INNER JOIN Item it ON dd.Category = it.ItemId ";
            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "DO_Det");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    dtpOrd.Text = (ds.Tables[0].Rows[0]["Ord_Date"] == DBNull.Value ? DateTime.Now.ToString() : ds.Tables[0].Rows[0]["Ord_Date"].ToString());
                    txtSaleType.Text = (ds.Tables[0].Rows[0]["SaleType"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["SaleType"].ToString());
                    mskCustomerCode.Text = (ds.Tables[0].Rows[0]["Customer"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Customer"].ToString());
                    lblCustName.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? DateTime.Now.ToString() : ds.Tables[0].Rows[0]["Name"].ToString());
                    txtSaleType.Text = (ds.Tables[0].Rows[0]["SaleType"] == DBNull.Value ? DateTime.Now.ToString() : ds.Tables[0].Rows[0]["SaleType"].ToString());
                    cboAdda.Text = (ds.Tables[0].Rows[0]["Adda"] == DBNull.Value ? DateTime.Now.ToString() : ds.Tables[0].Rows[0]["Adda"].ToString());
                    cboGodown.Text = (ds.Tables[0].Rows[0]["GodownName"] == DBNull.Value ? DateTime.Now.ToString() : ds.Tables[0].Rows[0]["GodownName"].ToString());
                    cboItemGroup.Text = (ds.Tables[0].Rows[0]["ItemGroupName"] == DBNull.Value ? DateTime.Now.ToString() : ds.Tables[0].Rows[0]["ItemGroupName"].ToString());
                    cboCategory.Text = (ds.Tables[0].Rows[0]["Category"] == DBNull.Value ? DateTime.Now.ToString() : ds.Tables[0].Rows[0]["Category"].ToString());
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
        
        private void PassDataVocID1(object sender)
        {
            txtOrderNo.Text = ((TextBox)sender).Text;
        }

        private void txtOrderNo_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc1();
        }

        private void txtOrderNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc1();
            }
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
                if (grd.Rows[i].Cells[(int)GColDO.AfterBal].Value != null)
                {
                    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GColDO.AfterBal].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fAmount = fAmount + outValue;
                    }
                }
                if (grd.Rows[i].Cells[(int)GColDO.DelQty].Value != null)
                {
                    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GColDO.DelQty].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fQty = fQty + outValue;
                    }
                } // if != null
                //grdVoucher[2, i].Value = (i + 1).ToString();
            }

            lblBalance.Text = String.Format("{0:0,0.00}", fAmount);
            lblInvQty.Text = String.Format("{0:0,0.00}", fQty);
        }


        private void txt_I_ItemID_DoubleClick(object sender, EventArgs e)
        {
            frmItemsHelpAuto frm = new frmItemsHelpAuto();
            frm.ShowDialog();

            txt_I_ItemID.Text = frm.Ret_ItemID.ToString();
            lbl_I_ItemCode.Text = frm.Ret_ItemCode.ToString();
            lbl_I_ItemName.Text = frm.Ret_ItemName.ToString();
            lblAvailBal.Text = "0";
            lblOrderQty.Text = "0";
            lblPrevDel.Text = "0";
            lblRemQty.Text = "0";
            lblDelQty.Text = "0";
            lblAfterBal.Text = "0";
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
                lblAvailBal.Text = "0";
                lblOrderQty.Text = "0";
                lblPrevDel.Text = "0";
                lblRemQty.Text = "0";
                lblDelQty.Text = "0";
                lblAfterBal.Text = "0";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grd.Rows.Add(txt_I_ItemID.Text.ToString(),
                lbl_I_ItemCode.Text.ToString(),
                lbl_I_ItemName.Text.ToString(),
                cbo_I_Size.Text.ToString(),
                cbo_I_Color.Text.ToString(),
                cbo_I_UOM.Text.ToString(),
                "0","0","0","0","0","0",
                cbo_I_Size.SelectedValue.ToString(),
                cbo_I_Color.SelectedValue.ToString(),
                cbo_I_UOM.SelectedValue.ToString());

            MessageBox.Show("Data Successfully Added To GridView");

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

            
            lFieldList = "Code";                  //  0-    ItemID";       
            lFieldList += ",ItemCode";            //  1-    ItemCode";     
            lFieldList += ",ItemName";            //  2-    ItemName"; 
            lFieldList += ",SizeName";            //  3-    SizeName";       
            lFieldList += ",ColorName";           //  4-    ColorName";      
            lFieldList += ",UnitName";            //  5-    UOMName";
            lFieldList += ",AvailBal";            //  6-    AvailBal";
            lFieldList += ",OrdQty";              //  7-    OrdQty";
            lFieldList += ",PrevDel";             //  8-    PrevDel";
            lFieldList += ",DelQty";              //  9-    DelQty";
            lFieldList += ",RemQty";              // 10-    RemQty";
            lFieldList += ",AfterBal";            // 11-    AfterBal";
            lFieldList += ",SizeID";              // 12-    SizeID";     
            lFieldList += ",ColorID";             // 13-    ColorID";     
            lFieldList += ",UOMID";               // 14-    UOMID"; 


            lHDR += "Item ID";            //  0-    ItemID";    
            lHDR += ",Item Code";         //  1-    ItemCode";   
            lHDR += ",Item Name";         //  2-    ItemName"; 
            lHDR += ",Size";              //  3-    SizeName";  
            lHDR += ",Color";              //  4-    ColorName";  
            lHDR += ",UOM";             //  5-    UOMName"; 
            lHDR += ",Avail.Bal";          //  6-    AvailBal";
            lHDR += ",Ord.Qty";            //  7-    OrdQty";
            lHDR += ",Prev.Del";               //  8-    PrevDel";
            lHDR += ",Del.Qty";            //  9-    DelQty";
            lHDR += ",Rem.Qty";           // 10-    RemQty";
            lHDR += ",AfterBal";             // 11-    AfterBal";
            lHDR += ",SizeID";          // 12-    SizeID";    
            lHDR += ",ColorID";            // 13-    ColorID";   
            lHDR += ",UOMID";              // 14-    UOMID"; 
            
            
            
            // Col Visible Width
            lColWidth = "   5";                //  0-    ItemID";    
            lColWidth += ",12";                //  1-    ItemCode";      
            lColWidth += ",20";                //  2-    ItemName"; 
            lColWidth += ",10";                //  3-    SizeName";  
            lColWidth += ", 7";                //  4-    ColorName";     
            lColWidth += ", 7";                //  5-    UOMName";    
            lColWidth += ", 7";                //  6-    AvailBal";
            lColWidth += ", 7";                //  7-    OrdQty";
            lColWidth += ", 5";                //  8-    PrevDel";
            lColWidth += ", 5";                //  9-    DelQty";
            lColWidth += ", 5";                // 10-    RemQty";
            lColWidth += ", 5";                // 11-    AfterBal";
            lColWidth += ", 5";                // 12-    SizeID";    
            lColWidth += ", 5";                // 13-    ColorID";   
            lColWidth += ", 5";                // 14-    UOMID"; 


            // Column Input Length/Width
            lColMaxInputLen = "  0";                 //  0-    ItemID";   
            lColMaxInputLen += ", 0";                //  1-    ItemCode"; 
            lColMaxInputLen += ", 0";                //  2-    ItemName"; 
            lColMaxInputLen += ", 0";                //  3-    SizeName"; 
            lColMaxInputLen += ", 0";                //  4-    ColorName";
            lColMaxInputLen += ", 0";                //  5-    UOMName";  
            lColMaxInputLen += ", 0";                //  6-    AvailBal";
            lColMaxInputLen += ", 0";                //  7-    OrdQty";
            lColMaxInputLen += ", 0";                //  8-    PrevDel";
            lColMaxInputLen += ", 0";                //  9-    DelQty";
            lColMaxInputLen += ", 0";                // 10-    RemQty";
            lColMaxInputLen += ", 0";                // 11-    AfterBal";
            lColMaxInputLen += ", 0";                // 12-    SizeID";   
            lColMaxInputLen += ", 0";                // 13-    ColorID";  
            lColMaxInputLen += ", 0";                // 14-    UOMID"; 

            // Column Min Width
            lColMinWidth = "   0";                       //  0-    ItemID";      
            lColMinWidth += ", 0";                       //  1-    ItemCode";    
            lColMinWidth += ", 0";                       //  2-    ItemName"; 
            lColMinWidth += ", 0";                       //  3-    SizeName"; 
            lColMinWidth += ", 0";                       //  4-    ColorName";   
            lColMinWidth += ", 0";                       //  5-    UOMName";     
            lColMinWidth += ", 0";                       //  6-    AvailBal";
            lColMinWidth += ", 0";                       //  7-    OrdQty";
            lColMinWidth += ", 0";                       //  8-    PrevDel";
            lColMinWidth += ", 0";                       //  9-    DelQty"; 
            lColMinWidth += ", 0";                       // 10-    RemQty";  
            lColMinWidth += ", 0";                       // 11-    AfterBal";
            lColMinWidth += ", 0";                       // 12-    SizeID";   
            lColMinWidth += ", 0";                       // 13-    ColorID";  
            lColMinWidth += ", 0";                       // 14-    UOMID"; 

            // Column Format
            lColFormat = "   T";                        //  0-    ItemID";       
            lColFormat += ", T";                        //  1-    ItemCode";    
            lColFormat += ", T";                        //  2-    ItemName"; 
            lColFormat += ", T";                        //  3-    SizeName"; 
            lColFormat += ", T";                        //  4-    ColorName";   
            lColFormat += ", T";                        //  5-    UOMName";     
            lColFormat += ", N2";                        //  6-    AvailBal";
            lColFormat += ", N2";                        //  7-    OrdQty";
            lColFormat += ", N2";                        //  8-    PrevDel";
            lColFormat += ", N2";                        //  9-    DelQty"; 
            lColFormat += ", N2";                        // 10-    RemQty";  
            lColFormat += ", N2";                        // 11-    AfterBal";
            lColFormat += ", H";                        // 12-    SizeID";   
            lColFormat += ", H";                        // 13-    ColorID";  
            lColFormat += ", H";                        // 14-    UOMID"; 

            // Column ReadOnly 1= readonly, 0 = read-write
            lColReadOnly = "  0";                        //  0-    ItemID";     
            lColReadOnly += ",1";                        //  1-    ItemCode";   
            lColReadOnly += ",1";                        //  2-    ItemName"; 
            lColReadOnly += ",0";                        //  3-    SizeName"; 
            lColReadOnly += ",0";                        //  4-    ColorName";  
            lColReadOnly += ",0";                        //  5-    UOMName";    
            lColReadOnly += ",0";                        //  6-    AvailBal";
            lColReadOnly += ",0";                        //  7-    OrdQty";
            lColReadOnly += ",0";                        //  8-    PrevDel";
            lColReadOnly += ",0";                        //  9-    DelQty";
            lColReadOnly += ",0";                        // 10-    RemQty"; 
            lColReadOnly += ",0";                        // 11-    AfterBal";
            lColReadOnly += ",1";                        // 12-    SizeID";   
            lColReadOnly += ",1";                        // 13-    ColorID";  
            lColReadOnly += ",1";                        // 14-    UOMID"; 


            // For Saving Time
            tColType += "  N0";              //  0-    ItemID";   
            tColType += ",SKP";              //  1-    ItemCode"; 
            tColType += ",SKP";              //  2-    ItemName"; 
            tColType += ",SKP";               //  3-    SizeName"; 
            tColType += ",SKP";              //  4-    ColorName";
            tColType += ",SKP";              //  5-    UOMName";  
            tColType += ", SKP";              //  6-    AvailBal";
            tColType += ", N0";              //  7-    OrdQty";
            tColType += ", N0";              //  8-    PrevDel";
            tColType += ", N0";              //  9-    DelQty";
            tColType += ", SKP";              // 10-    RemQty";
            tColType += ", SKP";              // 11-    AfterBal";
            tColType += ", N0";              // 12-    SizeID";   
            tColType += ", N0";              // 13-    ColorID";  
            tColType += ", N0";              // 14-    UOMID"; 


            tFieldName += "Code";                //  0-    ItemID";    
            tFieldName += ",ItemCode";           //  1-    ItemCode";    
            tFieldName += ",ItemName";           //  2-    ItemName"; 
            tFieldName += ",SizeName";        //  3-    SizeName"; 
            tFieldName += ",ColorName";           //  4-    ColorName";     
            tFieldName += ",UnitName";          //  5-    UOMName";       
            tFieldName += ",AvailBal";           //  6-    AvailBal";
            tFieldName += ",OrdQty";         //  7-    OrdQty";
            tFieldName += ",PrevDel";                //  8-    PrevDel";
            tFieldName += ",DelQty";             //  9-    DelQty";
            tFieldName += ",RemQty";            // 10-    RemQty"; 
            tFieldName += ",AfterBal";              // 11-    AfterBal";
            tFieldName += ",SizeID";           // 12-    SizeID";   
            tFieldName += ",ColorID";       // 13-    ColorID";  
            tFieldName += ",UOMID";         // 14-    UOMID"; 


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
                        fLastID = txtDONo.Text.ToString();
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

        private bool PrepareDocMaster()
        {
            bool rtnValue = true;
            string lSQL = string.Empty;

            try
            {
                if (txtDONo.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    fDocID = clsDbManager.GetNextValDocID("DO_Det", "DocId", fDocWhere, "");
                    fDocID = fDocID + 1;
                    strDocId = "1-" + DateTime.Now.Year.ToString() + "-" + fDocID.ToString();
                    txtDONo.Text = strDocId;
                    

                    lSQL = "insert into DO_Det (";
                    lSQL += " DocId ";
                    lSQL += ", DO_No ";
                    lSQL += ", DO_Date ";                                //  1-    ItemCod  
                    lSQL += ", Customer ";                                        //  2-    ItemNam 
                    lSQL += ", Ord_No ";                                        //  4-    SizeNam  
                    lSQL += ", Bilty_No ";                                      //  6-    UOMName
                    lSQL += ", Bilty_Date ";                                      // 7- GodownName
                    lSQL += ", Qty ";                                         // 8- Qty
                    lSQL += ", AddaID ";                                      // 9    SizeID";   
                    lSQL += ", Category ";
                    lSQL += ", ItemGroupID ";
                    lSQL += ", Godown ";
                    lSQL += " ) values (";
                    //                                               
                    lSQL += fDocID.ToString();
                    lSQL += ",'" + strDocId.ToString() + "'";   
                    lSQL += ", " + StrF01.D2Str(dtpDO) + "";         
                    lSQL += ",'" + mskCustomerCode.Text.ToString() + "'";
                    lSQL += ",'" + txtOrderNo.Text.ToString() + "'";
                    lSQL += ", 1";
                    lSQL += ", " + StrF01.D2Str(dtpOrd) + "";
                    lSQL += ", 10";
                    lSQL += ", " + cboAdda.SelectedValue.ToString() + "";
                    lSQL += ", " + cboCategory.SelectedValue.ToString() + "";
                    lSQL += ", " + cboItemGroup.SelectedValue.ToString() + "";
                    lSQL += ", " + cboGodown.SelectedValue.ToString() + "";  
                    lSQL += ")";                                             
                }                                                            
                else
                {
                    fDocWhere = " DO_No = '" + txtDONo.Text.ToString() + "'";
                    if (clsDbManager.IDAlreadyExistWw("DO_Det", "DO_No", fDocWhere))
                    {

                        fDocAlreadyExists = true;
                        lSQL = "delete from DO_Hist ";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);
                        //
                    }

                    lSQL = "update DO_Det set";
                    lSQL += " DO_Date = '" + StrF01.D2Str(dtpDO.Value) + "'";
                    lSQL += ", Customer = '" + mskCustomerCode.Text.ToString() + "'";
                    lSQL += ", Amount = 1000";
                    lSQL += ", Ord_No = '" + txtOrderNo.Text.ToString() + "'";
                    lSQL += ", Adda = " + cboAdda.SelectedValue.ToString() + "";
                    lSQL += ", Category = " + cboCategory.SelectedValue.ToString() + "";
                    lSQL += ", ItemGroupID = " + cboItemGroup.SelectedValue.ToString() + "";
                    //lSQL += " Godown '" + cboGodown.SelectedValue.ToString() + "'";
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

                    lSQL = "INSERT INTO DO_Hist (DocId";
                    lSQL += ",DO_No,Code,SizeId,ColorID,Rate,Qty,FromDelivery)";
                    lSQL += " VALUES (";
                    lSQL += "" + fDocID + "";
                    lSQL += ", '" + strDocId.ToString() + "'";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColDO.ItemID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColDO.SizeID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColDO.ColorID].Value.ToString() + "";
                    lSQL += ", 100";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColDO.OrdQty].Value.ToString() + "";
                    lSQL += ", 0";
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


        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            //MessageBox.Show("Data Saved Successfullly");
            textAlert.Text = "Data Saved Successfully";
            this.notifyIcon1.BalloonTipText = "Delivery Order Number '" + txtDONo.Text.ToString() + "'";
            this.notifyIcon1.BalloonTipTitle = "Data Saved";
            //this.notifyIcon1.Icon = new Icon("icon.ico");
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.ShowBalloonTip(5);
        }

        private void btnOrdHelp_Click(object sender, EventArgs e)
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


        private void btnNewIssues_Click(object sender, EventArgs e)
        {
            grd.Rows.Clear();
            ClearTextBoxes();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            //smtp.Text = "smtp.gmail.com";
            MailMessage mail = new MailMessage("usama.naveed.hussain@gmail.com", "usama.naveed.hussain@gmail.com", "Data Saved", "Data Saved against Delivery Order Number: " + txtDONo.Text.ToString());
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            // client.Host = "stmp.gmail.com";
            client.Port = 587;
            // client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("usama.naveed.hussain@gmail.com", "waleedtablet");
            client.EnableSsl = true;
            client.Send(mail);
            //MessageBox.Show("Mail Sent", "Success", MessageBoxButtons.OK);
            textAlert.Text = "Mail Sent Successfully";
        }
    }
}
