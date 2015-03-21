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
    enum GColIssueRet
    {
        ItemID = 0,          // ItemID = 0,
        ItemCode = 1,       //  ItemCode = 1,
        ItemName = 2,       //  ItemName = 2,
        SizeName = 3,        // SizeName = 3,
        ColorName = 4,        //ColorName = 4,
        GodownName = 5,      // GodownName = 5,
        Stock = 6,           // Stock = 6,
        IssueQty = 7,        // IssueQty = 8,
        ReturnQty = 8,       // ReturnQty = 9,
        NewStock = 9,       // NewStock = 10,
        SizeID = 10,         // SizeID = 11,
        ColorID = 11,        // ColorID = 12,
        GodownID = 12        // GodownID = 14

    }

    public partial class frmIssueRetItems : Form
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

        public frmIssueRetItems()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIssueRtnItems_Load(object sender, EventArgs e)
        {
            AtFormLoad();
            blnFormLoad = false;
            this.MaximizeBox = false;

        }

        private void AtFormLoad()
        {
            string lSQL = string.Empty;
            //dtpOrder.Value = now.;
            //msk_VocDate.Text = now.Date.ToString();

            this.KeyPreview = true;

            SettingGridVariable();
            LoadInitialControls();

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

            ////UOM Combo Fill
            //lSQL = "select UOMID, UnitName from IMS_UOM order by UnitName";

            //clsFillCombo.FillCombo(cbo_I_UOM, clsGVar.ConString1, "IMS_UOM" + "," + "UnitName" + "," + "False", lSQL);
            //fcboDefaultValue = Convert.ToInt16(cbo_I_UOM.SelectedValue);

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
            Godown.DataSource = ds.Tables [0];
            Godown.ValueMember = ds.Tables[0].Columns[0].ToString();
            Godown.DisplayMember = ds.Tables[0].Columns[1].ToString();
            ds.Clear();

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

            lSQL += " select id.ItemId AS Code, i.ItemCode, i.Name AS ItemName, sz.cgdDesc AS SizeName, clr.cgdDesc AS ColorName, ";
            lSQL += " gd.cgdDesc AS GodownName, i.StockLevel, e.Qty AS IssueQty, i.Qty AS ReturnQty, (isnull(it.Qty_In+i.Qty,0)) AS NewStock, id.SizeId, id.ColorId, id.GodownId ";
            lSQL += " from IssueRetDetail id INNER JOIN Item i ON i.ItemId=id.ItemId";
            lSQL += " INNER JOIN CatDtl sz ON id.SizeId = sz.cgdCode AND sz.cgCode = 5 ";
            lSQL += " INNER JOIN CatDtl clr ON id.ColorID=clr.cgdCode AND clr.cgCode=3 ";
            lSQL += " INNER JOIN CatDtl gd ON id.GodownId = gd.cgdCode AND gd.cgCode = 2 ";
            lSQL += " INNER JOIN IssueDetail e ON id.ItemId = e.ItemId INNER JOIN Item_Sec it ON it.Code = i.ItemId ";
            lSQL += " where IssueRetId = '" + txtRetNo.Text.ToString() + "'";

            clsDbManager.FillDataGrid(
                grd,
                lSQL,
                fFieldList,
                fColFormat);
        }

        private void frmIssueRetnItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void txtRetNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
        }

        private void txtRetNo_DoubleClick(object sender, EventArgs e)
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
            frmLookUp sForm = new frmLookUp(
                    "ir.IssueRetId",
                " ir.IssueDate, ir.ItemGroupId, ir.ItemGroupID AS ItemGroupName, ir.DepartmentId AS DepartmentName, ir.EmployeeId AS EmployeeName, ir.Note",
                " IssueRet ir inner join IssueRetDetail ird on ir.IssueRetId=ird.IssueRetId",
                    this.Text.ToString(),
                    1,
                    "Issue Return # ,Issue Return Date ,Item Group, Department, Employee Name, Note",
                    "12,8,10,10,15,20",
                    " T, T, T, T, T, T",
                    true,
                    "",
                //"d.Category = " + cboMainGroup.SelectedValue.ToString(), 
                    "",
                    "TextBox"
                    );
            txtRetNo.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID);
            sForm.ShowDialog();

            if (txtRetNo.Text != null)
            {
                if (txtRetNo.Text != null)
                {
                    if (txtRetNo.Text.ToString() == "" || txtRetNo.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtRetNo.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecords();
                        //LoadSampleData();
                        //SumVoc();
                    }
            }
        }
        }

        #endregion

        private void PassDataVocID(object sender)
        {
            //txtPassDataVocID.Text = ((TextBox)sender).Text;
            txtRetNo.Text = ((TextBox)sender).Text;
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
           tSQL = " SELECT ir.IssueRetId, ir.IssueId, p.first_name + ' ' + p.last_name AS EmpName, ";
           tSQL += " d.department_name AS DeptName, pu.cgdDesc AS Purpose, m.cgdDesc AS MachineName, ";
           tSQL += " c.cgdDesc AS ContractorName, i.cgdDesc AS ItemGroupName, ir.Note ";
           tSQL += " FROM IssueRet ir ";
           tSQL += " INNER JOIN PR_Employee p ON p.employeeid = ir.EmployeeId ";
           tSQL += " INNER JOIN PR_Department d ON d.departmentid = ir.DepartmentId ";
           tSQL += " INNER JOIN CatDtl pu ON ir.PurposeId = pu.cgdCode AND pu.cgCode = 10 ";
           tSQL += " INNER JOIN CatDtl m ON ir.Machine = m.cgdCode AND m.cgCode = 11 ";
           tSQL += " INNER JOIN CatDtl c ON ir.Contract = c.cgdCode AND c.cgCode = 12 ";
           tSQL += " INNER JOIN CatDtl i ON ir.ItemGroupID = i.cgdCode AND i.cgCode = 6 ";
           tSQL += " where ir.IssueRetId='" + txtRetNo.Text.ToString() + "';";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "IssueRet");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    txtRetNo.Text = (ds.Tables[0].Rows[0]["IssueRetId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["IssueRetId"].ToString());
                    txtIssueNo.Text = (ds.Tables[0].Rows[0]["IssueId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["IssueId"].ToString());
                    cboEmployee.Text = (ds.Tables[0].Rows[0]["EmpName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["EmpName"].ToString());
                    cboDepartment.Text = (ds.Tables[0].Rows[0]["DeptName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DeptName"].ToString());
                    cboPurpose.Text = (ds.Tables[0].Rows[0]["Purpose"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Purpose"].ToString());
                    cboMachine.Text = (ds.Tables[0].Rows[0]["MachineName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["MachineName"].ToString());
                    cboContractor.Text = (ds.Tables[0].Rows[0]["ContractorName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ContractorName"].ToString());
                    cboItemGroup.Text = (ds.Tables[0].Rows[0]["ItemGroupName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemGroupName"].ToString());
                    txtNote.Text = (ds.Tables[0].Rows[0]["Note"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Note"].ToString());

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

            tSQL = " SELECT i.IssueId, p.first_name + ' ' + p.last_name AS EmpName, ";
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
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    txtIssueNo.Text = (ds.Tables[0].Rows[0]["IssueId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["IssueId"].ToString());
                    cboEmployee.Text = (ds.Tables[0].Rows[0]["EmpName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["EmpName"].ToString());
                    cboDepartment.Text = (ds.Tables[0].Rows[0]["DeptName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DeptName"].ToString());
                    cboPurpose.Text = (ds.Tables[0].Rows[0]["Purpose"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Purpose"].ToString());
                    cboMachine.Text = (ds.Tables[0].Rows[0]["MachineName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["MachineName"].ToString());
                    cboContractor.Text = (ds.Tables[0].Rows[0]["ContractorName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ContractorName"].ToString());
                    cboItemGroup.Text = (ds.Tables[0].Rows[0]["ItemGroupName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemGroupName"].ToString());
                    txtNote.Text = (ds.Tables[0].Rows[0]["Note"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Note"].ToString());
                    
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                        //btn_EnableDisable(true);
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


        #region Color ForeGround/Background

        //private class CellBackColorAlternate : SourceGrid.Cells.Views.Cell
        //{
        //    public CellBackColorAlternate(Color firstColor, Color secondColor)
        //    {
        //        FirstBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(firstColor);
        //        SecondBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(secondColor);
        //    }

        //    private DevAge.Drawing.VisualElements.IVisualElement mFirstBackground;
        //    public DevAge.Drawing.VisualElements.IVisualElement FirstBackground
        //    {
        //        get { return mFirstBackground; }
        //        set { mFirstBackground = value; }
        //    }

        //    private DevAge.Drawing.VisualElements.IVisualElement mSecondBackground;
        //    public DevAge.Drawing.VisualElements.IVisualElement SecondBackground
        //    {
        //        get { return mSecondBackground; }
        //        set { mSecondBackground = value; }
        //    }

        //    protected override void PrepareView(SourceGrid.CellContext context)
        //    {
        //        base.PrepareView(context);

        //        if (Math.IEEERemainder(context.Position.Row, 2) == 0)
        //            Background = FirstBackground;
        //        else
        //            Background = SecondBackground;
        //    }
        //}

        //private class CheckBoxBackColorAlternate : SourceGrid.Cells.Views.CheckBox
        //{
        //    public CheckBoxBackColorAlternate(Color firstColor, Color secondColor)
        //    {
        //        FirstBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(firstColor);
        //        SecondBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(secondColor);
        //    }

        //    private DevAge.Drawing.VisualElements.IVisualElement mFirstBackground;
        //    public DevAge.Drawing.VisualElements.IVisualElement FirstBackground
        //    {
        //        get { return mFirstBackground; }
        //        set { mFirstBackground = value; }
        //    }

        //    private DevAge.Drawing.VisualElements.IVisualElement mSecondBackground;
        //    public DevAge.Drawing.VisualElements.IVisualElement SecondBackground
        //    {
        //        get { return mSecondBackground; }
        //        set { mSecondBackground = value; }
        //    }

        //    protected override void PrepareView(SourceGrid.CellContext context)
        //    {
        //        base.PrepareView(context);

        //        if (Math.IEEERemainder(context.Position.Row, 2) == 0)
        //            Background = FirstBackground;
        //        else
        //            Background = SecondBackground;
        //    }

        //}
        #endregion

        private void chkReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            //DataSet ds = new DataSet();
            //string tSQL = string.Empty;
            //tSQL = "SELECT cgdDesc FROM CatDtl WHERE cgCode=" + Convert.ToString((int)Category.enmColor);
            //ds = clsDbManager.GetData_Set(tSQL, "CatDtl");
            //int count = ds.Tables[0].Rows.Count;
            //string[] a_Color = new string[count];

            //for (int i = 0; i < count; i++)
            //{
            //    a_Color[i] = ds.Tables[0].Rows[i]["cgdDesc"].ToString();
            //}
            //ds.Dispose();
            //ds.Clear();

            //SourceGrid.Cells.Editors.EditorBase mEditor_Color;
            //mEditor_Color = new SourceGrid.Cells.Editors.ComboBox(typeof(string), a_Color, false);
            //mEditor_Color.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.AnyKey | SourceGrid.EditableMode.SingleClick;

            //for (int r = 1; r < grid1.RowsCount - 1; r++)
            //    for (int c = 0; c < grid1.ColumnsCount; c++)
            //    {
            //        if (grid1[2, 3].Editor != null)
            //            grid1[2, 4].Editor.EnableEdit = true;
            //        //grid1[r, c].Editor.EnableEdit = !chkReadOnly.Checked;
            //    }
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
            lFieldList = "Code";            // ItemID = 0,
            lFieldList += ",ItemCode";     //  ItemCode = 1,
            lFieldList += ",ItemName";         //  ItemName = 2,
            lFieldList += ",SizeName";      // SizeName = 3,
            lFieldList += ",ColorName";      //ColorName = 4,
            //lFieldList += ",UOM";           // UnitName = 5,
            lFieldList += ",GodownName";    // GodownName = 6,
            lFieldList += ",StockLevel";         // Stock = 7,
            lFieldList += ",IssueQty";      // IssueQty = 8,
            lFieldList += ",ReturnQty";     // ReturnQty = 9,
            lFieldList += ",NewStock";      // NewStock = 10,
            lFieldList += ",SizeID";       // SizeID = 11,
            lFieldList += ",ColorID";       // ColorID = 12,
            //lFieldList += ",UOMID";         // UOMID = 13,
            lFieldList += ",GodownID";      // GodownID = 14


            lHDR += "Item ID";           // ItemID = 0,
            lHDR += ",Item Code";        // ItemCode = 1,  
            lHDR += ",Item Name";        // ItemName = 2,
            lHDR += ",Size";             // SizeName = 3,
            lHDR += ",Color";            // ColorName = 4,
            //lHDR += ",UOM ID";           // UnitName = 5,
            lHDR += ",Godown";         // GodownName = 6,
            lHDR += ",Stock";       // Stock = 7,
            lHDR += ",IssueQty";        // IssueQty = 8,
            lHDR += ",ReturnQty";     // ReturnQty = 9,
            lHDR += ",NewStock";          // NewStock = 10,
            lHDR += ",SizeID";  // SizeID = 11,
            lHDR += ",ColorID";           // ColorID = 12,
            //lHDR += ",UOMID";         // UOMID = 13,
            lHDR += ",GodownID";       // GodownID = 14

            // Col Visible Width
            lColWidth = "   5";               // ItemID = 0,
            lColWidth += ", 12";               // ItemCode = 1,  
            lColWidth += ", 15";              // ItemName = 2,
            lColWidth += ", 7";               // SizeName = 3,
            lColWidth += ", 7";               // ColorName = 4,
            //lColWidth += ", 7";               // UnitName = 5,
            lColWidth += ", 7";               // GodownName = 6,
            lColWidth += ", 5";             // Stock = 7,
            lColWidth += ", 5";             // IssueQty = 8,
            lColWidth += ", 5";               // ReturnQty = 9,
            lColWidth += ", 1";               // NewStock = 10,
            lColWidth += ", 1";             // SizeID = 11,
            lColWidth += ", 1";             // ColorID = 12,
            //lColWidth += ", 7";            // UOMID = 13,
            lColWidth += ", 1";             // GodownID = 14

            // Column Input Length/Width
            lColMaxInputLen = "  0";               // ItemID = 0,
            lColMaxInputLen += ", 0";              // ItemCode = 1,  
            lColMaxInputLen += ", 0";              // ItemName = 2,
            lColMaxInputLen += ", 0";              // SizeName = 3,
            lColMaxInputLen += ", 0";              // ColorName = 4,
            //lColMaxInputLen += ", 0";              // UnitName = 5,
            lColMaxInputLen += ", 0";              // GodownName = 6,
            lColMaxInputLen += ", 0";            // Stock = 7,
            lColMaxInputLen += ", 0";            // IssueQty = 8,
            lColMaxInputLen += ", 0";              // ReturnQty = 9,
            lColMaxInputLen += ", 0";              // NewStock = 10,
            lColMaxInputLen += ", 0";            // SizeID = 11,
            lColMaxInputLen += ", 0";            // ColorID = 12,
            //lColMaxInputLen += ", 0";            // UOMID = 13,
            lColMaxInputLen += ", 0";            // GodownID = 14

            // Column Min Width
            lColMinWidth = "   0";                     // ItemID = 0,
            lColMinWidth += ", 0";                     // ItemCode = 1,  
            lColMinWidth += ", 0";                     // ItemName = 2,
            lColMinWidth += ", 0";                     // SizeName = 3,
            lColMinWidth += ", 0";                     // ColorName = 4,
            //lColMinWidth += ", 0";                     // UnitName = 5,
            lColMinWidth += ", 0";                     // GodownName = 6,
            lColMinWidth += ", 0";                   // Stock = 7, 
            lColMinWidth += ", 0";                   // IssueQty = 8, 
            lColMinWidth += ", 0";                     // ReturnQty = 9,
            lColMinWidth += ", 0";                     // NewStock = 10,
            lColMinWidth += ", 0";                   // SizeID = 11, 
            lColMinWidth += ", 0";                   // ColorID = 12, 
            //lColMinWidth += ", 0";                   // UOMID = 13, 
            lColMinWidth += ", 0";                   // GodownID = 14 

            // Column Format
            lColFormat = "  T";                       // ItemID = 0,
            lColFormat += ", T";                      // ItemCode = 1,  
            lColFormat += ", T";                      // ItemName = 2,
            lColFormat += ", T";                      // SizeName = 3,
            lColFormat += ", T";                      // ColorName = 4,
            //lColFormat += ", T";                      // UnitName = 5,
            lColFormat += ", T";                      // GodownName = 6,
            lColFormat += ",N0";                    // Stock = 7, 
            lColFormat += ",N0";                    // IssueQty = 8, 
            lColFormat += ",N0";                      // ReturnQty = 9,
            lColFormat += ",N0";                      // NewStock = 10,
            lColFormat += ", H";                    // SizeID = 11, 
            lColFormat += ", H";                    // ColorID = 12, 
            //lColFormat += ", H";                    // UOMID = 13, 
            lColFormat += ", H";                    // GodownID = 14 

            // Column ReadOnly 1= readonly, 0 = read-write
            lColReadOnly = "  0";                       // ItemID = 0,
            lColReadOnly += ",1";                       // ItemCode = 1,  
            lColReadOnly += ",1";                       // ItemName = 2,
            lColReadOnly += ",1";                       // SizeName = 3,
            lColReadOnly += ",1";                       // ColorName = 4,
            //lColReadOnly += ",1";                       // UnitName = 5,
            lColReadOnly += ",1";                       // GodownName = 6,
            lColReadOnly += ",1";                     // Stock = 7,
            lColReadOnly += ",0";                     // IssueQty = 8,
            lColReadOnly += ",0";                       // ReturnQty = 9,
            lColReadOnly += ",1";                       // NewStock = 10,
            lColReadOnly += ",1";                     // SizeID = 11,
            lColReadOnly += ",1";                     // ColorID = 12,
            //lColReadOnly += ",1";                     // UOMID = 13,
            lColReadOnly += ",1";                     // GodownID = 14

            // For Saving Time
            tColType += "  N0";             // ItemID = 0,
            tColType += ",  T";             // ItemCode = 1,  
            tColType += ",  T";             // ItemName = 2,
            tColType += ",  T";             // SizeName = 3,
            tColType += ",  T";             // ColorName = 4,
            //tColType += ",  T";             // UnitName = 5,
            tColType += ",  T";             // GodownName = 6,
            tColType += ", N0";           // Stock = 7,
            tColType += ", N0";           // IssueQty = 8,
            tColType += ", N0";             // ReturnQty = 9,
            tColType += ", N0";             // NewStock = 10,
            tColType += ", N0";           // SizeID = 11,
            tColType += ", N0";           // ColorID = 12,
            //tColType += ", N0";           // UOMID = 13,
            tColType += ", N0";           // GodownID = 14

            tFieldName += "Code";               // ItemID = 0,
            tFieldName += ",ItemCode";          // ItemCode = 1,  
            tFieldName += ",ItemName";          // ItemName = 2,
            tFieldName += ",SizeName";          // SizeName = 3, 
            tFieldName += ",ColorName";         // ColorName = 4, 
            //tFieldName += ",UOMID";             // UnitName = 5,
            tFieldName += ",GodownName";          // GodownName = 6,
            tFieldName += ",Stock";         // Stock = 7, 
            tFieldName += ",IssueQty";          // IssueQty = 8, 
            tFieldName += ",ReturnQty";        // ReturnQty = 9,
            tFieldName += ",NewStock";           // NewStock = 10,
            tFieldName += ",SizeID";     // SizeID = 11, 
            tFieldName += ",ColorID";            // ColorID = 12, 
            //tFieldName += ",UOMID";          // UOMID = 13, 
            tFieldName += ",GodownID";        // GodownID = 14 


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

        private void txtIssueNo_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc1();
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
                lblIssueQty.Text.ToString(),
                txtRetQty.Text.ToString(),
                "",
                cbo_I_Size.SelectedValue.ToString(),
                cbo_I_Color.SelectedValue.ToString(),
                //cbo_I_UOM.SelectedValue.ToString(),
                cboGodown.SelectedValue.ToString());
            SumVoc();

            MessageBox.Show("Data Successfully Added To GridView");
        }

        private void txt_I_ItemID_DoubleClick(object sender, EventArgs e)
        {
            frmItemsHelpAuto frm = new frmItemsHelpAuto();
            frm.ShowDialog();

            txt_I_ItemID.Text = frm.Ret_ItemID.ToString();
            lbl_I_ItemCode.Text = frm.Ret_ItemCode.ToString();
            lbl_I_ItemName.Text = frm.Ret_ItemName.ToString();
            lblStock.Text = "0";
            lblIssueQty.Text = "0";

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
                lblIssueQty.Text = "0";
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
                        fLastID = txtRetNo.Text.ToString();
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
                if (txtRetNo.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    fDocID = clsDbManager.GetNextValDocID("IssueRet", "DocId", fDocWhere, "");
                    fDocID = fDocID + 1;
                    strDocId = "1-" + DateTime.Now.Year.ToString() + "-" + fDocID.ToString();
                    txtRetNo.Text = strDocId;

                    lSQL = "insert into IssueRet (";
                    lSQL += "  IssueRetId ";                              //  0-    ItemID";   
                    lSQL += ", Date ";                                        //  2-    ItemNam 
                    lSQL += ", IssueId ";
                    lSQL += ", IssueDate ";
                    lSQL += ", EmployeeId ";
                    lSQL += ", DepartmentId ";
                    lSQL += ", PurposeId ";
                    lSQL += ", MachineNo ";
                    lSQL += ", Contractor ";
                    lSQL += ", Note ";
                    lSQL += ", ItemGroupID";
                    lSQL += ", OrgId ";
                    lSQL += ", UserId ";
                    lSQL += ", Status ";
                    lSQL += ", BranchId ";
                    lSQL += " ) values (";
                    //                                                       
                    lSQL += "'" + fDocID.ToString() + "'";                  //  0-    ItemID";   
                    lSQL += ",'" + strDocId.ToString() + "'";          //  1-    ItemCod  
                    lSQL += ", " + StrF01.D2Str(dtpIssueRet) + "";          //  2-    ItemNam
                    lSQL += ", '" + txtIssueNo.Text.ToString() + "'";
                    lSQL += ", " + StrF01.D2Str(dtpIssue) + "";
                    lSQL += ", " + cboEmployee.SelectedValue.ToString() + "";
                    lSQL += ", " + cboDepartment.SelectedValue.ToString() + "";
                    lSQL += ", " + cboPurpose.SelectedValue.ToString() + "";
                    lSQL += ", " + cboMachine.SelectedValue.ToString() + "";
                    lSQL += ", " + cboContractor.SelectedValue.ToString() + "";
                    lSQL += ", '" + txtNote.Text.ToString() + "'";
                    lSQL += ", " + cboItemGroup.SelectedValue.ToString() + "";
                    lSQL += ", 1";
                    lSQL += ", " + clsGVar.UserID;
                    lSQL += ", 0";
                    lSQL += ", 1";
                    lSQL += ")";                                              // 11    UOMID"; 
                }                                                               // 12- GodownID
                else
                {
                    fDocWhere = " IssueRetId = '" + txtRetNo.Text.ToString() + "'";
                    if (clsDbManager.IDAlreadyExistWw("IssueRet", "IssueRetId", fDocWhere))
                    {

                        fDocAlreadyExists = true;
                        lSQL = "delete from IssueRetDetail ";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);
                        //
                    }

                    lSQL = "update IssueRet set";
                    lSQL += "  Date = '" + StrF01.D2Str(dtpIssueRet.Value) + "'";
                    lSQL += ", IssueId = '" + txtIssueNo.Text.ToString() + "'";
                    lSQL += ", IssueDate = " + StrF01.D2Str(dtpIssue) + "";
                    lSQL += ", EmployeeId = '" + cboEmployee.SelectedValue.ToString() + "'";
                    lSQL += ", DepartmentId = '" + cboDepartment.SelectedValue.ToString() + "'";
                    lSQL += ", PurposeId = '" + cboPurpose.SelectedValue.ToString() + "'";
                    lSQL += ", Contractor = '" + cboContractor.SelectedValue.ToString() + "'";
                    lSQL += ", Note = '" + txtNote.Text.ToString() + "'";
                    lSQL += ", ItemGroupId = '" + cboItemGroup.SelectedValue.ToString() + "'";
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

                    lSQL = " INSERT INTO IssueRetDetail (DocId";
                    lSQL += " ,IssueRetId,ItemId, SizeId,ColorID,GodownId,Qty,ReturnQty)";
                    lSQL += " VALUES (";
                    lSQL += "" + fDocID + "";
                    lSQL += ", '" + strDocId.ToString() + "'";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColIssueRet.ItemID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColIssueRet.SizeID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColIssueRet.ColorID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColIssueRet.GodownID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColIssueRet.IssueQty].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColIssueRet.ReturnQty].Value.ToString() + "";
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

        private void btnHelp_Click(object sender, EventArgs e)
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


        private void btnAdd_Click(object sender, EventArgs e)
        {
            grd.Rows.Clear();
            ClearTextBoxes();
        }

        private void txtIssueNo_KeyDown(object sender, KeyEventArgs e)
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
                if (grd.Rows[i].Cells[(int)GColIssueRet.IssueQty].Value != null)
                {
                    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GColIssueRet.IssueQty].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fAmount = fAmount + outValue;
                    }
                }
            }

            lblTotalQty.Text = String.Format("{0:0,0.00}", fAmount);
        }
    }
}
