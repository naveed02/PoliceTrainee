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
    public partial class frmItemCodeDes : Form
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

        public frmItemCodeDes()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frmItemCodeDes_Load(object sender, EventArgs e)
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

            //Item group cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmItemGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGroup, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGroup.SelectedValue);

            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Table.enmIMS_UOM);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboUnit, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboUnit.SelectedValue);

        }

        private void frmItemCodeDes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void PassDataVocID(object sender)
        {
            txtItemID.Text = ((TextBox)sender).Text;
        }


        private void PopulateRecords()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  
            tSQL =  " SELECT i.ItemId, i.ItemCode, i.Name, u.UnitName, i.MinLevel, i.MaxLevel, i.StockLevel, i.CreatedDate, i.UrduItemName, i.UrduItemUnit ";
            tSQL += " from Item i INNER JOIN IMS_UOM u ON i.UOMId = u.UOMID ";
            tSQL += " where ItemId = " + txtItemID.Text.ToString() + "";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Heads");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    txtItemID.Text = (ds.Tables[0].Rows[0]["ItemId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemId"].ToString());
                    txtItemCode.Text = (ds.Tables[0].Rows[0]["ItemCode"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemCode"].ToString());
                    txtItemName.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());
                    cboUnit.Text = (ds.Tables[0].Rows[0]["UnitName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["UnitName"].ToString());
                    txtMinLevel.Text = (ds.Tables[0].Rows[0]["MinLevel"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["MinLevel"].ToString());
                    txtMaxLevel.Text = (ds.Tables[0].Rows[0]["MaxLevel"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["MaxLevel"].ToString());
                    txtStockLevel.Text = (ds.Tables[0].Rows[0]["StockLevel"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["StockLevel"].ToString());
                    dtpCreatedDate.Text = (ds.Tables[0].Rows[0]["CreatedDate"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CreatedDate"].ToString());
                    txtUrduItemName.Text = (ds.Tables[0].Rows[0]["UrduItemName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["UrduItemName"].ToString());
                    txtUrduItemUnit.Text = (ds.Tables[0].Rows[0]["UrduItemUnit"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["UrduItemUnit"].ToString());

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                    }

                    btnDuplicateItems.Enabled = true;
                    //LoadGridData();
                    //SumVoc();
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
                    "i.ItemId", 
                    "i.ItemCode, i.Name, u.UnitName, i.MinLevel, i.MaxLevel, i.StockLevel,i.CreatedDate, i.UrduItemName, i.UrduItemUnit",
                    "Item i INNER JOIN IMS_UOM u ON i.UOMId = u.UOMID ",
                    this.Text.ToString(),
                    1,
                    "Item ID, Item Code, Item Name, Unit Name, Min. Level, Max. Level, Stock Level, Created Date, Urdu Item Name, Urdu Item Unit",
                    "8,8,12,12,8,8,8,8,12,12",
                    " T, T, T, T, T, T, T, T, T, T",
                    true,
                    "",
                    "",
                    "TextBox"
                    );

            txtItemID.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID);
            sForm.ShowDialog();

            if (txtItemID.Text != null)
            {
                if (txtItemID.Text != null)
                {
                    if (txtItemID.Text.ToString() == "" || txtItemID.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtItemID.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecords();
                    }

                }

            }
        }
        #endregion

        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
        }

        private void txtGLCode_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc1();
        }

        private void txtGLCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc1();
            }
        }

        #region LookUp_Voc1

        private void LookUp_Voc1()
        {
            frmLookUp sForm = new frmLookUp(
                    "Code",
                    "Name",
                    "Heads",
                    this.Text.ToString(),
                    1,
                    "Code, Account Description",
                    "20,40",
                    " T, T",
                    true,
                    "",
                    "",
                    "TextBox"
                    );

            txtGLCode.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID1);
            sForm.ShowDialog();

            if (txtGLCode.Text != null)
            {
                if (txtGLCode.Text != null)
                {
                    if (txtGLCode.Text.ToString() == "" || txtGLCode.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtGLCode.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecords1();
                    }

                }

            }
        }
        #endregion
        private void PassDataVocID1(object sender)
        {
            txtGLCode.Text = ((TextBox)sender).Text;
        }

        private void PopulateRecords1()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  
            tSQL = "SELECT Code, Name ";
            tSQL += "from Heads ";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Heads");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    txtGLCode.Text = (ds.Tables[0].Rows[0]["Code"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Code"].ToString());
                    txtAccountName.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                    }
                    //LoadGridData();
                    //SumVoc();
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            LookUp_Voc();
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

        private void ClearThisForm()
        {
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
                if (!FormValidation())
                {
                    textAlert.Text = "Form Validation Error: Not Saved." + "  " + lNow.ToString();
                    MessageBox.Show(ErrrMsg, "Save: " + this.Text.ToString());
                    return false;
                }

                fManySQL = new List<string>();

                // Prepare Master Doc Query List
                
                if (!PrepareDocMaster())
                {
                    textAlert.Text = "DocMaster: Modifying Doc/Voucher not available for updation.'  ...." + "  " + lNow.ToString();
                    //tabMDtl.SelectedTab = tabError;
                    return false;
                }
                //
                    DateTime now = DateTime.Now;
                    textAlert.Text = "selected Box Empty... " + now.ToString("T");
                    // pending return false;
                
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
                        fLastID = txtItemID.Text.ToString();
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
                if (txtItemID.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    fDocID = fDocID + 1;
                    strDocId = fDocID.ToString();
                    txtItemID.Text = strDocId;
                    fDocID = clsDbManager.GetNextValDocID("Item", "ItemId", fDocWhere, "");

                    lSQL = "insert into Item (";
                    lSQL += "  ItemId ";                 // ItemID                 
                    lSQL += ", ItemGroupId ";           // ItemGoupId 
                    lSQL += ", ItemSerial ";              // ItemCode
                    lSQL += ", Name ";              // ItemName             
                    lSQL += ", UOMId ";                 // UOMId             
                    lSQL += ", MinLevel ";              // MinLevel             
                    lSQL += ", MaxLevel ";              // MaxLevel             
                    lSQL += ", StockLevel ";            // StockLevel             
                    lSQL += ", UrduItemName ";          // UrduItemName             
                    lSQL += ", UrduItemUnit ";          // UrduItemUnit              
                    lSQL += ", CreatedDate ";           // CreatedDate             
                    lSQL += ", GLCode ";                // GLCode
                    lSQL += ", ItemCategory ";
                    lSQL += " ) values (";
                    //                                                       
                    lSQL += "" + fDocID.ToString() + "";
                    lSQL += ", " + cboItemGroup.SelectedValue.ToString() + "";
                    lSQL += ",'" + txtItemCode.Text.ToString() + "'";
                    lSQL += ",'" + txtItemName.Text.ToString() + "'";           
                    lSQL += ", " + cboUnit.SelectedValue.ToString() + "";          
                    lSQL += ", " + txtMinLevel.Text.ToString();                    
                    lSQL += ", " + txtMaxLevel.Text.ToString();                    
                    lSQL += ", " + txtStockLevel.Text.ToString();                  
                    lSQL += ",'" + txtUrduItemName.Text.ToString() + "'";                
                    lSQL += ",'" + txtUrduItemUnit.Text.ToString() + "'";
                    lSQL += ", " + StrF01.D2Str(dtpCreatedDate) + "";
                    lSQL += ", " + txtGLCode.Text.ToString() + "";
                    lSQL += ", " + txtCategory.Text.ToString() + "";
                    lSQL += ")";                                                   
                }                                                                  
                else
                {
                    fDocWhere = " ItemId = " + txtItemID.Text.ToString() + "";
                    if (clsDbManager.IDAlreadyExistWw("Item", "ItemId", fDocWhere))
                    {
                        fDocAlreadyExists = true;
                        //fManySQL.Add(lSQL);
                    }

                    lSQL = "update Item set";
                    //lSQL += "  ItemId = " + txtItemID.Text.ToString() + "";                // ItemID        
                    //lSQL += ", ItemGroupID = " + cboItemGroup.SelectedValue.ToString() + "";  // ItemGroupId   
                    lSQL += " UOMId = " + cboUnit.SelectedValue.ToString() + "";             // UOMId         
                    lSQL += ", MinLevel = " + txtMinLevel.Text.ToString() + "";            // MinLevel      
                    lSQL += ", MaxLevel = " + txtMaxLevel.Text.ToString() + "";             // MaxLevel      
                    lSQL += ", StockLevel = " + txtStockLevel.Text.ToString() + "";            // StockLevel    
                    lSQL += ", UrduItemName = '" + txtUrduItemName.Text.ToString() + "'";          // UrduItemName  
                    lSQL += ", UrduItemUnit = '" + txtUrduItemUnit.Text.ToString() + "'";        // UrduItemUnit  
                    lSQL += ", CreatedDate = '" + StrF01.D2Str(dtpCreatedDate.Value) + "'";      // CreatedDate   
                    lSQL += ", GLCode = '" + txtGLCode.Text.ToString() + "'";                   // GLCode
                    lSQL += ", ItemCategory = '" + txtCategory.Text.ToString() + "'";
                    //lSQL += ", ItemCode = '" + txtItemCode.Text.ToString() + "'";
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


        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageBox.Show("Data Saved Successfullly");
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
            ClearTextBoxes();
        }

        private void btnNewCode_Click(object sender, EventArgs e)
        {
            string tSQL = string.Empty;

            //mySQL = "select top 1 " + pPidField;
            //mySQL += " from " + pTable + " Where " + pKeyFieldID + " = " + pSearchValue.ToString();

            tSQL = " select isNull(Max(ItemSerial),0)+1 AS ItemSerial, 'A' AS ItemCategory from Item where ItemGroupId= " + cboItemGroup.SelectedValue.ToString();
            
            //if (clsDbManager.IDAlreadyExistWw("Item", "ItemSerial", fDocWhere))
            //{
            //    fManySQL.Add(mySQL);
            //}
            DataSet ds = new DataSet();
            ds = clsDbManager.GetData_Set(tSQL, "Item");

            txtItemCode.Text = (ds.Tables[0].Rows[0]["ItemSerial"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemSerial"].ToString());
            txtCategory.Text = (ds.Tables[0].Rows[0]["ItemCategory"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemCategory"].ToString());
        }

        private void ASCII()
        {
            string eng = txtCategory.Text.ToString();
            byte[] pass_byte = Encoding.ASCII.GetBytes(eng);


            foreach (int element in pass_byte)
            {
                txtCategory.Text = element.ToString();
            }

            //ASCIIEncoding ascii = new ASCIIEncoding();
            //String decoded = ascii.GetString(pass_byte);

            //txtCategory.Text = decoded;

            int next = Convert.ToInt32(txtCategory.Text.ToString()) + 1;
            byte[] converted = BitConverter.GetBytes(next);
            txtCategory.Text = next.ToString();

            ASCIIEncoding ascii = new ASCIIEncoding();
            String decoded = ascii.GetString(converted);

            txtCategory.Text = decoded;
            //char engNext = (char)next;
            //lblEnglish.Text = engNext.ToString();
        }

        private void btnDuplicateItems_Click(object sender, EventArgs e)
        {
            string tSQL = string.Empty;

            tSQL = " select MAX(ItemCategory) AS ItemCategory from Item ";

            DataSet ds = new DataSet();
            ds = clsDbManager.GetData_Set(tSQL, "Item");

            txtCategory.Text = (ds.Tables[0].Rows[0]["ItemCategory"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemCategory"].ToString());
            ASCII();
        }

    }
}

﻿