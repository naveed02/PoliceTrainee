﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI_Task.StringFun01;

namespace GUI_Task
{
     enum GColVDes
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

    public partial class frmVenderDescription : Form
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

        public frmVenderDescription()
        {
            InitializeComponent();
        }

        private void mskSupplierCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_GL();
            }

        }

        private void mskSupplierCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           LookUp_GL();
        }



   
        private void frmVenderDescription_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            //this.MaximizeBox = false;
        }


        private void AtFormLoad()
        {
            string lSQL = string.Empty;


            this.KeyPreview = true;
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
                    //" Type='A'",
                    "TextBox"
                    );

            //mskSupplierCode.Mask = "";
            //mskSupplierCode.Text = string.Empty;
            //mskSupplierCode.Mask = clsGVar.maskGLCode;

            sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
            sForm.ShowDialog();
            if (mskSupplierCode.Text != null)
            {
                if (mskSupplierCode.Text != null)
                {
                    if (mskSupplierCode.Text.ToString() == "" || mskSupplierCode.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    //if (mskSupplierCode.Text.ToString().Trim().Length > 0)
                    //{
                        PopulateRecordsGL();
                        //LoadSampleData();
                        //SumVoc();
                    //}

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
           // mskSupplierCode.Mask = "";
            mskSupplierCode.Text = ((TextBox)sender).Text;
           //mskSupplierCode.Mask = clsGVar.maskGLCode;
            //mskSupplierCode.Text = ((MaskedTextBox)sender).Text;
            //mskSupplierCode.Mask = clsGVar.maskGLCode;

        }

        //Populate Recordset 
        private void PopulateRecordsGL()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  
            tSQL = " SELECT v.Code,h.Name, h.Add1,h.Add2,h.City,h.Contact,h.Phone,h.Mobile,h.Fax,h.Email,v.UName,v.UAdd1 from Vendor v ";
            tSQL += " inner join Heads h on v.Code=Right(h.Code,7) and Left(h.Code,6)='3-2-02'";
            tSQL += " where h.Code ='" + mskSupplierCode.Text.ToString() + "';";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Heads");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    txtSupplierName.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());
                    txtContact.Text = (ds.Tables[0].Rows[0]["Contact"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Contact"].ToString());
                    txtAdd1.Text = (ds.Tables[0].Rows[0]["Add1"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Add1"].ToString());
                    txtAdd2.Text = (ds.Tables[0].Rows[0]["Add2"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Add2"].ToString());
                    txtCity.Text = (ds.Tables[0].Rows[0]["City"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["City"].ToString());
                    txtPhone.Text = (ds.Tables[0].Rows[0]["Phone"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Phone"].ToString());
                    txtMobile.Text = (ds.Tables[0].Rows[0]["Mobile"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Mobile"].ToString());
                    txtFax.Text = (ds.Tables[0].Rows[0]["Fax"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Fax"].ToString());
                    txtEmail.Text = (ds.Tables[0].Rows[0]["Email"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["EMail"].ToString());
                    txtUName.Text = (ds.Tables[0].Rows[0]["UName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["UName"].ToString());
                    txtUAdd1.Text = (ds.Tables[0].Rows[0]["UAdd1"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["UAdd1"].ToString());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
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

        private void btnHelp_Click(object sender, EventArgs e)
        {
            LookUp_GL();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageBox.Show("Data Saved Successfullly");
        }

        private bool PrepareDocMaster()
        {
            bool rtnValue = true;
            string lSQL = string.Empty;

            try
            {
                // ** 
                //select v.Code, h.Name, h.Type, v.Contact
                //from Vendor v inner join Heads h on v.Code=Right(h.Code,7) 
                //and LEFT(h.Code,6)='3-2-02'
                //and v.Code='01-0001'

                if (mskSupplierCode.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    fDocID = clsDbManager.GetNextValDocID("Vendor", "Code", fDocWhere, "");

                    lSQL = "insert into Vendor (";
                    lSQL += "  Code ";                              //  0-    ItemID";   
                    lSQL += ", Name ";
                    lSQL += ", City ";//  1-    ItemCod  
                    lSQL += ", Contact ";                                        //  2-    ItemNam 
                    lSQL += ", Add1 ";                                      // 3- Descripti
                    lSQL += ", Add2 ";                                        //  4-    SizeNam  
                    lSQL += ", Phone ";                                 //  5-    ColorNa  
                    lSQL += ", Mobile ";                                      //  6-    UOMName
                    lSQL += ", Fax ";                                      // 7- GodownName
                    lSQL += ", Email ";                                         // 8- Qty
                    lSQL += ", UName ";                                      // 9    SizeID";   
                    lSQL += ", UAdd1 ";                                    // 10    ColorID"  
                    lSQL += " ) values (";
                    //fDocID.ToString()
                    //                                                       
                    lSQL += "'" + fDocID.ToString() + "'";                  //  0-    ItemID";   
                    lSQL += "," + txtSupplierName + "'";        //  1-    ItemCod  
                    lSQL += "," + txtCity + "'"; 
                    lSQL += "," + txtContact + "'";          //  2-    ItemNam 
                    lSQL += ",'" + txtAdd1 + "'";                                              // 3- Descripti
                    lSQL += ",'" + txtAdd1 + "'";                             //  4-    SizeNam  
                    lSQL += ",'" + txtPhone + "'";  //  5-    ColorNa  
                    lSQL += ",'" + txtMobile + "'";                                            //  6-    UOMName
                    lSQL += ",'" + txtFax + "'";                                            // 7- GodownName
                    lSQL += ",'" + txtEmail + "'";                                              // 8- Qty
                    lSQL += ",'" + txtUName + "'";                                             // 9    SizeID";   
                    lSQL += ",'" + txtUAdd1 + "'";                                            // 10    ColorID"  
                    lSQL += ")";                                              // 11    UOMID"; 
                }                                                               // 12- GodownID
                else
                {
                    fDocWhere = " Code = '" + mskSupplierCode.Text.ToString() + "'";
                    if (clsDbManager.IDAlreadyExistWw("Heads", "Code", fDocWhere))
                    {

                        fDocAlreadyExists = true;
                        lSQL = "delete from  Heads";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);
                        //    //

                    }
                        lSQL = "update Heads set";
                        lSQL += "  Name = '" + txtSupplierName.Text.ToString() + "'";
                        lSQL += ",Contact ='" + txtContact.Text.ToString() + "'";

                        lSQL += ", Add1 = '" + txtAdd1.Text.ToString() + "'";
                        lSQL += ", Add2 = '" + txtAdd2.Text.ToString() + "'"; 
                        lSQL += ",City ='" + txtCity.Text.ToString() + "'";
                       
                        lSQL += ", Phone = '" + txtPhone.Text.ToString() + "'";
                        lSQL += ", Mobile = '" + txtMobile.Text.ToString() + "'";
                        lSQL += ", Fax = '" + txtFax.Text.ToString() + "'";
                        lSQL += ", Email = '" + txtEmail.Text.ToString() + "'";
                        //lSQL += ", UName ='" + txtUName.Text.ToString() + "'";
                        //lSQL += ", UAdd1 = '" + txtUAdd1.Text.ToString() + "'";

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
            //try
            //{
            //    ErrrMsg = "";
            //    if (grd.Rows.Count < 1)
            //    {
            //        fTErr++;
            //        MessageBox.Show("No transaction in grid to Save", "Save: " + this.Text.ToString());
            //        return false;
            //    }
            //    fLastRow = grd.Rows.Count - 1;    
            if (!FormValidation())
            {
                textAlert.Text = "Form Validation Error: Not Saved." + "  " + lNow.ToString();
                MessageBox.Show(ErrrMsg, "Save: " + this.Text.ToString());
                return false;
            }

            fManySQL = new List<string>();

                //// Prepare Master Doc Query List
                ////fTNOT = GridTNOT(grd);
                if (!PrepareDocMaster())
                {
                    textAlert.Text = "DocMaster: Modifying Doc/Voucher not available for updation.'  ...." + "  " + lNow.ToString();
                    //tabMDtl.SelectedTab = tabError;
                    return false;
                }
                //
                //if (grd.Rows.Count > 0)
                //{
                //    // Prepare Detail Doc Query List
                //    if (!PrepareDocDetail())
                //    {
                //        return false;
                //    }
                //}
                //else
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
                        fLastID = mskSupplierCode.Text.ToString();
           //             ClearThisForm();
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Data Preparation list empty, Not Saved...", this.Text.ToString());
                    return false;
               } // End Execute Query
            }


            //catch (Exception ex)
            //{
            //    MessageBox.Show("Exception Processing Save: " + ex.Message, "Save Data: " + this.Text.ToString());
            //    return false;
            //}

        } // End Save

        }

