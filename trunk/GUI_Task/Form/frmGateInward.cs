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
    enum GColGIn
    {
        ItemID = 0,
        ItemCode = 1,
        ItemName = 2,
        Description = 3,
        SizeName = 4,
        ColorName = 5,
        UnitName = 6,
        GodownName = 7,
        Qty = 8,
        SizeID = 9,
        ColorID = 10,
        UOMID = 11,
        GodownID = 12
    }

    public partial class frmGateInward : Form
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


        public frmGateInward()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGateInward_Load(object sender, EventArgs e)
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

            //UOM Combo Fill
            lSQL = "select UOMID, UnitName from IMS_UOM order by UnitName";

            clsFillCombo.FillCombo(cbo_I_UOM, clsGVar.ConString1, "IMS_UOM" + "," + "UnitName" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cbo_I_UOM.SelectedValue);

            ds = clsDbManager.GetData_Set(lSQL, "IMS_UOM");
            UnitColumn.DataSource = ds.Tables[0];
            UnitColumn.ValueMember = ds.Tables[0].Columns[0].ToString();
            UnitColumn.DisplayMember = ds.Tables[0].Columns[1].ToString();
            ds.Clear();

            //Godown cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmGodown);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboGodown, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboGodown.SelectedValue);


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
            lSQL += " SELECT h.ItemId AS Code, i.ItemCode, i.Name AS ItemName, h.Description, sz.cgdDesc AS SizeName, ";
			lSQL += " clr.cgdDesc AS ColorName, ";
            lSQL += " u.UnitName, gd.cgdDesc AS GodownName, h.Qty, h.SizeID, h.ColorID, i.UOMID, h.GodownId ";
            lSQL += " from GateInwordDetail h INNER JOIN Item i ON h.ItemId=i.ItemId ";
            lSQL += " JOIN CatDtl clr ON h.ColorID=clr.cgdCode AND clr.cgCode=3 ";
            lSQL += " INNER JOIN CatDtl sz ON h.sizeid=sz.cgdCode AND sz.cgCode=5 ";
            lSQL += " INNER JOIN IMS_UOM u ON i.UOMID=u.UOMID ";
            lSQL += " INNER JOIN CatDtl gd ON h.GodownId = gd.cgdCode AND gd.cgCode=2 ";
            lSQL += " where h.GateInwordId ='" + txtGateInward.Text.ToString() + "'; ";

            clsDbManager.FillDataGrid(
                grd,
                lSQL,
                fFieldList,
                fColFormat);
        }


        private void frmGateInward_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void PassDataVocID(object sender)
        {
            txtGateInward.Text = ((TextBox)sender).Text;
        }


        private void PopulateRecords()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  

            tSQL = "SELECT gi.GateInwordId, gi.Date, cd.cgdDesc AS ItemGroupName,";
            tSQL += " g.GRNId, g.Date AS GRNDate,g.Note,gi.GateTime, gt.cgdDesc AS GateName  ";
            tSQL += "FROM GateInword gi INNER JOIN CatDtl cd ON gi.ItemGroupID=cd.cgdCode AND cd.cgCode=6 ";
            tSQL += "LEFT OUTER JOIN GRN g ON gi.GateInwordId=g.GateInwordId ";
            tSQL += "INNER JOIN CatDtl gt ON gi.GateID = gt.cgdCode AND gt.cgCode = 20 ";
            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Heads");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    txtNote.Text = (ds.Tables[0].Rows[0]["Note"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Note"].ToString());
                    dtpGateInword.Text = (ds.Tables[0].Rows[0]["Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Date"].ToString());
                    cboItemGroup.Text = (ds.Tables[0].Rows[0]["ItemGroupName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemGroupName"].ToString());
                    lblTime.Text = (ds.Tables[0].Rows[0]["GateTime"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["GateTime"].ToString());
                    cboGate.Text = (ds.Tables[0].Rows[0]["GateName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["GateName"].ToString());

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

        #region LookUp_Voc

        private void LookUp_Voc()
        {
            frmLookUp sForm = new frmLookUp(
                    "gi.GateInwordId",
                    "gi.Date, cd.cgdDesc AS ItemGroupName, "
                    + "g.GRNId,g.Date AS GRNDate,g.Note,gi.GateTime, gt.cgdDesc AS GateName",
                    " GateInword gi INNER JOIN CatDtl cd ON gi.ItemGroupID=cd.cgdCode AND cd.cgCode=6 LEFT OUTER JOIN GRN g ON gi.GateInwordId=g.GateInwordId INNER JOIN CatDtl gt ON gi.GateID = gt.cgdCode AND gt.cgCode = 20 ",
                    this.Text.ToString(),
                    1,
                    "GateInword#,Date,Item Group Name,Grn Id,Grn Date,Note, Gate Time ",
                    "10,8,12,12,12,15,8",
                    " T, T, T, T, T, T, T",
                    true,
                    "",
                    "",
                    "TextBox"
                    );

            txtGateInward.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID);
            sForm.ShowDialog();

            if (txtGateInward.Text != null)
            {
                if (txtGateInward.Text != null)
                {
                    if (txtGateInward.Text.ToString() == "" || txtGateInward.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtGateInward.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecords();
                    }

                }

            }
        }
        #endregion


        private void txtGateInward_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
        }

        private void txtGateInward_DoubleClick(object sender, EventArgs e)
        {
            {
                LookUp_Voc();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            LookUp_Voc();
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
            lFieldList = "Code";                //  0-    ItemID";       
            lFieldList += ",ItemCode";            //  1-    ItemCode";     
            lFieldList += ",ItemName";            //  2-    ItemName"; 
            lFieldList += ",Description";           // 3- Description
            lFieldList += ",SizeName";            //  4-    SizeName";       
            lFieldList += ",ColorName";           //  5-    ColorName";      
            lFieldList += ",UnitName";            //  6-    UOMName";
            lFieldList += ",GodownName";          // 7- GodownName
            lFieldList += ",Qty";                   // 8- Qty
            lFieldList += ",SizeID";              // 9    SizeID";     
            lFieldList += ",ColorID";             // 10    ColorID";     
            lFieldList += ",UOMID";               // 11    UOMID"; 
            lFieldList += ",GodownId";              // 12- GodownID

            lHDR += "Item ID";             //  0-    ItemID";      
            lHDR += ",Item Code";            //  1-    ItemCod     
            lHDR += ",Item Name";            //  2-    ItemNam 
            lHDR += ",Description";            // 3- Descripti
            lHDR += ",Size";                 //  4-    SizeNam     
            lHDR += ",Color";                //  5-    ColorNa     
            lHDR += ",UOM Name";             //  6-    UOMName
            lHDR += ",Godown";               // 7- GodownName
            lHDR += ",Qty";                    // 8- Qty
            lHDR += ",SizeID";               // 9    SizeID";    
            lHDR += ",ColorID";              // 10    ColorID"    
            lHDR += ",UOMID";                // 11    UOMID"; 
            lHDR += ",GodownId";               // 12- GodownID

            // Col Visible Width
            lColWidth = "   5";                 //  0-    ItemID";        
            lColWidth += ",12";                   //  1-    ItemCod";     
            lColWidth += ",20";                 //  2-    ItemNam; 
            lColWidth += ",10";                     // 3- Descripti
            lColWidth += ", 7";                   //  4-    SizeNam       
            lColWidth += ", 7";                   //  5-    ColorNa;      
            lColWidth += ", 7";                   //  6-    UOMName
            lColWidth += ", 7";                   // 7- GodownName
            lColWidth += ", 5";                     // 8- Qty
            lColWidth += ", 5";                   // 9    SizeID";      
            lColWidth += ", 5";                   // 10    ColorID";     
            lColWidth += ", 5";                   // 11    UOMID"; 
            lColWidth += ", 5";                     // 12- GodownID

            // Column Input Length/Width
            lColMaxInputLen = "  0";                 //  0-    ItemID";    
            lColMaxInputLen += ", 0";                  //  1-    ItemCod   
            lColMaxInputLen += ", 0";                  //  2-    ItemNam
            lColMaxInputLen += ", 0";                    // 3- Descripti
            lColMaxInputLen += ", 0";                  //  4-    SizeNam   
            lColMaxInputLen += ", 0";                  //  5-    ColorNa   
            lColMaxInputLen += ", 0";                  //  6-    UOMName
            lColMaxInputLen += ", 0";                  // 7- GodownName
            lColMaxInputLen += ", 0";                    // 8- Qty
            lColMaxInputLen += ", 0";                  // 9    SizeID";  
            lColMaxInputLen += ", 0";                  // 10    ColorID"  
            lColMaxInputLen += ", 0";                  // 11    UOMID"; 
            lColMaxInputLen += ", 0";                    // 12- GodownID

            // Column Min Width
            lColMinWidth = "   0";                      //  0-    ItemID";       
            lColMinWidth += ", 0";                        //  1-    ItemCod;     
            lColMinWidth += ", 0";                        //  2-    ItemNam; 
            lColMinWidth += ", 0";                          // 3- Descripti
            lColMinWidth += ", 0";                        //  4-    SizeNam      
            lColMinWidth += ", 0";                        //  5-    ColorNa      
            lColMinWidth += ", 0";                        //  6-    UOMName
            lColMinWidth += ", 0";                        // 7- GodownName
            lColMinWidth += ", 0";                          // 8- Qty
            lColMinWidth += ", 0";                        // 9    SizeID";     
            lColMinWidth += ", 0";                        // 10    ColorID"     
            lColMinWidth += ", 0";                        // 11    UOMID"; 
            lColMinWidth += ", 0";                          // 12- GodownID

            // Column Format
            lColFormat = "   T";                       //  0-    ItemID";       
            lColFormat += ", T";                         //  1-    ItemCod     
            lColFormat += ", T";                         //  2-    ItemNam 
            lColFormat += ", T";                           // 3- Descripti
            lColFormat += ", T";                         //  4-    SizeNam     
            lColFormat += ", T";                         //  5-    ColorNa     
            lColFormat += ", T";                         //  6-    UOMName
            lColFormat += ", T";                         // 7- GodownName
            lColFormat += ", T";                           // 8- Qty
            lColFormat += ", H";                         // 9    SizeID";    
            lColFormat += ", H";                         // 10    ColorID"    
            lColFormat += ", H";                         // 11    UOMID"; 
            lColFormat += ", H";                           // 12- GodownID

            // Column ReadOnly 1= readonly, 0 = read-write
            lColReadOnly = "  0";                       //  0-    ItemID";      
            lColReadOnly += ",1";                         //  1-    ItemCod     
            lColReadOnly += ",1";                         //  2-    ItemNam
            lColReadOnly += ",0";                           // 3- Descripti
            lColReadOnly += ",0";                         //  4-    SizeNam     
            lColReadOnly += ",0";                         //  5-    ColorNa     
            lColReadOnly += ",0";                         //  6-    UOMName
            lColReadOnly += ",0";                         // 7- GodownName
            lColReadOnly += ",0";                           // 8- Qty
            lColReadOnly += ",1";                         // 9    SizeID";    
            lColReadOnly += ",1";                         // 10    ColorID"    
            lColReadOnly += ",1";                         // 11    UOMID"; 
            lColReadOnly += ",1";                           // 12- GodownID

            // For Saving Time
            tColType += "  N0";             //  0-    ItemID"; 
            tColType += ",SKP";               //  1-    ItemCod
            tColType += ",SKP";               //  2-    ItemNam
            tColType += ", T";                  // 3- Descripti
            tColType += ",SKP";               //  4-    SizeNam
            tColType += ",SKP";               //  5-    ColorNa
            tColType += ",SKP";               //  6-    UOMName
            tColType += ",SKP";               // 7- GodownName
            tColType += ", N0";                 // 8- Qty
            tColType += ", N0";               // 9    SizeID"; 
            tColType += ", N0";               // 10    ColorID"
            tColType += ", N0";               // 11    UOMID"; 
            tColType += ", N0";                 // 12- GodownID

            tFieldName += "Code";                //  0-    ItemID";       
            tFieldName += ",ItemCode";             //  1-    ItemCode";     
            tFieldName += ",ItemName";             //  2-    ItemName"; 
            tFieldName += ",Description";            // 3- Descripti
            tFieldName += ",SizeName";             //  4-    SizeNamD";       
            tFieldName += ",ColorName";            //  5-    ColorNaID";      
            tFieldName += ",UnitName";             //  6-    UOMNameD"; 
            tFieldName += ",GodownName";           // 7- GodownName
            tFieldName += ",Qty";                    // 8- Qty
            tFieldName += ",SizeID";               // 9    SizeID";     
            tFieldName += ",ColorID";              // 10    ColorID";     
            tFieldName += ",UOMID";              // 11    UOMID"; 
            tFieldName += ",GodownID";               // 12- GodownID

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

        private void btnAdd_Click(object sender, EventArgs e)
        {

            grd.Rows.Add(txt_I_ItemID.Text.ToString(),
                lbl_I_ItemCode.Text.ToString(),
                lbl_I_ItemName.Text.ToString(),
                txtDescription.Text.ToString(),
                cbo_I_Size.Text.ToString(),
                cbo_I_Color.Text.ToString(),
                cbo_I_UOM.Text.ToString(),
                cboGodown.Text.ToString(),
                txtQty.Text.ToString(),
                cbo_I_Size.SelectedValue.ToString(),
                cbo_I_Color.SelectedValue.ToString(),
                cbo_I_UOM.SelectedValue.ToString(),
                cboGodown.SelectedValue.ToString());

            SumVoc();
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

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageBox.Show("Data Saved Successfullly");
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
                        fLastID = txtGateInward.Text.ToString();
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
                if (txtGateInward.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    fDocID = clsDbManager.GetNextValDocID("GateInword", "DocId", fDocWhere, "");
                    strDocId = "1-" + DateTime.Now.Year.ToString() + fDocID.ToString();
                    txtGateInward.Text = strDocId;
                    fDocID += fDocID;

                    lSQL = "insert into GateInword (";
                    lSQL += " DocId ";
                    lSQL += ", GateInwordId ";                              //  0-    ItemID";   
                    //lSQL += ", GateInwordNo ";                                //  1-    ItemCod  
                    lSQL += ", Date ";                                        //  2-    ItemNam 
                    lSQL += ", VendorId ";                                      // 3- Descripti
                    lSQL += ", Note ";                                        //  4-    SizeNam  
                    lSQL += ", ItemGroupId ";                                 //  5-    ColorNa  
                    lSQL += ", GateId ";                                      //  6-    UOMName
                    lSQL += ", UserId ";                                      // 7- GodownName
                    lSQL += ", OrgId ";                                         // 8- Qty
                    lSQL += ", Status ";                                      // 9    SizeID";   
                    lSQL += ", BranchId ";                                    // 10    ColorID"  
                    lSQL += " ) values (";
                    //                                                       
                    lSQL += fDocID.ToString();
                    lSQL += ",'" + strDocId.ToString() + "'";   
                   // lSQL += ",'" + txtGateInward.Text.ToString() + "'";        //  1-    ItemCod  
                    lSQL += ", " + StrF01.D2Str(dtpGateInword) + "";          //  2-    ItemNam 
                    lSQL += ", 1";                                              // 3- Descripti
                    lSQL += ",'" + txtNote.Text.ToString() + "'";                             //  4-    SizeNam  
                    lSQL += ", " + cboItemGroup.SelectedValue.ToString() + "";  //  5-    ColorNa  
                    lSQL += ", 1";                                            //  6-    UOMName
                    lSQL += ", 0";                                            // 7- GodownName
                    lSQL += ", 1";                                              // 8- Qty
                    lSQL += ", 0";                                             // 9    SizeID";   
                    lSQL += ", 1";                                            // 10    ColorID"  
                    lSQL += ")";                                              // 11    UOMID"; 
                }                                                               // 12- GodownID
                else
                {
                    fDocWhere = " GateInwordId = '" + txtGateInward.Text.ToString() + "'";
                    if (clsDbManager.IDAlreadyExistWw("GateInword", "GateInwordId", fDocWhere))
                    {

                        fDocAlreadyExists = true;
                        lSQL = "delete from GateInwordDetail ";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);
                        //
                    }

                    lSQL = "update GateInword set";
                    lSQL += "  Date = '" + StrF01.D2Str(dtpGateInword.Value) + "'";
                    lSQL += ",VendorId = '' ";
                    lSQL += ", Note = '" + txtNote.Text.ToString() + "'";
                    lSQL += ", ItemGroupID = " + cboItemGroup.SelectedValue.ToString() + "";
                    lSQL += ", GateID = 1";
                    lSQL += ", UserId = 0";
                    lSQL += ", OrgId = 1";
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

                    lSQL = "INSERT INTO GateInwordDetail( DocId ";
                    lSQL += ",GateInwordId,ItemId,SizeId,ColorID,GodownId,Qty,Description)";
                    lSQL += " VALUES (";
                    lSQL += "" + fDocID + "";
                    lSQL += ", '" + txtGateInward.Text.ToString() + "'";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColGIn.ItemID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColGIn.SizeID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColGIn.ColorID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColGIn.GodownID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColGIn.Qty].Value.ToString() + "";
                    lSQL += ", '" + grd.Rows[dGVRow].Cells[(int)GColGIn.Description].Value.ToString() + "'";
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
            frmItemsHelpAuto frm = new frmItemsHelpAuto();
            frm.ShowDialog();

            txt_I_ItemID.Text = frm.Ret_ItemID.ToString();
            lbl_I_ItemCode.Text = frm.Ret_ItemCode.ToString();
            lbl_I_ItemName.Text = frm.Ret_ItemName.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            //MessageBox.Show("Data Saved Successfullly");
            textAlert.Text = "Data Saved Successfully";
            this.notifyIcon1.BalloonTipText = "GateInward Number '" + txtGateInward.Text.ToString() + "'";
            this.notifyIcon1.BalloonTipTitle = "Data Saved";
            //this.notifyIcon1.Icon = new Icon("icon.ico");
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.ShowBalloonTip(5);
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
                    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GColGIn.Qty].Value.ToString(), out outValue);
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
                    {
                        (control as TextBox).Clear();
                        lblTime.Text= "";
                        lblTotal.Text = "";
                    }
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

        private void button1_Click(object sender, EventArgs e)
        {
            //smtp.Text = "smtp.gmail.com";
            MailMessage mail = new MailMessage("usama.naveed.hussain@gmail.com", "usama.naveed.hussain@gmail.com", "Data Saved", "Data Saved against GateInward Number: " + txtGateInward.Text.ToString());
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

