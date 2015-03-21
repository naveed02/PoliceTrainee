using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI_Task.Class;
using JThomas.Controls;
using GUI_Task.StringFun01;

namespace GUI_Task
{
    enum GColPO
    {
        ItemID = 0,
        ItemCode = 1,
        ItemName = 2,
        SizeName = 3,
        ColorName = 4,
        Stock = 5,
        DNQty = 6,
        POQty = 7,
        RemQty = 8,
        LastRate = 9,
        Amount = 10,
        SizeID = 11,
        ColorID = 12,
    }
    public partial class frmPurchaseOrder : Form
    {
        //******* Grid Variable Setting -- Begin ******
        string strDocId = string.Empty;
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
        public frmPurchaseOrder()
        {
            InitializeComponent();
        }

        private void Purchase_Order_Load(object sender, EventArgs e)
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


            //Emp Code Combo Fill
            lSQL = "SELECT employeeid, first_name +' '+ last_name AS EmpName FROM PR_Employee ";
            //lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboEmpCode, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboEmpCode.SelectedValue);

            //Item group cOMBO
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

        }
        private void button6_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageBox.Show("Data Saved Successfullly");
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
                if (grd.Rows[i].Cells[(int)GColPO.Amount].Value != null)
                {
                    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GColPO.Amount].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fAmount = fAmount + outValue;
                    }
                }
                if (grd.Rows[i].Cells[(int)GColPO.POQty].Value != null)
                {
                    bcheck = decimal.TryParse(grd.Rows[i].Cells[(int)GColPO.POQty].Value.ToString(), out outValue);
                    if (bcheck)
                    {
                        rtnVal += outValue;
                        fQty = fQty + outValue;
                    }
                } // if != null
                //grdVoucher[2, i].Value = (i + 1).ToString();
            }

            lblVal.Text = String.Format("{0:0,0.00}", fAmount);
            lblQty.Text = String.Format("{0:0,0.00}", fQty);

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageBox.Show("Data Saved Successfullly");
            //}
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
                        fLastID = txtPONo.Text.ToString();
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
                if (txtPONo.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    fDocID = clsDbManager.GetNextValDocID("PO", "DocId", fDocWhere, "");
                    fDocID = fDocID + 1;
                    strDocId = "1-" + DateTime.Now.Year.ToString() + "-" + fDocID.ToString();
                    txtPONo.Text = strDocId;

                    lSQL = "insert into PO (";
                    lSQL += "  DocId ";
                    lSQL += "  ,POId ";                              //  0-    ItemID";   
                    lSQL += ", Date ";                                        //  2-    ItemNam 
                    lSQL += ", DNId ";
                    lSQL += ", DNDate ";
                    lSQL += ", EmployeeId "; 
                    lSQL += ", ItemGroupId ";                                 //  5-    ColorNa  
                    lSQL += ", VendorId ";                                    // 10    ColorID"
                    lSQL += ", PurchaserId ";     
                    lSQL += ", Note ";
                    lSQL += ", Note2 ";
                    lSQL += ", SuggCash ";
                    lSQL += ", OrgId ";
                    lSQL += ", UserId ";
                    lSQL += ", Status ";
                    lSQL += ", BranchId ";// 8- Qty
                                                   // 10    ColorID"
                    
                    lSQL += " ) values (";
                    //                                                       
                    lSQL += fDocID.ToString();
                    lSQL += ",'" + strDocId.ToString() + "'";  
                    lSQL += ", " + StrF01.D2Str(dtpPO) + "";          //  2-    ItemNam 
                    lSQL += ",'" + txtDNNo.Text.ToString() + "'";
                    lSQL += ", " + StrF01.D2Str(dtpDN) + "";
                    lSQL += ", " + cboEmpCode.SelectedValue.ToString() + "";  //  5-    ColorNa 
                    lSQL += ", " + cboItemGroup.SelectedValue.ToString() + "";  //  5-    ColorNa 
                    lSQL += ",'" + mskVenderCode.Text.ToString() + "'";  //  5-    ColorNa 
                    lSQL += ",'" + mskPurchaseCode.Text.ToString() + "'";  //  5-    ColorNa 
                    lSQL += ",'" + txtNote.Text.ToString() + "'";      
                    lSQL += ", ''";                                              // 3- Descripti
                                 //  4-    SizeNam  
                     
                    lSQL += ", 0";                                            //  6-    UOMName
                    lSQL += ", 1";                                            // 7- GodownName
                    lSQL += ", 0";                                              // 8- Qty
                    lSQL += ", 0";                                             // 9    SizeID";   
                    lSQL += ", 1";                                            // 10    ColorID"  
                    lSQL += ")";                                              // 11    UOMID"; 
                }                                                               // 12- GodownID
                else
                {
                    fDocWhere = " POId = '" + txtPONo.Text.ToString() + "'";
                    if (clsDbManager.IDAlreadyExistWw("PO", "POId", fDocWhere))
                    {

                        fDocAlreadyExists = true;
                        lSQL = "delete from PODetail ";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);
                        //
                    }

                    lSQL = "update PO set";
                    lSQL += "  Date = '" + StrF01.D2Str(dtpPO.Value) + "'";
                    lSQL += " , DNDate = " + StrF01.D2Str(dtpDN) + "";
                    lSQL += ", ItemGroupID = " + cboItemGroup.SelectedValue.ToString() + "";
                    lSQL += ", Note = '" + txtNote.Text.ToString() + "'";
                    lSQL += ", EmployeeId = " + cboEmpCode.SelectedValue.ToString() + "";
                    lSQL += ", VendorId = " + mskVenderCode.Text.ToString() + "";
                    lSQL += ", PurchaserId = " + mskPurchaseCode.Text.ToString() + "";
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

                    lSQL = "INSERT INTO PODetail (DocId,POId";
                    lSQL += ",ItemId,SizeId,ColorID,DNQty,POQty,RemainingQty,LastRate)";
                    lSQL += " VALUES (";
                    lSQL += "" + fDocID + "";
                    lSQL += ", '" + strDocId.ToString() + "'";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColPO.ItemID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColPO.SizeID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColPO.ColorID].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColPO.DNQty].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColPO.POQty].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColPO.RemQty].Value.ToString() + "";
                    lSQL += ", " + grd.Rows[dGVRow].Cells[(int)GColPO.LastRate].Value.ToString() + "";
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




        private void button3_Click(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            LookUp_Voc1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmHelp frm = new frmHelp();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmHelp frm = new frmHelp();
            frm.Show();
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
            //                    "d.DNId",
            //                    "d.Date, ig.cgdDesc AS ItemGroupName, pd.department_name, " 
            //                    + "pe.first_name + ' ' + pe.last_name AS EmpName, d.Note ",
            //                    "DN d INNER JOIN CatDtl ig ON d.ItemGroupId=ig.cgdCode AND ig.cgCode=6 "
            //                    + "INNER JOIN PR_Department pd ON d.DepartmentId=pd.departmentid " 
            //                    + "INNER JOIN PR_Employee pe ON d.EmployeeId=pe.employeeid",
            //                    this.Text.ToString(),
            //                    1,
            //                    "DN#,Date,Item Group Name,Department Name,Employee Name,Note ",
            //                    "10,8,12,12,12,15",
            //                    " T, T, T, T, T, T",
            //                    true,
            //                    "",

            //"sl.StockLevelId",
            //   " sl.Date, cd.cgdDesc AS ItemGroupName, sl.Note ",
            //   "  StockLevel sl inner join StockLevelDetail sld on sl.StockLevelId=sld.StockLevelId "
            //   + " inner join CatDtl cd on sl.ItemGroupID=cd.cgdCode AND cd.cgCode=6",
            //       this.Text.ToString(),
            //       1,
            //       "Stock #,Date,Item Group Name,Note",
            //       "12,8,15,20",
            //       " T, T, T, T",
            //       true,
            //       "",
            //   //"d.Category = " + cboMainGroup.SelectedValue.ToString(), 
            //       "",
            //       "TextBox"
            //       );
            //            select po.POId, po.Date, po.DNId, po.DNDate, e.first_name + ' ' + e.last_name AS EmployeeName,
            // po.Note
            //from PO po
            //inner join PoDetail pod on po.POId=pod.POId
            //inner join PR_Employee e on po.EmployeeId=e.employeeid


            frmLookUp sForm = new frmLookUp(
                    "po.POId",
                " po.Date, po.DNId, po.DNDate, po.Note ",
                " PO po  ",
                //      "inner join PR_Employee e on po.EmployeeId=e.employeeid",
                    this.Text.ToString(),
                    1,
                    "PO #, PO Date, DN #, DN Date, Note",
                    "8,8,8,8,20",
                    " T, T, T, T, T",
                    true,
                    "",
                //"d.Category = " + cboMainGroup.SelectedValue.ToString(), 
                    "",
                    "TextBox"
                    );
            txtPONo.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID);
            sForm.ShowDialog();

            if (txtPONo.Text != null)
            {
                if (txtPONo.Text != null)
                {
                    if (txtPONo.Text.ToString() == "" || txtPONo.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtPONo.Text.ToString().Trim().Length > 0)
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
            txtPONo.Text = ((TextBox)sender).Text;
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

            //            select po.POId, po.Date, po.DNId, po.DNDate, e.first_name + ' ' + e.last_name AS EmployeeName,
            // po.Note
            //from PO po
            //inner join PoDetail pod on po.POId=pod.POId
            //inner join PR_Employee e on po.EmployeeId=e.employeeid


            //tSQL = "    select po.POId,
            tSQL = " select po.POId, po.Date, po.DNId, po.DNDate, e.first_name + ' ' + e.last_name AS EmployeeName, po.Note, ";
		    tSQL += " po.VendorId, v.Name AS VendorName, po.PurchaserId, c.Name AS PurchaserName, cd.cgdDesc AS ItemGroupName ";
            tSQL += " from PO po inner join PoDetail pod on po.POId=pod.POId ";
            tSQL += " inner join PR_Employee e on po.EmployeeId=e.employeeid ";
            tSQL += " INNER JOIN Vendor v ON v.Code = RIGHT(po.VendorId, 7) ";
            tSQL += " INNER JOIN Customer c ON c.Code = RIGHT(po.PurchaserId, 10) ";
            tSQL += " LEFT OUTER JOIN CatDtl cd ON po.ItemGroupID = cd.cgdCode AND cd.cgCode = 6 ";
            tSQL += " where po.POId='" + txtPONo.Text.ToString() + "';";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "PO");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    txtPONo.Text = (ds.Tables[0].Rows[0]["POId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["POId"].ToString());
                    dtpPO.Text = (ds.Tables[0].Rows[0]["Date"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Date"].ToString());
                    txtDNNo.Text = (ds.Tables[0].Rows[0]["DNId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DNId"].ToString());
                    dtpDN.Text = (ds.Tables[0].Rows[0]["DNDate"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DNDate"].ToString());
                    cboEmpCode.Text = (ds.Tables[0].Rows[0]["EmployeeName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["EmployeeName"].ToString());
                    mskVenderCode.Text = (ds.Tables[0].Rows[0]["VendorId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["VendorId"].ToString());
                    lblNameVendor.Text = (ds.Tables[0].Rows[0]["VendorName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["VendorName"].ToString());
                    mskPurchaseCode.Text = (ds.Tables[0].Rows[0]["PurchaserId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["PurchaserId"].ToString());
                    lblName.Text = (ds.Tables[0].Rows[0]["PurchaserName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["PurchaserName"].ToString());
                    cboItemGroup.Text = (ds.Tables[0].Rows[0]["ItemGroupName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemGroupName"].ToString());
                    txtNote.Text = (ds.Tables[0].Rows[0]["Note"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Note"].ToString());
                    //txtDetail.Text = (ds.Tables[0].Rows[0]["Detail"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Detail"].ToString());

                    //cboTransport.Text = (ds.Tables[0].Rows[0]["AddaId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["AddaId"].ToString());
                    //clsSetCombo.Set_ComboBox(cboAdda, Convert.ToInt32(ds.Tables[0].Rows[0]["AddaId"]));
                    //clsSetCombo.Set_ComboBox(cboItemGroup, Convert.ToInt32(ds.Tables[0].Rows[0]["ItemGroupID"]));


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
                    //txtManualDoc.Enabled = false;
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

        private void LoadGridData()
        {
            string lSQL = "";
            lSQL += " SELECT h.ItemId, i.ItemCode, i.Name AS ItemName, ";
            lSQL += " sz.cgdDesc AS SizeName, ";
            lSQL += " clr.cgdDesc AS ColorName,  0 AS Stock, ";
            lSQL += " h.DNQty, h.POQty, h.RemainingQty AS RemQty, h.LastRate, 0 AS Amount, ";
            lSQL += " h.SizeID, h.ColorID";
            lSQL += " from PoDetail h INNER JOIN Item i ON h.ItemId=i.ItemId ";
            lSQL += " INNER JOIN CatDtl clr ON h.ColorID=clr.cgdCode AND clr.cgCode=3 ";
            lSQL += " INNER JOIN CatDtl sz ON h.sizeid=sz.cgdCode AND sz.cgCode=5 ";
            lSQL += " where h.POId ='" + txtPONo.Text.ToString() + "'; ";

            clsDbManager.FillDataGrid(
                grd,
                lSQL,
                fFieldList,
                fColFormat);

            SumVoc();
        }

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
            lFieldList = "ItemId";          //ItemID = 0,
            lFieldList += ",ItemCode";      //ItemCode = 1, 
            lFieldList += ",ItemName";      //ItemName = 2, 
            lFieldList += ",SizeName";      //SizeName = 3, 
            lFieldList += ",ColorName";     //ColorName = 4,
            lFieldList += ",stock";         //Stock = 6,  
            lFieldList += ",DNQty";         //DNQty = 7,
            lFieldList += ",POQty";         //POQty = 8,
            lFieldList += ",RemQty";        //RemQty = 9,
            lFieldList += ",LastRate";      //LastRate = 10,
            lFieldList += ",Amount";        //Amount = 11,
            lFieldList += ",SizeId";        //SizeID = 12,
            lFieldList += ",ColorId";       //ColorID = 13, 
            //lFieldList += ",AvailBal";     
            //ItemID = 0,
            //ItemCode = 1, 
            //ItemName = 2, 
            //SizeName = 3, 
            //ColorName = 4,
            //UnitName = 5, 
            //Stock = 6,  
            //DNQty = 7,
            //POQty = 8,
            //RemQty = 9,
            //LastRate = 10,
            //Amount = 11,
            //SizeID = 12,
            //ColorID = 13, 
            //UOMID = 14,
            //ItemCode = 1,
            //ItemName = 2,
            //SizeName = 3,
            //ColorName = 4,
            //UnitName = 5,
            //Stock = 6,
            //DNQty = 7,
            //POQty = 8,
            //RemQty = 9,
            //LastRate = 10,
            //Amount = 11,
            //SizeID = 12,
            //ColorID = 13,
            //UOMID = 14,
            //lHDR += "Code";
            lHDR += " ItemID";      //ItemID = 0,   
            lHDR += ",Item Code";   //ItemCode = 1,    
            lHDR += ",Item Name";   //ItemName = 2,    
            lHDR += ",Size";        //SizeName = 3,    
            lHDR += ",Color";       //ColorName = 4,   
            lHDR += ",Stock";       //Stock = 6,  
            lHDR += ",DNQty";       //DNQty = 7,
            lHDR += ",POQty";       //POQty = 8, 
            lHDR += ",RemQty";      //RemQty = 9,
            lHDR += ",LastRate";    //LastRate = 10,
            lHDR += ",Amount";      //Amount = 11,
            lHDR += ",SizeId";       //SizeID = 12,
            lHDR += ",ColorId";     //ColorID = 13, 

            //lHDR += ",Ord.UnDel.Qty";     // 12    OrdUnDelQty";  
            //lHDR += ",Rate";              // 13    Rate";         
            //lHDR += ",Amount";            // 14    Amount";       
            //lHDR += ",AvailBal";          // 15    AvailBal";     

            // Col Visible Width
            lColWidth = " 5";                // 0-    ItemID";       
            lColWidth += ",12";                // 1-    ItemCode";     
            lColWidth += ", 20";                // 2-    ItemName";     
            lColWidth += ", 7";                // 3-    SizeID";       
            lColWidth += ", 7";                // 5-    ColorID";      
            lColWidth += ", 7";                // 7-    stock";     
            lColWidth += ", 7";                // 8-    DNQty";      
            lColWidth += ", 7";                // 9-    POQty";       
            lColWidth += ", 7";                // 10    RemQty";   
            lColWidth += ", 7";                // 11    lastRate";      
            lColWidth += ", 7";                // 12    amount";  
            lColWidth += ", 10";               // 14    SizeID";       
            lColWidth += ", 7";                // 15    AvailBal";     

            // Column Input Length/Width
            lColMaxInputLen = "  0";                // 0-    ItemID";     
            lColMaxInputLen += ", 0";               // 1-    ItemCode";   
            lColMaxInputLen += ", 0";                // 2-    ItemName";  
            lColMaxInputLen += ", 0";               // 3-    SizeID";     
            lColMaxInputLen += ", 0";               // 5-    ColorID";    
            lColMaxInputLen += ", 0";               // 7-    stock";      
            lColMaxInputLen += ", 0";               // 8-    DNQty";      
            lColMaxInputLen += ", 0";               // 9-    POQty";      
            lColMaxInputLen += ", 0";               // 10    RemQty";    
            lColMaxInputLen += ", 0";               // 11    lastRate";   
            lColMaxInputLen += ", 0";               // 12    amount";   
            lColMaxInputLen += ", 0";               // 14    SizeID";     
            lColMaxInputLen += ", 0";               // 15    AvailBal";   

            // Column Min Width
            lColMinWidth = "   0";                      // 0-    ItemID";    
            lColMinWidth += ", 0";                      // 1-    ItemCode";  
            lColMinWidth += ", 0";                       // 2-    ItemName"; 
            lColMinWidth += ", 0";                      // 3-    SizeID";    
            lColMinWidth += ", 0";                      // 5-    ColorID";   
            lColMinWidth += ", 0";                      // 7-    stock";     
            lColMinWidth += ", 0";                    // 8-    DNQty";       
            lColMinWidth += ", 0";                    // 9-    POQty";       
            lColMinWidth += ", 0";                      // 10    RemQty";   
            lColMinWidth += ", 0";                      // 11    lastRate";  
            lColMinWidth += ", 0";                    // 12    amount";    
            lColMinWidth += ", 0";                    // 14    SizeID";      
            lColMinWidth += ", 0";                      // 15    AvailBal";  

            // Column Format
            lColFormat = "  T";                      //ItemID = 0,
            lColFormat += ", T";                     //ItemCode = 1, 
            lColFormat += ", T";                     //ItemName = 2, 
            lColFormat += ", T";                     //SizeName = 3, 
            lColFormat += ", T";                     //ColorName = 4,
            lColFormat += ",N0";                     //Stock = 6,  
            lColFormat += ",N0";                     //DNQty = 7,
            lColFormat += ",N0";                     //POQty = 8,
            lColFormat += ",N0";                     //RemQty = 9,
            lColFormat += ",N2";                     //LastRate = 10,
            lColFormat += ",N2";                     //Amount = 11,
            lColFormat += ", H";                      //SizeID = 12,
            lColFormat += ", H";                      //ColorID = 13, 

            // Column ReadOnly 1= readonly, 0 = read-write
            lColReadOnly = "  1";                   //ItemID = 0,
            lColReadOnly += ",1";                   //ItemCode = 1, 
            lColReadOnly += ",1";                   //ItemName = 2, 
            lColReadOnly += ",0";                   //SizeName = 3, 
            lColReadOnly += ",0";                   //ColorName = 4,
            lColReadOnly += ",0";                   //Stock = 6,  
            lColReadOnly += ",0";                   //DNQty = 7,
            lColReadOnly += ",0";                   //POQty = 8,
            lColReadOnly += ",0";                   //RemQty = 9,
            lColReadOnly += ",0";                   //LastRate = 10,
            lColReadOnly += ",0";                   //Amount = 11,
            lColReadOnly += ",1";                   //SizeID = 12,
            lColReadOnly += ",1";                   //ColorID = 13, 

            // For Saving Time
            tColType += "  N0";            //ItemID = 0,
            tColType += ",  SKP";          //ItemCode = 1,  
            tColType += ",  SKP";          //ItemName = 2,  
            tColType += ",  SKP";          //SizeName = 3,  
            tColType += ",  SKP";          //ColorName = 4, 
            tColType += ", N0";            //Stock = 6,  
            tColType += ", N0";            //DNQty = 7,
            tColType += ", N0";            //POQty = 8,
            tColType += ", N0";            //RemQty = 9,
            tColType += ", N0";            //LastRate = 10,
            tColType += ", N0";            //Amount = 11,
            tColType += ", N0";            //SizeID = 12,
            tColType += ", N0";            //ColorID = 13, 

            tFieldName += "Code";              //ItemID = 0,
            tFieldName += ",ItemCode";         //ItemCode = 1, 
            tFieldName += ",ItemName";         //ItemName = 2, 
            tFieldName += ",SizeName";         //SizeName = 3,  
            tFieldName += ",ColorName";        //ColorName = 4, 
            tFieldName += ",Stock";         //Stock = 6,  
            tFieldName += ",DNQty";        //DNQty = 7, 
            tFieldName += ",POQty";         //POQty = 8, 
            tFieldName += ",RemQty";       //RemQty = 9,
            tFieldName += ",LastRate";          //LastRate = 10,
            tFieldName += ",Amount";    //Amount = 11, 
            tFieldName += ",SizeID";           //SizeID = 12, 
            tFieldName += ",ColorID";         //ColorID = 13,  


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

        private void frmPurchaseOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtPONo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
        }

        private void txtPONo_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        private void mskVenderCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_GL2();
            }
        }

        private void mskVenderCode_DoubleClick(object sender, EventArgs e)
        {
            LookUp_GL2();
        }

        private void mskPurchaseCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_GL1();
            }
        }

        private void mskPurchaseCode_DoubleClick(object sender, EventArgs e)
        {
            LookUp_GL1();
        }

        private void txt_I_ItemID_MouseDoubleClick(object sender, MouseEventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {

            grd.Rows.Add(txt_I_ItemID.Text.ToString(),     //ItemID = 0,
                lbl_I_ItemCode.Text.ToString(),            //ItemCode = 1, 
                lbl_I_ItemName.Text.ToString(),            //ItemName = 2, 
                cbo_I_Size.Text.ToString(),                //SizeName = 3, 
                cbo_I_Color.Text.ToString(),               //ColorName = 4,
                txtStock.Text.ToString(),                  //Stock = 6,  
                txtDNQty.Text.ToString(),                  //DNQty = 7,
                txtPOQty.Text.ToString(),                  //POQty = 8,
                txtRemQty.Text.ToString(),                 //RemQty = 9,
                txtLastRate.Text.ToString(),               //LastRate = 10,
                txtAmount.Text.ToString(),                 //Amount = 11,
                cbo_I_Size.SelectedValue.ToString(),       //UOMID = 14,
                cbo_I_Color.SelectedValue.ToString());

            SumVoc();

        }

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
            //
            //select doc_id, doc_strid, doc_date, doc_remarks, doc_amt 
            //from gl_tran
            //where doc_vt_id=1 and doc_fiscal_id=1

            //SELECT d.Ord_No, d.Cont_No, d.Ord_Date, h.Name AS CustName, d.Qty, d.Amount, d.Category
            //FROM Ord_Det d INNER JOIN Heads h ON d.Customer=h.Code
            //WHERE d.Category = 1

            frmLookUp sForm = new frmLookUp(
                    "d.DNId",
                    "d.Date, ig.cgdDesc AS ItemGroupName, pd.department_name, "
                    + "pe.first_name + ' ' + pe.last_name AS EmpName, d.Note ",
                    "DN d INNER JOIN CatDtl ig ON d.ItemGroupId=ig.cgdCode AND ig.cgCode=6 "
                    + "INNER JOIN PR_Department pd ON d.DepartmentId=pd.departmentid "
                    + "INNER JOIN PR_Employee pe ON d.EmployeeId=pe.employeeid",
                    this.Text.ToString(),
                    1,
                    "DN#,Date,Item Group Name,Department Name,Employee Name,Note ",
                    "10,8,12,12,12,15",
                    " T, T, T, T, T, T",
                    true,
                    "",
                //"d.Category = " + cboMainGroup.SelectedValue.ToString(), 
                    "",
                    "TextBox"
                    );

            txtDNNo.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID1);
            sForm.ShowDialog();

            if (txtDNNo.Text != null)
            {
                if (txtDNNo.Text != null)
                {
                    if (txtDNNo.Text.ToString() == "" || txtDNNo.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtDNNo.Text.ToString().Trim().Length > 0)
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

        private void PassDataVocID1(object sender)
        {
            //txtPassDataVocID.Text = ((TextBox)sender).Text;
            txtDNNo.Text = ((TextBox)sender).Text;
            //msk_VocCode.Text = ((MaskedTextBox)sender).Text;
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
                    "Code, Purchaser Name",
                    "16,40",
                    " T, T",
                    true,
                    "",
                    " Type='A'",
                    "TextBox"
                    );

            mskPurchaseCode.Mask = "";
            mskPurchaseCode.Text = string.Empty;
            mskPurchaseCode.Mask = clsGVar.maskGLCode;

            sForm.lupassControl = new frmLookUp.LUPassControl(PassData1);
            sForm.ShowDialog();
            if (mskPurchaseCode.Text != null)
            {
                if (mskPurchaseCode.Text != null)
                {
                    if (mskPurchaseCode.Text.ToString() == "" || mskPurchaseCode.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (mskPurchaseCode.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecordsGL1();
                        //LoadSampleData();
                    }


                }


            }
        }

        private void PassData1(object sender)
        {
            mskPurchaseCode.Mask = "";
            mskPurchaseCode.Text = ((TextBox)sender).Text;
            mskPurchaseCode.Mask = clsGVar.maskGLCode;

        }
        //Populate Recordset 
        private void PopulateRecordsGL1()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  

            tSQL = "SELECT Code, Name ";
            tSQL += " from Heads ";
            tSQL += " where Code ='" + mskPurchaseCode.Text.ToString() + "';";

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
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }

        #region PopulateRecords1
        //Populate Recordset 
        private void PopulateRecords1()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  

            tSQL = "SELECT d.DNId, d.Date, d.ItemGroupId, ig.cgdDesc AS ItemGroupName, ";
            tSQL += " d.DepartmentId, pd.department_name, ";
            tSQL += " d.EmployeeId, pe.first_name + ' ' + pe.last_name AS EmpName, d.Note ";
            tSQL += " FROM DN d INNER JOIN CatDtl ig ON d.ItemGroupId=ig.cgdCode AND ig.cgCode=6";
            tSQL += " INNER JOIN PR_Department pd ON d.DepartmentId=pd.departmentid";
            tSQL += " INNER JOIN PR_Employee pe ON d.EmployeeId=pe.employeeid";
            tSQL += " where d.DNId='" + txtDNNo.Text.ToString() + "';";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "DN");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    txtDNNo.Text = (ds.Tables[0].Rows[0]["DNId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DNId"].ToString());

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                        //btn_EnableDisable(true);
                    }
                    //PopulateGridData();
                    LoadGridData();
                    //txtManualDoc.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Order No...", this.Text.ToString());
            }
        }
        #endregion

        private void txtDemandNote_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc1();
        }

        private void txtDNNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc1();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
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


        private void PassDataVocID2(object sender)
        {
            //txtPassDataVocID.Text = ((TextBox)sender).Text;
            txtDNNo.Text = ((TextBox)sender).Text;
            //msk_VocCode.Text = ((MaskedTextBox)sender).Text;
        }

        private void LookUp_GL2()
        {

                    //select VendorId, v.Name AS VendorName 
                    //from PO po
                    //INNER JOIN Vendor v ON v.Code = RIGHT(po.VendorId, 7)
            frmLookUp sForm = new frmLookUp(
                    "po.VendorId",
                    "v.Name",
                    "PO po INNER JOIN Vendor v ON v.Code = RIGHT(po.VendorId, 7)",
                    this.Text.ToString(),
                    1,
                    "Code, Vendor Name",
                    "16,40",
                    " T, T",
                    true,
                    "",
                    "",
                    "TextBox"
                    );

            mskVenderCode.Mask = "";
            mskVenderCode.Text = string.Empty;
            mskVenderCode.Mask = clsGVar.maskGLCode;

            sForm.lupassControl = new frmLookUp.LUPassControl(PassData2);
            sForm.ShowDialog();
            if (mskVenderCode.Text != null)
            {
                if (mskVenderCode.Text != null)
                {
                    if (mskVenderCode.Text.ToString() == "" || mskVenderCode.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (mskVenderCode.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecordsGL2();
                        //LoadSampleData();
                    }


                }


            }
        }

        private void PassData2(object sender)
        {
            mskVenderCode.Mask = "";
            mskVenderCode.Text = ((TextBox)sender).Text;
            mskVenderCode.Mask = clsGVar.maskGLCode;

        }
        //Populate Recordset 
        private void PopulateRecordsGL2()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  

               tSQL =  " SELECT po.VendorId, v.Name ";
               tSQL += " from PO po  INNER JOIN Vendor v ON v.Code = RIGHT(po.VendorId, 7) ";
               tSQL += " where po.VendorId ='" + mskVenderCode.Text.ToString() + "';";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Vendor");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    lblNameVendor.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                        //btn_EnableDisable(true);
                    }
                    //LoadGridData();
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }

        

    }
}