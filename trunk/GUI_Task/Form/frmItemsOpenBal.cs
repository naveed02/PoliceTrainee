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
using JThomas.Controls;

namespace GUI_Task
{
    enum GcolIOB
    {
        ItemID = 0,
        ItemCode = 1,
        ItemName = 2,
        SizeName = 3,
        ColorName = 4,
       GodownName = 5,
        Qty = 6,
        Rate = 7,
        Amount = 8,
        SizeID = 9,
        ColorID = 10,
        GodownID = 11

    }
    public partial class frmItemsOpenBal : Form
    {
        //******* Grid Variable Setting -- Begin ******
        string fHDR = string.Empty;                       // Column Header
        string fColWidth = string.Empty;                  // Column Width (Input)
        string fColMinWidth = string.Empty;               // Column Minimum Width
        string fColMaxInputLen = string.Empty;            // Column Visible Length/Width 
        string fColFormat = string.Empty;                 // Column Format  
        string fColReadOnly = string.Empty;               // Column ReadOnly 1 = ReadOnly, 0 = Read-Write  
        string fFieldList = string.Empty;
        string strDocId = string.Empty;
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
        public frmItemsOpenBal()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmItemsOpenBal_Load(object sender, EventArgs e)
        {
            AtFormLoad();
            // blnFormLoad = false;
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

            //Item group cOMBO
            lSQL = "select cgdCode, cgdDesc from CatDtl where cgcode=" + Convert.ToString((int)Category.enmItemGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGroup, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGroup.SelectedValue);

            //Category Combo Fill
            lSQL = "SELECT DISTINCT 1,RIGHT(Itemcode,1) FROM Item ";
            //lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboCategory, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
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

            lSQL += " select id.ItemId AS Code, i.ItemCode, i.Name AS ItemName, sz.cgdDesc AS SizeName, clr.cgdDesc AS ColorName, ";
            lSQL += " gd.cgdDesc AS Godown, id.Qty, id.Rate, isNull(id.Qty,0)*isNull(id.Rate,0) AS Amount, id.SizeId, id.ColorId, id.GodownId";
        lSQL +=  "  from IOBDetail id ";
        lSQL +=   " INNER JOIN Item i ON i.ItemId=id.ItemId ";
        lSQL +=    "INNER JOIN CatDtl sz ON id.SizeId = sz.cgdCode AND sz.cgCode = 5 ";
        lSQL +=    "INNER JOIN CatDtl clr ON id.ColorID=clr.cgdCode AND clr.cgCode=3 ";
        lSQL +=   " INNER JOIN CatDtl gd ON id.GodownId = gd.cgdCode AND gd.cgCode = 2 ";
        lSQL += " where id.IOBId = '" + txtIOBNo.Text.ToString() + "'; ";   

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
                    "ir.IOBid",
                " ir.Date, ir.ItemGroupID AS ItemGroupName, ir.Note",
                " IOB ir inner join IOBDetail ird on ir.IOBId =ird.IOBId",
                    this.Text.ToString(),
                    1,
                    "IOB # ,IOB Date ,Item Group, Note",
                    "12,8,10,10",
                    " T, T, T, T",
                    true,
                    "",
                //"d.Category = " + cboMainGroup.SelectedValue.ToString(), 
                    "",
                    "TextBox"
                    );
            txt_I_ItemID.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID);
            sForm.ShowDialog();

            if (txtIOBNo.Text != null)
            {
                if (txtIOBNo.Text != null)
                {
                    if (txtIOBNo.Text.ToString() == "" || txtIOBNo.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtIOBNo.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecords();
                        //LoadSampleData();
                        SumVoc();
                    }
                }
            }
        }

        #endregion

        private void PassDataVocID(object sender)
        {
            //txtPassDataVocID.Text = ((TextBox)sender).Text;
            txtIOBNo.Text = ((TextBox)sender).Text;
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
            tSQL = "select ir.IOBId, ir.Date, cd.cgdDesc AS ItemGroupName, ir.Note";
            tSQL += " from IOB ir ";
            tSQL += " inner join IOBDetail ird on ir.IOBId=ird.IOBId INNER JOIN CatDtl cd on ir.ItemGroupID = cd.cgdCode AND cd.cgCode = 6 ";
            tSQL += " where ir.IOBId='" + txtIOBNo.Text.ToString() + "';";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "IOB");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    txtIOBNo.Text = (ds.Tables[0].Rows[0]["IOBId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["IOBId"].ToString());
                    dtpDate.Text = (ds.Tables[0].Rows[0]["Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Date"].ToString());
                    cboItemGroup.Text = (ds.Tables[0].Rows[0]["ItemGroupName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemGroupName"].ToString());
                    //cboCategory.Text = (ds.Tables[0].Rows[0]["ItemGroupName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemGroupName"].ToString());
                    txtNote.Text = (ds.Tables[0].Rows[0]["Note"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Note"].ToString());



                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    txtIOBNo.Text = (ds.Tables[0].Rows[0]["IOBId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["IOBId"].ToString());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
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


        private void txtDemandNoteNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
        }

        
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
            lFieldList += ",ItemCode";                // 1-    ItemCode";     
            lFieldList += ",ItemName";                  // 2-    ItemName";     
            lFieldList += ",SizeName";              // 3-    Size";       
            lFieldList += ",ColorName";             // 4-    Color";      
           // lFieldList += ",UnitName";               // 5-    UOM";        
            lFieldList += ",Godown";                 // 6-    godown";     
            lFieldList += ",Qty";                    // 7    Qty";   
            lFieldList += ",Rate";                   // 8    Rate";      
            lFieldList += ",Amount";                 // 9    Amount";  
            lFieldList += ",SizeId";                 // 10    sizeId";         
            lFieldList += ",ColorId";                // 11    ColorId";       
           // lFieldList += ",UomID";                  // 12    UOMID";     
            lFieldList += ",GodownId";               // 13    GodownId";

            lHDR += "Item ID";            // 0-    ItemID";     
            lHDR += ",Item Code";           // 1-    ItemCode"; 
            lHDR += ",Item Name";         // 2-    ItemName";   
            lHDR += ",Size";              // 3-    Size";       
            lHDR += ",Color";             // 4-    Color";      
           // lHDR += ",UOM";             // 5-    UOM";       
            lHDR += ",Godown";           // 6-    godown";    
            lHDR += ",Qty";         // 7    Qty";     
            lHDR += ",Rate";          // 8    Rate";        
            lHDR += ",Amount";       // 9    Amount";  
            lHDR += ",SizeID";            // 10    sizeId";    
            lHDR += ",ColorID";    // 11    ColorId";     
           // lHDR += ",UOMID";             // 12    UOMID";       
            lHDR += ",GodownID";           // 13    GodownId";  

            // Col Visible Width
            lColWidth = "   5";               // 0-    ItemID";      
            lColWidth += ",12";                 // 1-    ItemCode";  
            lColWidth += ", 20";              // 2-    ItemName";     
            //lColWidth += ", 7";               // 3-    Size";       
            lColWidth += ", 7";               // 4-    Color";      
            lColWidth += ", 7";                // 5-    UOM";        
            lColWidth += ", 7";                // 6-    godown";     
            lColWidth += ", 7";              // 7    Qty";     
            lColWidth += ", 7";              // 8    Rate";        
            lColWidth += ", 7";                // 9    Amount";  
            lColWidth += ", 7";                // 10    sizeId";     
           // lColWidth += ", 7";              // 11    ColorId";      
            lColWidth += ", 7";              // 12    UOMID";       
            lColWidth += ", 10";             // 13    GodownId";  
                           

            // Column Input Length/Width
            lColMaxInputLen = "  0";                // 0-    ItemID";      
            lColMaxInputLen += ", 0";                 // 1-    ItemCode";  
           // lColMaxInputLen += ", 0";               // 2-    ItemName";    
            lColMaxInputLen += ", 0";               // 3-    Size";       
            lColMaxInputLen += ", 0";               // 4-    Color";      
            lColMaxInputLen += ", 0";                // 5-    UOM";        
            lColMaxInputLen += ", 0";                // 6-    godown";     
            lColMaxInputLen += ", 0";              // 7    Qty";    
            lColMaxInputLen += ", 0";              // 8    Rate";       
            lColMaxInputLen += ", 0";                // 9    Amount";  
          //  lColMaxInputLen += ", 0";                // 10    sizeId";     
            lColMaxInputLen += ", 0";              // 11    ColorId";     
            lColMaxInputLen += ", 0";              // 12    UOMID";      
            lColMaxInputLen += ", 0";              // 13    GodownId"; 

            // Column Min Width
            lColMinWidth = "   0";                        // 0-    ItemID";    
            lColMinWidth += ", 0";                          // 1-    ItemCode";
            lColMinWidth += ", 0";                        // 2-    ItemName";  
           // lColMinWidth += ", 0";                        // 3-    Size";      
            lColMinWidth += ", 0";                        // 4-    Color";     
            lColMinWidth += ", 0";                         // 5-    UOM";      
            lColMinWidth += ", 0";                         // 6-    godown";   
            lColMinWidth += ", 0";                     // 7    Qty";     
            lColMinWidth += ", 0";                     // 8    Rate";        
            lColMinWidth += ", 0";                         // 9    Amount";  
            lColMinWidth += ", 0";                         // 10    sizeId";   
          //  lColMinWidth += ", 0";                     // 11    ColorId";     
            lColMinWidth += ", 0";                     // 12    UOMID";       
            lColMinWidth += ", 0";                     // 13    GodownId";     

            // Column Format
            lColFormat = "  T";                           // 0-    ItemID";    
            lColFormat += ", T";                            // 1-    ItemCode";
           // lColFormat += ", T";                          // 2-    ItemName";  
            lColFormat += ", T";                          // 3-    Size";      
            lColFormat += ", T";                          // 4-    Color";     
            lColFormat += ", T";                           // 5-    UOM";      
            lColFormat += ",T";                           // 6-    godown";   
            lColFormat += ",N2";                     // 7    Qty";      
            lColFormat += ",N2";                     // 8    Rate";         
            lColFormat += ",N2";                           // 9    Amount";  
            lColFormat += ", H";                           // 10    sizeId";   
            lColFormat += ", H";                     // 11    ColorId";      
           // lColFormat += ", H";                     // 12    UOMID";        
            lColFormat += ", H";                     // 13    GodownId";         

            // Column ReadOnly 1= readonly, 0 = read-write
            lColReadOnly = "  1";                           // 0-    ItemID";    
            lColReadOnly += ",1";                             // 1-    ItemCode";
            lColReadOnly += ",1";                           // 2-    ItemName";  
            lColReadOnly += ",0";                           // 3-    Size";      
            lColReadOnly += ",0";                           // 4-    Color";     
           // lColReadOnly += ",0";                            // 5-    UOM";      
            lColReadOnly += ",0";                           // 6-    godown";   
            lColReadOnly += ",0";                    // 7    Qty";      
            lColReadOnly += ",0";                    // 8    Rate";         
            lColReadOnly += ",1";                            // 9    Amount";  
            lColReadOnly += ",0";                            // 10    sizeId";   
            lColReadOnly += ",0";                    // 11    ColorId";      
           // lColReadOnly += ",0";                    // 12    UOMID";        
            lColReadOnly += ",0";                    // 13    GodownId";         

            // For Saving Time
            tColType += "  T";                  // 0-    ItemID";    
            tColType += ",  SKP";                    // 1-    ItemCode";
            tColType += ",  SKP";                  // 2-    ItemName";  
            tColType += ",  SKP";                  // 3-    Size";      
            tColType += ",  SKP";                  // 4-    Color";     
          //  tColType += ",  SKP";                   // 5-    UOM";      
            tColType += ", SKP";                  // 6-    godown";   
            tColType += ", N2";           // 7    Qty";       
            tColType += ", N2";           // 8    Rate";          
            tColType += ", N2";                   // 9    Amount";  
            tColType += ", N0";                   // 10    sizeId";   
            tColType += ", N0";           // 11    ColorId";       
            //tColType += ", N0";           // 12    UOMID";         
            tColType += ", N0";           // 13    GodownId";         

            tFieldName += "Code";                        // 0-    ItemID";    
            tFieldName += ",ItemCode";                     // 1-    ItemCode";
            tFieldName += ",ItemName";                   // 2-    ItemName";  
            tFieldName += ",SizeName";                   // 3-    Size";        
            tFieldName += ",ColorName";                  // 4-    Color";       
           // tFieldName += ",UOM";                       // 5-    UOM";      
            tFieldName += ",Godown";                   // 6-    godown";   
            tFieldName += ",Qty";               // 7    Qty";      
            tFieldName += ",Rate";                // 8    Rate";         
            tFieldName += ",Amount";                  // 9    Amount";  
            tFieldName += ",SizeID";                     // 10    sizeId";   
            tFieldName += ",ColorID";           // 11    ColorId";      
            //tFieldName += ",UOMID";                  // 12    UOMID";        
            tFieldName += ",GodownID";                // 13    GodownId";         


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

        private void frmItemsOpenBal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            double l_Amount = 0;
            //string FormatTwoDecimal = "N";
            l_Amount = Convert.ToDouble(txtQty.Text.ToString()) * Convert.ToDouble(txtRate.Text.ToString());

             grd.Rows.Add(txt_I_ItemID.Text.ToString(),
                lbl_I_ItemCode.Text.ToString(),                              // 0-    ItemID";    
                lbl_I_ItemName.Text.ToString(),                                // 1-    ItemCode";
                cbo_I_Size.Text.ToString(),                                  // 2-    ItemName";  
                cbo_I_Color.Text.ToString(),                                 // 3-    Size";        
                //cbo_I_UOM.Text.ToString(),                                   // 4-    Color";       
                cboGodown.Text.ToString(),                                  // 5-    UOM";      
                txtQty.Text.ToString(),                                       // 6-    godown";   
                txtRate.Text.ToString(),                          // 7    Qty";    
                                l_Amount.ToString(),
                                               // 8    Rate";         
                //"",                                                       // 9    Amount";  
                cbo_I_Size.SelectedValue.ToString(),                         // 10    sizeId";   
                cbo_I_Color.SelectedValue.ToString(),               // 11    ColorId";      
                //cbo_I_UOM.SelectedValue.ToString(),                      // 12    UOMID";        
                cboGodown.SelectedValue.ToString());                      // 13    GodownId";   

             SumVoc();
        }
        

        private void btnDgrd_Click(object sender, EventArgs e)
        {
             DataTable SizeSource;
            DataTable SizeGrid;

            DataTable ColorSource;
            DataTable ColorGrid;

            
            //using JThomas.Controls;
            //DataGridViewMaskedTextColumn mcol = new DataGridViewMaskedTextColumn("00000999");
            //mcol.DataPropertyName = "Number";
            //mcol.HeaderText = "Number";
            //mcol.Name = "Column";
            //mcol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            //mcol.Width = 90;
            //dGrd.Columns.Add(mcol);

        }

        private void txtIOBNo_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc();
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
            ds.Clear();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageBox.Show("Data Saved Successfullly");
            //}
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


        private void SumVoc()
        {
            bool bcheck;
            decimal fQty = 0;
            decimal fAmount = 0;
            decimal rtnVal = 0;
            decimal outValue = 0;

            for (int i = 0; i < grd.RowCount; i++)
            {
                if (grd.Rows[i].Cells[(int)GcolIOB.Amount].Value != null)
                {
                    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GcolIOB.Amount].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fAmount = fAmount + outValue;
                    }
                }
                if (grd.Rows[i].Cells[(int)GcolIOB.Qty].Value != null)
                {
                    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GcolIOB.Qty].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fQty = fQty + outValue;
                    }
                } // if != null
                //grdVoucher[2, i].Value = (i + 1).ToString();
                lblTotalAmount.Text = String.Format("{0:0,0.00}", fAmount);
                lblTotalQty.Text = String.Format("{0:0,0.00}", fQty);
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
                SumVoc();

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
                        fLastID = txtIOBNo.Text.ToString();
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
                if (txtIOBNo.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    fDocID = clsDbManager.GetNextValDocID("IOB", "DocId", fDocWhere, "");
                    strDocId = "1-" + DateTime.Now.Year.ToString() + "-" + fDocID.ToString();
                    txtIOBNo.Text = strDocId;
                    fDocID += fDocID;

                    lSQL = "insert into IOB (";
                    lSQL += " DocId ";
                    lSQL += " ,IOBid ";                                   // 1-    ItemCode";
                    lSQL += ", Date ";
                    lSQL += ", ItemGroupId ";
                    lSQL += ", Note ";
                    //lSQL += ", ItemCode ";                          // 2-    ItemName";  
                                                      // 3-    Size";      
                    
                                                       // 5-    UOM";      
                    lSQL += ", InOut ";                         // 7    Qty";      
                    lSQL += ", UserId ";                         // 8    Rate";         
                    lSQL += ", OrgId ";                                  // 9    Amount";  
                    //lSQL += ", Status ";                                 // 10    sizeId";   
                    lSQL += ", BranchId ";                       // 11    ColorId";      
                    lSQL += " ) values (";                       // 12    UOMID";        
                    //
                    lSQL += fDocID.ToString();
                    lSQL += ", '" + strDocId.ToString() + "'";// 13    GodownId";                      
                    lSQL += ", " + StrF01.D2Str(dtpDate) + "";          //  2-    ItemNam 
                    lSQL += ", " + cboItemGroup.SelectedValue.ToString() + "";
                    lSQL += ",'" + txtNote.Text.ToString() + "'";                             //  4-    SizeNam  
                    lSQL += ", 0";                                            //  6-    UOMName
                    lSQL += ", " + clsGVar.UserID.ToString() + "";                                            // 7- GodownName
                    lSQL += ", 0";                                              // 8- Qty
                    lSQL += ", 1";                                             // 9    SizeID";   
                    lSQL += ")";                                              // 11    UOMID"; 
                }                                                               // 12- GodownID
                else
                {
                    fDocWhere = " IOBId = '" + txtIOBNo.Text.ToString() + "'";
                    if (clsDbManager.IDAlreadyExistWw("IOB", "IOBId", fDocWhere))
                    {

                        fDocAlreadyExists = true;
                        lSQL = "delete from IOBDetail ";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);
                        //
                    }

                    lSQL = "update IOB set";
                    lSQL += "  Date = '" + StrF01.D2Str(dtpDate.Value) + "'";
                    lSQL += ", ItemGroupID = " + cboItemGroup.SelectedValue.ToString() + "";
                    lSQL += ", Note = '" + txtNote.Text.ToString() + "'";
                    lSQL += ", InOut = 1";
                    lSQL += ", UserId = 0";
                    lSQL += ", OrgId = 1";
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

                    lSQL = "INSERT INTO IOBDetail (DocId,IOBId";
                    lSQL += ",ItemId,SizeId,ColorID,GodownID,Qty,Rate)";
                    lSQL += " VALUES (";
                    lSQL += fDocID;
                    lSQL += ", '" + txtIOBNo.Text.ToString() + "'";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GcolIOB.ItemID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GcolIOB.SizeID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GcolIOB.ColorID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GcolIOB.GodownID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GcolIOB.Qty].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GcolIOB.Rate].Value.ToString() + "";
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

        private void txtIOBNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            grd.Rows.Clear();
            ClearTextBoxes();
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

        

        }
    }

