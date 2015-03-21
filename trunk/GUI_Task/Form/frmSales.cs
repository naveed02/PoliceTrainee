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
    enum GColSale
    {
        ItemId = 0,
        ItemCode = 1,
        ItemName = 2,
        SizeName = 3,
        ColorName = 4,
       // UnitName = 6,
        GodownName = 5,
        Stock = 6,
        Qty = 7,
        NewStock = 8,
        Rate = 9,
        
        //Amount = 12,
        SizeId = 10,
        ColorId = 11,
        //UOMID = 14,
        GodownId = 12      
    }
    public partial class frmSales : Form
    { //******* Grid Variable Setting -- Begin ******
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
        public frmSales()
        {
            InitializeComponent();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            AtFormLoad();
            this.MaximizeBox = false;
            blnFormLoad = false;
        }

        private void AtFormLoad()
        {
            string lSQL = string.Empty;

            this.KeyPreview = true;
            SettingGridVariable();
            LoadInitialControls();
            this.KeyPreview = true;

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
//            ds.Clear();

            //Godown cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmGodown);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboGodown, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboGodown.SelectedValue);

            ds = clsDbManager.GetData_Set(lSQL, "CatDtl");
            GodownColumn.DataSource = ds.Tables[0];
            GodownColumn.ValueMember = ds.Tables[0].Columns[0].ToString();
            GodownColumn.DisplayMember = ds.Tables[0].Columns[1].ToString();
            ds.Clear();


            //Type combo
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmType);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboType, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboType.SelectedValue);


            //LC cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmLC);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboLC, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboLC.SelectedValue);

            //Item group cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmItemGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGroup, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGroup.SelectedValue);

        }


        private void LoadInitialControls()
        {
           
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

            lSQL = " SELECT i.ItemId AS Code, i.ItemCode, i.Name AS ItemName, sz.cgdDesc AS SizeName, clr.cgdDesc AS ColorName, ";
            lSQL += " gdw.cgdDesc AS GodownName, 0 AS Stock, sd.Qty,sd.Rate,0 AS [New Stock], sd.SizeId, sd.ColorId, sd.GodownId ";
            lSQL += " FROM SaleDetail sd ";
            lSQL += " INNER JOIN Item i on i.ItemId = sd.ItemId ";
           // lSQL += " INNER JOIN Vendor v on v.VendorId = sd.VendorId ";
            lSQL += " INNER JOIN CatDtl sz on sd.SizeId = sz.cgdCode AND sz.cgCode = 5 ";
            lSQL += " INNER JOIN CatDtl clr on sd.ColorId = clr.cgdCode AND clr.cgCode = 3 ";
            //lSQL += " INNER JOIN IMS_UOM u on u.UOMID = u.UOMID ";
            lSQL += " INNER JOIN CatDtl gdw on sd.GodownId = gdw.cgdCode AND gdw.cgCode = 2 ";
            lSQL += " where sd.SaleId ='" + txtSale.Text.ToString() + "'; ";

            clsDbManager.FillDataGrid(
                grd,
                lSQL,
                fFieldList,
                fColFormat);
        }


        private void PopulateRecords()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  


            tSQL = "select s.SaleId, s.Date,s.GateOutwordId,s.VendorId,s.PurchaserId,t.cgdDesc AS TypeName,l.cgdDesc AS LCName,s.Discount,s.RecPerName, cd.cgdDesc AS ItemGroupName, s.Note, s.ItemGroupID ";
            tSQL += "from Sale s inner join SaleDetail sd on s.SaleId=sd.SaleId INNER JOIN CatDtl t ON s.TypeId=t.cgdCode AND t.cgCode = 8 ";
            tSQL += " inner join CatDtl cd on s.ItemGroupID=cd.cgdCode AND cd.cgCode=6 INNER JOIN CatDtl l ON s.LCId=l.cgdCode AND l.cgCode = 9 ";
            tSQL += " where s.SaleId='" + txtSale.Text.ToString() + "';";
            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Sale");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    lblGateOutwordId.Text = (ds.Tables[0].Rows[0]["GateOutwordId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["GateOutwordId"].ToString());
                    dtpSale.Text = (ds.Tables[0].Rows[0]["Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Date"].ToString());
                    //lblGateInward.Text = (ds.Tables[0].Rows[0]["GateInwordId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["GateInwordId"].ToString());
                    //dtpGI.Text = (ds.Tables[0].Rows[0]["GateInwordDate"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["GateInwordDate"].ToString());
                    cboType.Text = (ds.Tables[0].Rows[0]["TypeName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["TypeName"].ToString());
                    cboLC.Text = (ds.Tables[0].Rows[0]["LCName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["LCName"].ToString());
                   // cboGodown.Text = (ds.Tables[0].Rows[0]["GateInwordId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["GateInwordId"].ToString());
                    cboItemGroup.Text = (ds.Tables[0].Rows[0]["ItemGroupID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemGroupID"].ToString());
                    //cboGate.Text = (ds.Tables[0].Rows[0]["GateID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["GateID"].ToString());
                    txtNote.Text = (ds.Tables[0].Rows[0]["Note"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Note"].ToString());
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

        #region LookUp_Voc

        private void LookUp_Voc()
        {

           
            frmLookUp sForm = new frmLookUp(
                    "s.SaleId",
                " s.Date, cd.cgdDesc AS ItemGroupName, s.Note ",
                "  Sale s inner join SaleDetail sd on s.SaleId=sd.SaleId "
                + " inner join CatDtl cd on s.ItemGroupID=cd.cgdCode AND cd.cgCode=6",
                    this.Text.ToString(),
                    1,
                    "Sale,Date,Item Group Name,Note",
                    "12,8,15,20",
                    " T, T, T, T",
                    true,
                    "",
               
                    "",
                    "TextBox"
                    );
            txtSale.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID);
            sForm.ShowDialog();

            if (txtSale.Text != null)
            {
                if (txtSale.Text != null)
                {
                    if (txtSale.Text.ToString() == "" || txtSale.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtSale.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecords();
                       
                    }

                   
                }

                
            }
        }
        #endregion

        private void PassDataVocID(object sender)
        {
            //txtSaleID.Text = ((TextBox)sender).Text;
            txtSale.Text = ((TextBox)sender).Text;
            //msk_VocCode.Text = ((MaskedTextBox)sender).Text;
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
            lFieldList = "Code";                    //  0-    ItemID";       
            lFieldList += ",ItemCode";              //  1-    ItemCode";     
            lFieldList += ",ItemName";              //  2-    ItemName";
           // lFieldList += ",VenderName";                   //  8-    Vender Name
            lFieldList += ",SizeName";              //  3-    SizeName";       
            lFieldList += ",ColorName";             //  4-    ColorName";      
           // lFieldList += ",UnitName";              //  5-    UOMName";
            lFieldList += ",GodownName";            //  6- GodownName
            lFieldList += ",Stock";                 //  7- Stock
            lFieldList += ",Qty";                   //  8- Qty
            lFieldList += ",New Stock";                   //  8- Qty
            lFieldList += ",Rate";                   //  8- Qty
            //lFieldList += ",Amount";                   //  8- Qty

            lFieldList += ",SizeID";                //  9    SizeID";     
            lFieldList += ",ColorID";               //  10    ColorID";     
           // lFieldList += ",UOMID";                 //  11    UOMID"; 
            lFieldList += ",GodownId";              //  12- GodownID


            lHDR += "Item ID";            //  0-    ItemID";       
            lHDR += ",Item Code";         //  1-    ItemCode";     
            lHDR += ",Item Name";         //  2-    ItemName";
           // lHDR += ",Vender Name";         //  2-    ItemName";
            lHDR += ",Size";       //  3-    SizeName";      
            lHDR += ",Color";              //  4-    ColorName";     
            //lHDR += ",UOM Name";             //  5-    UOMName";
            lHDR += ",Godown";          //  6- GodownName
            lHDR += ",Stock";            //  7- Stock
            lHDR += ",Qty";               //  8- Qty
            lHDR += ",New Stock";               //  8- Qty
            lHDR += ",Rate";               //  8- Qty
            //lHDR += ",Amount";               //  8- Qty
            lHDR += ",SizeID";            //  9    SizeID";     
            lHDR += ",ColorID";           //  10    ColorID";     
            //lHDR += ",UOMID";             //  11    UOMID"; 
            lHDR += ",GodownId";          //  12- GodownID

            // Col Visible Width
            lColWidth = "   5";                 //  0-    ItemID";       
            lColWidth += ",12";                 //  1-    ItemCode";     
            lColWidth += ",20";                 //  2-    ItemName";
            //lColWidth += ",20";                 //  2-    VenderName";
            lColWidth += ",10";                 //  3-    SizeName";      
            lColWidth += ", 7";                 //  4-    ColorName";     
            //lColWidth += ", 7";                 //  5-    UOMName";
            lColWidth += ", 7";                 //  6- GodownName
            lColWidth += ", 7";                 //  7- Stock
            lColWidth += ", 5";                 //  8- Qty
            lColWidth += ", 5";                 //  8- New Stock
            lColWidth += ", 5";                 //  8- Rate
            //lColWidth += ", 5";                 //  8- Amount
            lColWidth += ", 5";                 //  9    SizeID";     
            lColWidth += ", 5";                 //  10    ColorID";     
            //lColWidth += ", 5";                 //  11    UOMID"; 
            lColWidth += ", 5";                 //  12- GodownID

            // Column Input Length/Width
            lColMaxInputLen = "  0";                 //  0-    ItemID";       
            lColMaxInputLen += ", 0";                //  1-    ItemCode";     
            lColMaxInputLen += ", 0";                //  2-    ItemName";
            //lColMaxInputLen += ", 0";                //  2-    VenderName";
            lColMaxInputLen += ", 0";                //  3-    SizeName";      
            lColMaxInputLen += ", 0";                //  4-    ColorName";     
            //lColMaxInputLen += ", 0";                //  5-    UOMName";
            lColMaxInputLen += ", 0";                //  6- GodownName
            lColMaxInputLen += ", 0";                //  7- Stock
            lColMaxInputLen += ", 0";                //  8- Qty
            lColMaxInputLen += ", 0";                //  2-    NewStock";
            lColMaxInputLen += ", 0";                //  2-    Rate";
            //lColMaxInputLen += ", 0";                //  2-    Amount";
            lColMaxInputLen += ", 0";                //  9    SizeID";     
            lColMaxInputLen += ", 0";                //  10    ColorID";     
            //lColMaxInputLen += ", 0";                //  11    UOMID"; 
            lColMaxInputLen += ", 0";                //  12- GodownID

            // Column Min Width
            lColMinWidth = "   0";                      //  0-    ItemID";           
            lColMinWidth += ", 0";                      //  1-    ItemCode";         
            lColMinWidth += ", 0";                      //  2-    ItemName";
            //lColMinWidth += ", 0";                      //  2-    VenderName";
            lColMinWidth += ", 0";                      //  3-    SizeName";      
            lColMinWidth += ", 0";                      //  4-    ColorName";         
            //lColMinWidth += ", 0";                      //  5-    UOMName";    
            lColMinWidth += ", 0";                      //  6- GodownName
            lColMinWidth += ", 0";                      //  7- Stock
            lColMinWidth += ", 0";                      //  8- Qty
            lColMinWidth += ", 0";                      //  2-    New Stock";
            lColMinWidth += ", 0";                      //  2-    Rate";
            //lColMinWidth += ", 0";                      //  2-    Amount";
            lColMinWidth += ", 0";                      //  9    SizeID";       
            lColMinWidth += ", 0";                      //  10    ColorID";        
            //lColMinWidth += ", 0";                      //  11    UOMID"; 
            lColMinWidth += ", 0";                      //  12- GodownID

            // Column Format
            lColFormat = "   T";                       //  0-    ItemID";            
            lColFormat += ", T";                       //  1-    ItemCode";         
            lColFormat += ", T";                       //  2-    ItemName";
            //lColFormat += ", T";                       //  2-    VenderName";
            lColFormat += ", T";                       //  3-    SizeName";      
            lColFormat += ", T";                       //  4-    ColorName";         
            //lColFormat += ", T";                       //  5-    UOMName";    
            lColFormat += ", T";                       //  6- GodownName
            lColFormat += ", T";                       //  7- Stock
            lColFormat += ", T";                       //  8- Qty
            lColFormat += ", T";                       //  2-    New Stock";
            lColFormat += ", T";                       //  2-    Rate";
            //lColFormat += ", T";                       //  2-    Amount";

            lColFormat += ", H";                       //  9    SizeID";       
            lColFormat += ", H";                       //  10    ColorID";        
            //lColFormat += ", H";                       //  11    UOMID"; 
            lColFormat += ", H";                       //  12- GodownID

            // Column ReadOnly 1= readonly, 0 = read-write
            lColReadOnly = "  0";                      //  0-    ItemID";       
            lColReadOnly += ",1";                      //  1-    ItemCode";     
            lColReadOnly += ",1";                      //  2-    ItemName";
            //lColReadOnly += ",0";                      //  2-    VenderName";
            lColReadOnly += ",0";                      //  3-    SizeName";      
            lColReadOnly += ",0";                      //  4-    ColorName";     
            //lColReadOnly += ",0";                      //  5-    UOMName";
            lColReadOnly += ",0";                      //  6- GodownName
            lColReadOnly += ",0";                      //  7- Stock
            lColReadOnly += ",0";                      //  8- Qty
            lColReadOnly += ",0";                      //  2-    New Stock";
            lColReadOnly += ",0";                      //  2-    Rate";
            //lColReadOnly += ",0";                      //  2-    Amount";
            lColReadOnly += ",1";                      //  9    SizeID";     
            lColReadOnly += ",1";                      //  10    ColorID";     
            //lColReadOnly += ",1";                      //  11    UOMID"; 
            lColReadOnly += ",1";                      //  12- GodownID

            // For Saving Time
            tColType += "  N0";             //  0-    ItemID";       
            tColType += ",SKP";             //  1-    ItemCode";     
            tColType += ",SKP";             //  2-    ItemName";
            //tColType += ",SKP";             //  2-    ItemName";
            tColType += ",SKP";              //  3-    SizeName";      
            tColType += ",SKP";             //  4-    ColorName";     
            //tColType += ",SKP";             //  5-    UOMName";
            tColType += ",SKP";             //  6- GodownName
            tColType += ", N0";             //  7- Stock
            tColType += ", N0";             //  8- Qty
            tColType += ",N0";             //  2-    NewStock";
            tColType += ",N0";             //  2-    Rate";
            //tColType += ",N0";             //  2-    Amount";
            tColType += ", N0";             //  9    SizeID";     
            tColType += ", N0";             //  10    ColorID";     
            //tColType += ", N0";             //  11    UOMID"; 
            tColType += ", N0";             //  12- GodownID

            tFieldName += "Code";               //  0-    ItemID";        
            tFieldName += ",ItemCode";          //  1-    ItemCode";        
            tFieldName += ",ItemName";          //  2-    ItemName";
            //tFieldName += ",VenderName";          //  2-    ItemName";
            tFieldName += ",SizeName";       //  3-    SizeName";      
            tFieldName += ",ColorName";          //  4-    ColorName";          
            //tFieldName += ",UnitName";         //  5-    UOMName";     
            tFieldName += ",GodownName";          //  6- GodownName
            tFieldName += ",Stock";        //  7- Stock
            tFieldName += ",Qty";               //  8- Qty
            tFieldName += ",NewStock";          //  2-    New Stock";
            tFieldName += ",Rate";          //  2-    Rate";
            //tFieldName += ",Amount";          //  2-    Amount";
            tFieldName += ",SizeID";            //  9    SizeID";     
            tFieldName += ",ColorID";           //  10    ColorID";      
            //tFieldName += ",UOMID";             //  11    UOMID"; 
            tFieldName += ",GodownID";          //  12- GodownID

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

        private void SumVoc()
        {
            bool bcheck;
            decimal fQty = 0;
            decimal fAmount = 0;
            decimal rtnVal = 0;
            decimal outValue = 0;

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
                        fLastID = txtSale.Text.ToString();
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
                if (txtSale.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    fDocID = clsDbManager.GetNextValDocID("Sale", "SaleId", fDocWhere, "");

                    lSQL = "insert into Sale (";
                    lSQL += "  SaleId ";                              //  0-    ItemID";   
                    lSQL += ", Date ";
                    lSQL += ", GateOutwordId ";
                    lSQL += ", GateOutDate ";//  1-    ItemCod  
                                                          //  2-    ItemNam 
                    lSQL += ", VendorId ";
                    lSQL += ", PurchaserId "; // 3- Descripti
                    lSQL += ", TypeId ";
                    lSQL += ", LCId ";
                    lSQL += ", ItemGroupId ";                                 //  5-    ColorNa  
                    lSQL += ", Note ";
                    //lSQL += ", GateId ";                                      //  6-    UOMName
                    lSQL += ", OrgId "; 
                    lSQL += ", UserId ";
                    lSQL += ", Status "; // 7- GodownName
                                                          // 8- Qty
                    //lSQL += ", Status ";                                      // 9    SizeID";   
                    lSQL += ", BranchId ";                                    // 10    ColorID"  
                    //lSQL += ", Disc2 ";                                     // 11    UOMID"; 
                    //lSQL += ", Adda ";                                        // 12- GodownID
                    lSQL += " ) values (";
                    //                                                       
                    lSQL += "'" + fDocID.ToString() + "'";                  //  0-    ItemID";   
                    lSQL += ",'" + txtSale.Text.ToString() + "";        //  1-    ItemCod  
                    lSQL += ", " + StrF01.D2Str(dtpSale) + "";
                    lSQL += ",'" + lblGateOutwordId.Text.ToString() + ""; 
                    lSQL += ", " + StrF01.D2Str(dtpGateOut) + "";//  2-    ItemNam 
                    lSQL += ",";
                    lSQL += ",";     // 3- Descripti
                    lSQL += ", 1";
                    lSQL += ", 1";                              
                         //  4-    SizeNam  
                    lSQL += ", " + cboItemGroup.SelectedValue.ToString() + "";  //  5-    ColorNa  
                    lSQL += ",'" + txtNote + "'";        
                    lSQL += ", 1";                                            //  6-    UOMName
                    lSQL += ", 1";                                            // 7- GodownName
                    lSQL += ", 0";                                              // 8- Qty
                    lSQL += ", 1";                                             // 9    SizeID";   
                    //lSQL += ", 1";                                            // 10    ColorID"  
                    lSQL += ")";                                              // 11    UOMID"; 
                }                                                               // 12- GodownID
                else
                {
                    fDocWhere = " SaleId = '" + txtSale.Text.ToString() + "'";
                    if (clsDbManager.IDAlreadyExistWw("Sale", "SaleId", fDocWhere))
                    {

                        fDocAlreadyExists = true;
                        lSQL = "delete from SaleDetail ";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);
                        //
                    }

                    lSQL = "update Sale set";
                    lSQL += "  Date = '" + StrF01.D2Str(dtpSale.Value) + "'";
                    lSQL += ", VendorId = " + mskSalesCode.Text.ToString() + "";
                    lSQL += ", PurchaserId = " + mskCustomerCode.Text.ToString() + "";
                    lSQL += ", TypeId = 1";
                    lSQL += ", LCId = 1";
                    lSQL += ", ItemGroupID = " + cboItemGroup.SelectedValue.ToString() + "";
                    lSQL += ", Note = '" + txtNote.Text.ToString() + "'";
                    lSQL += ", OrgId = 1";
                    lSQL += ", UserId = 0";
                    lSQL += ", Status = 0";
                  
                  //              lSQL += ",VendorId = '' ";


                    //                lSQL += ", GateID = 1";

                    //                  lSQL += ", Status = 0";
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

                    lSQL = "INSERT INTO SaleDetail (SaleId";
                    lSQL += ",ItemId,SizeId,ColorId,GodownId,Qty,Rate)";
                    lSQL += " VALUES (";
                    lSQL += "'" + txtSale.Text.ToString() + "'";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColSale.ItemId].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColSale.SizeId].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColSale.ColorId].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColSale.GodownId].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColSale.Qty].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColSale.Rate].Value.ToString() + "";
                  //  lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColSale.ItemSeq].Value.ToString() + "";
                    //lSQL += ", '" + grd.Rows[dGVRow].Cells[(int)GColIstm.Description].Value.ToString() + "'";
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
        
        
        
        
        
        
        
        
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mskSalesCodeCR_MouseDoubleClick(object sender, MouseEventArgs e)
        
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
                    " Code, Name",
                    "16,40",
                    " T, T",
                    true,
                    "",
                    "",
                    "TextBox"
                    );

           mskSalesCode.Mask = "";
           mskSalesCode.Text = string.Empty;
            mskSalesCode.Mask = clsGVar.maskGLCode;

            sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
            sForm.ShowDialog();
            if (mskSalesCode.Text != null)
            {
                if (mskSalesCode.Text != null)
                {
                    if (mskSalesCode.Text.ToString() == "" || mskSalesCode.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (mskSalesCode.Text.ToString().Trim().Length > 0)
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
            mskSalesCode.Mask = "";
            mskSalesCode.Text = ((TextBox)sender).Text;
            mskSalesCode.Mask = clsGVar.maskGLCode;
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
            tSQL += " where Code ='" + mskSalesCode.Text.ToString() + "';";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Heads");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    lblNameS.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());
                    
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


        private void mskSalesCodeCR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_GL();
            }
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
                    lblNameC.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());
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

        private void frmSales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
       
        

       

        private void txtSaleNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
        }

        private void txtSaleNo_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

     

       
        

        private void txtGateOutward_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                
            }
        }

        private void txtGateOutward_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double l_Amount = 0;
            //string FormatTwoDecimal = "N";
            l_Amount = Convert.ToDouble(txtQty.Text.ToString()) * Convert.ToDouble(txtRate.Text.ToString());
            grd.Rows.Add(txt_I_ItemID.Text.ToString(),
               lbl_I_ItemCode.Text.ToString(),
               lbl_I_ItemName.Text.ToString(),
               cbo_I_Size.Text.ToString(),
               cbo_I_Color.Text.ToString(),
               //cbo_I_UOM.Text.ToString(),
               cboGodown.Text.ToString(),
               txtStock.Text.ToString(),
               txtQty.Text.ToString(),
               txtNewStock.Text.ToString(),
               txtRate.Text.ToString(),
               l_Amount.ToString(),
                cboGodown.Text.ToString(),
                //txtQty.Text.ToString(),
               cbo_I_Size.SelectedValue.ToString(),
               cbo_I_Color.SelectedValue.ToString(),
               //cbo_I_UOM.SelectedValue.ToString(),
            cboGodown.SelectedValue.ToString());

            SumVoc();
        }

        private void txt_I_ItemID_DoubleClick(object sender, EventArgs e)
        {
            frmItemsHelpAuto frm = new frmItemsHelpAuto();
            frm.ShowDialog();

            txt_I_ItemID.Text = frm.Ret_ItemID.ToString();
            lbl_I_ItemCode.Text = frm.Ret_ItemCode.ToString();
            lbl_I_ItemName.Text = frm.Ret_ItemName.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageBox.Show("Data Saved Successfullly");
        }

        private void optApprovedVerified_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void optInProcess_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void lblNetValue_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalQty_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalValue_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void txtDeliveryPersonName_TextChanged(object sender, EventArgs e)
        {

        }

        private void grd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboLC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void optSingleItem_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void optMultiItem_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dtpSale_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dtpGateOut_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblNameS_Click(object sender, EventArgs e)
        {

        }

        private void lblNameC_Click(object sender, EventArgs e)
        {

        }

        private void mskSalesCode_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void mskCustomerCode_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboItemGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSale_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void cboGodown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtNewStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void cbo_I_Color_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbo_I_Size_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void lbl_I_ItemName_Click(object sender, EventArgs e)
        {

        }

        private void lbl_I_ItemCode_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void txt_I_ItemID_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sSMaster_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tSlblUser_Click(object sender, EventArgs e)
        {

        }

        private void tStextUser_Click(object sender, EventArgs e)
        {

        }

        private void tSlblStatus_Click(object sender, EventArgs e)
        {

        }

        private void tStextStatus_Click(object sender, EventArgs e)
        {

        }

        private void tSlblTotal_Click(object sender, EventArgs e)
        {

        }

        private void tStextTotal_Click(object sender, EventArgs e)
        {

        }

        private void tSlblAlert_Click(object sender, EventArgs e)
        {

        }

        private void textAlert_Click(object sender, EventArgs e)
        {

        }

        private void lblGateOutwordId_Click(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        
          
    }
}

       


       

      
     

    