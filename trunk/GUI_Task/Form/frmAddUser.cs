using System;
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
    public partial class frmAddUser : Form
    {

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

        int strDocId = 0;

        public frmAddUser()
        {
            InitializeComponent();
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                SaveData();
                MessageBox.Show("User Added Successfullly");
            }

            else if ((txtUserName.Text == "") || (txtConfirmPassword.Text == ""))
            {
                MessageBox.Show("Validation Error, Please Revise the Credientials");
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
                        fLastID = txtUserID.Text.ToString();
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
                if (txtUserID.Text.ToString().Trim(' ', '-') == "")
                {
                    fDocAlreadyExists = false;
                    fDocID = clsDbManager.GetNextValDocID("Users", "UserId", fDocWhere, "");
                    //strDocId = "1-" + DateTime.Now.Year.ToString() + fDocID.ToString();
                    //txtUserID.Text = strDocId;
                    fDocID += fDocID;

                    lSQL = "insert into Users (";
                    lSQL += " UserID ";
                    lSQL += ", UserName ";
                    lSQL += ", Password ";
                    lSQL += ", Status ";                                 
                    lSQL += " ) values (";
                    //                                                       
                    lSQL += fDocID.ToString();
                    lSQL += "" + txtUserID.Text + "";
                    lSQL += ",'" + txtUserName.Text.ToString() + "'";
                    lSQL += ",'" + txtPassword.Text.ToString() + "'";
                    lSQL += ", " + (optActive.Checked == true ? 1 : 2).ToString() + "";
                    lSQL += ")";

                    fManySQL.Add(lSQL);    
                }                                                           
                else
                {
                    fDocWhere = " UserID = '" + txtUserID.Text.ToString() + "'";
                    if (clsDbManager.IDAlreadyExistWw("Users", "UserID", fDocWhere))
                    {
                        fDocAlreadyExists = true;
                    }

                    lSQL =  " update Users set";
                    lSQL += " UserName = '" + txtUserName.Text.ToString() + "'";
                    lSQL += ", Password = '" + txtPassword.Text.ToString() + "'";
                    lSQL += ", Status = " + (optActive.Checked == true ? 1 : 2).ToString() + "";
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

        private void frmAddUser_KeyDown(object sender, KeyEventArgs e)
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

                    "UserID ",
                    "UserName",
                    " Users",
                    this.Text.ToString(),
                    1,
                    "ID, UserName",
                    "8, 15",
                    "T, T",
                    true,
                    "ORDER BY UserName",
                    "",
                    "TextBox"
                    );

            txtUserID.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID);
            sForm.ShowDialog();

            if (txtUserID.Text != null)
            {
                if (txtUserID.Text != null)
                {
                    if (txtUserID.Text.ToString() == "" || txtUserID.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtUserID.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecords();
                    }

                }

            }
        }
        #endregion

        private void PassDataVocID(object sender)
        {
            txtUserID.Text = ((TextBox)sender).Text;
        }

        private void PopulateRecords()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin 

            //select cgdDesc AS BloodGroup
            //from CatDtl
            //where cgCode = 6

            tSQL += " select UserID, UserName, Status";
            tSQL += " from Users where UserID = " + txtUserID.Text.ToString();
            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Users");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    txtUserID.Text = (ds.Tables[0].Rows[0]["UserID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["UserID"].ToString());
                    txtUserName.Text = (ds.Tables[0].Rows[0]["UserName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["UserName"].ToString());

                    if (ds.Tables[0].Rows[0]["Status"].Equals(1))
                    {
                        optActive.Checked = true;
                    }
                    else
                    {
                        optInActive.Checked = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }
        private void txtUserName_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        private void txtUserName_DoubleClick_1(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
        }
    }
}
