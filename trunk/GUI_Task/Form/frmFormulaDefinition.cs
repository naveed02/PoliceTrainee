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
    enum GColFD
    {
        ItemID = 0,
        ItemCode = 1,
        ItemName = 2,
        SizeName = 3,
        ColorName = 4,
        GodownName = 5,
        Qty = 6,
        SizeID = 7,
        ColorID = 8,
        GodownID = 9
    }

    public partial class frmFormulaDefinition : Form
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


        public frmFormulaDefinition()
        {
            InitializeComponent();
        }

        #region LookUp_Voc

        private void LookUp_Voc()
        {
            frmLookUp sForm = new frmLookUp(
                    "p.ItemId ",
                    "i.ItemCode, i.Name AS ItemName, sz.cgdDesc AS SizeName, clr.cgdDesc AS ColorName, p.Date, pd.Qty, p.Note, CASE [Status] WHEN 0 THEN 'InActive' WHEN 1 THEN 'ACTIVE' END AS [Status] ",
                     " Formula p  INNER JOIN Item i ON p.ItemId = i.ItemId INNER JOIN CatDtl sz ON sz.cgdCode = p.SizeID AND sz.cgCode = 5 "
                    + " INNER JOIN CatDtl clr ON clr.cgdCode = p.ColorID AND clr.cgCode = 3 INNER JOIN FormulaDetail pd ON pd.ItemId = p.ItemId ",
                    this.Text.ToString(),
                    1,
                    "ItemID,ItemCode,ItemName,Size,Color,Date,Qty,Note,Status ",
                    "8,8,12,8,8,8,8,8,12",
                    " T, T, T, T, T, T, T, T, T",
                    true,
                    "",
                    "",
                    "TextBox"
                    );

            txtFormula.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID);
            sForm.ShowDialog();

            if (txtFormula.Text != null)
            {
                if (txtFormula.Text != null)
                {
                    if (txtFormula.Text.ToString() == "" || txtFormula.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtFormula.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecords();
                    }

                }

            }
        }
        #endregion

        private void PassDataVocID(object sender)
        {
            txtFormula.Text = ((TextBox)sender).Text;
        }


        private void PopulateRecords()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  

            tSQL = " select p.FormulaId, p.ItemId, i.ItemCode, i.Name AS ItemName, sz.cgdDesc AS SizeName, ";
            tSQL += " clr.cgdDesc AS ColorName, p.Date, pd.Qty, p.WeightUnit, p.Note, ";
            tSQL += " CASE [Status] WHEN 0 THEN 'InActive' WHEN 1 THEN 'ACTIVE' END AS [Status] ";
            tSQL += " from Formula p INNER JOIN Item i ON p.ItemId = i.ItemId ";
            tSQL += " INNER JOIN CatDtl sz ON sz.cgdCode = p.SizeID AND sz.cgCode = 5 ";
            tSQL += " INNER JOIN CatDtl clr ON clr.cgdCode = p.ColorID AND clr.cgCode = 3 ";
            tSQL += " INNER JOIN PackFormulaDetail pd ON pd.ItemId = p.ItemId ";
            

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Heads");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    txtItemID.Text = (ds.Tables[0].Rows[0]["ItemID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemID"].ToString());
                    lblItemCode.Text = (ds.Tables[0].Rows[0]["ItemCode"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemCode"].ToString());
                    lblItemName.Text = (ds.Tables[0].Rows[0]["ItemName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemName"].ToString());
                    cboSize.Text = (ds.Tables[0].Rows[0]["SizeName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["SizeName"].ToString());
                    cboColor.Text = (ds.Tables[0].Rows[0]["ColorName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ColorName"].ToString());
                    dtpFormula.Text = (ds.Tables[0].Rows[0]["Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Date"].ToString());
                    txtQtyBatch.Text = (ds.Tables[0].Rows[0]["Qty"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Qty"].ToString());
                    txtWeightUnit.Text = (ds.Tables[0].Rows[0]["WeightUnit"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["WeightUnit"].ToString());

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


        private void txtFormula_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        private void txtFormula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
        }

        private void frmFormulaDefinition_Load(object sender, EventArgs e)
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


            //Size Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmSize);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboSize, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboSize.SelectedValue);

            DataSet ds = new DataSet();
            ds = clsDbManager.GetData_Set(lSQL, "CatDtl");
            SizeColumn.DataSource = ds.Tables[0];
            SizeColumn.ValueMember = ds.Tables[0].Columns[0].ToString();
            SizeColumn.DisplayMember = ds.Tables[0].Columns[1].ToString();
            ds.Clear();

            //Color Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmColor);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboColor, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboColor.SelectedValue);

            ds = clsDbManager.GetData_Set(lSQL, "CatDtl");
            ColorColumn.DataSource = ds.Tables[0];
            ColorColumn.ValueMember = ds.Tables[0].Columns[0].ToString();
            ColorColumn.DisplayMember = ds.Tables[0].Columns[1].ToString();
            ds.Clear();

            //Size Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmSize);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cbo_I_Size, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cbo_I_Size.SelectedValue);

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

        private void frmFormulaDefinition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            frmItemsHelpAuto frm = new frmItemsHelpAuto();
            frm.ShowDialog();

            txt_I_ItemID.Text = frm.Ret_ItemID.ToString();
            lbl_I_ItemCode.Text = frm.Ret_ItemCode.ToString();
            lbl_I_ItemName.Text = frm.Ret_ItemName.ToString();
        }

        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grd.Rows.Add(txt_I_ItemID.Text.ToString(),
                lbl_I_ItemCode.Text.ToString(),
                lbl_I_ItemName.Text.ToString(),
                cbo_I_Size.Text.ToString(),
                cbo_I_Color.Text.ToString(),
                cboGodown.Text.ToString(),
                txtQty.Text.ToString(),
                cbo_I_Size.SelectedValue.ToString(),
                cbo_I_Color.SelectedValue.ToString(),
                cboGodown.SelectedValue.ToString());

            MessageBox.Show("Data Successfully Added to GridView");

            SumVoc();
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
                    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GColFD.Qty].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fAmount = fAmount + outValue;
                    }
                }
            }

            lblTotal.Text = String.Format("{0:0,0.00}", fAmount);
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
                10,
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

            lSQL += " select i.ItemId AS Code, i.ItemCode, i.Name AS ItemName, sz.cgdDesc AS SizeName, ";
            lSQL += " clr.cgdDesc AS ColorName, gd.cgdDesc AS GodownName, pd.Qty, pd.SizeId, pd.ColorId, pd.GodownId ";
            lSQL += " from FormulaDetail pd ";
            lSQL += " INNER JOIN Item i ON i.ItemId = pd.ItemId ";
            lSQL += " INNER JOIN CatDtl sz ON pd.SizeId = sz.cgdCode AND sz.cgCode = 5 ";
            lSQL += " INNER JOIN CatDtl clr ON pd.ColorId = clr.cgdCode AND clr.cgCode = 3 ";
            lSQL += " INNER JOIN CatDtl gd ON pd.GodownId = gd.cgdCode AND gd.cgCode = 2 ";
            lSQL += " where pd.FormulaId ='" + txtFormula.Text.ToString() + "'; ";

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
            lFieldList = "Code";         //ItemID = 0,
            lFieldList += ",ItemCode";   //ItemCode = 1,
            lFieldList += ",ItemName";   //ItemName = 2,
            lFieldList += ",SizeName";   //SizeName = 3,
            lFieldList += ",ColorName";  //ColorName = 4,
            lFieldList += ",GodownName";        //GodownName = 6,
            lFieldList += ",Qty";     //Qty = 7,
            lFieldList += ",SizeID";    //SizeID = 8,
            lFieldList += ",ColorID";      //ColorID = 9,
            lFieldList += ",GodownID";                             //GodownID = 11


            lHDR += "Item ID";             //ItemID = 0,  
            lHDR += ",Item Code";          //ItemCode = 1,  
            lHDR += ",Item Name";          //ItemName = 2,
            lHDR += ",Size";        //SizeName = 3,
            lHDR += ",Color";               //ColorName = 4,  
            lHDR += ",Godown";           //GodownName = 6,
            lHDR += ",Qty";             //Qty = 7,
            lHDR += ",SizeID";                //SizeID = 8,
            lHDR += ",ColorID";             //ColorID = 9,
            lHDR += ",GodownID";              //GodownID = 11


            // Col Visible Width
            lColWidth = "    8";               //ItemID = 0,
            lColWidth += ", 10";               //ItemCode = 1,
            lColWidth += ", 15";               //ItemName = 2,
            lColWidth += ", 10";               //SizeName = 3,
            lColWidth += ", 10";               //ColorName = 4,
            lColWidth += ", 10";               //GodownName = 6,
            lColWidth += ", 10";               //Qty = 7,
            lColWidth += ",  5";               //SizeID = 8,
            lColWidth += ",  5";               //ColorID = 9,
            lColWidth += ",  5";               //GodownID = 11


            // Column Input Length/Width
            lColMaxInputLen = "  0";                //ItemID = 0,
            lColMaxInputLen += ", 0";               //ItemCode = 1,
            lColMaxInputLen += ", 0";               //ItemName = 2,
            lColMaxInputLen += ", 0";               //SizeName = 3,
            lColMaxInputLen += ", 0";               //ColorName = 4,
            lColMaxInputLen += ", 0";               //GodownName = 6,
            lColMaxInputLen += ", 0";               //Qty = 7,
            lColMaxInputLen += ", 0";               //SizeID = 8,
            lColMaxInputLen += ", 0";               //ColorID = 9,
            lColMaxInputLen += ", 0";               //GodownID = 11


            // Column Min Width
            lColMinWidth = "   0";                    //ItemID = 0,    
            lColMinWidth += ", 0";                    //ItemCode = 1,    
            lColMinWidth += ", 0";                    //ItemName = 2,
            lColMinWidth += ", 0";                    //SizeName = 3,
            lColMinWidth += ", 0";                    //ColorName = 4,    
            lColMinWidth += ", 0";                    //GodownName = 6,
            lColMinWidth += ", 0";                    //Qty = 7,
            lColMinWidth += ", 0";                    //SizeID = 8,
            lColMinWidth += ", 0";                    //ColorID = 9,  
            lColMinWidth += ", 0";                    //GodownID = 11


            // Column Format
            lColFormat = "   T";                      //ItemID = 0, 
            lColFormat += ", T";                      //ItemCode = 1,
            lColFormat += ", T";                      //ItemName = 2,
            lColFormat += ", T";                      //SizeName = 3,
            lColFormat += ", T";                      //ColorName = 4,
            lColFormat += ", T";                      //GodownName = 6,
            lColFormat += ", T";                      //Qty = 7,
            lColFormat += ", H";                      //SizeID = 8,
            lColFormat += ", H";                      //ColorID = 9,
            lColFormat += ", H";                      //GodownID = 11


            // Column ReadOnly 1= readonly, 0 = read-write
            lColReadOnly = "  0";                      //ItemID = 0,   
            lColReadOnly += ",1";                      //ItemCode = 1,   
            lColReadOnly += ",1";                      //ItemName = 2,
            lColReadOnly += ",0";                      //SizeName = 3,
            lColReadOnly += ",0";                      //ColorName = 4,   
            lColReadOnly += ",0";                      //GodownName = 6,
            lColReadOnly += ",0";                      //Qty = 7,
            lColReadOnly += ",1";                      //SizeID = 8,
            lColReadOnly += ",1";                      //ColorID = 9, 
            lColReadOnly += ",1";                      //GodownID = 11


            // For Saving Time
            tColType += "  N0";             //ItemID = 0,
            tColType += ",SKP";             //ItemCode = 1,
            tColType += ",SKP";             //ItemName = 2,
            tColType += ",SKP";              //SizeName = 3,
            tColType += ",SKP";             //ColorName = 4,
            tColType += ",SKP";             //GodownName = 6,
            tColType += ", N0";             //Qty = 7,
            tColType += ", N0";             //SizeID = 8,
            tColType += ", N0";             //ColorID = 9,
            tColType += ", N0";             //GodownID = 11


            tFieldName += "Code";               //ItemID = 0, 
            tFieldName += ",ItemCode";          //ItemCode = 1,   
            tFieldName += ",ItemName";          //ItemName = 2,
            tFieldName += ",SizeName";       //SizeName = 3,
            tFieldName += ",ColorName";          //ColorName = 4,     
            tFieldName += ",GodownName";          //GodownName = 6,
            tFieldName += ",Qty";        //Qty = 7,
            tFieldName += ",SizeID";               //SizeID = 8,
            tFieldName += ",ColorID";            //ColorID = 9,
            tFieldName += ",GodownID";             //GodownID = 11


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

        private bool FormValidation()
        {
            bool lRtnValue = true;
            DateTime lNow = DateTime.Now;
            decimal lDebit = 0;
            decimal lCredit = 0;
            fDocAmt = 0;
            try
            {
                //        SumVoc();

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
                        fLastID = txtFormula.Text.ToString();
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
                if (txtFormula.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    fDocID = clsDbManager.GetNextValDocID("Formula", "FormulaId", fDocWhere, "");

                    lSQL = "insert into Formula (";
                    lSQL += "  FormulaId ";                              //  0-    ItemID";   
                    lSQL += ", Date ";                                //  1-    ItemCod  
                    lSQL += ", ItemId ";                                        //  2-    ItemNam 
                    lSQL += ", SizeID ";                                      // 3- Descripti
                    lSQL += ", ColorID ";                                        //  4-    SizeNam  
                    lSQL += ", Note ";                                 //  5-    ColorNa  
                    lSQL += ", UserId ";                                      //  6-    UOMName
                    lSQL += ", OrdId ";                                      // 7- GodownName
                    lSQL += ", Status ";                                      // 9    SizeID";   
                    lSQL += ", BranchId ";
                    lSQL += ", WeightUnit ";
                    lSQL += ", QtyBatch ";
                    lSQL += " ) values (";
                    //                                                       
                    lSQL += "'" + fDocID.ToString() + "'";
                    lSQL += ",'" + txtFormula.Text.ToString() + "";
                    lSQL += ", " + StrF01.D2Str(dtpFormula) + "";
                    lSQL += ", " + txtItemID.Text.ToString() + "";
                    lSQL += ", " + cboSize.SelectedValue.ToString() + "";
                    lSQL += ", " + cboColor.SelectedValue.ToString() + "";
                    lSQL += ",'" + txtNote + "'";
                    lSQL += ", 1";
                    lSQL += ", 0";
                    lSQL += ", 1";
                    lSQL += ", 0";
                    lSQL += ", 1";
                    lSQL += ", " + txtWeightUnit.Text.ToString() + "";
                    lSQL += ", " + txtQtyBatch.Text.ToString() + "";
                    lSQL += ")";
                }
                else
                {
                    fDocWhere = " FormulaId = '" + txtFormula.Text.ToString() + "'";
                    if (clsDbManager.IDAlreadyExistWw("Formula", "FormulaId", fDocWhere))
                    {

                        fDocAlreadyExists = true;
                        lSQL = "delete from FormulaDetail ";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);
                        //
                    }


                    lSQL = "update Formula set";
                    lSQL += "  Date = '" + StrF01.D2Str(dtpFormula.Value) + "'";
                    lSQL += ", ItemID = " + txtItemID.Text.ToString() + "";
                    lSQL += ", SizeID = " + cboSize.SelectedValue.ToString() + "";
                    lSQL += ", ColorID = " + cboColor.SelectedValue.ToString() + "";
                    lSQL += ", Note = '" + txtNote.Text.ToString() + "'";
                    lSQL += ", UserId = 0";
                    lSQL += ", OrgId = 1";
                    lSQL += ", Status = 0";
                    lSQL += ", BranchId = 1";
                    lSQL += ", WeightUnit = " + txtWeightUnit.Text.ToString() + "";
                    lSQL += ", QtyBatch = " + txtQtyBatch.Text.ToString() + "";
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

                    lSQL = "INSERT INTO FormulaDetail (FormulaId";
                    lSQL += ",ItemId,SizeId,ColorID,GodownId,Qty)";
                    lSQL += " VALUES (";
                    lSQL += "'" + txtFormula.Text.ToString() + "'";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColFD.ItemID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColFD.SizeID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColFD.ColorID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColFD.GodownID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColFD.Qty].Value.ToString() + "";
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
    }
}
