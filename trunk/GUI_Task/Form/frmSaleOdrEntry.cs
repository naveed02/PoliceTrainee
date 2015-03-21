using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI_Task.Class;
//using JThomas.Controls;

using GUI_Task.StringFun01;
using GUI_Task.PrintDataSets;
using GUI_Task.PrintReport;
using GUI_Task.PrintViewer;

namespace GUI_Task
{
    enum GCol
    {
        ItemID = 0,
        ItemCode = 1,
        ItemName = 2,
        SizeName = 3,
        ColorName = 4, 
        UnitName = 5,
        Discount =6,
        ContQty=7,
        OrdQty=8,
        ContRemQty=9,
        DelQty=10,
        OrdUnDelQty=11,
        Rate=12,
        Amount=13,
        AvailBal=14,
        SizeID=15,
        ColorID=16, 
        UOMID=17
    }

    public partial class frmSaleOrdEntry : Form
    {

        //private ClientInfo _myClient;
        //private BindingList<InsuranceDetails> all_insurance_types = new BindingList<InsuranceDetails>();

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

        bool blnFormLoad=true;

        string strDocId = string.Empty;

        //bool blnFormLoad = true;


        public frmSaleOrdEntry()
        {
            InitializeComponent();
            //grd.EditMode = DataGridViewEditMode.EditOnEnter;

            ////DataGridView grid = new DataGridView();
            //grd.Dock = DockStyle.Fill;
            //grd.AutoGenerateColumns = true;

            //all_insurance_types.Add(new InsuranceDetails(1, "Health"));
            //all_insurance_types.Add(new InsuranceDetails(2, "Home"));
            //all_insurance_types.Add(new InsuranceDetails(3, "Life"));

            //var col = new DataGridViewComboBoxColumn
            //{
            //    DataSource = all_insurance_types,
            //    HeaderText = "Insurance Type",
            //    DataPropertyName = "InsurDetailz",
            //    DisplayMember = "ItType",
            //    ValueMember = "Self",
            //};

            //_myClient = new ClientInfo
            //{
            //    InsurDetailz = all_insurance_types[2],
            //    Name = "Jimbo"
            //};
            //grd.Columns.Add(col);
            //grd.DataSource = new BindingList<ClientInfo> { _myClient };
            //this.Controls.Add(grd);

            //this.FormClosing += new FormClosingEventHandler(frmSaleOrdEntry_FormClosing);
        }

        void frmSaleOrdEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            // make sure its updated
            //InsuranceDetails c = _myClient.InsurDetailz;
            //string name = _myClient.Name;
            // Place breakpoint here to see the changes in _myClient 
            //throw new NotImplementedException();
        }

        //class ClientInfo
        //{
        //    public string Name { get; set; }
        //    public InsuranceDetails InsurDetailz { get; set; }
        //}

        //class InsuranceDetails
        //{
        //    public int InsuranceTypeID { get; set; }
        //    public String ItType { get; set; }
        //    public InsuranceDetails Self { get { return this; } }

        //    public InsuranceDetails(int typeId, String itType)
        //    {
        //        this.InsuranceTypeID = typeId;
        //        this.ItType = itType;
        //    }
        //}

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSaleOrdEntry_Load(object sender, EventArgs e)
        {
            AtFormLoad();
            blnFormLoad = false;
            cboMainGroup_SelectedIndexChanged(sender, e);
            this.MaximizeBox = false;
            //grd.EditMode = DataGridViewEditMode.EditOnEnter;
        }
        
        private void AtFormLoad()
        {
            //private SourceGrid.Cells.Editors.EditorBase mEditor_Color;
            string lSQL = string.Empty;
            SettingGridVariable();
            LoadInitialControls();

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

            //Category Combo Fill
            lSQL = "Select Distinct 1 as SrNo, RIGHT(ItemCode,1) as Category from Item Order By RIGHT(ItemCode,1) ";

            clsFillCombo.FillCombo(cboCategory, clsGVar.ConString1, "Item" + "," + "ItemCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboCategory.SelectedValue);

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

            //Category Combo Fill
            lSQL = "SELECT DISTINCT 1,RIGHT(Itemcode,1) FROM Item ";
            clsFillCombo.FillCombo(cboCategory, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboCategory.SelectedValue);

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
                18,
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
            lSQL = "SELECT h.Code, i.ItemCode, i.Name AS ItemName, sz.cgdDesc AS SizeName, clr.cgdDesc AS ColorName, ";
            lSQL += " u.UnitName, h.Discount, 0 AS ContQty, h.Qty AS OrdQty, 0 AS ContRemQty, ";
            lSQL += " h.Del_Qty, 0 AS OrdUnDelQty, h.Rate, isNull(h.Qty,0)*(isNull(h.Rate,0)-isNull(h.Discount,0)) AS Amount, ";
            lSQL += " 0 AS AvailBal, h.SizeID, h.ColorID, i.UOMID ";
            lSQL += " from Ord_Hist h INNER JOIN Item i ON h.Code=i.ItemId ";
            lSQL += " INNER JOIN CatDtl clr ON h.ColorID=clr.cgdCode AND clr.cgCode=3";
            lSQL += " INNER JOIN CatDtl sz ON h.sizeid=sz.cgdCode AND sz.cgCode=5";
            lSQL += " INNER JOIN IMS_UOM u ON i.UOMID=u.UOMID ";
            lSQL += " where h.Ord_No='" + txtOrderNo.Text.ToString() + "';";
            //
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

        private void txtOrderNo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LookUp_Voc();
            
        }

        #region LookUp_Voc

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
        #endregion

        private void PassDataVocID(object sender)
        {
            //txtPassDataVocID.Text = ((TextBox)sender).Text;
            txtOrderNo.Text = ((TextBox)sender).Text;
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

            tSQL = "SELECT DISTINCT RIGHT(Itemcode,1) AS Category, d.Ord_No, d.Ord_Date, d.Cont_No, d.Cont_Date, d.Customer, h.Name AS CustName, ";
            tSQL += " d.BillNo, d.Status, d.Type, d.Adda, d.AddaId, d.ItemCategory,d.Cash_Pay, ";
            tSQL += " d.Qty, d.Amount, d.Category, d.Detail, d.ItemGroupID, c.cgdDesc AS ItemGroupName ";
            tSQL += " from Ord_Det d INNER JOIN Heads h ON d.Customer=h.Code ";
            tSQL += " INNER JOIN CatDtl c ON d.ItemGroupID = c.cgdCode AND c.cgCode = 6 ";
            tSQL += " INNER JOIN Item it ON d.Category = it.ItemId ";
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
                    dtpOrder.Text = (ds.Tables[0].Rows[0]["Ord_Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Ord_Date"].ToString());
                    //dtpOrder.Value = (ds.Tables[0].Rows[0]["doc_date"] == DBNull.Value ? DateTime.Now.ToString("T") : ds.Tables[0].Rows[0]["doc_date"]);
                    txtContractNo.Text = (ds.Tables[0].Rows[0]["Cont_No"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Cont_No"].ToString());
                    dtpContract.Text = (ds.Tables[0].Rows[0]["Cont_Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Cont_Date"].ToString());
                    mskCustomerCode.Text = (ds.Tables[0].Rows[0]["Customer"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Customer"].ToString());
                    lblName.Text = (ds.Tables[0].Rows[0]["CustName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CustName"].ToString());
                    txtBillNo.Text = (ds.Tables[0].Rows[0]["BillNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BillNo"].ToString());
                    txtOrderStatus.Text = (ds.Tables[0].Rows[0]["Status"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Status"].ToString());
                    txtSaleType.Text = (ds.Tables[0].Rows[0]["Type"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Type"].ToString());
                    txtDetail.Text = (ds.Tables[0].Rows[0]["Detail"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Detail"].ToString());
                    cboTransport.Text = (ds.Tables[0].Rows[0]["Adda"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Adda"].ToString());
                    cboItemGroup.Text = (ds.Tables[0].Rows[0]["ItemGroupName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemGroupName"].ToString());
                    cboCategory.Text = (ds.Tables[0].Rows[0]["Category"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Category"].ToString());
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
                    //PopulateGridData();
                    LoadGridData();
                    SumVoc();
                    //txtManualDoc.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Order No...", this.Text.ToString());
            }
        }
        #endregion

        private void txtOrderNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
        }

        private void mskCustomerCode_DoubleClick(object sender, EventArgs e)
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

            mskCustomerCode.Mask="";
            mskCustomerCode.Text= string.Empty;
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
        #endregion

        private void PassData(object sender)
        {
            mskCustomerCode.Mask = "";
            mskCustomerCode.Text = ((TextBox)sender).Text;
            mskCustomerCode.Mask = clsGVar.maskGLCode;
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
        #endregion

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
            lFieldList =   "Code";                //  0-    ItemID";       
            lFieldList += ",ItemCode";            //  1-    ItemCode";     
            lFieldList += ",ItemName";            //  2-    ItemName";     
            lFieldList += ",SizeName";            //  3-    SizeName";       
            lFieldList += ",ColorName";           //  4-    ColorName";      
            lFieldList += ",UnitName";            //  5-    UOMName";        
            lFieldList += ",Discount";            //  6-    Discount";     
            lFieldList += ",ContQty";             //  7-    ContQty";      
            lFieldList += ",OrdQty";              //  8-    OrdQty";       
            lFieldList += ",ContRemQty";          //  9    ContRemQty";   
            lFieldList += ",Del_Qty";             // 10    Del_Qty";      
            lFieldList += ",OrdUnDelQty";         // 11    OrdUnDelQty";  
            lFieldList += ",Rate";                // 12    Rate";         
            lFieldList += ",Amount";              // 13    Amount";       
            lFieldList += ",AvailBal";            // 14    AvailBal";     
            lFieldList += ",SizeID";              // 15    SizeID";     
            lFieldList += ",ColorID";             // 16    ColorID";     
            lFieldList += ",UOMID";               // 17    UOMID";     

            lHDR +=  "Item ID";            // 0-    ItemID";       
            lHDR += ",Item Code";         // 1-    ItemCode";     
            lHDR += ",Item Name";         // 2-    ItemName";     
            lHDR += ",Size";              // 3-    SizeID";       
            lHDR += ",Color";             // 4-    ColorID";      
            lHDR += ",UOM Name";            // 5-    UOMID";        
            lHDR += ",Discount";          // 6-    Discount";     
            lHDR += ",Cont.Qty";          // 7-    ContQty";      
            lHDR += ",Ord.Qty";           // 8-    OrdQty";       
            lHDR += ",Cont.Rem.Qty";      // 9     ContRemQty";   
            lHDR += ",Del.Qty";           // 10    Del_Qty";      
            lHDR += ",Ord.UnDel.Qty";     // 11    OrdUnDelQty";  
            lHDR += ",Rate";              // 12    Rate";         
            lHDR += ",Amount";            // 13    Amount";       
            lHDR += ",AvailBal";          // 14    AvailBal";     
            lHDR += ",SizeID";            // 15    SizeID";     
            lHDR += ",ColorID";           // 16    ColorID";     
            lHDR += ",UOMID";             // 17    UOMID";     

            // Col Visible Width
            lColWidth = "   5";                // 0-    ItemID";       
            lColWidth += ",12";                // 1-    ItemCode";     
            lColWidth += ",20";               // 2-    ItemName";     
            lColWidth += ", 7";                // 3-    SizeID";       
            lColWidth += ", 7";                // 4-    ColorID";      
            lColWidth += ", 7";                // 5-    UOMID";        
            lColWidth += ", 7";                // 6-    Discount";     
            lColWidth += ", 7";                // 7-    ContQty";      
            lColWidth += ", 7";                // 8-    OrdQty";       
            lColWidth += ", 7";                // 9    ContRemQty";   
            lColWidth += ", 7";                // 10    Del_Qty";      
            lColWidth += ", 7";                // 11    OrdUnDelQty";  
            lColWidth += ", 7";                // 12    Rate";         
            lColWidth += ",10";               // 13    Amount";       
            lColWidth += ", 7";                // 14    AvailBal";     
            lColWidth += ", 5";                // 15    SizeID";     
            lColWidth += ", 5";                // 16    ColorID";     
            lColWidth += ", 5";                // 17    UOMID";     

            // Column Input Length/Width
            lColMaxInputLen = "  0";                // 0-    ItemID";       
            lColMaxInputLen += ", 0";               // 1-    ItemCode";     
            lColMaxInputLen += ", 0";               // 2-    ItemName";     
            lColMaxInputLen += ", 0";               // 3-    SizeID";       
            lColMaxInputLen += ", 0";               // 4-    ColorID";      
            lColMaxInputLen += ", 0";               // 5-    UOMID";        
            lColMaxInputLen += ", 0";               // 6-    Discount";     
            lColMaxInputLen += ", 0";               // 7-    ContQty";      
            lColMaxInputLen += ", 0";               // 8-    OrdQty";       
            lColMaxInputLen += ", 0";               // 9    ContRemQty";   
            lColMaxInputLen += ", 0";               // 10    Del_Qty";      
            lColMaxInputLen += ", 0";               // 11    OrdUnDelQty";  
            lColMaxInputLen += ", 0";               // 12    Rate";         
            lColMaxInputLen += ", 0";               // 13    Amount";       
            lColMaxInputLen += ", 0";               // 14    AvailBal";     
            lColMaxInputLen += ", 0";               // 15    SizeID";     
            lColMaxInputLen += ", 0";               // 16    ColorID";     
            lColMaxInputLen += ", 0";               // 17    UOMID";     

            // Column Min Width
            lColMinWidth = "   0";                      // 0-    ItemID";       
            lColMinWidth += ", 0";                      // 1-    ItemCode";     
            lColMinWidth += ", 0";                      // 2-    ItemName";     
            lColMinWidth += ", 0";                      // 3-    SizeID";       
            lColMinWidth += ", 0";                      // 5-    ColorID";      
            lColMinWidth += ", 0";                      // 6-    UOMID";        
            lColMinWidth += ", 0";                      // 7-    Discount";     
            lColMinWidth += ", 0";                      // 8-    ContQty";      
            lColMinWidth += ", 0";                      // 9-    OrdQty";       
            lColMinWidth += ", 0";                      // 10    ContRemQty";   
            lColMinWidth += ", 0";                      // 11    Del_Qty";      
            lColMinWidth += ", 0";                      // 12    OrdUnDelQty";  
            lColMinWidth += ", 0";                      // 13    Rate";         
            lColMinWidth += ", 0";                      // 14    Amount";       
            lColMinWidth += ", 0";                      // 15    AvailBal";     
            lColMinWidth += ", 0";                      // 15    SizeID";     
            lColMinWidth += ", 0";                      // 16    ColorID";     
            lColMinWidth += ", 0";                      // 17    UOMID";     

            // Column Format
            lColFormat = "   T";                        // 0-    ItemID";       
            lColFormat += ", T";                       // 1-    ItemCode";     
            lColFormat += ", T";                       // 2-    ItemName";     
            lColFormat += ", T";                       // 3-    SizeID";       
            lColFormat += ", T";                       // 5-    ColorID";      
            lColFormat += ", T";                       // 6-    UOMID";        
            lColFormat += ",N2";                       // 7-    Discount";     
            lColFormat += ",N2";                       // 8-    ContQty";      
            lColFormat += ",N2";                       // 9-    OrdQty";       
            lColFormat += ",N2";                       // 10    ContRemQty";   
            lColFormat += ",N2";                       // 11    Del_Qty";      
            lColFormat += ",N2";                       // 12    OrdUnDelQty";  
            lColFormat += ",N2";                       // 13    Rate";         
            lColFormat += ",N2";                       // 14    Amount";       
            lColFormat += ",N2";                       // 15    AvailBal";     
            lColFormat += ", H";                       // 16    SizeID";     
            lColFormat += ", H";                       // 17    ColorID";     
            lColFormat += ", H";                       // 18    UOMID";     

            // Column ReadOnly 1= readonly, 0 = read-write
            lColReadOnly = "  0";                       // 0-    ItemID";       
            lColReadOnly += ",1";                       // 1-    ItemCode";     
            lColReadOnly += ",1";                       // 2-    ItemName";     
            lColReadOnly += ",0";                       // 3-    SizeID";       
            lColReadOnly += ",0";                       // 5-    ColorID";      
            lColReadOnly += ",0";                       // 6-    UOMID";        
            lColReadOnly += ",0";                       // 7-    Discount";     
            lColReadOnly += ",1";                       // 8-    ContQty";      
            lColReadOnly += ",0";                       // 9-    OrdQty";       
            lColReadOnly += ",1";                       // 10    ContRemQty";   
            lColReadOnly += ",1";                       // 11    Del_Qty";      
            lColReadOnly += ",1";                       // 12    OrdUnDelQty";  
            lColReadOnly += ",0";                       // 13    Rate";         
            lColReadOnly += ",1";                       // 14    Amount";       
            lColReadOnly += ",1";                       // 15    AvailBal";     
            lColReadOnly += ",1";                       // 16    SizeID";     
            lColReadOnly += ",1";                       // 17    ColorID";     
            lColReadOnly += ",1";                       // 18    UOMID";     

            // For Saving Time
            tColType += "  N0";             // 0-    ItemID";       
            tColType += ",SKP";             // 1-    ItemCode";     
            tColType += ",SKP";             // 2-    ItemName";     
            tColType += ",SKP";             // 3-    SizeID";       
            tColType += ",SKP";             // 5-    ColorID";      
            tColType += ",SKP";             // 6-    UOMID";        
            tColType += ", N2";             // 7-    Discount";     
            tColType += ",SKP";             // 8-    ContQty";      
            tColType += ", N2";             // 9-    OrdQty";       
            tColType += ",SKP";             // 10    ContRemQty";   
            tColType += ",SKP";             // 11    Del_Qty";      
            tColType += ",SKP";             // 12    OrdUnDelQty";  
            tColType += ", N2";             // 13    Rate";         
            tColType += ",SKP";             // 14    Amount";       
            tColType += ",SKP";             // 15    AvailBal";     
            tColType += ", N0";             // 15    SizeID";     
            tColType += ", N0";             // 15    ColorID";     
            tColType += ", N0";             // 15    UOMID";     

            tFieldName += "Code";               // 0-    ItemID";       
            tFieldName += ",ItemCode";            // 1-    ItemCode";     
            tFieldName += ",ItemName";            // 2-    ItemName";     
            tFieldName += ",SizeName";              // 3-    SizeID";       
            tFieldName += ",ColorName";             // 5-    ColorID";      
            tFieldName += ",UnitName";               // 6-    UOMID";        
            tFieldName += ",Discount";            // 7-    Discount";     
            tFieldName += ",ContQty";             // 8-    ContQty";      
            tFieldName += ",OrdQty";              // 9-    OrdQty";       
            tFieldName += ",ContRemQty";          // 10    ContRemQty";   
            tFieldName += ",Del_Qty";             // 11    Del_Qty";      
            tFieldName += ",OrdUnDelQty";         // 12    OrdUnDelQty";  
            tFieldName += ",Rate";                // 13    Rate";         
            tFieldName += ",Amount";              // 14    Amount";       
            tFieldName += ",AvailBal";            // 15    AvailBal";     
            tFieldName += ",SizeID";            // 16    SizeID";     
            tFieldName += ",ColorID";            // 17    ColorID";     
            tFieldName += ",UOMID";            // 18    UOMID";     

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

        //private void chkEdit_Click(object sender, EventArgs e)
        //{
        //    if (chkEdit.Checked == true)
        //    {
        //        grd.EditMode = DataGridViewEditMode.EditOnF2;
        //    }

        //}

        private void btnRunOrd2_Click(object sender, EventArgs e)
        {
            string strColumnHeaderName = string.Empty;
            string strColumnType = string.Empty;
            string strColumnWidth = string.Empty;
            string strColumnColName = string.Empty;
            string strColumnReadOnly = string.Empty;
            string strColumnDefaultCellStypeFormat = string.Empty;

            string[] strGridHeaderName = new string[grd.Columns.Count];
            string[] strGridType = new string[grd.Columns.Count];
            string[] strGridWidth = new string[grd.Columns.Count];
            string[] strGridColName = new string[grd.Columns.Count];
            string[] strGridReadOnly = new string[grd.Columns.Count];
            string[] strGridDefaultCellStypeFormat = new string[grd.Columns.Count];

            for (int i = 0; i < grd.Columns.Count; i++)
            {
                strGridHeaderName[i] = grd.Columns[i].HeaderText;
                strGridType[i] = grd.Columns[i].CellType.ToString();
                strGridWidth[i] = grd.Columns[i].Width.ToString();
                strGridColName[i] = grd.Columns[i].Name;
                strGridReadOnly[i] = grd.Columns[i].ReadOnly.ToString();
                strGridDefaultCellStypeFormat[i] = grd.Columns[i].DefaultCellStyle.Format.ToString();
            }
            for (int i = 0; i < grd.Columns.Count; i++)
            {
                strColumnHeaderName = strColumnHeaderName + strGridHeaderName[i].ToString() + ",";
                strColumnType = strColumnType + strGridType[i].ToString() + ",";
                strColumnWidth = strColumnWidth + strGridWidth[i].ToString() + ",";
                strColumnColName = strColumnColName + strGridColName[i].ToString() + ",";
                strColumnReadOnly = strColumnReadOnly + strGridReadOnly[i].ToString() + ",";
                strColumnDefaultCellStypeFormat = strColumnDefaultCellStypeFormat + strGridDefaultCellStypeFormat[i].ToString() + ",";
            }
            MessageBox.Show(strColumnHeaderName);
            //MessageBox.Show(strColumnType);
            //MessageBox.Show(strColumnWidth);
            //MessageBox.Show(strColumnColName);
            //MessageBox.Show(strColumnReadOnly);
            //MessageBox.Show(strColumnDefaultCellStypeFormat);
        }

        //private void btnContView_Click(object sender, EventArgs e)
        //{
        //    DataTable SizeSource;
        //    DataTable SizeGrid;

        //    DataTable ColorSource;
        //    DataTable ColorGrid;

        //    //dGrd.AutoGenerateColumns = false;
            
        //    //tableSource = new DataTable("tableSource");
        //    //tableSource.Columns.AddRange(new DataColumn[] { new DataColumn("id"), new DataColumn("job") });

        //    //tableSource.Rows.Add(1, "Manager");
        //    //tableSource.Rows.Add(2, "Supervisor");
        //    //tableSource.Rows.Add(3, "Cashier");
        //    //tableSource.Rows.Add(4, "Officer");
        //    //tableSource.Rows.Add(5, "Peon");

        //    //tableGrid = new DataTable("tableGrid");
        //    //tableGrid.Columns.Add("jobid");
        //    //tableGrid.Rows.Add(2);

        //    SizeSource = new DataTable("tableSource");
        //    SizeSource.Columns.AddRange(new DataColumn[] { new DataColumn("SizeId"), new DataColumn("SizeName") });

        //    ColorSource = new DataTable("ColorSource");
        //    ColorSource.Columns.AddRange(new DataColumn[] { new DataColumn("ColorId"), new DataColumn("ColorName") });

        //    DataSet ds = new DataSet();
        //    string tSQL = string.Empty;

        //    tSQL = "SELECT cgdCode, cgdDesc FROM CatDtl WHERE cgCode=" + Convert.ToString((int)Category.enmSize) + ";";
        //    tSQL += "SELECT cgdCode, cgdDesc FROM CatDtl WHERE cgCode=" + Convert.ToString((int)Category.enmColor) + ";";

        //    ds = clsDbManager.GetData_Set(tSQL, "CatDtl");

        //    int count = ds.Tables[0].Rows.Count;
        //    for (int i = 0; i < count; i++)
        //    {
        //        SizeSource.Rows.Add((int)ds.Tables[0].Rows[i]["cgdCode"], ds.Tables[0].Rows[i]["cgdDesc"].ToString());
        //    }

        //    count = ds.Tables[1].Rows.Count;
        //    for (int i = 0; i < count; i++)
        //    {
        //        ColorSource.Rows.Add((int)ds.Tables[1].Rows[i]["cgdCode"], ds.Tables[1].Rows[i]["cgdDesc"].ToString());
        //    }

        //    ds.Dispose();
        //    ds.Clear();

        //    //SizeGrid = new DataTable("tableGrid");
        //    //SizeGrid.Columns.Add("SizeNameSizeId");
        //    //SizeGrid.Rows.Add(2);

        //    //ColorGrid = new DataTable("ColorGrid");
        //    //ColorGrid.Columns.Add("ColorNameColorId");
        //    //ColorGrid.Rows.Add(2);

        //    //// When it is bound. It does not accept row manually. Evan a blank row is not acceptable.
        //    //DataGridViewTextBoxColumn cTB = new DataGridViewTextBoxColumn();
        //    //cTB.HeaderText = "Text Box Column";
        //    //cTB.Width = 100;
        //    //dGrd.Columns.Add(cTB);
        //    //// Combo Box Size
        //    //DataGridViewComboBoxColumn SizeCol = new DataGridViewComboBoxColumn();
        //    //SizeCol.HeaderText = "Size";
        //    //SizeCol.Width = 100;
        //    //SizeCol.DataSource = SizeSource;
        //    //SizeCol.DisplayMember = "SizeName";
        //    //SizeCol.ValueMember = "SizeId";
        //    //SizeCol.DataPropertyName = "SizeNameSizeID";
        //    //dGrd.Columns.Add(SizeCol);

        //    //// Combo Box Color
        //    //DataGridViewComboBoxColumn ColorCol = new DataGridViewComboBoxColumn();
        //    //ColorCol.HeaderText = "Color";
        //    //ColorCol.Width = 100;
        //    //ColorCol.DataSource = ColorSource;
        //    //ColorCol.DisplayMember = "ColorName";
        //    //ColorCol.ValueMember = "ColorId";
        //    //ColorCol.DataPropertyName = "ColorNameColorID";
        //    //dGrd.Columns.Add(ColorCol);

        //    ////using JThomas.Controls;
        //    //DataGridViewMaskedTextColumn mcol = new DataGridViewMaskedTextColumn("00000999");
        //    //mcol.DataPropertyName = "Number";
        //    //mcol.HeaderText = "Number";
        //    //mcol.Name = "Column";
        //    //mcol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
        //    //mcol.Width = 90;
        //    //dGrd.Columns.Add(mcol);

        //}

        //private void txt_I_ItemID_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F1)
        //    { 
                
        //    }
        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double l_Amount = 0;
            //string FormatTwoDecimal = "N";
            l_Amount = Convert.ToDouble(txt_I_OrdQty.Text.ToString()) * Convert.ToDouble(txt_I_Rate.Text.ToString());

            grd.Rows.Add(txt_I_ItemID.Text.ToString(),
                lbl_I_ItemCode.Text.ToString(),
                lbl_I_ItemName.Text.ToString(),
                cbo_I_Size.Text.ToString(),
                cbo_I_Color.Text.ToString(),
                cbo_I_UOM.Text.ToString(),
                txt_I_Discount.Text.ToString(),
                txt_I_ContQty.Text.ToString(),
                txt_I_OrdQty.Text.ToString(),
                "",  // Cont Rem Qty
                "",
                "",
                txt_I_Rate.Text.ToString(),
                l_Amount.ToString(),
                lblAvailBal.Text.ToString(),
                cbo_I_Size.SelectedValue.ToString(),
                cbo_I_Color.SelectedValue.ToString(),
                cbo_I_UOM.SelectedValue.ToString());

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
                //string aaa1 = mtDocDate.Text.ToString().Trim(' ', '-');
                //string aaa2 = mtDocDate.Text.ToString().Trim(' ', '-');
                //string aaa3 = mtDocID.Text.ToString().Trim(' ', '-');
                //string aaa4 = textDocRef.Text.ToString().Trim(' ', '-'); 
                //
                //if (mtBookID.Text.ToString().Trim(' ', '-') == "")
                //{
                //    ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Voucher Type ID / Book ID empty or blank");
                //    fTErr++;
                //    dGvError.Rows.Add(fTErr.ToString(), "Voucher Type ID / Book ID empty or blank", "", "Form Validation: " + ErrrMsg + "  " + lNow.ToString());
                //    lRtnValue = false;
                //}
                if (txtBillNo.Text.ToString().Trim(' ', '-') == "")
                {
                    //ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Date empty or blank, select a valid date and try again");
                    //fTErr++;
                    ////dGvError.Rows.Add(fTErr.ToString(), "Date empty or blank", "", "Form Validation: " + ErrrMsg + "  " + lNow.ToString());
                    //lRtnValue = false;
                }

                SumVoc();

                ////lDebit = (lblTotalDr.Text == "" ? 0 : Convert.ToDecimal(lblTotalDr.Text));
                ////lCredit = (lblTotalCr.Text == "" ? 0 : Convert.ToDecimal(lblTotalCr.Text));

                //lDebit = decimal.Parse((lblTotalDr.Text=="" ? 0: lblTotalDr.Text));
                //lCredit = decimal.Parse(lblTotalDr.Text);

                //if (lDebit != lCredit)
                //{
                //    if (!fSingleEntryAllowed)
                //    {
                //        // for for conventional books as in old Finac.
                //        fTErr++;
                //        ErrrMsg = StrF01.BuildErrMsg(ErrrMsg, "'" + "Sum: Debit: " + lDebit.ToString() + " Credit: " + lCredit.ToString() + " Diff: " + (lDebit - lCredit).ToString() + "");
                //        //dGvError.Rows.Add(fTErr.ToString(), "Total Debit/Credit", "", ErrrMsg + "  " + lNow.ToString());
                //        return false;
                //    }
                //}
                //fDocAmt = lDebit;
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
            //lblDocID.Text = string.Empty;
            //txtManualDoc.Tag = string.Empty;
            //txtManualDoc.Tag = 0;
            //txtManualDoc.Text = string.Empty;
            //txtManualDoc.Enabled = true;
            //txtRemarks.Text = string.Empty;
            //lblTotalCr.Text = string.Empty;
            //lblTotalDr.Text = string.Empty;
            //
            if (grd.Rows.Count > 0)
            {
                grd.Rows.Clear();
            }
            ResetFields();
            //chk_Edit.Checked = false;
            //txtManualDoc.Focus();
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

        private void SumVoc()
        {
            bool bcheck;
            decimal fQty = 0;
            decimal fAmount = 0;
            decimal rtnVal = 0;
            decimal outValue = 0;
            decimal fDiscount = 0;
            decimal fNetValue = 0;

            for (int i = 0; i < grd.RowCount; i++)
            {
                if (grd.Rows[i].Cells[(int)GCol.Amount].Value != null)
                {
                    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GCol.Amount].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fAmount = fAmount + outValue;
                    }
                }
                if (grd.Rows[i].Cells[(int)GCol.OrdQty].Value != null)
                {
                    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GCol.OrdQty].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fQty = fQty + outValue;
                    }
                } // if != null
                //grdVoucher[2, i].Value = (i + 1).ToString();

                if (grd.Rows[i].Cells[(int)GCol.Discount].Value != null)
                {
                    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GCol.Discount].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fDiscount = fDiscount + outValue;
                    }
                }

                if (grd.Rows[i].Cells[(int)GCol.Amount].Value != null)
                {
                    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GCol.Amount].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fNetValue = fNetValue + outValue;
                    }
                }
            }

            fNetValue = fNetValue - fDiscount;

            lblOrderValue.Text = String.Format("{0:0,0.00}", fAmount);
            lblOrderQty2.Text = String.Format("{0:0,0.00}", fQty);
            txtDiscountRs.Text = String.Format("{0:0,0.00}", fDiscount);
            lblNetvalue.Text = String.Format("{0:0,0.00}", fNetValue);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtManualDoc.Text))
            //{
            //    MessageBox.Show("Manual Voucher Number is Empty! Unable to Save");
            //    return;
            //}

            //if (fEditMod == true)
            //{
            //    if (chk_Edit.Checked == false)
            //    {
            //        return;
            //    }
            //}
            //if (msk_AccountIDDr.Text.Trim(' ', '_') == "")
            //{
            //    MessageBox.Show("Master GL Code is Empty! Unable to Save");
            //    return;
            //}
            //else
            //{
            //    //MessageBox.Show("has data");
            SaveData();
            MessageBox.Show("Data Saved Successfullly");
            //}
        }

        private bool SaveData()
        {
            bool rtnValue = true;
            fTErr = 0;
            //List<string> lManySQL = new List<string>();
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
                //if (mtBookID.Text.ToString().Trim(' ', '-') == "")
                //{
                //    MessageBox.Show("Voucher Type ID / Book ID empty or blank, select one and try again.", "Save: " + lblFormTitle.Text.ToString());
                //    return false;
                //}
                if (txtOrderNo.Text != null)
                {
                    if (txtOrderNo.Text.ToString().Trim(' ', '-') != "")
                    {
                        //if (Convert.ToInt32(txtManualDoc.Text.ToString()) > 0)
                        //{
                        //    // if already exists       
                        //}
                    }
                }
                ErrrMsg = "";
                if (grd.Rows.Count < 1)
                {
                    fTErr++;
                    //dGvError.Rows.Add(fTErr.ToString(), "Trans.", "", "No Transaction in the grid to save. " + "  " + lNow.ToString());
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
                // Grid Validation
                //if (!GridIDValidation("Ac ID", "MT", grdVoucher, dGvError, (int)GCol.acstrid, "gl_ac", "ac_strid", (int)GCol.debit, (int)GCol.credit, "STR"))
                //{
                //    textAlert.Text = "Grid: Validation Ac ID, Error. Check 'Error Tab'  ...." + "  " + lNow.ToString();
                //    //tabMDtl.SelectedTab = tabError;
                //    rtnValue = false;
                //}
                //if (!GridIDValidation("Ref/Prj ID", "MT", grdVoucher, dGvError, (int)GCol.refid, "geo_city", "city_id", (int)GCol.debit, (int)GCol.credit, "NUM"))
                //{
                //    textAlert.Text = "Grid: Validation Ref/Prj ID, Error. Check 'Error Tab'  ...." + "  " + lNow.ToString();
                //    //tabMDtl.SelectedTab = tabError;
                //    rtnValue = false;
                //}
                //if (!rtnValue)
                //{
                //    tabMDtl.SelectedTab = tabError;
                //    return rtnValue;
                //}
                // pending un comment when required
                //if (!GridCboValidation("Ref/Prj ID", "MT", grdVoucher, dGvError, (int)GCol.refid, "gl_ac", "ac_strid", (int)GCol.debit, (int)GCol.credit))
                //{
                //    tStextAlert.Text = "Grid: Validation Ref/Prj ID, Error. Check 'Error Tab'  ...." + lNow.ToString();
                //    tabMDtl.SelectedTab = tabError;
                //    return false;
                //}
                //

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
                        //fLastID = mtDocID.Text.ToString();
                        fLastID = txtOrderNo.Text.ToString();
                        if (fDocAlreadyExists)
                        {
                            textAlert.Text = "Existing ID: " + txtBillNo.Text + " Modified .... " + "  " + lNow.ToString();
                        }
                        else
                        {
                            textAlert.Text = "New ID: " + txtBillNo.Text + " Inserted .... " + "  " + lNow.ToString();
                        }
                        //EDButtons(true);
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
            //fDocAmt = clsDbManager.ConvDecimal(lblOrderValue.Text);

            try
            {
                //string lDocDateStr = StrF01.D2Str(msk_VocDate);
                //DateTime lDocDate = DateTime.Parse(lDocDateStr);

                if (txtOrderNo.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    //fDocAmt = decimal.Parse(lblTotalDr.Text.ToString());
                    //fDocID = clsDbManager.GetNextValDocID("gl_tran", "doc_id", NewDocWhere(), "");
                    fDocID = clsDbManager.GetNextValDocID("Ord_Det", "DocId", fDocWhere, "");
                    fDocID = fDocID + 1;
                    strDocId = "1-" + DateTime.Now.Year.ToString() + "-" + fDocID.ToString();
                    txtOrderNo.Text = strDocId;
                    
                    //txtOrderNo.Text = fDocID.ToString();
                    //
//                    INSERT INTO Ord_Det
//(Ord_No, Ord_Date,Customer,Type
//,Detail,Amount,Status,Discount,Disc_Dzn
//,Qty,Cash_Pay,Disc2,Adda,AddaId,P_H,Cont_No
//,Cont_Date,Category,ItemGroupID,ItemCategory,BillNo)
//     VALUES

                    lSQL = "insert into Ord_Det (";
                    lSQL += " DocId ";
                    lSQL += ", Ord_No ";                                         // 1-
                    lSQL += ", Ord_Date ";                                     // 2-
                    lSQL += ", Customer ";                                            // 3-
                    lSQL += ", Type ";                                         // 4-
                    lSQL += ", Detail ";                                          // 5-
                    lSQL += ", Amount ";                                          // 6-
                    lSQL += ", Status ";                                          // 7-
                    lSQL += ", Discount ";                                       // 8-
                    lSQL += ", Disc_Dzn ";                                           // 8-
                    lSQL += ", Qty ";                                        // 7-
                    lSQL += ", Cash_Pay ";                                        // 8-
                    //lSQL += ", Disc2 ";                                     // 9-
                    //lSQL += ", Adda ";                                      // 10-
                    lSQL += ", AddaId  ";                                  // 11-
                    //lSQL += ", P_H  ";                                  // 11-
                    lSQL += ", Cont_No  ";                                  // 11-
                    lSQL += ", Cont_Date  ";                                  // 11-
                    lSQL += ", Category  ";                                  // 11-
                    lSQL += ", ItemGroupID  ";                                  // 11-
                    lSQL += ", ItemCategory  ";                                  // 11-
                    lSQL += ", BillNo  ";                                  // 11-
                    lSQL += " ) values (";
                    //
                    lSQL += fDocID.ToString();
                    lSQL += ",'" + strDocId.ToString() + "'";      
                    lSQL += ", " + StrF01.D2Str(dtpOrder) + "";                 // 6-
                    lSQL += ",'" + mskCustomerCode.Text.ToString() + "'";                    
                    lSQL += ",'" + txtSaleType.Text.ToString() + "'";                        
                    lSQL += ",'" + txtDetail.Text.ToString() + "'";                          
                    lSQL += ",'" + Convert.ToDecimal(lblOrderValue.Text.ToString()) + "'";   
                    lSQL += ",'" + txtOrderStatus.Text.ToString() + "'";                     
                    lSQL += ",'" + Convert.ToDecimal(txtDiscountRs.Text.ToString()) + "'";
                    lSQL += ",'" + Convert.ToDecimal(txtDiscDZN.Text.ToString()) + "'";
                    lSQL += ",'" + Convert.ToDecimal(lblOrderQty2.Text.ToString()) + "'";
                    lSQL += ",'" + Convert.ToDecimal(txtAdvance.Text.ToString()) + "'";
                    lSQL += ", " + cboTransport.SelectedValue.ToString() + "";
                    lSQL += ",'" + txtContractNo.Text.ToString() + "'";                      
                    lSQL += ", " + StrF01.D2Str(dtpContract) + "";                 // 6-
                    lSQL += ", " + cboMainGroup.SelectedValue.ToString() + "";
                    lSQL += ", " + cboItemGroup.SelectedValue.ToString() + "";
                    lSQL += ",'" + cboCategory.Text.ToString() + "'";
                    lSQL += ",'" + txtBillNo.Text.ToString() + "'";                          
                    lSQL += ")";
                }
                else
                {
                    fDocWhere = " Ord_No = '" + txtOrderNo.Text.ToString() + "'";
                    //fDocWhere += " AND doc_Fiscal_ID = " + fDocFiscal.ToString();
                    //fDocWhere += " AND Doc_ID = " + String.Format("{0,0}", txtBillNo.Tag.ToString());
                    //if (clsDbManager.IDAlreadyExistWw("gl_tran", "doc_id", DocWhere("")))
                    if (clsDbManager.IDAlreadyExistWw("Ord_Det", "Ord_No", fDocWhere))
                    {

                        fDocAlreadyExists = true;
                        lSQL = "delete from ord_Hist ";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);
                        //
                    }
                    else
                    {
                        //dGvError.Rows.Add("M", "Master Doc", mtDocID.Text.ToString(), "Doc/Voucher " + mtDocID.Text.ToString() + " has been removed.");
                        //MessageBox.Show("Doc/Voucher ID " + txtBillNo.Tag.ToString() + " has been deleted or removed"
                        //   + "\n\r" + "The Voucher will be saved as new voucher, try again "
                        //   + "\n\r" + "Or press clear button to discard the voucher/Doc.", this.Text.ToString());
                        ////lblDocID.Text = "";
                        //rtnValue = false;
                        //return rtnValue;
                    }
                    //fDocID = Convert.ToInt64(txtBillNo.Tag.ToString());
                    lSQL = "update Ord_Det set";
                    //
                    lSQL += "  Ord_date = '" + StrF01.D2Str(dtpOrder.Value) + "'";                       // 9-
                    lSQL += ", Customer = '" + mskCustomerCode.Text.ToString() +"'";                   // 9-
                    lSQL += ", Type = '" + txtSaleType.Text.ToString() + "'";                   // 9-
                    lSQL += ", Detail = '" + StrF01.EnEpos(txtDetail.Text.ToString()) + "'";
                    lSQL += ", Amount =  " + Convert.ToDouble(lblOrderValue.Text.ToString()) + "";
                    lSQL += ", Status = '" + StrF01.EnEpos(txtOrderStatus.Text.ToString()) + "'";
                    lSQL += ", Discount = " + string.Format("{0:N2}", txtDiscountRs.Text) + "";
                    //lSQL += ", Disc_DZN = " + txtDiscountRs.ToString() == "" ? 0 : Convert.ToDecimal(txtDiscountRs.Text);
                    lSQL += ", Disc_DZN = " + string.Format("{0:N2}", txtDiscDZN.Text) + "";
                    lSQL += ", Qty = " + Convert.ToDouble(lblOrderQty2.Text.ToString()) + "";
                    lSQL += ", Cash_Pay = " + Convert.ToDouble(txtAdvance.Text.ToString()) + "";
                    lSQL += ", AddaID = " + cboTransport.SelectedValue.ToString() + "";
                    lSQL += ", Cont_No = '" + txtContractNo.Text.ToString() + "'";
                    lSQL += ", Cont_Date = '" + StrF01.D2Str(dtpContract.Value) + "'";
                    lSQL += ", Category = " + cboMainGroup.SelectedValue.ToString() + "";
                    lSQL += ", ItemGroupID = " + cboItemGroup.SelectedValue.ToString() + "";
                    lSQL += ", ItemCategory = '" + cboCategory.Text.ToString() + "'";
                    lSQL += ", BillNo = '" + StrF01.EnEpos(txtDetail.Text.ToString()) + "'";
                    //lSQL += ", modified_by = " + clsGVar.AppUserID.ToString();                  // 16-
                    //lSQL += ", modified_date = '" + StrF01.D2Str(DateTime.Now, true) + "'";     // 18-
                    lSQL += " where ";
                    lSQL += fDocWhere;
                    //

                }
                fManySQL.Add(lSQL);

                //// Top Portion
                //lSQL = "insert into gl_trandtl ( ";
                //// Middle Pottion
                //lSQL += " doc_vt_id ";                                                               // Form 1- 
                //lSQL += ", doc_fiscal_id ";                                                                // 4- Doc Fiscal 
                //lSQL += ", doc_id ";                                                                    // Form 2- 
                //lSQL += ", ac_id ";                                                                     // 3-
                //lSQL += ", NARRATION ";                                                                 // 8-
                //lSQL += ", DEBIT ";                                                                     // 9-    
                //lSQL += ", CREDIT ";                                                                    // 10-
                ////
                //lSQL += ", SERIAL_ORDER ";                                                              // 1-
                //lSQL += ", isChecked ";                                                                // 7-
                ////
                //// Bottom Portion
                ////
                //lSQL += ") values (";
                //lSQL += " " + clsGVar.GRN.ToString();                      // 3- Document Type, JV, Cash Receipt, Cash Payment, Bank Receipt, Bank Payment etc
                //lSQL += ", " + fDocFiscal.ToString();                      // 4- Document Fiscal
                //lSQL += ", " + txtBillNo.Tag.ToString();                          // 2- Form 1- Voucher_id
                ////
                //lSQL += ", " + lblName.Tag; //grdVoucher.Rows[dGVRow].Cells[(int)GColGRN_Old.acid].Value.ToString();            // 2- Serial Order replaced with SNo. 
                ////                                                                                       // 5- Ac Title NA
                //lSQL += ", '" + "Cash Receipt Voucher" + "'";      // 8- Narration 
                //lSQL += ", " + float.Parse(lblOrderValue.Text);           // 9- Debit. 
                //lSQL += ", " + 0;          // 10- Credit
                //lSQL += ", " + 0;          // 11- Combo 1 
                //lSQL += ", 0"; //is Checked
                //lSQL += ")";

                //
                //fManySQL.Add(lSQL);

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
                for (int dGVRow = 1; dGVRow < grd.Rows.Count; dGVRow++)
                {
                    //frmGroupRights.dictGrpForms.Add(Convert.ToInt32(dGVSelectedForms.Rows[dGVRow].Cells[0].Value.ToString()),
                    //    dGVSelectedForms.Rows[dGVRow].Cells[1].Value.ToString());
                    // Prepare Save Data to Db Table
                    //
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

                    lSQL = "INSERT INTO Ord_Hist (DocId";
                    lSQL += ",Ord_No,Code,sizeid,ColorID,Discount,Rate,Qty,Customer,SaleGLCode,FromDelivery)";
                    lSQL += " VALUES (";
                    lSQL += "" + fDocID + "";
                    lSQL += ", '" + strDocId.ToString() + "'";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GCol.ItemID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GCol.SizeID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GCol.ColorID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GCol.Discount].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GCol.Rate].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GCol.OrdQty].Value.ToString() + "";
                    lSQL += ",'" + mskCustomerCode.Text.ToString() + "'";
                    lSQL += ",'4-1-01-00-0000'";
                    lSQL += ", 0";
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

        private void txt_I_ItemID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_I_ItemID_DoubleClick(object sender, EventArgs e)
        {
            frmItemsHelpAuto frm = new frmItemsHelpAuto();
            //frm.MdiParent = this;
            //frm.Show();
            frm.ShowDialog();

            txt_I_ItemID.Text = frm.Ret_ItemID.ToString() ;
            lbl_I_ItemCode.Text = frm.Ret_ItemCode.ToString();
            lbl_I_ItemName.Text = frm.Ret_ItemName.ToString();
            Get_ItemsData();
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
            lblAvailBal.Text = (ds.Tables[0].Rows[0]["ItemBal"] == DBNull.Value ? "0" : ds.Tables[0].Rows[0]["ItemBal"].ToString());
            ds.Clear();

        }

        private void frmSaleOrdEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

        }

        private void btnOrdHelp_Click(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        private void mskCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_GL();
            }
        }

        private void btnACHelp_Click(object sender, EventArgs e)
        {
            LookUp_GL();
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


        private void btnNewOrd_Click(object sender, EventArgs e)
        {
            grd.Rows.Clear();
            ClearTextBoxes();
        }
    }
}
