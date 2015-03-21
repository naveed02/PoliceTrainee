using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GUI_Task.Class;
using GUI_Task.StringFun01;
using System.Net.Mail;

namespace GUI_Task
{
    enum GColDN
    {
        ItemID = 0,
        ItemCode = 1,
        ItemName = 2,
        Description = 3,
        SizeName = 4,
        ColorName = 5,
        UnitName = 6,
        Qty = 7,
        AvailStock = 8,
        SizeID = 9,
        ColorID = 10,
        UOMID = 11
    }

    public partial class frmDemandNote : Form
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

        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.Container components = null;

        int fcboDefaultValue = 0;

        bool blnFormLoad = true;

        string[] a_Color = new string[0];
        int[] a_ColorInt = new int[0];

        string[] a_Size = new string[0];
        int[] a_SizeInt = new int[0];

        string strDocId = string.Empty;

        //bool blnFormLoad = true;
        public frmDemandNote()
        {

            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        private void frmDemandNote_Load(object sender, EventArgs e)
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

            //Item group cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmItemGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGroup, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGroup.SelectedValue);


            //dEPARTMENT Combo Fill
            lSQL = "SELECT departmentid, department_name FROM PR_Department";
            //lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboDepartment, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboDepartment.SelectedValue);

            //Emp Code Combo Fill
            lSQL = "SELECT employeeid, first_name +' '+ last_name AS EmpName FROM PR_Employee ";
            //lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboEmpCode, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboEmpCode.SelectedValue);

            //Godown cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmGodown);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboGodownForBal, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboGodownForBal.SelectedValue);

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
            ds.Clear();


            grd.Hide();
            grd.Refresh();
            grd.Show();

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
            //grd.Columns[(int)GColMfg.Amount].MinimumWidth = 100;

        }
        
        private void LoadGridData()
        {
            string lSQL = "";

            //lSQL += " SELECT h.ItemId AS Code, i.ItemCode, i.Name AS ItemName, h.Des, sz.cgdDesc AS SizeName, ";
            //lSQL += " clr.cgdDesc AS ColorName, h.Qty, 0 AS AvailStock, ";
            //lSQL += " h.SizeId, h.ColorId, h.UOMID ";
            //lSQL += " from dnDetail h ";
            //lSQL += " JOIN CatDtl clr ON h.ColorID=clr.cgdCode AND clr.cgCode=3 ";
            //lSQL += " INNER JOIN CatDtl sz ON h.sizeid=sz.cgdCode AND sz.cgCode=5 ";
            //lSQL += " INNER JOIN Item i ON h.ItemId=i.ItemId ";
            //lSQL += " where h.DNId ='" + txtDNNo.Text.ToString() + "';";

            //Change This Query with this one
            //Select i.UOMID
            //LEFT OUTER JOIN IMS_UOM u ON u.UOMID = i.UOMId

            lSQL+= " SELECT h.ItemId AS Code, i.ItemCode, i.Name AS ItemName, h.Des, ";
            lSQL+= " sz.cgdDesc AS SizeName, clr.cgdDesc AS ColorName, u.UnitName, h.Qty, 0 AS AvailStock, ";
            lSQL+= " h.SizeId, h.ColorId, i.UOMID ";
	        lSQL+= " from dnDetail h ";
	        lSQL+= " LEFT OUTER JOIN CatDtl clr ON h.ColorID=clr.cgdCode AND clr.cgCode=3 ";
	        lSQL+= " LEFT OUTER JOIN CatDtl sz ON h.sizeid=sz.cgdCode AND sz.cgCode=5 ";
            lSQL+= " LEFT OUTER JOIN Item i ON h.ItemId=i.ItemId ";
            lSQL+= " LEFT OUTER JOIN IMS_UOM u ON u.UOMID = i.UOMID ";
            lSQL+= " where h.DNId ='" + txtDNNo.Text.ToString() + "';";
            
            clsDbManager.FillDataGrid(
                grd,
                lSQL,
                fFieldList,
                fColFormat);
        }

        private void frmDemandNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void txtDemandNoteNumber_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        #region LookUp_Voc

        private void LookUp_Voc()
        {
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
                    "d.DNId",
                    "d.Date, ig.cgdDesc AS ItemGroupName, pd.department_name, "
                    + "pe.first_name + ' ' + pe.last_name AS EmpName, d.Note ",
                    "DN d INNER JOIN CatDtl ig ON d.ItemGroupId=ig.cgdCode AND ig.cgCode=6 "
                    + "INNER JOIN PR_Department pd ON d.DepartmentId=pd.departmentid "
                    + "INNER JOIN PR_Employee pe ON d.EmployeeId=pe.employeeid",
                    this.Text.ToString(),
                    1,
                    "DN#,Date,Item Group Name,Department Name,Employee Name,Note ",
                    "10,8,12,12,12,15",
                    " T, T, T, T, T, T",
                    true,
                    "",
                //"d.Category = " + cboMainGroup.SelectedValue.ToString(), 
                    "",
                    "TextBox"
                    );

            txtDNNo.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID);
            sForm.ShowDialog();

            if (txtDNNo.Text != null)
            {
                if (txtDNNo.Text != null)
                {
                    if (txtDNNo.Text.ToString() == "" || txtDNNo.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtDNNo.Text.ToString().Trim().Length > 0)
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
            txtDNNo.Text = ((TextBox)sender).Text;
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

            tSQL = "SELECT d.DNId, d.Date, d.ItemGroupId, ig.cgdDesc AS ItemGroupName, ";
            tSQL += " d.DepartmentId, pd.department_name, ";
            tSQL += " d.EmployeeId, pe.first_name + ' ' + pe.last_name AS EmpName, d.Note ";
            tSQL += " FROM DN d INNER JOIN CatDtl ig ON d.ItemGroupId=ig.cgdCode AND ig.cgCode=6";
            tSQL += " INNER JOIN PR_Department pd ON d.DepartmentId=pd.departmentid";
            tSQL += " INNER JOIN PR_Employee pe ON d.EmployeeId=pe.employeeid";
            tSQL += " where d.DNId='" + txtDNNo.Text.ToString() + "';";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "DN");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    txtDNNo.Text = (ds.Tables[0].Rows[0]["DNId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DNId"].ToString());
                    cboDepartment.Text = (ds.Tables[0].Rows[0]["department_name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["department_name"].ToString());
                    cboEmpCode.Text = (ds.Tables[0].Rows[0]["EmpName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["EmpName"].ToString());
                    cboItemGroup.Text = (ds.Tables[0].Rows[0]["ItemGroupName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemGroupName"].ToString());
                    txtNoteMain.Text = (ds.Tables[0].Rows[0]["Note"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Note"].ToString());

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
                MessageBox.Show("Unable to Get Order No...", this.Text.ToString());
            }
        }
        #endregion

        private void txtDemandNoteNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
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
            lFieldList = "Code";                    // 0-    ItemID";       
            lFieldList += ",ItemCode";              // 1-    ItemCode";     
            lFieldList += ",ItemName";                  // 2-    ItemName";   
            lFieldList += ",Des";           //3 -    Description;
            lFieldList += ",SizeName";              // 4-    SizeID";       
            lFieldList += ",ColorName";             // 5-    ColorID";
            lFieldList += ",UnitName";              // 6-    UnitName
            lFieldList += ",Qty";                   // 7-    Qty";  
            lFieldList += ",AvailStock";            // 8-    Available Stock;
            //lFieldList += ",AvailBal";              // 9-    Available Balance
            lFieldList += ",SizeId";                //10-    SizeID";     
            lFieldList += ",ColorId";               //11-    ColorID";
            lFieldList += ",UOMID";                 //12-    UOMID



            lHDR += "Item ID";             // 0-    ItemID";       
            lHDR += ",Item Code";          // 1-    ItemCode";     
            lHDR += ",Item Name";          // 2-    ItemName";   
            lHDR += ",Description";        //3 -    Description;
            lHDR += ",Size";               // 4-    SizeID";       
            lHDR += ",Color";              // 5-    ColorID";
            lHDR += ",UOM";                // 6-    UnitName
            lHDR += ",Qty";    // 7-    Qty";  
            lHDR += ",Available Stock";             // 8-    Available Stock;
           // lHDR += ",Available Balance";            // 9-    Available Balance
            lHDR += ",SizeID";                               //10-    SizeID";     
            lHDR += ",ColorID";                               //11-    ColorID";
            lHDR += ",UOMID";                               //12-    UOMID

            // Col Visible Width
            lColWidth = "   5";               // 0-    ItemID";       
            lColWidth += ",12";               // 1-    ItemCode";     
            lColWidth += ", 20";              // 2-    ItemName";   
            lColWidth += ", 30";              //3 -    Description;
            lColWidth += ", 7";               // 4-    SizeID";       
            lColWidth += ", 7";               // 5-    ColorID";
            lColWidth += ", 7";               // 6-    UnitName
            lColWidth += ", 7";               // 7-    Qty";  
            lColWidth += ", 5";               // 8-    Available Stock;
           // lColWidth += ", 5";               // 9-    Available Balance
            lColWidth += ", 5";             //10-    SizeID";     
            lColWidth += ", 5";        //11-    ColorID";
            lColWidth += ", 5";          //12-    UOMID


            // Column Input Length/Width
            lColMaxInputLen = "  0";               // 0-    ItemID";       
            lColMaxInputLen += ", 0";              // 1-    ItemCode";     
            lColMaxInputLen += ", 0";              // 2-    ItemName";   
            lColMaxInputLen += ", 0";              //3 -    Description;
            lColMaxInputLen += ", 0";              // 4-    SizeID";       
            lColMaxInputLen += ", 0";              // 5-    ColorID";
            lColMaxInputLen += ", 0";              // 6-    UnitName
            lColMaxInputLen += ", 0";              // 7-    Qty";  
            lColMaxInputLen += ", 0";              // 8-    Available Stock;
            //lColMaxInputLen += ", 0";              // 9-    Available Balance
            lColMaxInputLen += ", 0";    //10-    SizeID";     
            lColMaxInputLen += ", 0";    //11-    ColorID";
            lColMaxInputLen += ", 0";    //12-    UOMID

            // Column Min Width
            lColMinWidth = "   0";                    // 0-    ItemID";       
            lColMinWidth += ", 0";                    // 1-    ItemCode";     
            lColMinWidth += ", 0";                    // 2-    ItemName";   
            lColMinWidth += ", 0";                    //3 -    Description;
            lColMinWidth += ", 0";                    // 4-    SizeID";       
            lColMinWidth += ", 0";                    // 5-    ColorID";
            lColMinWidth += ", 0";                    // 6-    UnitName
            lColMinWidth += ", 0";                    // 7-    Qty";  
            lColMinWidth += ", 0";                    // 8-    Available Stock;
            //lColMinWidth += ", 0";                    // 9-    Available Balance
            lColMinWidth += ", 0";    //10-    SizeID";     
            lColMinWidth += ", 0";   //11-    ColorID";
            lColMinWidth += ", 0";    //12-    UOMID
            
            // Column Format
            lColFormat = "   T";                     // 0-    ItemID";          
            lColFormat += ", T";                     // 1-    ItemCode";       
            lColFormat += ", T";                     // 2-    ItemName";   
            lColFormat += ", T";                     //3 -    Description;
            lColFormat += ", T";                     // 4-    SizeID";         
            lColFormat += ", T";                     // 5-    ColorID";  
            lColFormat += ", T";                     // 6-    UnitName
            lColFormat += ", T";                     // 7-    Qty";  
            lColFormat += ", T";                     // 8-    Available Stock;
           // lColFormat += ", T";                     // 9-    Available Balance
            lColFormat += ", H";                                        //10-    SizeID";     
            lColFormat += ", H";    //11-    ColorID";
            lColFormat += ", H";    //12-    UOMID
            
            // Column ReadOnly 1= readonly, 0 = read-write
            lColReadOnly = "  0";                         // 0-    ItemID";       
            lColReadOnly += ",1";                         // 1-    ItemCode";     
            lColReadOnly += ",1";                         // 2-    ItemName";   
            lColReadOnly += ",0";                         //3 -    Description;
            lColReadOnly += ",1";                         // 4-    SizeName";       
            lColReadOnly += ",1";                         // 5-    ColorName";
            lColReadOnly += ",1";                         // 6-    UnitName
            lColReadOnly += ",0";                         // 7-    Qty";  
            lColReadOnly += ",1";                         // 8-    Available Stock;
            //lColReadOnly += ",1";                         // 9-    Available Balance
            lColReadOnly += ",1";    //10-    SizeID";     
            lColReadOnly += ",1";   //11-    ColorID";
            lColReadOnly += ",1";    //12-    UOMID
            
            // For Saving Time
            tColType += "   N0";            // 0-    ItemID";       
            tColType += ",  SKP";           // 1-    ItemCode";          
            tColType += ",  SKP";           // 2-    ItemName";      
            tColType += ",  T";             //3 -    Description;
            tColType += ",  SKP";           // 4-    SizeID";            
            tColType += ",  SKP";           // 5-    ColorID";     
            tColType += ",  N0";            // 6-    UnitName
            tColType += ", N0";             // 7-    Qty";  
            tColType += ", N0";             // 8-    Available Stock;
            //tColType += ", N0";             // 9-    Available Balance
            tColType += ", N0";    //10-    SizeID";     
            tColType += ", N0";    //11-    ColorID";
            tColType += ", N0";  //12-    UOMID


            tFieldName += "Code";              // 0-    ItemID";       
            tFieldName += ",ItemCode";         // 1-    ItemCode";     
            tFieldName += ",ItemName";         // 2-    ItemName";   
            tFieldName += ",Dec=sription";     //3 -    Description;
            tFieldName += ",SizeName";         // 4-    SizeID";       
            tFieldName += ",ColorName";        // 5-    ColorID";
            tFieldName += ",UOMID";            // 6-    UnitName
            tFieldName += ",Del_Qty";          // 7-    Qty";  
            tFieldName += ",AvailStock";           // 8-    Available Stock;
            //tFieldName += ",AvailBal";          // 9-    Available Balance
            tFieldName += ",SizeID";    //10-    SizeID";     
            tFieldName += ",ColorID";    //11-    ColorID";
            tFieldName += ",UOMID";    //12-    UOMID

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

        private void txt_I_ItemID_DoubleClick(object sender, EventArgs e)
        {
            frmItemsHelpAuto frm = new frmItemsHelpAuto();
            frm.ShowDialog();

            txt_I_ItemID.Text = frm.Ret_ItemID.ToString();
            lbl_I_ItemCode.Text = frm.Ret_ItemCode.ToString();
            lbl_I_ItemName.Text = frm.Ret_ItemName.ToString();
            Get_ItemsData();
            LoadGridData();
        }

        private void txt_I_ItemID_KeyDown(object sender, KeyEventArgs e)
        {
            frmItemsHelpAuto frm = new frmItemsHelpAuto();
            //frm.MdiParent = this;
            //frm.Show();
            frm.ShowDialog();

            txt_I_ItemID.Text = frm.Ret_ItemID.ToString();
            lbl_I_ItemCode.Text = frm.Ret_ItemCode.ToString();
            lbl_I_ItemName.Text = frm.Ret_ItemName.ToString();
            //Get_ItemsData();
        }
        private void cbo_I_Color_Click(object sender, EventArgs e)
        {
            Get_ItemsData();
        }

        private void cbo_I_Size_Click(object sender, EventArgs e)
        {
            Get_ItemsData();
        }

        private void Get_ItemsData()
        {
            string lSQL = string.Empty;
            DataSet ds = new DataSet();
            lSQL = "SELECT isNull(Sum(isNull(Qty_In,0)-isNull(Qty_Out,0)),0) AS ItemBal ";
            lSQL += " FROM Item_Sec ";
            lSQL += " WHERE Code=" + Convert.ToInt32(txt_I_ItemID.Text);
            lSQL += " AND SizeID=" + cbo_I_Size.SelectedValue.ToString();
            lSQL += " AND ColorID=" + cbo_I_Color.SelectedValue.ToString();

            ds = clsDbManager.GetData_Set(lSQL, "ItemSec");
            lblAvailStock.Text = (ds.Tables[0].Rows[0]["ItemBal"] == DBNull.Value ? "0" : ds.Tables[0].Rows[0]["ItemBal"].ToString());
            ds.Clear();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            grd.Rows.Add(txt_I_ItemID.Text.ToString(),
                lbl_I_ItemCode.Text.ToString(),
                lbl_I_ItemName.Text.ToString(),
                txtDescription.Text.ToString(),
                cbo_I_Size.Text.ToString(),
                cbo_I_Color.Text.ToString(),
                cbo_I_UOM.Text.ToString(),
                txtQty.Text.ToString(),
                lblAvailStock.Text.ToString(),
                cbo_I_Size.SelectedValue.ToString(),
                cbo_I_Color.SelectedValue.ToString(),
                cbo_I_UOM.SelectedValue.ToString());

            MessageBox.Show("Record Successfully Added To Grid View");

            SumVoc();
        }

        private bool FormValidation()
        {
            bool lRtnValue = true;
            DateTime lNow = DateTime.Now;
            decimal lDebit = 0;
            decimal lCredit = 0;
            fDocAmt = 0;
            //
            try
            {
                return lRtnValue;

            }
            catch (Exception ex)
            {
                fTErr++;
                ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "Exception: FormValidation -> " + ex.Message.ToString());
                //dGvError.Rows.Add(fTErr.ToString(), "Exception: FormValidation -> ", "", ErrrMsg + "  " + lNow.ToString());
                return false;
            }
            //return lRtnValue;        // to be removed
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            //MessageBox.Show("Data Saved Successfully");
            textAlert.Text = "Data Saved Successfully";
            this.notifyIcon1.BalloonTipText = "DN Number '" + txtDNNo.Text.ToString() + "'";
            this.notifyIcon1.BalloonTipTitle = "Data Saved";
            //this.notifyIcon1.Icon = new Icon("icon.ico");
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.ShowBalloonTip(5);
        }
        private int GridTNOT(DataGridView pdGv)
        {
            int rtnValue = 0;
            try
            {
                //
                for (int dGVRow = 0; dGVRow < pdGv.Rows.Count; dGVRow++)
                {
                    //frmGroupRights.dictGrpForms.Add(Convert.ToInt32(dGVSelectedForms.Rows[dGVRow].Cells[0].Value.ToString()),
                    //    dGVSelectedForms.Rows[dGVRow].Cells[1].Value.ToString());
                    // Prepare Save Data to Db Table
                    //
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
                            //lBlank = true;
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

        private bool PrepareDocMaster()
        {
            bool rtnValue = true;
            string lSQL = string.Empty;
           

            try
            {
                if (txtDNNo.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    //fDocWhere = " Doc_vt_id = " + fDocTypeID.ToString();
                    //fDocWhere += " AND doc_Fiscal_ID = " + fDocFiscal.ToString();
                    fDocID = clsDbManager.GetNextValDocID("DN", "DocId", fDocWhere, "");
                    strDocId = "1-" + DateTime.Now.Year.ToString() + fDocID.ToString();
                    txtDNNo.Text = strDocId;
                    fDocID += fDocID;

                    lSQL = "insert into DN (";
                    lSQL += "  DocId ";
                    lSQL += ", DNId ";                                         // 1-
                    lSQL += ", Date ";                                     // 2-
                    lSQL += ", DepartmentId ";                                            // 3-
                    lSQL += ", EmployeeId ";                                         // 4-
                    lSQL += ", ItemGroupId ";                                          // 5-
                    lSQL += ", Note ";                                          // 6-
                    lSQL += ", UserId ";                                          // 7-
                    lSQL += ", OrgId ";                                       // 8-
                    lSQL += ", Status ";                                           // 8-
                    lSQL += ", BranchId ";                                        // 7-
                    lSQL += " ) values (";
                    //
                    lSQL += fDocID.ToString();
                    lSQL += ",'"+ strDocId.ToString() + "'";
                    lSQL += ", " + StrF01.D2Str(dtpDN) + "";                 // 6-
                    lSQL += ",'" + cboDepartment.SelectedValue.ToString() + "'";
                    lSQL += ",'" + cboEmpCode.SelectedValue.ToString() + "'";
                    lSQL += ",'" + cboItemGroup.SelectedValue.ToString() + "'";
                    lSQL += ",'" + txtNoteMain.Text.ToString() + "'";
                    //lSQL += ",'" + clsGVar.UserID.ToString() + "'";
                    lSQL += ",0";
                    lSQL += ",1";
                    lSQL += ",0";
                    lSQL += ",1";
                    lSQL += ")";
                }
                else
                {
                    fDocWhere = " DNId = '" + txtDNNo.Text.ToString() + "'";
                    if (clsDbManager.IDAlreadyExistWw("DN", "DNId", fDocWhere))
                    {
                        fDocAlreadyExists = true;
                        lSQL = "delete from dnDetail ";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);
                        //
                    }
                   
                    lSQL = "update dn set";
                    //
                    lSQL += "  Date = '" + StrF01.D2Str(dtpDN.Value) + "'";                       // 9-
                    lSQL += ",DepartmentId= " + cboDepartment.SelectedValue.ToString() + "";
                    lSQL += ",EmployeeId= " + cboEmpCode.SelectedValue.ToString() + "";
                    lSQL += ",ItemGroupId= " + cboItemGroup.SelectedValue.ToString() + "";
                    lSQL += ",Note = '" + txtNoteMain.Text.ToString() + "'";
                    lSQL += ",UserId = 0";
                    lSQL += ",OrgId = 1";
                    lSQL += ",Status = 0";
                    lSQL += ",BranchId = 1";

                    lSQL += " where ";
                    lSQL += fDocWhere;
                    //lSQL += fDocID;
                    //

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
        } // End PrepareDocMaster
        //
        private bool PrepareDocDetail()
        {
            bool rtnValue = true;
            string lSQL = "";
            //Int64 lAcID = 0;
            try
            {
                //
                for (int dGVRow = 0; dGVRow < grd.Rows.Count; dGVRow++)
                {
                    //frmGroupRights.dictGrpForms.Add(Convert.ToInt32(dGVSelectedForms.Rows[dGVRow].Cells[0].Value.ToString()),
                    //    dGVSelectedForms.Rows[dGVRow].Cells[1].Value.ToString());
                    // Prepare Save Data to Db Table
                    //
                    if (grd.Rows[dGVRow].Cells[(int)GColDN.ItemID].Value == null)
                    {
                        if (dGVRow == fLastRow)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if ((grd.Rows[dGVRow].Cells[(int)GColDN.ItemID].Value.ToString()).Trim(' ', '-') == "")
                        {
                            //lBlank = true;
                            if (dGVRow == fLastRow)
                            {
                                continue;
                            }
                        }
                    }

                    lSQL = "INSERT INTO dnDetail (DocId ";
                    lSQL += ",DNId,ItemId,Des,SizeId,ColorId,Qty)";
                    lSQL += " VALUES (";
                    lSQL += fDocID;
                    lSQL += ", '" + txtDNNo.Text.ToString() + "'";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColDN.ItemID].Value.ToString() + "";
                    lSQL += ", '" + grd.Rows[dGVRow].Cells[(int)GColDN.Description].Value.ToString() + "'";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColDN.SizeID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColDN.ColorID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColDN.Qty].Value.ToString() + "";
                    lSQL += ")";
                    //
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
                if (txtDNNo.Text != null)
                {
                    if (txtDNNo.Text.ToString().Trim(' ', '-') != "")
                    {
                    }
                }
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
                        fLastID = txtDNNo.Text.ToString();
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

        
        private void ResetFields()
        {
            // Reset Form Level Variables/Fields
            fEditMod = false;
            fTNOT = 0;
            fDocAmt = 0;
            fDocWhere = string.Empty;
            fLastRow = 0;
        }

        private void cbo_I_Color_Click_1(object sender, EventArgs e)
        {
            Get_ItemsData();
        }

        private void cbo_I_Size_Click_1(object sender, EventArgs e)
        {
            Get_ItemsData();
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
                if (grd.Rows[i].Cells[(int)GColDN.Qty].Value != null)
                {
                    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GColDN.Qty].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fAmount = fAmount + outValue;
                    }
                }
            }

            lblTotal.Text = String.Format("{0:0,0.00}", fAmount);
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

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            grd.Rows.Clear();
            ClearTextBoxes();
        }

        private void grd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                // MessageBox.Show("Delete key is pressed");
                //if (grdVoucher.Rows[lLastRow].Cells[(int)GCol.acid].Value == null && grdVoucher.Rows[lLastRow].Cells[(int)GCol.refid].Value == null)

                //if (!fGridControl)
                //{
                //    return;
                //}

                if (grd.Rows.Count > 0)
                {
                    if (MessageBox.Show("Are you sure, really want to Delete row ?", "Delete Row", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        grd.Rows.RemoveAt(grd.CurrentRow.Index);
                        SumVoc();
                        return;
                    }
                }
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            //smtp.Text = "smtp.gmail.com";
            MailMessage mail = new MailMessage("usama.naveed.hussain@gmail.com", "usama.naveed.hussain@gmail.com", "Data Saved", "Data Saved against DN Number: " + txtDNNo.Text.ToString());
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
