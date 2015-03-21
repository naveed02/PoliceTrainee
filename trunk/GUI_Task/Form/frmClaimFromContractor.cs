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
    enum GColClaimCon
    {
        MachineNo = 0,
        Contractor = 1,
        Shift = 2,
        Charges = 3,
        ClaimAmountOffice = 4,
        CompensationAmount = 5,
        ClaimAmount = 6,
        Reason = 7,
        OrderedBy = 8,
       
        MachineID = 9,
         ContractorID= 10,
        ShiftID = 11,
        ChargesTypeID = 12
    }
    public partial class frmClaimContractor : Form
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

        public frmClaimContractor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmClaimFromContractor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
        }

        private void frmClaimFromContractor_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc();
        }
       

        private void LookUp_Voc()
        {
            frmLookUp sForm = new frmLookUp(
                    "ClaimID",
                    " Note , case Status when 0 then 'Active' else 'InActive' end as Status",
                     " ClaimCont",
                    this.Text.ToString(),
                    1,
                    "ClaimID, Note, Status ",
                    "8,20,10",
                    " T, T, T",
                    true,
                    "",
                //"d.Category = " + cboMainGroup.SelectedValue.ToString(), 
                    "",
                    "TextBox"
                    );

            txtClaim.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID) ;
            sForm.ShowDialog();

            if (txtClaim.Text != null)
            {
                if (txtClaim.Text != null)
                {
                    if (txtClaim.Text.ToString() == "" || txtClaim.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtClaim.Text.ToString().Trim().Length > 0)
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
  

        private void PassDataVocID(object sender)
        {
            //txtPassDataVocID.Text = ((TextBox)sender).Text;
            txtClaim.Text = ((TextBox)sender).Text;
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
            
//            select Note, ClaimID, 
//              case Status when 0 then 'Active' else 'InActive' end as Status
//              from ClaimCont 


            tSQL = " select ClaimID, Note, Date, case Status when 0 then 'Active' else 'InActive' end as Status ";
            tSQL += " from ClaimCont ";
            tSQL += " where ClaimID= '" + txtClaim.Text.ToString() + "';";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "ClaimCont");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    txtClaim.Text = (ds.Tables[0].Rows[0]["ClaimID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ClaimID"].ToString());
                    //dtpDate.Value = (ds.Tables[0].Rows[0]["doc_date"] == DBNull.Value ? DateTime.Now.ToString("T") : ds.Tables[0].Rows[0]["doc_date"]);
                    dtpClaim.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["Date"]);
                    //txtContractNo.Text = (ds.Tables[0].Rows[0]["Cont_No"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Cont_No"].ToString());
                    //mskCustomerCode.Text = (ds.Tables[0].Rows[0]["Customer"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Customer"].ToString());
                    // lblName.Text = (ds.Tables[0].Rows[0]["CustName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CustName"].ToString());
                    //txtBillNo.Text = (ds.Tables[0].Rows[0]["BillNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BillNo"].ToString());
                    //txtOrderStatus.Text = (ds.Tables[0].Rows[0]["Status"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Status"].ToString());
                    //txtSaleType.Text = (ds.Tables[0].Rows[0]["Type"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Type"].ToString());
                    //txtDetail.Text = (ds.Tables[0].Rows[0]["Detail"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Detail"].ToString());
                    txtNote.Text = (ds.Tables[0].Rows[0]["Note"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Note"].ToString());

                   
                    //}
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                        //btn_EnableDisable(true);
                    }
                    //PopulateGridData();
                    
                    //txtManualDoc.Enabled = false;
                }
                LoadGridData();
            }
            catch
            {
                MessageBox.Show("Unable to Get Item No...", this.Text.ToString());
            }
        }
#endregion
        private void txtClaim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
        }

      

        private void frmClaimFromContractor_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            AtFormLoad();
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


        private void AtFormLoad()

        {

            string lSQL = string.Empty;
            SettingGridVariable();
            LoadInitialControls();
            this.KeyPreview = true;

            //Size Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmMachineNo);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboMachine, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboMachine.SelectedValue);

            DataSet ds = new DataSet();
            ds = clsDbManager.GetData_Set(lSQL, "CatDtl");
            MachineColumn.DataSource = ds.Tables[0];
            MachineColumn.ValueMember = ds.Tables[0].Columns[0].ToString();
            MachineColumn.DisplayMember = ds.Tables[0].Columns[1].ToString();
            ds.Clear();

            //Color Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmContractor);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboContractor, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboContractor.SelectedValue);

            ds = clsDbManager.GetData_Set(lSQL, "CatDtl");
            ContractorColumn.DataSource = ds.Tables[0];
            ContractorColumn.ValueMember = ds.Tables[0].Columns[0].ToString();
            ContractorColumn.DisplayMember = ds.Tables[0].Columns[1].ToString();
            ds.Clear();

            //Shift Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmShift);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboShift, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboShift.SelectedValue);

            ds = clsDbManager.GetData_Set(lSQL, "CatDtl");
            ShiftColumn.DataSource = ds.Tables[0];
            ShiftColumn.ValueMember = ds.Tables[0].Columns[0].ToString();
            ShiftColumn.DisplayMember = ds.Tables[0].Columns[1].ToString();
            ds.Clear();

            //Charges Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmCharges);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboCharges, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboCharges.SelectedValue);

            ds = clsDbManager.GetData_Set(lSQL, "CatDtl");
            ChargesColumn.DataSource = ds.Tables[0];
            ChargesColumn.ValueMember = ds.Tables[0].Columns[0].ToString();
            ChargesColumn.DisplayMember = ds.Tables[0].Columns[1].ToString();
            ds.Clear();

          
        
        }


        private void LoadGridData()
        {
           

            string lSQL = "";
            lSQL += " SELECT CC.ClaimID AS Code, mch.cgdDesc AS MachineNo, ";
            lSQL += " con.cgdDesc AS Contractor, ";
            lSQL += " sh.cgdDesc AS Shift,ct.cgdDesc AS ChargesType,CC.ClaimAmountOffice,CC.CompensationAmount,CC.ClaimAmount,";
            lSQL += "  CC.Reason, CC.OrderedBY, ";
            lSQL += "  CC.MachineID, CC.ContractorID, CC.ShiftID, CC.ChargesTypeID ";
            lSQL += " from ClaimContDet CC ";
            lSQL += " JOIN CatDtl mch ON CC.MachineID=mch.cgdCode AND mch.cgCode=11 ";
            lSQL += " INNER JOIN CatDtl con ON CC.ContractorID=con.cgdCode AND con.cgCode=12 ";
            lSQL += " INNER JOIN CatDtl sh ON CC.ShiftID = sh.cgdCode AND sh.cgCode=1 ";
            lSQL += " INNER JOIN CatDtl ct ON CC.ChargesTypeID = ct.cgdCode AND ct.cgCode=4 ";
            lSQL += " where CC.ClaimID ='" + txtClaim.Text.ToString() + "'; ";

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
            lFieldList = "MachineNo";                    //  0-    ItemID";       
            lFieldList += ",Contractor";              //  1-    ItemCode";     
            lFieldList += ",Shift";              //  2-    ItemName";
            lFieldList += ",ChargesType";                   //  8-    Vender Name
         
            lFieldList += ",ClaimAmountOffice";                   //  8- Qty
            lFieldList += ",CompensationAmount";                   //  8- Qty
            lFieldList += ",ClaimAmount";                   //  8- Qty
            lFieldList += ",Reason";                 //  7- Stock
            lFieldList += ",OrderedBY";                 //  7- Stock
            //lFieldList += ",Rate";                   //  8- Qty
            //lFieldList += ",Amount";                   //  8- Qty

            lFieldList += ",MachineID";                //  9    SizeID";     
            lFieldList += ",ContractorID";               //  10    ColorID";     
            lFieldList += ",ShiftID";                 //  11    UOMID"; 
            lFieldList += ",ChargesTypeID";              //  12- GodownID


            lHDR += "MachineNo";            //  0-    ItemID";       
            lHDR += ",Contractor";         //  1-    ItemCode";     
            lHDR += ",Shift";         //  2-    ItemName";
            lHDR += ",ChargesType";         //  2-    ItemName";
            lHDR += ",ClaimAmountOffice";       //  3-    SizeName";      
            lHDR += ",CompensationAmount";              //  4-    ColorName";     
            lHDR += ",ClaimAmount";             //  5-    UOMName";
            lHDR += ",Reason";          //  6- GodownName
            lHDR += ",OrderedBy";            //  7- Stock
           
            lHDR += ",MachineID";            //  9    SizeID";     
            lHDR += ",ContractorID";           //  10    ColorID";     
            lHDR += ",ShiftID";             //  11    UOMID"; 
            lHDR += ",ChargestypeID";          //  12- GodownID

            // Col Visible Width
            lColWidth = "   12";                 //  0-    ItemID";       
            lColWidth += ",12";                 //  1-    ItemCode";     
            lColWidth += ",20";                 //  2-    ItemName";
            lColWidth += ",12";                 //  2-    VenderName";
            lColWidth += ",15";                 //  3-    SizeName";      
            lColWidth += ", 15";                 //  4-    ColorName";     
            lColWidth += ", 15";                 //  5-    UOMName";
            lColWidth += ", 20";                 //  6- GodownName
            lColWidth += ", 20";                 //  7- Stock
           
            lColWidth += ", 15";                 //  9    SizeID";     
            lColWidth += ", 15";                 //  10    ColorID";     
            lColWidth += ", 15";                 //  11    UOMID"; 
            lColWidth += ", 15";                 //  12- GodownID

            // Column Input Length/Width
            lColMaxInputLen = "  0";                 //  0-    ItemID";       
            lColMaxInputLen += ", 0";                //  1-    ItemCode";     
            lColMaxInputLen += ", 0";                //  2-    ItemName";
            lColMaxInputLen += ", 0";                //  2-    VenderName";
            lColMaxInputLen += ", 0";                //  3-    SizeName";      
            lColMaxInputLen += ", 0";                //  4-    ColorName";     
            lColMaxInputLen += ", 0";                //  5-    UOMName";
            lColMaxInputLen += ", 0";                //  6- GodownName
            lColMaxInputLen += ", 0";                //  7- Stock
            lColMaxInputLen += ", 0";                //  8- Qty
            lColMaxInputLen += ", 0";                //  8- Qty
            lColMaxInputLen += ", 0";                //  2-    NewStock";
            lColMaxInputLen += ", 0";                //  2-    Rate";
           

            // Column Min Width
            lColMinWidth = "   0";                      //  0-    ItemID";           
            lColMinWidth += ", 0";                      //  1-    ItemCode";         
            lColMinWidth += ", 0";                      //  2-    ItemName";
            lColMinWidth += ", 0";                      //  2-    VenderName";
            lColMinWidth += ", 0";                      //  3-    SizeName";      
            lColMinWidth += ", 0";                      //  4-    ColorName";         
            lColMinWidth += ", 0";                      //  5-    UOMName";    
            lColMinWidth += ", 0";                      //  6- GodownName
            lColMinWidth += ", 0";                      //  7- Stock
            lColMinWidth += ", 0";                      //  8- Qty
            lColMinWidth += ", 0";                      //  8- Qty
            lColMinWidth += ", 0";                      //  2-    New Stock";
            lColMinWidth += ", 0";                      //  2-    Rate";
           

            // Column Format
            lColFormat = "   T";                       //  0-    ItemID";            
            lColFormat += ", T";                       //  1-    ItemCode";         
            lColFormat += ", T";                       //  2-    ItemName";
            lColFormat += ", T";                       //  2-    VenderName";
            lColFormat += ", T";                       //  3-    SizeName";      
            lColFormat += ", T";                       //  4-    ColorName";         
            lColFormat += ", T";                       //  5-    UOMName";    
            lColFormat += ", T";                       //  6- GodownName
            lColFormat += ", T";                       //  7- Stock
           

            lColFormat += ", H";                       //  9    SizeID";       
            lColFormat += ", H";                       //  10    ColorID";        
            lColFormat += ", H";                       //  11    UOMID"; 
            lColFormat += ", H";                       //  12- GodownID

            // Column ReadOnly 1= readonly, 0 = read-write
            lColReadOnly = "  0";                      //  0-    ItemID";       
            lColReadOnly += ",0";                      //  1-    ItemCode";     
            lColReadOnly += ",0";                      //  2-    ItemName";
            lColReadOnly += ",0";                      //  2-    VenderName";
            lColReadOnly += ",0";                      //  3-    SizeName";      
            lColReadOnly += ",0";                      //  4-    ColorName";     
            lColReadOnly += ",0";                      //  5-    UOMName";
            lColReadOnly += ",0";                      //  6- GodownName
            lColReadOnly += ",0";                      //  7- Stock
          
            lColReadOnly += ",1";                      //  9    SizeID";     
            lColReadOnly += ",1";                      //  10    ColorID";     
            lColReadOnly += ",1";                      //  11    UOMID"; 
            lColReadOnly += ",1";                      //  12- GodownID

            // For Saving Time
            tColType += "  SKP";             //  0-    ItemID";       
            tColType += ",SKP";             //  1-    ItemCode";     
            tColType += ",SKP";             //  2-    ItemName";
            tColType += ",SKP";             //  2-    ItemName";
            tColType += ",N0";              //  3-    SizeName";      
            tColType += ",N0";             //  4-    ColorName";     
            tColType += ",N0";             //  5-    UOMName";
            tColType += ",SKP";             //  6- GodownName
            tColType += ", SKP";             //  7- Stock
           
            tColType += ", N0";             //  9    SizeID";     
            tColType += ", N0";             //  10    ColorID";     
            tColType += ", N0";             //  11    UOMID"; 
            tColType += ", N0";             //  12- GodownID

            tFieldName += "MachineNo";               //  0-    ItemID";        
            tFieldName += ",Contractor";          //  1-    ItemCode";        
            tFieldName += ",Shift";          //  2-    ItemName";
            tFieldName += ",ChargesType";          //  2-    ItemName";
            tFieldName += ",ClaimAmountOffice";       //  3-    SizeName";      
            tFieldName += ",CompensationAmount";          //  4-    ColorName";          
            tFieldName += ",ClaimAmount";         //  5-    UOMName";     
            tFieldName += ",Reason";          //  6- GodownName
            tFieldName += ",OrderedBY";        //  7- Stock
           
            tFieldName += ",MachineID";            //  9    SizeID";     
            tFieldName += ",ContractorID";           //  10    ColorID";      
            tFieldName += ",ShiftID";             //  11    UOMID"; 
            tFieldName += ",ChargesTypeID";          //  12- GodownID

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
                        fLastID = txtClaim.Text.ToString();
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
                if (txtClaim.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    fDocID = clsDbManager.GetNextValDocID("ClaimCont", "ClaimID", fDocWhere, "");

                    lSQL = "insert into ClaimCont (";
                    lSQL += "  ClaimID ";                                
                    lSQL += ", Date ";
                    lSQL += "  OrgId ";   
                    lSQL += ",Note ";
                    lSQL += ", Status ";
                    lSQL += ", UserId ";
                    lSQL += ", BranchId ";
                   
                    lSQL += " ) values (";
                    //                                                       
                    lSQL += "'" + fDocID.ToString() + "'";
                    lSQL += ",'" + txtClaim.Text.ToString() + "";
                    lSQL += ", " + StrF01.D2Str(dtpClaim) + "";
                    lSQL += ", 1";
                    lSQL += ",'" + txtNote + "'";
                    lSQL += ", 0";
                    lSQL += ", 1";
                    lSQL += ", 1";
                   
                    lSQL += ")";
                }
                else
                {
                    fDocWhere = " ClaimID = '" + txtClaim.Text.ToString() + "'";
                    if (clsDbManager.IDAlreadyExistWw("ClaimCont", "ClaimID", fDocWhere))
                    {

                        fDocAlreadyExists = true;
                        lSQL = "delete from ClaimContDet ";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);
                        //
                    }

                    lSQL = "update ClaimCont set";
                    lSQL += "  Date = '" + StrF01.D2Str(dtpClaim.Value) + "'";
                    
                    lSQL += ", Note = '" + txtNote.Text.ToString() + "'";
                   
                    lSQL += ", UserID = 1";
                    lSQL += ",Status = 0";
                    lSQL += ", BranchID = 1";
                   
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

                    lSQL = "INSERT INTO ClaimContDet (ClaimID";
                    lSQL += ",MachineID,ContractorID,ShiftID,ChargesTypeID,ClaimAmountOffice,CompensationAmount,ClaimAmount)";
                    lSQL += " VALUES (";
                    lSQL += "'" + txtClaim.Text.ToString() + "'";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColClaimCon.MachineID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColClaimCon.ContractorID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColClaimCon.ShiftID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColClaimCon.ChargesTypeID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColClaimCon.ClaimAmountOffice].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColClaimCon.CompensationAmount].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColClaimCon.ClaimAmount].Value.ToString() + "";
                    //lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColGRNRet.Amount].Value.ToString() + "";
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


        
        private void cboLC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void SumVoc()
        {
            bool bcheck;
            decimal fQty = 0;
            decimal fAmount = 0;
            decimal rtnVal = 0;
            decimal outValue = 0;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grd.Rows.Add(cboMachine.Text.ToString(),
              cboContractor.Text.ToString(),
              cboShift.Text.ToString(),
              cboCharges.Text.ToString(),
              txtClaimAmountOffice.Text.ToString(),
              txtCompensationAmount.Text.ToString(),
              txtClaimAmount.Text.ToString(),
              txtReason.Text.ToString(),
              txtOrder.Text.ToString(),

               cboMachine.SelectedValue.ToString(),
              cboContractor.SelectedValue.ToString(),
              cboShift.SelectedValue.ToString(),
            cboCharges.SelectedValue.ToString());

            SumVoc();
        }

        private void txtClaim_KeyDown_1(object sender, KeyEventArgs e)
        {
            LookUp_Voc();
        }

     

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageBox.Show("Data Saved Successfullly");
        }

        private void txtClaim_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc();
        }
    }
}