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
    enum GColIssueItems
    {
        ItemID = 0,             // 0 - ItemID
        ItemCode = 1,           // 1 - ItemCode
        ItemName = 2,           // 2 - ItemName
        SizeName = 3,           // 3 - SizeName
        ColorName = 4,          // 4 - ColorName
        GodownName = 5,         // 6 - GodownName
        Stock = 6,              // 7 - Stock
        WIPQty = 7,             // 8 - WIPQty
        Qty = 8,                // 9 - Qty
        NewStock = 9,          //10 - NewStock
        SizeID = 10,            //11 - SizeID
        ColorID = 11,           //12 - ColorID
        GodownID = 12           //14 - GodownID

    }

    public partial class frmIssueItems : Form
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

        public frmIssueItems()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIssueItems_Load(object sender, EventArgs e)
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

            //Emp Code Combo Fill
            lSQL = "SELECT employeeid, first_name +' '+ last_name AS EmpName FROM PR_Employee ";
            //     lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboEmployee, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboEmployee.SelectedValue);

            //Item group cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmItemGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGroup, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGroup.SelectedValue);

            //Purpose cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmPurpose);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboPurpose, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboPurpose.SelectedValue);

            //Machine cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmMachineNo);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboMachine, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboMachine.SelectedValue);

            //Contractor cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmContractor);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboContractor, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboContractor.SelectedValue);

            //dEPARTMENT Combo Fill
            lSQL = "SELECT departmentid, department_name FROM PR_Department";
            //lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboDepartment, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboDepartment.SelectedValue);

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

            //ds = clsDbManager.GetData_Set(lSQL, "IMS_UOM");
            //UnitColumn.DataSource = ds.Tables[0];
            //UnitColumn.ValueMember = ds.Tables[0].Columns[0].ToString();
            //UnitColumn.DisplayMember = ds.Tables[0].Columns[1].ToString();
            //ds.Clear();

            //Godown cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmGodown);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboGodown, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboGodown.SelectedValue);

            ds = clsDbManager.GetData_Set(lSQL, "CatDtl");
            Godown.DataSource = ds.Tables[0];
            Godown.ValueMember = ds.Tables[0].Columns[0].ToString();
            Godown.DisplayMember = ds.Tables[0].Columns[1].ToString();
            ds.Clear();

        }

        #region LookUp_Voc1

        private void LookUp_Voc1()
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

            frmLookUp sForm = new frmLookUp(

                    "i.IssueId",
                " i.Date, cd.cgdDesc AS ItemGroupName, d.department_name, e.first_name + ' ' + e.last_name AS EmployeeName,i.Note",
                " Issue i INNER JOIN CatDtl cd ON cd.cgdCode=i.ItemGroupID AND cgCode=6 INNER JOIN PR_Department d ON i.DepartmentId=d.departmentid INNER JOIN PR_Employee e ON i.EmployeeId=e.employeeid",
                    this.Text.ToString(),
                    1,
                    "Issue # ,Issue Date ,Item Group, Department, Employee Name, Note",
                    "12,8,10,10,15,20",
                    " T, T, T, T, T, T",
                    true,
                    "",
                    "",
                    "TextBox"
                    );
            txtIssueNo.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID1);
            sForm.ShowDialog();

            if (txtIssueNo.Text != null)
            {
                if (txtIssueNo.Text != null)
                {
                    if (txtIssueNo.Text.ToString() == "" || txtIssueNo.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtIssueNo.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecords1();
                    }

                }
            }
        }
        #endregion

        private void PassDataVocID1(object sender)
        {
            txtIssueNo.Text = ((TextBox)sender).Text;
        }

        #region PopulateRecords1
        //Populate Recordset 
        private void PopulateRecords1()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  

            //select i.IssueId, i.Date, cd.cgdDesc AS ItemGroupName, d.department_name,e.first_name + ' ' + e.last_name AS EmployeeName,i.Note 
            //from Issue i
            //INNER JOIN CatDtl cd ON cd.cgdCode=i.ItemGroupID AND cgCode=6 
            //INNER JOIN PR_Department d ON i.DepartmentId=d.departmentid 
            //INNER JOIN PR_Employee e ON i.EmployeeId=e.employeeid

            tSQL = " SELECT i.IssueId,i.Date, p.first_name + ' ' + p.last_name AS EmpName, ";
            tSQL += " d.department_name AS DeptName, pu.cgdDesc AS Purpose, m.cgdDesc AS MachineName, ";
            tSQL += " c.cgdDesc AS ContractorName, it.cgdDesc AS ItemGroupName, i.Note ";
            tSQL += " FROM Issue i ";
            tSQL += " INNER JOIN PR_Employee p ON p.employeeid = i.EmployeeId ";
            tSQL += " INNER JOIN PR_Department d ON d.departmentid = i.DepartmentId ";
            tSQL += " INNER JOIN CatDtl pu ON i.PurposeId = pu.cgdCode AND pu.cgCode = 10 ";
            tSQL += " INNER JOIN CatDtl m ON i.Machine = m.cgdCode AND m.cgCode = 11 ";
            tSQL += " INNER JOIN CatDtl c ON i.Contract = c.cgdCode AND c.cgCode = 12 ";
            tSQL += " INNER JOIN CatDtl it ON i.ItemGroupID = it.cgdCode AND it.cgCode = 6 ";
            tSQL += " where i.IssueId='" + txtIssueNo.Text.ToString() + "';";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Issue");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    txtIssueNo.Text = (ds.Tables[0].Rows[0]["IssueId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["IssueId"].ToString());
                    dtpIssue.Text = (ds.Tables[0].Rows[0]["Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Date"].ToString());
                    cboEmployee.Text = (ds.Tables[0].Rows[0]["EmpName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["EmpName"].ToString());
                    cboDepartment.Text = (ds.Tables[0].Rows[0]["DeptName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DeptName"].ToString());
                    cboPurpose.Text = (ds.Tables[0].Rows[0]["Purpose"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Purpose"].ToString());
                    cboMachine.Text = (ds.Tables[0].Rows[0]["MachineName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["MachineName"].ToString());
                    cboContractor.Text = (ds.Tables[0].Rows[0]["ContractorName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ContractorName"].ToString());
                    cboItemGroup.Text = (ds.Tables[0].Rows[0]["ItemGroupName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemGroupName"].ToString());
                    txtNote.Text = (ds.Tables[0].Rows[0]["Note"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Note"].ToString());
                    
                    
                    
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    txtIssueNo.Text = (ds.Tables[0].Rows[0]["IssueId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["IssueId"].ToString());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                        //btn_EnableDisable(true);
                    }
                    LoadGridData();
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Order No...", this.Text.ToString());
            }
        }
        #endregion

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
                13,
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

            lSQL += " select id.ItemId AS Code, i.ItemCode, i.Name AS ItemName, sz.cgdDesc AS SizeName, ";
            lSQL += " clr.cgdDesc AS ColorName, gd.cgdDesc AS GodownName, ";
            lSQL += " i.StockLevel AS Stock, 0 AS WIPQty, id.Qty, 0 AS NewStock ";
            lSQL += " from IssueDetail id INNER JOIN Item i ON i.ItemId = id.ItemId INNER JOIN CatDtl sz ON sz.cgdCode=id.SizeId AND sz.cgCode = 5 ";
            lSQL += " INNER JOIN CatDtl clr ON clr.cgCode = id.ColorId AND clr.cgdCode = 3 ";
            lSQL += " INNER JOIN CatDtl gd ON gd.cgdCode=id.GodownId AND gd.cgCode=2 ";
            lSQL += " where id.IssueId = '" + txtIssueNo.Text.ToString() + "'; ";

            clsDbManager.FillDataGrid(
                grd,
                lSQL,
                fFieldList,
                fColFormat);
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
            lFieldList = "Code";           // 0 - ItemID
            lFieldList += ",ItemCode";     // 1 - ItemCode
            lFieldList += ",ItemName";         // 2 - ItemName
            lFieldList += ",SizeName";     // 3 - SizeName
            lFieldList += ",ColorName";    // 4 - ColorName
            //lFieldList += ",UOM";          // 5 - UnitName
            lFieldList += ",GodownName";   // 6 - GodownName
            lFieldList += ",Stock";        // 7 - Stock
            lFieldList += ",WIPQty";     // 8 - WIPQty
            lFieldList += ",Qty";    // 9 - Qty
            lFieldList += ",NewStock";     //10 - NewStock
            lFieldList += ",SizeID";       //11 - SizeID
            lFieldList += ",ColorID";      //12 - ColorID
            //lFieldList += ",UOMID";        //13 - UOMID
            lFieldList += ",GodownID";     //14 - GodownID


            lHDR += "Item ID";         // 0 - ItemID
            lHDR += ",Item Code";      // 1 - ItemCode
            lHDR += ",Item Name";      // 2 - ItemName
            lHDR += ",Size";           // 3 - SizeName
            lHDR += ",Color";          // 4 - ColorName
            //lHDR += ",UOM ID";         // 5 - UnitName
            lHDR += ",Godown";         // 6 - GodownName
            lHDR += ",Stock";          // 7 - Stock
            lHDR += ",WIP Qty";       // 8 - WIPQty
            lHDR += ",Qty";              // 9 - Qty
            lHDR += ",New Stock";       //10 - NewStock
            lHDR += ",SizeID";         //11 - SizeID
            lHDR += ",ColorID";        //12 - ColorID
            //lHDR += ",UOMID";          //13 - UOMID
            lHDR += ",GodownID";       //14 - GodownID

            // Col Visible Width
            lColWidth = "   5";         // 0 - ItemID
            lColWidth += ",12";         // 1 - ItemCode
            lColWidth += ", 15";        // 2 - ItemName
            lColWidth += ", 7";         // 3 - SizeName
            lColWidth += ", 7";         // 4 - ColorName
            //lColWidth += ", 7";         // 5 - UnitName
            lColWidth += ", 7";         // 6 - GodownName
            lColWidth += ", 7";         // 7 - Stock
            lColWidth += ", 7";         // 8 - WIPQty
            lColWidth += ", 7";         // 9 - Qty
            lColWidth += ", 7";         //10 - NewStock
            lColWidth += ", 7";         //11 - SizeID
            lColWidth += ", 7";         //12 - ColorID
            //lColWidth += ", 7";         //13 - UOMID
            lColWidth += ", 7";         //14 - GodownID

            // Column Input Length/Width
            lColMaxInputLen = "  0";           // 0 - ItemID
            lColMaxInputLen += ", 0";          // 1 - ItemCode
            lColMaxInputLen += ", 0";          // 2 - ItemName
            lColMaxInputLen += ", 0";          // 3 - SizeName
            lColMaxInputLen += ", 0";          // 4 - ColorName
            //lColMaxInputLen += ", 0";          // 5 - UnitName
            lColMaxInputLen += ", 0";          // 6 - GodownName
            lColMaxInputLen += ", 0";          // 7 - Stock
            lColMaxInputLen += ", 0";          // 8 - WIPQty
            lColMaxInputLen += ", 0";          // 9 - Qty
            lColMaxInputLen += ", 0";          //10 - NewStock
            lColMaxInputLen += ", 0";          //11 - SizeID
            lColMaxInputLen += ", 0";          //12 - ColorID
            //lColMaxInputLen += ", 0";          //13 - UOMID
            lColMaxInputLen += ", 0";          //14 - GodownID

            // Column Min Width
            lColMinWidth = "   0";                // 0 - ItemID
            lColMinWidth += ", 0";                // 1 - ItemCode
            lColMinWidth += ", 0";                // 2 - ItemName
            lColMinWidth += ", 0";                // 3 - SizeName
            lColMinWidth += ", 0";                // 4 - ColorName
            //lColMinWidth += ", 0";                // 5 - UnitName
            lColMinWidth += ", 0";                // 6 - GodownName
            lColMinWidth += ", 0";                // 7 - Stock
            lColMinWidth += ", 0";                // 8 - WIPQty
            lColMinWidth += ", 0";                // 9 - Qty
            lColMinWidth += ", 0";                //10 - NewStock
            lColMinWidth += ", 0";                //11 - SizeID
            lColMinWidth += ", 0";                //12 - ColorID
            //lColMinWidth += ", 0";                //13 - UOMID
            lColMinWidth += ", 0";                //14 - GodownID

            // Column Format
            lColFormat = "  T";                     // 0 - ItemID
            lColFormat += ", T";                    // 1 - ItemCode
            lColFormat += ", T";                    // 2 - ItemName
            lColFormat += ", T";                    // 3 - SizeName
            lColFormat += ", T";                    // 4 - ColorName
            //lColFormat += ", T";                    // 5 - UnitName
            lColFormat += ", T";                    // 6 - GodownName
            lColFormat += ",N0";                    // 7 - Stock
            lColFormat += ",N0";                    // 8 - WIPQty
            lColFormat += ",N0";                    // 9 - Qty
            lColFormat += ",N0";                    //10 - NewStock
            lColFormat += ", H";                    //11 - SizeID
            lColFormat += ", H";                    //12 - ColorID
            //lColFormat += ", H";                    //13 - UOMID
            lColFormat += ", H";                    //14 - GodownID

            // Column ReadOnly 1= readonly, 0 = read-write
            lColReadOnly = "  0";                     // 0 - ItemID
            lColReadOnly += ",1";                     // 1 - ItemCode
            lColReadOnly += ",1";                     // 2 - ItemName
            lColReadOnly += ",1";                     // 3 - SizeName
            lColReadOnly += ",1";                     // 4 - ColorName
            //lColReadOnly += ",1";                     // 5 - UnitName
            lColReadOnly += ",1";                     // 6 - GodownName
            lColReadOnly += ",1";                     // 7 - Stock
            lColReadOnly += ",1";                     // 8 - WIPQty
            lColReadOnly += ",1";                     // 9 - Qty
            lColReadOnly += ",1";                     //10 - NewStock
            lColReadOnly += ",1";                     //11 - SizeID
            lColReadOnly += ",1";                     //12 - ColorID
            //lColReadOnly += ",1";                     //13 - UOMID
            lColReadOnly += ",1";                     //14 - GodownID

            // For Saving Time
            tColType += "  N0";          // 0 - ItemID
            tColType += ",  T";          // 1 - ItemCode
            tColType += ",  T";          // 2 - ItemName
            tColType += ",  T";          // 3 - SizeName
            tColType += ",  T";          // 4 - ColorName
            //tColType += ",  T";          // 5 - UnitName
            tColType += ",  T";          // 6 - GodownName
            tColType += ", N0";          // 7 - Stock
            tColType += ", N0";          // 8 - WIPQty
            tColType += ", N0";          // 9 - Qty
            tColType += ", N0";          //10 - NewStock
            tColType += ", N0";          //11 - SizeID
            tColType += ", N0";          //12 - ColorID
            //tColType += ", N0";          //13 - UOMID
            tColType += ", N0";          //14 - GodownID

            tFieldName += "Code";           // 0 - ItemID
            tFieldName += ",ItemCode";      // 1 - ItemCode
            tFieldName += ",ItemName";      // 2 - ItemName
            tFieldName += ",SizeName";      // 3 - SizeName
            tFieldName += ",ColorName";     // 4 - ColorName
            //tFieldName += ",UOMID";         // 5 - UnitName
            tFieldName += ",GodownName";    // 6 - GodownName
            tFieldName += ",Stock";         // 7 - Stock
            tFieldName += ",WIPQty";      // 8 - WIPQty
            tFieldName += ",Qty";     // 9 - Qty
            tFieldName += ",NewStock";      //10 - NewStock
            tFieldName += ",SizeID";        //11 - SizeID
            tFieldName += ",ColorID";       //12 - ColorID
            //tFieldName += ",UOMID";         //13 - UOMID
            tFieldName += ",GodownID";      //14 - GodownID


            fHDR = lHDR;
            fColWidth = lColWidth;
            fColMaxInputLen = lColMaxInputLen;
            fColMinWidth = lColMinWidth;
            fColFormat = lColFormat;
            fColReadOnly = lColReadOnly;
            fFieldList = lFieldList;

            fColType = tColType;
            fFieldName = tFieldName;

            //lMask = null;
            //lCboFillType = null;
            //lCboTableKeyField = null;
            //lCboQry = null;         
        }


        private void frmIssueItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void txtIssueNo_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc1();
        }

        private void txtIssueNo_KeyDown(object sender, KeyEventArgs e)
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
            lblStock.Text = "0";
            lblWIPQty.Text = "0";
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
                lblStock.Text = "0";
                lblWIPQty.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grd.Rows.Add(txt_I_ItemID.Text.ToString(),
                lbl_I_ItemCode.Text.ToString(),
                lbl_I_ItemName.Text.ToString(),
                cbo_I_Size.Text.ToString(),
                cbo_I_Color.Text.ToString(),
                //cbo_I_UOM.Text.ToString(),
                cboGodown.Text.ToString(),
                lblStock.Text.ToString(),
                lblWIPQty.Text.ToString(),
                txtQty.Text.ToString(),
                "",
                cbo_I_Size.SelectedValue.ToString(),
                cbo_I_Color.SelectedValue.ToString(),
                //cbo_I_UOM.SelectedValue.ToString(),
                cboGodown.SelectedValue.ToString());
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
                        fLastID = txtIssueNo.Text.ToString();
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
                if (txtIssueNo.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    fDocID = clsDbManager.GetNextValDocID("Issue", "IssueId", fDocWhere, "");

                    lSQL = "insert into Issue (";
                    lSQL += "  IssueId ";                              //  0-    ItemID";   
                    lSQL += ", Date ";                                        //  2-    ItemNam 
                    lSQL += ", EmployeeId ";
                    lSQL += ", DepartmentId ";
                    lSQL += ", PurposeId ";
                    lSQL += ", MachineNo ";
                    lSQL += ", Contractor ";
                    lSQL += ", ItemGroupID";
                    lSQL += ", Note ";
                    lSQL += ", OrgId ";
                    lSQL += ", UserId ";
                    lSQL += ", Status ";
                    lSQL += ", BranchId ";
                    lSQL += " ) values (";
                    //                                                       
                    lSQL += "'" + fDocID.ToString() + "'";                  //  0-    ItemID";   
                    lSQL += ",'" + txtIssueNo.Text.ToString() + "";        //  1-    ItemCod  
                    lSQL += ", " + StrF01.D2Str(dtpIssue) + "";          //  2-    ItemNam
                    lSQL += ", " + cboEmployee.SelectedValue.ToString() + "";
                    lSQL += ", " + cboDepartment.SelectedValue.ToString() + "";
                    lSQL += ", " + cboPurpose.SelectedValue.ToString() + "";
                    lSQL += ", " + cboMachine.SelectedValue.ToString() + "";
                    lSQL += ", " + cboContractor.SelectedValue.ToString() + "";
                    lSQL += ", " + cboItemGroup.SelectedValue.ToString() + "";
                    lSQL += ", '" + txtNote.Text.ToString() + "'";
                    lSQL += ", 1";
                    lSQL += ", " + clsGVar.UserID;
                    lSQL += ", 0";
                    lSQL += ", 1";
                    lSQL += ")";                                              // 11    UOMID"; 
                }                                                               // 12- GodownID
                else
                {
                    fDocWhere = " IssueId = '" + txtIssueNo.Text.ToString() + "'";
                    if (clsDbManager.IDAlreadyExistWw("Issue", "IssueId", fDocWhere))
                    {

                        fDocAlreadyExists = true;
                        lSQL = "delete from IssueDetail ";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);
                        //
                    }

                    lSQL = "update Issue set";
                    lSQL += "  Date = '" + StrF01.D2Str(dtpIssue.Value) + "'";
                    lSQL += ", EmployeeId = '" + cboEmployee.SelectedValue.ToString() + "'";
                    lSQL += ", DepartmentId = '" + cboDepartment.SelectedValue.ToString() + "'";
                    lSQL += ", PurposeId = '" + cboPurpose.SelectedValue.ToString() + "'";
                    lSQL += ", Contractor = '" + cboContractor.SelectedValue.ToString() + "'";
                    lSQL += ", ItemGroupId = '" + cboItemGroup.SelectedValue.ToString() + "'";
                    lSQL += ", Note = '" + txtNote.Text.ToString() + "'";
                    lSQL += ", OrgId = 1";
                    lSQL += ", UserId = " + clsGVar.UserID;
                    lSQL += ", Status = 0";
                    lSQL += ", BranchId = 1";
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
                    if (grd.Rows[dGVRow].Cells[(int)GColIssueItems.ItemID].Value == null)
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

                    lSQL = "INSERT INTO IssueDetail (IssueId";
                    lSQL += ",ItemId,SizeId,ColorID,GodownId,Qty)";
                    lSQL += " VALUES (";
                    lSQL += "'" + txtIssueNo.Text.ToString() + "'";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColIssueItems.ItemID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColIssueItems.SizeID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColIssueItems.ColorID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColIssueItems.GodownID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColIssueItems.Qty].Value.ToString() + "";
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

        private void cboItemGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
  