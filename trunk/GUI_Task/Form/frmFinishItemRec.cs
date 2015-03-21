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
    enum GColFinItemRec
    {
        ItemID = 0,
        ItemCode = 1,
        ItemName = 2,
        SizeName = 3,
        ColorName = 4,
        GodownName = 5,
        Stock = 6,
        Qty = 7,
        SizeID = 8,
        ColorID = 9,
        GodownID = 10
    }

    public partial class frmFinishItemRec : Form
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
        bool fDocAlreadyExists = false;             // Check if Doc/voucher already exists (Edit Mode = True, New Mode = false)

        bool blnFormLoad = true;
        int fcboDefaultValue = 0;
        
        public frmFinishItemRec()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFinishItemRec_Load(object sender, EventArgs e)
        {
            AtFormLoad();
            this.MaximizeBox = false;
            blnFormLoad = false;
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
                11,
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

        private void AtFormLoad()
        {
            string lSQL = string.Empty;

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

            //Godown cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmGodown);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboGodown, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboGodown.SelectedValue);

            ds = clsDbManager.GetData_Set(lSQL, "IMS_UOM");
            GodownColumn.DataSource = ds.Tables[0];
            GodownColumn.ValueMember = ds.Tables[0].Columns[0].ToString();
            GodownColumn.DisplayMember = ds.Tables[0].Columns[1].ToString();
            ds.Clear();


            //Emp Code Combo Fill
            lSQL = "SELECT employeeid, first_name +' '+ last_name AS EmpName FROM PR_Employee ";
            //lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboEmpCode, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboEmpCode.SelectedValue);

            //Category Combo Fill
            lSQL = "SELECT DISTINCT 1,RIGHT(Itemcode,1) FROM Item ";
            //lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboCategory, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboCategory.SelectedValue);

            //Item group cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmItemGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGroup, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGroup.SelectedValue);

            //Machine No Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode= 11 ";
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboMachineNo, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboMachineNo.SelectedValue);

            //Contractor Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode= 12 ";
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboContractor, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboContractor.SelectedValue);

            //Shift Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode= 1 ";
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboShift, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboShift.SelectedValue);

            //Charges Type
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode= 4 ";
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboChargesType, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboChargesType.SelectedValue);
        }

        private void frmFinishItemRec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        #region LookUp_Voc

        private void LookUp_Voc()
        {
            frmLookUp sForm = new frmLookUp(
                    "f.FinishRecId",
                    "f.ChargesTmplID, f.ChargesTmplDes, f.Date, cd.cgdDesc AS ItemGroupName, fd.Qty ",
                    " FinRec f INNER JOIN CatDtl cd on f.ItemGroupID = cd.cgdCode AND cd.cgCode = 6 INNER JOIN FinishRecDetail fd on fd.FinishRecId = f.FinishRecId ",
                    this.Text.ToString(),
                    1,
                    " Receive No, Charges Templ No, Charge Templ, Receive Date, Item Group, Qty ",
                    "8,8,12,8,12,8",
                    " T, T, T, T, T, T",
                    true,
                    "",
                    "",
                    "TextBox"
                    );

            txtFinishRecNo.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID);
            sForm.ShowDialog();

            if (txtFinishRecNo.Text != null)
            {
                if (txtFinishRecNo.Text != null)
                {
                    if (txtFinishRecNo.Text.ToString() == "" || txtFinishRecNo.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtFinishRecNo.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecords();
                    }

                }

            }
        }
        #endregion

        private void PassDataVocID(object sender)
        {
            txtFinishRecNo.Text = ((TextBox)sender).Text;
        }


        private void PopulateRecords()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  

            tSQL += " select f.Date, f.ChargesTmplID ,f.ChargesTmplDes, f.FinishRecId, cd.cgdDesc AS ItemGroupName, fd.Qty, ";
			tSQL += " fr.MachineNo, fr.Contractor, s.cgdDesc AS Shift, c.cgdDesc AS ChargesType, ";
			tSQL += " f.Category, f.Note from FinRec f INNER JOIN CatDtl cd on f.ItemGroupID = cd.cgdCode AND cd.cgCode = 6 ";
            tSQL += " INNER JOIN FinishRecDetail fd on fd.FinishRecId = f.FinishRecId ";
            tSQL += " INNER JOIN FinishRec fr ON fr.FinishRecId = f.FinishRecId ";
            tSQL += " INNER JOIN CatDtl s ON fr.ShiftId = s.cgdCode AND s.cgCode = 1 ";
            tSQL += " INNER JOIN CatDtl c ON fr.ChargesType = c.cgdCode AND c.cgCode = 4 ";
            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Heads");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    txtFinishRecNo.Text = (ds.Tables[0].Rows[0]["FinishRecId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["FinishRecId"].ToString());
                    dtpFinishRec.Text = (ds.Tables[0].Rows[0]["Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Date"].ToString());
                    txtChargesTempNo.Text = (ds.Tables[0].Rows[0]["ChargesTmplID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ChargesTmplID"].ToString());
                    txtChargesDes.Text = (ds.Tables[0].Rows[0]["ChargesTmplDes"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ChargesTmplDes"].ToString());
                    cboMachineNo.Text = (ds.Tables[0].Rows[0]["MachineNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["MachineNo"].ToString());
                    txtNote.Text = (ds.Tables[0].Rows[0]["Note"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Note"].ToString());
                    cboContractor.Text = (ds.Tables[0].Rows[0]["Contractor"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Contractor"].ToString());
                    //
                    cboShift.Text = (ds.Tables[0].Rows[0]["Shift"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Shift"].ToString());
                    cboChargesType.Text = (ds.Tables[0].Rows[0]["ChargesType"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ChargesType"].ToString());
                    cboItemGroup.Text = (ds.Tables[0].Rows[0]["ItemGroupName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemGroupName"].ToString());
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

        private void SumVoc()
        {
            bool bcheck;
            decimal fQty = 0;
            decimal fAmount = 0;
            decimal rtnVal = 0;
            decimal outValue = 0;

            for (int i = 0; i < grd.RowCount; i++)
            {
                if (grd.Rows[i].Cells[(int)GColFD.Qty].Value != null)
                {
                    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GColFinItemRec.Qty].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fAmount = fAmount + outValue;
                    }
                }
            }

            lblTotal.Text = String.Format("{0:0,0.00}", fAmount);
        } 

        private void LoadGridData()
        {
            string lSQL = "";
           
          lSQL =  " SELECT i.ItemId AS Code, i.ItemCode, i.Name AS ItemName, sz.cgdDesc AS SizeName, clr.cgdDesc AS ColorName, ";
          lSQL += " gd.cgdDesc AS GodownName, 0 AS Stock, fd.Qty, fd.SizeId, fd.ColorId, fd.GodownId ";
          lSQL += " FROM FinishRecDetail fd ";
          lSQL += " INNER JOIN Item i on i.ItemId = fd.ItemId ";
          lSQL += " INNER JOIN CatDtl sz on fd.SizeId = sz.cgdCode AND sz.cgCode = 5 ";
          lSQL += " INNER JOIN CatDtl clr on fd.ColorId = clr.cgdCode AND clr.cgCode = 3 ";
          lSQL += " INNER JOIN CatDtl gd on fd.GodownId = gd.cgdCode AND gd.cgCode = 2 ";
          lSQL += " where fd.FinishRecId ='" + txtFinishRecNo.Text.ToString() + "'; ";

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
            lFieldList = "Code";                    //  0-    ItemID";       
            lFieldList += ",ItemCode";              //  1-    ItemCode";     
            lFieldList += ",ItemName";              //  2-    ItemName"; 
            lFieldList += ",SizeName";              //  3-    SizeName";       
            lFieldList += ",ColorName";             //  4-    ColorName";      
            lFieldList += ",GodownName";            //  6- GodownName
            lFieldList += ",Stock";                 //  7- Stock
            lFieldList += ",Qty";                   //  8- Qty
            lFieldList += ",SizeID";                //  9    SizeID";     
            lFieldList += ",ColorID";               //  10    ColorID";     
            lFieldList += ",GodownId";              //  12- GodownID


            lHDR += "Item ID";            //  0-    ItemID";       
            lHDR += ",Item Code";         //  1-    ItemCode";     
            lHDR += ",Item Name";         //  2-    ItemName"; 
            lHDR += ",Size";       //  3-    SizeName";      
            lHDR += ",Color";              //  4-    ColorName";     
            lHDR += ",Godown";          //  6- GodownName
            lHDR += ",Stock";            //  7- Stock
            lHDR += ",Qty";               //  8- Qty
            lHDR += ",SizeID";            //  9    SizeID";     
            lHDR += ",ColorID";           //  10    ColorID";     
            lHDR += ",GodownId";          //  12- GodownID

            // Col Visible Width
            lColWidth = "   5";                 //  0-    ItemID";       
            lColWidth += ",12";                 //  1-    ItemCode";     
            lColWidth += ",20";                 //  2-    ItemName"; 
            lColWidth += ",10";                 //  3-    SizeName";      
            lColWidth += ", 7";                 //  4-    ColorName";     
            lColWidth += ", 7";                 //  6- GodownName
            lColWidth += ", 7";                 //  7- Stock
            lColWidth += ", 5";                 //  8- Qty
            lColWidth += ", 5";                 //  9    SizeID";     
            lColWidth += ", 5";                 //  10    ColorID";     
            lColWidth += ", 5";                 //  12- GodownID

            // Column Input Length/Width
            lColMaxInputLen = "  0";                 //  0-    ItemID";       
            lColMaxInputLen += ", 0";                //  1-    ItemCode";     
            lColMaxInputLen += ", 0";                //  2-    ItemName"; 
            lColMaxInputLen += ", 0";                //  3-    SizeName";      
            lColMaxInputLen += ", 0";                //  4-    ColorName";     
            lColMaxInputLen += ", 0";                //  6- GodownName
            lColMaxInputLen += ", 0";                //  7- Stock
            lColMaxInputLen += ", 0";                //  8- Qty
            lColMaxInputLen += ", 0";                //  9    SizeID";     
            lColMaxInputLen += ", 0";                //  10    ColorID";     
            lColMaxInputLen += ", 0";                //  12- GodownID

            // Column Min Width
            lColMinWidth = "   0";                      //  0-    ItemID";           
            lColMinWidth += ", 0";                      //  1-    ItemCode";         
            lColMinWidth += ", 0";                      //  2-    ItemName"; 
            lColMinWidth += ", 0";                      //  3-    SizeName";      
            lColMinWidth += ", 0";                      //  4-    ColorName";         
            lColMinWidth += ", 0";                      //  6- GodownName
            lColMinWidth += ", 0";                      //  7- Stock
            lColMinWidth += ", 0";                      //  8- Qty
            lColMinWidth += ", 0";                      //  9    SizeID";       
            lColMinWidth += ", 0";                      //  10    ColorID";        
            lColMinWidth += ", 0";                      //  12- GodownID

            // Column Format
            lColFormat = "   T";                       //  0-    ItemID";            
            lColFormat += ", T";                       //  1-    ItemCode";         
            lColFormat += ", T";                       //  2-    ItemName"; 
            lColFormat += ", T";                       //  3-    SizeName";      
            lColFormat += ", T";                       //  4-    ColorName";         
            lColFormat += ", T";                       //  6- GodownName
            lColFormat += ", T";                       //  7- Stock
            lColFormat += ", T";                       //  8- Qty
            lColFormat += ", H";                       //  9    SizeID";       
            lColFormat += ", H";                       //  10    ColorID";        
            lColFormat += ", H";                       //  12- GodownID

            // Column ReadOnly 1= readonly, 0 = read-write
            lColReadOnly = "  0";                      //  0-    ItemID";       
            lColReadOnly += ",1";                      //  1-    ItemCode";     
            lColReadOnly += ",1";                      //  2-    ItemName"; 
            lColReadOnly += ",0";                      //  3-    SizeName";      
            lColReadOnly += ",0";                      //  4-    ColorName";     
            lColReadOnly += ",0";                      //  6- GodownName
            lColReadOnly += ",0";                      //  7- Stock
            lColReadOnly += ",0";                      //  8- Qty
            lColReadOnly += ",1";                      //  9    SizeID";     
            lColReadOnly += ",1";                      //  10    ColorID";     
            lColReadOnly += ",1";                      //  12- GodownID

            // For Saving Time
            tColType += "  N0";             //  0-    ItemID";       
            tColType += ",SKP";             //  1-    ItemCode";     
            tColType += ",SKP";             //  2-    ItemName"; 
            tColType += ",SKP";              //  3-    SizeName";      
            tColType += ",SKP";             //  4-    ColorName";     
            tColType += ",SKP";             //  6- GodownName
            tColType += ", N0";             //  7- Stock
            tColType += ", N0";             //  8- Qty
            tColType += ", N0";             //  9    SizeID";     
            tColType += ", N0";             //  10    ColorID";     
            tColType += ", N0";             //  12- GodownID

            tFieldName += "Code";               //  0-    ItemID";        
            tFieldName += ",ItemCode";          //  1-    ItemCode";        
            tFieldName += ",ItemName";          //  2-    ItemName"; 
            tFieldName += ",SizeName";       //  3-    SizeName";      
            tFieldName += ",ColorName";          //  4-    ColorName";          
            tFieldName += ",GodownName";          //  6- GodownName
            tFieldName += ",Stock";        //  7- Stock
            tFieldName += ",Qty";               //  8- Qty
            tFieldName += ",SizeID";            //  9    SizeID";     
            tFieldName += ",ColorID";           //  10    ColorID";      
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            grd.Rows.Add(txt_I_ItemID.Text.ToString(),
               lbl_I_ItemCode.Text.ToString(),
               lbl_I_ItemName.Text.ToString(),
               cbo_I_Size.Text.ToString(),
               cbo_I_Color.Text.ToString(),
               cboGodown.Text.ToString(),
               txtStock.Text.ToString(),
               txtQty.Text.ToString(),
               cbo_I_Size.SelectedValue.ToString(),
               cbo_I_Color.SelectedValue.ToString(),
               cboGodown.SelectedValue.ToString());

            MessageBox.Show("Data Successfully Added to GridView");
            SumVoc();
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
                        fLastID = txtFinishRecNo.Text.ToString();
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

        private bool PrepareDocMaster()
        {
            bool rtnValue = true;
            string lSQL = string.Empty;

            try
            {
                if (txtFinishRecNo.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    fDocID = clsDbManager.GetNextValDocID("FinRec", "FinishRecId", fDocWhere, "");

                    lSQL = "insert into FinRec (";
                    lSQL += "  FinishRecId ";                              //  0-    ItemID";   
                    lSQL += ", Date ";                                //  1-    ItemCod  
                    lSQL += ", Status ";
                    lSQL += ", ItemGroupID ";                                        //  2-    ItemNam 
                    lSQL += ", Category ";                                      // 3- Descripti
                    lSQL += ", BranchId ";                                        //  4-    SizeNam  
                    lSQL += ",Note ";
                    lSQL += ",EmployeeID ";
                    lSQL += ",DeptID ";
                    lSQL += ",ChargesTmplID ";
                    lSQL += ",ChargesTmplDes ";
                    lSQL += " ) values (";
                    //                                                       
                    lSQL += "'" + fDocID.ToString() + "'";                  
                    //lSQL += ",'" + txtFinishRecNo.Text.ToString() + "";   
                    lSQL += ", " + StrF01.D2Str(dtpFinishRec) + "";
                    lSQL += ", 0";
                    lSQL += ", " + cboItemGroup.SelectedValue.ToString() + "";
                    lSQL += ", " + cboCategory.SelectedValue.ToString() + "";
                    lSQL += ", 1";
                    lSQL += ",'" + txtNote + "'";
                    lSQL += ", " + cboEmpCode.SelectedValue.ToString() + "";
                    lSQL += ", 1";
                    lSQL += ", " + txtChargesTempNo.Text.ToString() + "";
                    lSQL += ", " + txtChargesDes.Text.ToString() + "";                                        
                    lSQL += ")";                                            
                }                                                              
                else
                {
                    fDocWhere = " FinishRecId = '" + txtFinishRecNo.Text.ToString() + "'";
                    if (clsDbManager.IDAlreadyExistWw("FinRec", "FinishRecId", fDocWhere))
                    {

                        fDocAlreadyExists = true;
                        lSQL = "delete from FinishRecDetail ";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);
                        //
                    }

                    lSQL = "update FinRec set";
                    lSQL += "  Date = '" + StrF01.D2Str(dtpFinishRec.Value) + "'";
                    lSQL += ",Status = 0";
                    lSQL += ", ItemGroupID = " + cboItemGroup.SelectedValue.ToString() + "";
                    lSQL += ", Category = '" + cboCategory.SelectedValue.ToString() + "'";
                    lSQL += ", BranchID = 1";
                    lSQL += ", Note = '" + txtNote.Text.ToString() + "'";
                    lSQL += ", EmployeeID = " + cboEmpCode.SelectedValue.ToString() + "";
                    lSQL += ", DeptID = 1";
                    lSQL += ", ChargesTmplID = '" + txtChargesTempNo.Text.ToString() + "'";
                    lSQL += ", ChargesTmplDes = '" + txtChargesDes.Text.ToString() + "'";
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

                    lSQL = "INSERT INTO FinishRecDetail (FinishRecId";
                    lSQL += ",ItemId,SizeId,ColorID,GodownId,Qty)";
                    lSQL += " VALUES (";
                    lSQL += "'" + txtFinishRecNo.Text.ToString() + "'";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColFinItemRec.ItemID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColFinItemRec.SizeID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColFinItemRec.ColorID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColFinItemRec.GodownID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColFinItemRec.Qty].Value.ToString() + "";
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
            MessageBox.Show("Data Saved Successfullly");
        }

        private void txtFinishRecNo_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        private void txtFinishRecNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
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

        private void txt_I_ItemID_DoubleClick(object sender, EventArgs e)
        {
            frmItemsHelpAuto frm = new frmItemsHelpAuto();
            frm.ShowDialog();

            txt_I_ItemID.Text = frm.Ret_ItemID.ToString();
            lbl_I_ItemCode.Text = frm.Ret_ItemCode.ToString();
            lbl_I_ItemName.Text = frm.Ret_ItemName.ToString();
        }



    }
}
