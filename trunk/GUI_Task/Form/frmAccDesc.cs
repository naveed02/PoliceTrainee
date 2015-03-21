using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI_Task.StringFun01;
using System.Net.Mail;

namespace GUI_Task
{
    public partial class frmAccDesc : Form
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
        string strDocId = string.Empty;
        bool fSingleEntryAllowed = true;            // for the time being later set to false.
        bool fDocAlreadyExists = false;             // Check if Doc/voucher already exists (Edit Mode = True, New Mode = false)
        bool fIDConfirmed = false;                  // Account ID is valid and existance in Table is confirmed.
        bool fCellEditMode = false;                 // Cell Edit Mode

        bool blnFormLoad = true;
        int fcboDefaultValue = 0;
        public frmAccDesc()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAccDesc_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MaximizeBox = false;
           // blnFormLoad = false;
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
                    "Account Code, Account Name",
                    "16,40",
                    " T, T",
                    true,
                    "",
                    " Type='A'",
                    "TextBox"
                    );

            mskAccCode.Mask = "";
            mskAccCode.Text = string.Empty;
            mskAccCode.Mask = clsGVar.maskGLCode;

            sForm.lupassControl = new frmLookUp.LUPassControl(PassData);
            sForm.ShowDialog();
            if (mskAccCode.Text != null)
            {
                if (mskAccCode.Text != null)
                {
                    if (mskAccCode.Text.ToString() == "" || mskAccCode.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (mskAccCode.Text.ToString().Trim().Length > 0)
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
            mskAccCode.Mask = "";
            mskAccCode.Text = ((TextBox)sender).Text;
            mskAccCode.Mask = clsGVar.maskGLCode;
            //mskAccCode.Text = ((MaskedTextBox)sender).Text;
            //mskAccCode.Mask = clsGVar.maskGLCode;

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
            tSQL += " where Code ='" + mskAccCode.Text.ToString() + "';";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Heads");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    txtName.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());
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



        private void frmAccDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void mskAccCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            LookUp_GL();
 
        }

        private void mskAccCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_GL();
            }

        }

        private void optGroup_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            textAlert.Text = "Data Saved Successfully";
            this.notifyIcon1.BalloonTipText = "Account Number '" + mskAccCode.Text.ToString() + "'";
            this.notifyIcon1.BalloonTipTitle = "Data Saved";
            //this.notifyIcon1.Icon = new Icon("icon.ico");
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.ShowBalloonTip(5);
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

                if (mskAccCode.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    fDocID = clsDbManager.GetNextValDocID("Heads", "DocId", fDocWhere, "");
                    strDocId = "1-" + DateTime.Now.Year.ToString() + fDocID.ToString();
                    mskAccCode.Text = strDocId;
                    fDocID += fDocID;

                    lSQL = "insert into Heads (";
                    lSQL += "  DocId ";
                    lSQL += ", Code "; //  0-    ItemID";   
                    lSQL += ", Name ";
                                                     // 10    ColorID"  
                    lSQL += " ) values (";
                    //fDocID.ToString()
                    //                                                       
                    lSQL += fDocID.ToString();
                    lSQL += ",'" + strDocId.ToString() + "'";                 //  0-    ItemID";   
                    lSQL += ", '" + txtName.Text.ToString() + "'";        //  1-    ItemCod  
                                                         // 10    ColorID"  
                    lSQL += ")";                                              // 11    UOMID"; 
                }                                                               // 12- GodownID
                else
                {
                    fDocWhere = " Code = '" + mskAccCode.Text.ToString() + "'";
                    if (clsDbManager.IDAlreadyExistWw("Heads", "Code", fDocWhere))
                    {

                        fDocAlreadyExists = true;
                        lSQL = "delete from  Heads";
                        lSQL += " where " + fDocWhere;

                        fManySQL.Add(lSQL);
                        //    //

                    }
                    lSQL = "update Heads set";
                    lSQL += "  Name = '" + txtName.Text.ToString() + "'";
                 
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
                        fLastID = mskAccCode.Text.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            //smtp.Text = "smtp.gmail.com";
            MailMessage mail = new MailMessage("usama.naveed.hussain@gmail.com", "usama.naveed.hussain@gmail.com", "Data Saved0", "Data Saved against Account Number: " + mskAccCode.Text.ToString());
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


            //catch (Exception ex)
            //{
            //    MessageBox.Show("Exception Processing Save: " + ex.Message, "Save Data: " + this.Text.ToString());
            //    return false;
            //}

        } // End Save


  
    }

