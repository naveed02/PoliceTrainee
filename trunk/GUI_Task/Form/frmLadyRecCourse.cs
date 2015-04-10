using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using GUI_Task.StringFun01;
using GUI_Task.PrintReport;
using GUI_Task.PrintVw6;

namespace GUI_Task
{
    public partial class frmLadyRecCourse : Form
    {
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

        // Check if Form is edited or not
        bool isEdited = false;

        int strDocId = 0;

        public frmLadyRecCourse()
        {
            InitializeComponent();
        }

        private void AtFormLoad()
        {
            string lSQL = string.Empty;

            // SettingGridVariable();
            //   LoadInitialControls();

            this.KeyPreview = true;

            //Course Selection Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode= 8 AND Status = 1";
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboCourseSelection, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboCourseSelection.SelectedValue);

            //Batch Name Combo Fill
            lSQL = " select BatchID ,BatchName from Batches Where CourseID = " + cboCourseSelection.SelectedValue.ToString() + " AND Status = 1 ";
            lSQL += " order by BatchName ";

            clsFillCombo.FillCombo(cboBatchName, clsGVar.ConString1, "Batches" + "," + "BatchID" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboBatchName.SelectedValue);

            //Gender Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode= 1";
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboGender, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboGender.SelectedValue);

            //Rank Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode= 4 AND Status = 1";
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboRank, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboRank.SelectedValue);

            //AppRank Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode= 14 AND Status = 1";
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboAppRank, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboAppRank.SelectedValue);

            //District Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode= 2 AND Status = 1";
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboDistrict, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboDistrict.SelectedValue);

            //Education Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode= 5 AND Status = 1";
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboEducation, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboEducation.SelectedValue);

            //BloodGroup Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode= 6 AND Status = 1";
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboBloodGrp, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboBloodGrp.SelectedValue);

            //Martial Status Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode= 7";
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboMartialStat, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboMartialStat.SelectedValue);
        }


        private void frmLadyRecruitCourse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            else if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.S))
            {
                SaveData();
                MessageBox.Show("Data Saved Successfully");
                btnNextRec.Enabled = true;
                btnPrevRec.Enabled = true;
            }

            else if (e.KeyCode == Keys.Right)
            {
               // btnNextRec_Click(sender, e);
            }

            else if (e.KeyCode == Keys.Left)
            {
               // btnPrevRec_Click(sender, e);
            }


        }

        #region LookUp_Voc

        private void LookUp_Voc()
        {
            frmLookUp sForm = new frmLookUp(

                    " distinct l.ID",
                    " CAST(l.CapNo AS INT), l.Name, l.BeltNo, l.CNICNo AS CNIC, l.FatherName, g.cgdDesc, r.cgdDesc, d.cgdDesc, e.cgdDesc, m.cgdDesc, c.cgdDesc, b.BatchName",
                    " RecruitCourse l INNER JOIN CatDtl g ON l.GenderId = g.cgdCode AND g.cgCode = 1 INNER JOIN CatDtl r ON l.RankId = r.cgdCode AND r.cgCode = 4 INNER JOIN CatDtl c ON l.CourseId = c.cgdCode AND c.cgCode = 8 INNER JOIN Batches b ON l.BatchID = b.BatchID INNER JOIN CatDtl d ON l.DistrictId = d.cgdCode AND d.cgCode = 2 INNER JOIN CatDtl e ON l.EducationId = e.cgdCode AND e.cgCode = 5 INNER JOIN CatDtl m ON l.MartialStatusId = m.cgdCode AND m.cgCode = 7  ",
                    this.Text.ToString(),
                    1,
                    "ID,Cap No.,Name,Belt No.,CNIC,Father Name,Gender,Rank,District,Education,MartialStatus,Course,Batch",
                    "8,8,12,8,12,12,5,12,15,8,8,15,15",
                    " T, T, T, T, T, T, T, T, T, T, T, T, T",
                    true,
                    "",
                    "l.BatchID = " + cboBatchName.SelectedValue.ToString() + " AND l.CourseId = " + cboCourseSelection.SelectedValue.ToString(),
                    "TextBox"
                    );

            txtID.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID);
            sForm.ShowDialog();

            if (txtID.Text != null)
            {
                if (txtID.Text != null)
                {
                    if (txtID.Text.ToString() == "" || txtID.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtID.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecords();
                    }

                }

            }
        }
        #endregion

        private void PassDataVocID(object sender)
        {
            txtID.Text = ((TextBox)sender).Text;
        }

        private void PopulateRecords()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin 



            tSQL += " select l.ID, l.Name, l.FatherName AS FName, g.cgdDesc AS GenderName, r.cgdDesc AS RankName, ";
            tSQL += " l.BeltNo, l.CapNo, d.cgdDesc AS DistrictName, l.DOB, l.Education, l.CNICNo, ";
            tSQL += " l.MobileNo AS MobNo,l.DOApp, b.cgdDesc AS Blood, m.cgdDesc AS MartialName, ";
            tSQL += " l.Illness, l.Address,  l.EmergencyContact , c.cgdDesc AS CourseName, ";
            tSQL += " l.CourseDuration AS CourseDur, ";
            tSQL += " l.FromDate AS StartDate, l.ToDate AS EndDate, l.CoursePeriod AS TotalPeriod, ";
            tSQL += " l.Absence, l.Leave, l.ShortLeave AS SLeave, l.CourtApperance AS CourtAppear, ";
            tSQL += " l.OutDoor, l.Indoor, l.LongWeekend AS LWeek, l.ShortWeekend AS SWeek, ";
            tSQL += " l.PunishReward, l.SpecialAss, l.MedicalRest AS MRest, l.PreviousOR, l.Picture, ba.BatchName, ";
            tSQL += " l.isEdu, l.isStartDate, l.isEndDate, l.isDoApp, l.isDOB, l.isRTU, ar.cgdDesc AS AppRank ";
            tSQL += " from RecruitCourse l INNER JOIN CatDtl g ON l.GenderId = g.cgdCode AND g.cgCode = 1 ";
            tSQL += " INNER JOIN CatDtl r ON l.RankId = r.cgdCode AND r.cgCode = 4 INNER JOIN CatDtl d ON l.DistrictId = d.cgdCode AND d.cgCode = 2 ";
            tSQL += " INNER JOIN CatDtl b ON l.BloodGroupId = b.cgdCode AND b.cgCode = 6 ";
            tSQL += " INNER JOIN CatDtl m ON l.MartialStatusId = m.cgdCode AND m.cgCode = 7";
            tSQL += " INNER JOIN CatDtl c ON l.CourseId = c.cgdCode AND c.cgCode = 8 INNER JOIN Batches ba ON l.BatchID = ba.BatchID ";
            tSQL += " INNER JOIN CatDtl ar ON l.AppRankId = ar.cgdCode AND ar.cgCode = 14 ";

            tSQL += " WHERE l.ID = " + txtID.Text.ToString() + "";
            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "RecruitCourse");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    txtID.Text = (ds.Tables[0].Rows[0]["ID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ID"].ToString());
                    txtName.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());
                    txtFName.Text = (ds.Tables[0].Rows[0]["FName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["FName"].ToString());
                    cboGender.Text = (ds.Tables[0].Rows[0]["GenderName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["GenderName"].ToString());
                    cboRank.Text = (ds.Tables[0].Rows[0]["RankName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["RankName"].ToString());
                    txtBeltNo.Text = (ds.Tables[0].Rows[0]["BeltNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BeltNo"].ToString());
                    txtCapNo.Text = (ds.Tables[0].Rows[0]["CapNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CapNo"].ToString());
                    cboDistrict.Text = (ds.Tables[0].Rows[0]["DistrictName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DistrictName"].ToString());
                    dtpDOB.Text = (ds.Tables[0].Rows[0]["DOB"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DOB"].ToString());
                    cboEducation.Text = (ds.Tables[0].Rows[0]["Education"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Education"].ToString());
                    txtCNIC.Text = (ds.Tables[0].Rows[0]["CNICNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CNICNo"].ToString());
                    txtMobileNo.Text = (ds.Tables[0].Rows[0]["MobNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["MobNo"].ToString());
                    dtpAppDate.Text = (ds.Tables[0].Rows[0]["DOApp"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DOApp"].ToString());
                    cboBloodGrp.Text = (ds.Tables[0].Rows[0]["Blood"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Blood"].ToString());
                    cboMartialStat.Text = (ds.Tables[0].Rows[0]["MartialName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["MartialName"].ToString());
                    txtIllness.Text = (ds.Tables[0].Rows[0]["Illness"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Illness"].ToString());
                    txtAddress.Text = (ds.Tables[0].Rows[0]["Address"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Address"].ToString());
                    txtEmergency.Text = (ds.Tables[0].Rows[0]["EmergencyContact"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["EmergencyContact"].ToString());
                    cboBatchName.Text = (ds.Tables[0].Rows[0]["CourseName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CourseName"].ToString());
                    txtCourseDuration.Text = (ds.Tables[0].Rows[0]["CourseDur"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CourseDur"].ToString());
                    dtpStart.Text = (ds.Tables[0].Rows[0]["StartDate"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["StartDate"].ToString());
                    dtpEnd.Text = (ds.Tables[0].Rows[0]["EndDate"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["EndDate"].ToString());
                    txtCoursePeriod.Text = (ds.Tables[0].Rows[0]["TotalPeriod"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["TotalPeriod"].ToString());
                    txtAbsence.Text = (ds.Tables[0].Rows[0]["Absence"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Absence"].ToString());
                    txtLeave.Text = (ds.Tables[0].Rows[0]["Leave"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Leave"].ToString());
                    txtShortLeave.Text = (ds.Tables[0].Rows[0]["SLeave"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["SLeave"].ToString());
                    txtCourtAppear.Text = (ds.Tables[0].Rows[0]["CourtAppear"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CourtAppear"].ToString());
                    txtOutdoor.Text = (ds.Tables[0].Rows[0]["OutDoor"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["OutDoor"].ToString());
                    txtIndoor.Text = (ds.Tables[0].Rows[0]["Indoor"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Indoor"].ToString());
                    txtLWeek.Text = (ds.Tables[0].Rows[0]["LWeek"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["LWeek"].ToString());
                    txtSWeek.Text = (ds.Tables[0].Rows[0]["SWeek"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["SWeek"].ToString());
                    txtPunishReward.Text = (ds.Tables[0].Rows[0]["PunishReward"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["PunishReward"].ToString());
                    txtSpecialAss.Text = (ds.Tables[0].Rows[0]["SpecialAss"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["SpecialAss"].ToString());
                    txtMedicalRest.Text = (ds.Tables[0].Rows[0]["MRest"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["MRest"].ToString());
                    txtPreviousOR.Text = (ds.Tables[0].Rows[0]["PreviousOR"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["PreviousOR"].ToString());
                    cboBatchName.Text = (ds.Tables[0].Rows[0]["BatchName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BatchName"].ToString());
                    cboAppRank.Text = (ds.Tables[0].Rows[0]["AppRank"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["AppRank"].ToString());

                    if (ds.Tables[0].Rows[0]["isEdu"].Equals(1))
                    {
                        chkEducation.Checked = true;
                        cboEducation.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[0]["isEdu"].Equals(0))
                    {
                        chkEducation.Checked = false;
                        cboEducation.Visible = false;
                    }

                    if (ds.Tables[0].Rows[0]["isStartDate"].Equals(1))
                    {
                        chkStartDate.Checked = true;
                        dtpStart.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[0]["isStartDate"].Equals(0))
                    {
                        chkStartDate.Checked = false;
                        dtpStart.Visible = false;
                    }

                    if (ds.Tables[0].Rows[0]["isEndDate"].Equals(1))
                    {
                        chkEndDate.Checked = true;
                        dtpEnd.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[0]["isEndDate"].Equals(0))
                    {
                        chkEndDate.Checked = false;
                        dtpEnd.Visible = false;
                    }

                    if (ds.Tables[0].Rows[0]["isDoApp"].Equals(1))
                    {
                        chkAppDate.Checked = true;
                        dtpAppDate.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[0]["isDoApp"].Equals(0))
                    {
                        chkAppDate.Checked = false;
                        dtpAppDate.Visible = false;
                    }

                    if (ds.Tables[0].Rows[0]["isDOB"].Equals(1))
                    {
                        chkDOB.Checked = true;
                        dtpDOB.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[0]["isDOB"].Equals(0))
                    {
                        chkDOB.Checked = false;
                        dtpDOB.Visible = false;
                    }

                    if (ds.Tables[0].Rows[0]["isRTU"].Equals(1))
                    {
                        chkRTU.Checked = true;
                    }
                    else if (ds.Tables[0].Rows[0]["isRTU"].Equals(0))
                    {
                        chkRTU.Checked = false;
                    }

                    // Sir Shoaib Code for File Streaming

                    //    if (pictureBox1.Image != null)
                    //    {
                    //        pictureBox1.Image.Dispose();
                    //    }
                    //    if (File.Exists("usama.bmp"))
                    //    {
                    //        File.Delete("usama.bmp");
                    //    }
                    //    //Initialize a file stream to write image data
                    //    FileStream fs = new FileStream("usama.bmp", FileMode.Create, FileAccess.Write, FileShare.Write);

                    //    if (ds.Tables[0].Rows[0]["Picture"] != DBNull.Value)
                    //    {
                    //        byte[] blob = (byte[])ds.Tables[0].Rows[0]["Picture"];

                    //        //Write data in image file using file stream
                    //        fs.Write(blob, 0, blob.Length);
                    //        fs.Close();
                    //        fs.Dispose();
                    //        //fs = null;

                    //        pictureBox1.Image = Image.FromFile("usama.bmp");
                    //        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    //        pictureBox1.Refresh();

                    //    }
                    //    else
                    //    {
                    //        //pbPic.Image = Image.FromFile("Checkin.jpg");

                    //        pictureBox1.Image = imageList1.Images[0];
                    //        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    //        pictureBox1.Refresh();
                    //    }
                    //    fs.Close();
                    //    fs.Dispose();
                    //    if (File.Exists("PunjabPoliceLogo.jpg"))
                    //    {
                    //        File.Delete("PunjabPoliceLogo.jpg");
                    //    }
                    //}

                    // Sir Shoaib Code for Memory Streaming

                    pictureBox1.Image = imageList1.Images[0];
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Refresh();


                    if (ds.Tables[0].Rows[0]["Picture"] != DBNull.Value)
                    {
                        Byte[] byteBLOBData = new Byte[0];
                        byteBLOBData = (Byte[])ds.Tables[0].Rows[0]["Picture"];
                        //  byteBLOBData = (Byte[])(ds.Tables["LadyRecruitCourse"].Rows[c - 1]["Picture"]);

                        MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                        pictureBox1.Image = Image.FromStream(stmBLOBData);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Refresh();

                        byteBLOBData = null;
                        stmBLOBData.Close();
                        stmBLOBData.Dispose();
                        //lblMsg.Text = "File read from the database successfully.";
                    }
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Clear();
                }

                btnInsert.Enabled = true;
                btnRemove.Enabled = true;
            }


            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }

            else if (e.KeyCode == Keys.Right)
            {
                btnNextRec_Click(sender, e);
            }

            else if (e.KeyCode == Keys.Left)
            {
                btnPrevRec_Click(sender, e);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LookUp_Voc();
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

            //func = (test) =>
            //    {
            //        foreach (Control controlTest in test)
            //            if (controlTest is ComboBox)
            //                (controlTest as ComboBox).ResetText();
            //            else
            //                func(controlTest.Controls);
            //    };

            //func(Controls);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            btnInsert.Enabled = false;
            btnRemove.Enabled = false;

            Action<Control.ControlCollection> func4 = null;

            func4 = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Enabled = true;
                    else if (control is CheckBox)
                        (control as CheckBox).Enabled = true;
                    else if (control is ComboBox)
                        (control as ComboBox).Enabled = true;
                    else if (control is DateTimePicker)
                        (control as DateTimePicker).Enabled = true;
                    else
                        func4(control.Controls);
            };

            func4(Controls);

            btnSave.Enabled = true;
            btnNextRec.Enabled = false;
            btnPrevRec.Enabled = false;
            btnDelete.Enabled = false;
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
                        fLastID = txtID.Text.ToString();
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

        private void ImageInsert()
        {

        }

        private bool PrepareDocMaster()
        {
            bool rtnValue = true;
            string lSQL = string.Empty;

            try
            {
                if (txtID.Text.ToString().Trim(' ', '-') == "")
                {
                    strDocId = 0;
                    fDocAlreadyExists = false;
                    //fDocID = fDocID + 1;
                    txtID.Text = fDocID.ToString();
                    fDocID = clsDbManager.GetNextValDocID("RecruitCourse", "ID", fDocWhere, "");
                    fDocID = fDocID + 1;

                    lSQL = "insert into RecruitCourse (";
                    lSQL += " ID ";
                    lSQL += ", Name ";
                    lSQL += ", FatherName ";
                    lSQL += ", BeltNo ";
                    lSQL += ", CapNo ";
                    lSQL += ", DOB ";
                    lSQL += ", CNICNo ";
                    lSQL += ", MobileNo ";
                    lSQL += ", DOApp ";
                    lSQL += ", Illness ";
                    lSQL += ", Address ";
                    lSQL += ", EmergencyContact ";
                    lSQL += ", CourseDuration ";
                    lSQL += ", FromDate ";
                    lSQL += ", ToDate ";
                    lSQL += ", CoursePeriod ";
                    lSQL += ", Absence ";
                    lSQL += ", Leave ";
                    lSQL += ", LongWeekend ";
                    lSQL += ", ShortWeekend ";
                    lSQL += ", ShortLeave ";
                    lSQL += ", CourtApperance ";
                    lSQL += ", Outdoor ";
                    lSQL += ", Indoor ";
                    lSQL += ", MedicalRest ";
                    lSQL += ", PunishReward ";
                    lSQL += ", SpecialAss ";
                    lSQL += ", GenderId ";
                    lSQL += ", RankId ";
                    lSQL += ", DistrictId ";
                    lSQL += ", BloodGroupId ";
                    lSQL += ", MartialStatusId ";
                    lSQL += ", EducationId ";
                    lSQL += ", CourseId ";
                    lSQL += ", PreviousOR";
                    lSQL += ", BatchID";
                    lSQL += ", isEdu";
                    lSQL += ", isStartDate";
                    lSQL += ", isEndDate";
                    lSQL += ", isDoApp";
                    lSQL += ", isDOB";
                    lSQL += ", AppRankId";
                    lSQL += ", isRTU";
                    lSQL += " ) values (";
                    //                                                       
                    lSQL += "" + fDocID.ToString() + "";
                    lSQL += ",'" + txtName.Text.ToString() + "'";
                    lSQL += ",'" + txtFName.Text.ToString() + "'";
                    lSQL += ",'" + txtBeltNo.Text.ToString() + "'";
                    lSQL += ",'" + txtCapNo.Text.ToString() + "'";
                    lSQL += ", " + StrF01.D2Str(dtpDOB) + "";
                    lSQL += ",'" + txtCNIC.Text.ToString() + "'";
                    lSQL += ",'" + txtMobileNo.Text.ToString() + "'";
                    lSQL += ", " + StrF01.D2Str(dtpAppDate) + "";
                    lSQL += ",'" + txtIllness.Text.ToString() + "'";
                    lSQL += ",'" + txtAddress.Text.ToString() + "'";
                    lSQL += ",'" + txtEmergency.Text.ToString() + "'";
                    lSQL += ",'" + txtCourseDuration.Text.ToString() + "'";
                    lSQL += ", " + StrF01.D2Str(dtpStart) + "";
                    lSQL += ", " + StrF01.D2Str(dtpEnd) + "";
                    lSQL += ",'" + txtCoursePeriod.Text.ToString() + "'";
                    lSQL += ",'" + txtAbsence.Text.ToString() + "'";
                    lSQL += ",'" + txtLeave.Text.ToString() + "'";
                    lSQL += ",'" + txtLWeek.Text.ToString() + "'";
                    lSQL += ",'" + txtSWeek.Text.ToString() + "'";
                    lSQL += ",'" + txtShortLeave.Text.ToString() + "'";
                    lSQL += ",'" + txtCourtAppear.Text.ToString() + "'";
                    lSQL += ",'" + txtOutdoor.Text.ToString() + "'";
                    lSQL += ",'" + txtIndoor.Text.ToString() + "'";
                    lSQL += ",'" + txtMedicalRest.Text.ToString() + "'";
                    lSQL += ",'" + txtPunishReward.Text.ToString() + "'";
                    lSQL += ",'" + txtSpecialAss.Text.ToString() + "'";
                    lSQL += ", " + cboGender.SelectedValue.ToString() + "";
                    lSQL += ", " + cboRank.SelectedValue.ToString() + "";
                    lSQL += ", " + cboDistrict.SelectedValue.ToString() + "";
                    lSQL += ", " + cboBloodGrp.SelectedValue.ToString() + "";
                    lSQL += ", " + cboMartialStat.SelectedValue.ToString() + "";
                    lSQL += ", " + cboEducation.SelectedValue.ToString() + "";
                    lSQL += ", " + cboCourseSelection.SelectedValue.ToString() + "";
                    lSQL += ",'" + txtPreviousOR.Text.ToString() + "'";
                    lSQL += ", " + cboBatchName.SelectedValue.ToString() + "";
                    lSQL += ", " + (chkEducation.Checked == true ? 1 : 0);
                    lSQL += ", " + (chkStartDate.Checked == true ? 1 : 0);
                    lSQL += ", " + (chkEndDate.Checked == true ? 1 : 0);
                    lSQL += ", " + (chkAppDate.Checked == true ? 1 : 0);
                    lSQL += ", " + (chkDOB.Checked == true ? 1 : 0);
                    lSQL += ", " + cboAppRank.SelectedValue.ToString() + "";
                    lSQL += ", " + (chkRTU.Checked == true ? 1 : 0);
                    lSQL += ")";

                    fManySQL.Add(lSQL);
                }
                else
                {
                    fDocWhere = " ID = " + txtID.Text.ToString() + "";
                    if (clsDbManager.IDAlreadyExistWw("RecruitCourse", "ID", fDocWhere))
                    {
                        fDocAlreadyExists = true;
                        //fManySQL.Add(lSQL);
                    }

                    lSQL = "update RecruitCourse set";

                    lSQL += "  Name = '" + txtName.Text.ToString() + "'";
                    lSQL += ", FatherName = '" + txtFName.Text.ToString() + "'";
                    lSQL += ", BeltNo = '" + txtBeltNo.Text.ToString() + "'";
                    lSQL += ", CapNo = '" + txtCapNo.Text.ToString() + "'";
                    lSQL += ", DOB = " + StrF01.D2Str(dtpDOB) + "";
                    lSQL += ", Education = '" + cboEducation.Text.ToString() + "'";
                    lSQL += ", CNICNo = '" + txtCNIC.Text.ToString() + "'";
                    lSQL += ", MobileNo = '" + txtMobileNo.Text.ToString() + "'";
                    lSQL += ", DOApp = " + StrF01.D2Str(dtpAppDate) + "";
                    lSQL += ", Illness = '" + txtIllness.Text.ToString() + "'";
                    lSQL += ", Address = '" + txtAddress.Text.ToString() + "'";
                    lSQL += ", EmergencyContact = '" + txtEmergency.Text.ToString() + "'";
                    lSQL += ", CourseDuration = '" + txtCourseDuration.Text.ToString() + "'";
                    lSQL += ", FromDate = " + StrF01.D2Str(dtpStart) + "";
                    lSQL += ", ToDate = " + StrF01.D2Str(dtpEnd) + "";
                    lSQL += ", CoursePeriod = '" + txtCoursePeriod.Text.ToString() + "'";
                    lSQL += ", Absence =         '" + txtAbsence.Text.ToString() + "'";
                    lSQL += ", Leave =           '" + txtLeave.Text.ToString() + "'";
                    lSQL += ", LongWeekend =     '" + txtLWeek.Text.ToString() + "'";
                    lSQL += ", ShortWeekend =    '" + txtSWeek.Text.ToString() + "'";
                    lSQL += ", ShortLeave =     '" + txtShortLeave.Text.ToString() + "'";
                    lSQL += ", CourtApperance = '" + txtCourtAppear.Text.ToString() + "'";
                    lSQL += ", Outdoor =         '" + txtOutdoor.Text.ToString() + "'";
                    lSQL += ", Indoor =          '" + txtIndoor.Text.ToString() + "'";
                    lSQL += ", MedicalRest =    '" + txtMedicalRest.Text.ToString() + "'";
                    lSQL += ", PunishReward = '" + txtPunishReward.Text.ToString() + "'";
                    lSQL += ", SpecialAss = '" + txtSpecialAss.Text.ToString() + "'";
                    lSQL += ", GenderId = " + cboGender.SelectedValue.ToString() + "";
                    lSQL += ", RankId = " + cboRank.SelectedValue.ToString() + "";
                    lSQL += ", DistrictId = " + cboDistrict.SelectedValue.ToString() + "";
                    lSQL += ", BloodGroupId = " + cboBloodGrp.SelectedValue.ToString() + "";
                    lSQL += ", MartialStatusId = " + cboMartialStat.SelectedValue.ToString() + "";
                    lSQL += ", CourseId = " + cboCourseSelection.SelectedValue.ToString() + "";
                    lSQL += ", EducationId = " + cboEducation.SelectedValue.ToString() + "";
                    lSQL += ", PreviousOR = '" + txtPreviousOR.Text.ToString() + "'";
                    lSQL += ", BatchID = " + cboBatchName.SelectedValue.ToString() + "";
                    lSQL += ", isEdu = " + (chkEducation.Checked == true ? 1 : 0);
                    lSQL += ", isStartDate = " + (chkStartDate.Checked == true ? 1 : 0);
                    lSQL += ", isEndDate = " + (chkEndDate.Checked == true ? 1 : 0);
                    lSQL += ", isDoApp = " + (chkAppDate.Checked == true ? 1 : 0);
                    lSQL += ", isDOB = " + (chkDOB.Checked == true ? 1 : 0);
                    lSQL += ", AppRankId = " + cboAppRank.SelectedValue.ToString() + "";
                    lSQL += ", isRTU = " + (chkRTU.Checked == true ? 1 : 0);
                    lSQL += " where ";
                    lSQL += fDocWhere;

                    fManySQL.Add(lSQL);
                }

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
            btnNextRec.Enabled = true;
            btnPrevRec.Enabled = true;
        }

        byte[] convertToByte(string sourcePath)
        {
            //get the byte file size of picture
            FileInfo fInfo = new FileInfo(sourcePath);
            long sizeByte = fInfo.Length;

            //Read the file using File stream
            FileStream fs = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);

            // Read it again as byte using binary reader
            BinaryReader br = new BinaryReader(fs);

            //convert the picture to byte already
            byte[] data = br.ReadBytes((int)sizeByte);

            return data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileChooser = new OpenFileDialog();
            //fileChooser.Filter = "image files (*.jpg)|*.jpg|All files (*.*)|*.*";
            fileChooser.Filter = "image files All files (*.*)|*.*";
            fileChooser.InitialDirectory = "D:\\Pictures";
            fileChooser.Title = "Select Image";
            if (fileChooser.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = fileChooser.FileName;
            }

            SqlConnection con = new SqlConnection(clsGVar.ConString1);

            if (pictureBox1.ImageLocation != null)
            {
                byte[] imgData;
                imgData = File.ReadAllBytes(pictureBox1.ImageLocation);

                //if(cboCourseSelection.SelectedValue.ToString() == "1")
                //{
                SqlCommand cmd = new SqlCommand("UPDATE RecruitCourse SET Picture = @DATA WHERE ID = " + txtID.Text.ToString() + " AND BatchID = " + cboBatchName.SelectedValue.ToString(), con);
                cmd.Parameters.Add("@DATA", imgData);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            string fRptTitle = this.Text;
            string plstField = "@ID";
            string plstType = "8"; // {"8, 8, 8, 8, 8, 8"};
            string plstValue = this.txtID.Text;

            DataSet pDs = new DataSet();
            CrReport rpt1 = new CrReport();

            frmPrintVw6 rptLedger2 = new frmPrintVw6(
               fRptTitle,
               "",
               "",
                //StrF01.D2Str(this.dtpFromDate.Value),
                //StrF01.D2Str(this.dtpToDate.Value),
               "sp_Report",
               plstField,
               plstType,
               plstValue,
               pDs,
               rpt1,
               "SP"
               );

            //rptLedger2.ShowDialog();
            rptLedger2.Show();
        }

        private void frmLadyRecruitCourse_Load(object sender, EventArgs e)
        {
            AtFormLoad();
            this.MaximizeBox = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(clsGVar.ConString1);

            SqlCommand cmd = new SqlCommand("UPDATE RecruitCourse SET Picture = NULL WHERE ID = " + txtID.Text.ToString(), con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            pictureBox1.Image = null;
        }

        private void btnDetailedReport_Click(object sender, EventArgs e)
        {
            //if (cboCourseSelection.SelectedValue.ToString() == "1")
            //{
            string fRptTitle = this.Text;
            string plstField = "@ID,@CourseID,@BatchID";
            string plstType = "8,8,8"; // {"8, 8, 8, 8, 8, 8"};
            string plstValue = "1044," + cboCourseSelection.SelectedValue.ToString() + "," + cboBatchName.SelectedValue.ToString();
            //this.mskAccCode.Text + "," + StrF01.D2Str(this.dtpFromDate.Value) + "," +
            //  StrF01.D2Str(this.dtpToDate.Value);

            //dsLedgerNew pDs = new dsLedgerNew();

            DataSet pDs = new DataSet();
            CrReport rpt1 = new CrReport();

            frmPrintVw6 rptLedger2 = new frmPrintVw6(
               fRptTitle,
               "",
               "",
                //StrF01.D2Str(this.dtpFromDate.Value),
                //StrF01.D2Str(this.dtpToDate.Value),
               "sp_DetailedReport",
               plstField,
               plstType,
               plstValue,
               pDs,
               rpt1,
               "SP"
               );

            //rptLedger2.ShowDialog();
            rptLedger2.Show();
        }

        private void cboCourseSelection_Click(object sender, EventArgs e)
        {
            string lSQL = string.Empty;

            cboBatchName.Text = "";
            lSQL = " select BatchID ,BatchName from Batches Where CourseID = " + cboCourseSelection.SelectedValue.ToString() + " AND Status = 1 ";
            lSQL += " order by BatchName ";

            clsFillCombo.FillCombo(cboBatchName, clsGVar.ConString1, "Batches" + "," + "BatchID" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboBatchName.SelectedValue);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(clsGVar.ConString1);
            {
                DialogResult dialogResult = MessageBox.Show("Delete ?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM RecruitCourse WHERE ID = " + txtID.Text.ToString() + "AND BatchID = " + cboBatchName.SelectedValue.ToString(), con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ClearTextBoxes();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }

        }

        private void cboCourseSelection_DropDownClosed(object sender, EventArgs e)
        {
            string lSQL = string.Empty;

            cboBatchName.Text = "";
            lSQL = " select BatchID ,BatchName from Batches Where CourseID = " + cboCourseSelection.SelectedValue.ToString() + " AND Status = 1 ";
            lSQL += " order by BatchName ";

            clsFillCombo.FillCombo(cboBatchName, clsGVar.ConString1, "Batches" + "," + "BatchID" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboBatchName.SelectedValue);
        }

        private void chkDOB_Click(object sender, EventArgs e)
        {
            if (chkDOB.Checked == false)
            {
                dtpDOB.Visible = false;
            }

            if (chkDOB.Checked == true)
            {
                dtpDOB.Visible = true;
            }
        }

        private void chkAppDate_Click(object sender, EventArgs e)
        {
            if (chkAppDate.Checked == false)
            {
                dtpAppDate.Visible = false;
                cboAppRank.Visible = false;
            }

            if (chkAppDate.Checked == true)
            {
                dtpAppDate.Visible = true;
                cboAppRank.Visible = true;
            }
        }

        private void chkStartDate_Click(object sender, EventArgs e)
        {
            if (chkStartDate.Checked == false)
            {
                dtpStart.Visible = false;
            }

            if (chkStartDate.Checked == true)
            {
                dtpStart.Visible = true;
            }
        }

        private void chkEndDate_Click(object sender, EventArgs e)
        {
            if (chkEndDate.Checked == false)
            {
                dtpEnd.Visible = false;
            }

            if (chkEndDate.Checked == true)
            {
                dtpEnd.Visible = true;
            }
        }

        private void chkEducation_Click(object sender, EventArgs e)
        {
            if (chkEducation.Checked == false)
            {
                cboEducation.Visible = false;
            }

            if (chkEducation.Checked == true)
            {
                cboEducation.Visible = true;
            }
        }

        int nextRec = 0;

        private void btnNextRec_Click(object sender, EventArgs e)
        {
            Action<Control.ControlCollection> func3 = null;

            func3 = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                    {
                        (control as TextBox).Enabled = true;
                        (control as TextBox).ReadOnly = true;
                        (control as TextBox).BackColor = Color.White;
                    }
                    else if (control is CheckBox)
                    {
                        (control as CheckBox).Enabled = false;
                        (control as CheckBox).BackColor = Color.White;
                    }
                    else if (control is ComboBox)
                    {
                        (control as ComboBox).Enabled = false;
                    }
                    else
                        func3(control.Controls);
            };

            func3(Controls);

            btnSave.Enabled = false;

            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin 

            if (txtID.Text.ToString().Trim(' ', '-') == "")
            {
                nextRec = 1;
            }

            else
            {
                tSQL = "select top 1 CapNo from RecruitCourse where CapNo > " + txtCapNo.Text.ToString() + " AND CourseId = " + cboCourseSelection.SelectedValue.ToString() + " AND BatchID = " + cboBatchName.SelectedValue.ToString() + " ORDER BY CAST(CapNo AS INT)";
                ds = clsDbManager.GetData_Set(tSQL, "RecruitCourse");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    nextRec = Convert.ToInt32(ds.Tables[0].Rows[0]["CapNo"] == DBNull.Value ? "1" : ds.Tables[0].Rows[0]["CapNo"].ToString());
                }
            }

            tSQL = string.Empty;

            tSQL += " select l.ID, l.Name, l.FatherName AS FName, g.cgdDesc AS GenderName, r.cgdDesc AS RankName, ";
            tSQL += " l.BeltNo, CAST(l.CapNo AS INT) AS CapNo, d.cgdDesc AS DistrictName, l.DOB, l.Education, l.CNICNo, ";
            tSQL += " l.MobileNo AS MobNo,l.DOApp, b.cgdDesc AS Blood, m.cgdDesc AS MartialName, ";
            tSQL += " l.Illness, l.Address,  l.EmergencyContact , c.cgdDesc AS CourseName, ";
            tSQL += " l.CourseDuration AS CourseDur, ";
            tSQL += " l.FromDate AS StartDate, l.ToDate AS EndDate, l.CoursePeriod AS TotalPeriod, ";
            tSQL += " l.Absence, l.Leave, l.ShortLeave AS SLeave, l.CourtApperance AS CourtAppear, ";
            tSQL += " l.OutDoor, l.Indoor, l.LongWeekend AS LWeek, l.ShortWeekend AS SWeek, ";
            tSQL += " l.PunishReward, l.SpecialAss, l.MedicalRest AS MRest, l.PreviousOR, l.Picture, ba.BatchName, ";
            tSQL += " l.isEdu, l.isStartDate, l.isEndDate, l.isDoApp, l.isDOB, l.isRTU, ar.cgdDesc AS AppRank ";
            tSQL += " from RecruitCourse l INNER JOIN CatDtl g ON l.GenderId = g.cgdCode AND g.cgCode = 1 ";
            tSQL += " INNER JOIN CatDtl r ON l.RankId = r.cgdCode AND r.cgCode = 4 INNER JOIN CatDtl d ON l.DistrictId = d.cgdCode AND d.cgCode = 2 ";
            tSQL += " INNER JOIN CatDtl b ON l.BloodGroupId = b.cgdCode AND b.cgCode = 6 ";
            tSQL += " INNER JOIN CatDtl m ON l.MartialStatusId = m.cgdCode AND m.cgCode = 7";
            tSQL += " INNER JOIN CatDtl c ON l.CourseId = c.cgdCode AND c.cgCode = 8 INNER JOIN Batches ba ON l.BatchID = ba.BatchID ";
            tSQL += " INNER JOIN CatDtl ar ON l.AppRankId = ar.cgdCode AND ar.cgCode = 14 ";
            tSQL += " WHERE CapNo = " + nextRec.ToString() + " AND l.CourseId = " + cboCourseSelection.SelectedValue.ToString() + " AND l.BatchID = " + cboBatchName.SelectedValue.ToString();
            tSQL += " ORDER BY CapNo ";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "RecruitCourse");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    txtID.Text = (ds.Tables[0].Rows[0]["ID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ID"].ToString());
                    txtName.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());
                    txtFName.Text = (ds.Tables[0].Rows[0]["FName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["FName"].ToString());
                    cboGender.Text = (ds.Tables[0].Rows[0]["GenderName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["GenderName"].ToString());
                    cboRank.Text = (ds.Tables[0].Rows[0]["RankName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["RankName"].ToString());
                    txtBeltNo.Text = (ds.Tables[0].Rows[0]["BeltNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BeltNo"].ToString());
                    txtCapNo.Text = (ds.Tables[0].Rows[0]["CapNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CapNo"].ToString());
                    cboDistrict.Text = (ds.Tables[0].Rows[0]["DistrictName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DistrictName"].ToString());
                    dtpDOB.Text = (ds.Tables[0].Rows[0]["DOB"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DOB"].ToString());
                    cboEducation.Text = (ds.Tables[0].Rows[0]["Education"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Education"].ToString());
                    txtCNIC.Text = (ds.Tables[0].Rows[0]["CNICNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CNICNo"].ToString());
                    txtMobileNo.Text = (ds.Tables[0].Rows[0]["MobNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["MobNo"].ToString());
                    dtpAppDate.Text = (ds.Tables[0].Rows[0]["DOApp"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DOApp"].ToString());
                    cboBloodGrp.Text = (ds.Tables[0].Rows[0]["Blood"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Blood"].ToString());
                    cboMartialStat.Text = (ds.Tables[0].Rows[0]["MartialName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["MartialName"].ToString());
                    txtIllness.Text = (ds.Tables[0].Rows[0]["Illness"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Illness"].ToString());
                    txtAddress.Text = (ds.Tables[0].Rows[0]["Address"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Address"].ToString());
                    txtEmergency.Text = (ds.Tables[0].Rows[0]["EmergencyContact"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["EmergencyContact"].ToString());
                    cboBatchName.Text = (ds.Tables[0].Rows[0]["CourseName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CourseName"].ToString());
                    txtCourseDuration.Text = (ds.Tables[0].Rows[0]["CourseDur"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CourseDur"].ToString());
                    dtpStart.Text = (ds.Tables[0].Rows[0]["StartDate"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["StartDate"].ToString());
                    dtpEnd.Text = (ds.Tables[0].Rows[0]["EndDate"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["EndDate"].ToString());
                    txtCoursePeriod.Text = (ds.Tables[0].Rows[0]["TotalPeriod"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["TotalPeriod"].ToString());
                    txtAbsence.Text = (ds.Tables[0].Rows[0]["Absence"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Absence"].ToString());
                    txtLeave.Text = (ds.Tables[0].Rows[0]["Leave"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Leave"].ToString());
                    txtShortLeave.Text = (ds.Tables[0].Rows[0]["SLeave"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["SLeave"].ToString());
                    txtCourtAppear.Text = (ds.Tables[0].Rows[0]["CourtAppear"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CourtAppear"].ToString());
                    txtOutdoor.Text = (ds.Tables[0].Rows[0]["OutDoor"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["OutDoor"].ToString());
                    txtIndoor.Text = (ds.Tables[0].Rows[0]["Indoor"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Indoor"].ToString());
                    txtLWeek.Text = (ds.Tables[0].Rows[0]["LWeek"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["LWeek"].ToString());
                    txtSWeek.Text = (ds.Tables[0].Rows[0]["SWeek"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["SWeek"].ToString());
                    txtPunishReward.Text = (ds.Tables[0].Rows[0]["PunishReward"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["PunishReward"].ToString());
                    txtSpecialAss.Text = (ds.Tables[0].Rows[0]["SpecialAss"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["SpecialAss"].ToString());
                    txtMedicalRest.Text = (ds.Tables[0].Rows[0]["MRest"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["MRest"].ToString());
                    txtPreviousOR.Text = (ds.Tables[0].Rows[0]["PreviousOR"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["PreviousOR"].ToString());
                    cboBatchName.Text = (ds.Tables[0].Rows[0]["BatchName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BatchName"].ToString());
                    cboAppRank.Text = (ds.Tables[0].Rows[0]["AppRank"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["AppRank"].ToString());

                    if (ds.Tables[0].Rows[0]["isEdu"].Equals(1))
                    {
                        chkEducation.Checked = true;
                        cboEducation.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[0]["isEdu"].Equals(0))
                    {
                        chkEducation.Checked = false;
                        cboEducation.Visible = false;
                    }

                    if (ds.Tables[0].Rows[0]["isStartDate"].Equals(1))
                    {
                        chkStartDate.Checked = true;
                        dtpStart.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[0]["isStartDate"].Equals(0))
                    {
                        chkStartDate.Checked = false;
                        dtpStart.Visible = false;
                    }

                    if (ds.Tables[0].Rows[0]["isEndDate"].Equals(1))
                    {
                        chkEndDate.Checked = true;
                        dtpEnd.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[0]["isEndDate"].Equals(0))
                    {
                        chkEndDate.Checked = false;
                        dtpEnd.Visible = false;
                    }

                    if (ds.Tables[0].Rows[0]["isDoApp"].Equals(1))
                    {
                        chkAppDate.Checked = true;
                        dtpAppDate.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[0]["isDoApp"].Equals(0))
                    {
                        chkAppDate.Checked = false;
                        dtpAppDate.Visible = false;
                    }

                    if (ds.Tables[0].Rows[0]["isDOB"].Equals(1))
                    {
                        chkDOB.Checked = true;
                        dtpDOB.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[0]["isDOB"].Equals(0))
                    {
                        chkDOB.Checked = false;
                        dtpDOB.Visible = false;
                    }
                    
                    if (ds.Tables[0].Rows[0]["isRTU"].Equals(1))
                    {
                        chkRTU.Checked = true;
                    }
                    else if (ds.Tables[0].Rows[0]["isRTU"].Equals(0))
                    {
                        chkRTU.Checked = false;
                    }

                    // Sir Shoaib Code for Memory Streaming

                    pictureBox1.Image = imageList1.Images[0];
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Refresh();


                    if (ds.Tables[0].Rows[0]["Picture"] != DBNull.Value)
                    {
                        Byte[] byteBLOBData = new Byte[0];
                        byteBLOBData = (Byte[])ds.Tables[0].Rows[0]["Picture"];

                        MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                        pictureBox1.Image = Image.FromStream(stmBLOBData);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Refresh();

                        byteBLOBData = null;
                        stmBLOBData.Close();
                        stmBLOBData.Dispose();
                    }
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Clear();
                }

                btnInsert.Enabled = true;
                btnRemove.Enabled = true;
            }

            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }

        int PrevRec = 0;

        private void btnPrevRec_Click(object sender, EventArgs e)
        {
            Action<Control.ControlCollection> func3 = null;

            func3 = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                    {
                        (control as TextBox).Enabled = true;
                        (control as TextBox).ReadOnly = true;
                        (control as TextBox).BackColor = Color.White;
                    }
                    else if (control is CheckBox)
                    {
                        (control as CheckBox).Enabled = false;
                        (control as CheckBox).BackColor = Color.White;
                    }
                    else if (control is ComboBox)
                    {
                        (control as ComboBox).Enabled = false;
                    }
                    else
                        func3(control.Controls);
            };

            func3(Controls);

            btnSave.Enabled = false;
            
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin 

            if (txtID.Text.ToString().Trim(' ', '-') == "")
            {
                MessageBox.Show("Unable to Navigate");
            }

            else
            {
                tSQL = "select top 1 CapNo from RecruitCourse where CapNo < " + txtCapNo.Text.ToString() + " AND CourseId = " + cboCourseSelection.SelectedValue.ToString() + " AND BatchID = " + cboBatchName.SelectedValue.ToString() + " ORDER BY CAST(CapNo AS INT) DESC";
                ds = clsDbManager.GetData_Set(tSQL, "RecruitCourse");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    PrevRec = Convert.ToInt32(ds.Tables[0].Rows[0]["CapNo"] == DBNull.Value ? "1" : ds.Tables[0].Rows[0]["CapNo"].ToString());
                }
            }

            tSQL = string.Empty;

            tSQL += " select l.ID, l.Name, l.FatherName AS FName, g.cgdDesc AS GenderName, r.cgdDesc AS RankName, ";
            tSQL += " l.BeltNo, CAST(l.CapNo AS INT) AS CapNo, d.cgdDesc AS DistrictName, l.DOB, l.Education, l.CNICNo, ";
            tSQL += " l.MobileNo AS MobNo,l.DOApp, b.cgdDesc AS Blood, m.cgdDesc AS MartialName, ";
            tSQL += " l.Illness, l.Address,  l.EmergencyContact , c.cgdDesc AS CourseName, ";
            tSQL += " l.CourseDuration AS CourseDur, ";
            tSQL += " l.FromDate AS StartDate, l.ToDate AS EndDate, l.CoursePeriod AS TotalPeriod, ";
            tSQL += " l.Absence, l.Leave, l.ShortLeave AS SLeave, l.CourtApperance AS CourtAppear, ";
            tSQL += " l.OutDoor, l.Indoor, l.LongWeekend AS LWeek, l.ShortWeekend AS SWeek, ";
            tSQL += " l.PunishReward, l.SpecialAss, l.MedicalRest AS MRest, l.PreviousOR, l.Picture, ba.BatchName, ";
            tSQL += " l.isEdu, l.isStartDate, l.isEndDate, l.isDoApp, l.isDOB, isRTU, ar.cgdDesc AS AppRank ";
            tSQL += " from RecruitCourse l INNER JOIN CatDtl g ON l.GenderId = g.cgdCode AND g.cgCode = 1 ";
            tSQL += " INNER JOIN CatDtl r ON l.RankId = r.cgdCode AND r.cgCode = 4 INNER JOIN CatDtl d ON l.DistrictId = d.cgdCode AND d.cgCode = 2 ";
            tSQL += " INNER JOIN CatDtl b ON l.BloodGroupId = b.cgdCode AND b.cgCode = 6 ";
            tSQL += " INNER JOIN CatDtl m ON l.MartialStatusId = m.cgdCode AND m.cgCode = 7";
            tSQL += " INNER JOIN CatDtl c ON l.CourseId = c.cgdCode AND c.cgCode = 8 INNER JOIN Batches ba ON l.BatchID = ba.BatchID ";
            tSQL += " INNER JOIN CatDtl ar ON l.AppRankId = ar.cgdCode AND ar.cgCode = 14 ";

            tSQL += " WHERE CapNo = " + PrevRec.ToString() + " AND l.CourseId = " + cboCourseSelection.SelectedValue.ToString() + " AND l.BatchID = " + cboBatchName.SelectedValue.ToString();
            tSQL += " ORDER BY CapNo ";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "RecruitCourse");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    txtID.Text = (ds.Tables[0].Rows[0]["ID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ID"].ToString());
                    txtName.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());
                    txtFName.Text = (ds.Tables[0].Rows[0]["FName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["FName"].ToString());
                    cboGender.Text = (ds.Tables[0].Rows[0]["GenderName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["GenderName"].ToString());
                    cboRank.Text = (ds.Tables[0].Rows[0]["RankName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["RankName"].ToString());
                    txtBeltNo.Text = (ds.Tables[0].Rows[0]["BeltNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BeltNo"].ToString());
                    txtCapNo.Text = (ds.Tables[0].Rows[0]["CapNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CapNo"].ToString());
                    cboDistrict.Text = (ds.Tables[0].Rows[0]["DistrictName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DistrictName"].ToString());
                    dtpDOB.Text = (ds.Tables[0].Rows[0]["DOB"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DOB"].ToString());
                    cboEducation.Text = (ds.Tables[0].Rows[0]["Education"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Education"].ToString());
                    txtCNIC.Text = (ds.Tables[0].Rows[0]["CNICNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CNICNo"].ToString());
                    txtMobileNo.Text = (ds.Tables[0].Rows[0]["MobNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["MobNo"].ToString());
                    dtpAppDate.Text = (ds.Tables[0].Rows[0]["DOApp"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DOApp"].ToString());
                    cboBloodGrp.Text = (ds.Tables[0].Rows[0]["Blood"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Blood"].ToString());
                    cboMartialStat.Text = (ds.Tables[0].Rows[0]["MartialName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["MartialName"].ToString());
                    txtIllness.Text = (ds.Tables[0].Rows[0]["Illness"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Illness"].ToString());
                    txtAddress.Text = (ds.Tables[0].Rows[0]["Address"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Address"].ToString());
                    txtEmergency.Text = (ds.Tables[0].Rows[0]["EmergencyContact"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["EmergencyContact"].ToString());
                    cboBatchName.Text = (ds.Tables[0].Rows[0]["CourseName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CourseName"].ToString());
                    txtCourseDuration.Text = (ds.Tables[0].Rows[0]["CourseDur"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CourseDur"].ToString());
                    dtpStart.Text = (ds.Tables[0].Rows[0]["StartDate"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["StartDate"].ToString());
                    dtpEnd.Text = (ds.Tables[0].Rows[0]["EndDate"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["EndDate"].ToString());
                    txtCoursePeriod.Text = (ds.Tables[0].Rows[0]["TotalPeriod"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["TotalPeriod"].ToString());
                    txtAbsence.Text = (ds.Tables[0].Rows[0]["Absence"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Absence"].ToString());
                    txtLeave.Text = (ds.Tables[0].Rows[0]["Leave"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Leave"].ToString());
                    txtShortLeave.Text = (ds.Tables[0].Rows[0]["SLeave"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["SLeave"].ToString());
                    txtCourtAppear.Text = (ds.Tables[0].Rows[0]["CourtAppear"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CourtAppear"].ToString());
                    txtOutdoor.Text = (ds.Tables[0].Rows[0]["OutDoor"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["OutDoor"].ToString());
                    txtIndoor.Text = (ds.Tables[0].Rows[0]["Indoor"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Indoor"].ToString());
                    txtLWeek.Text = (ds.Tables[0].Rows[0]["LWeek"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["LWeek"].ToString());
                    txtSWeek.Text = (ds.Tables[0].Rows[0]["SWeek"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["SWeek"].ToString());
                    txtPunishReward.Text = (ds.Tables[0].Rows[0]["PunishReward"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["PunishReward"].ToString());
                    txtSpecialAss.Text = (ds.Tables[0].Rows[0]["SpecialAss"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["SpecialAss"].ToString());
                    txtMedicalRest.Text = (ds.Tables[0].Rows[0]["MRest"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["MRest"].ToString());
                    txtPreviousOR.Text = (ds.Tables[0].Rows[0]["PreviousOR"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["PreviousOR"].ToString());
                    cboBatchName.Text = (ds.Tables[0].Rows[0]["BatchName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BatchName"].ToString());
                    cboAppRank.Text = (ds.Tables[0].Rows[0]["AppRank"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["AppRank"].ToString());

                    if (ds.Tables[0].Rows[0]["isEdu"].Equals(1))
                    {
                        chkEducation.Checked = true;
                        cboEducation.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[0]["isEdu"].Equals(0))
                    {
                        chkEducation.Checked = false;
                        cboEducation.Visible = false;
                    }

                    if (ds.Tables[0].Rows[0]["isStartDate"].Equals(1))
                    {
                        chkStartDate.Checked = true;
                        dtpStart.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[0]["isStartDate"].Equals(0))
                    {
                        chkStartDate.Checked = false;
                        dtpStart.Visible = false;
                    }

                    if (ds.Tables[0].Rows[0]["isEndDate"].Equals(1))
                    {
                        chkEndDate.Checked = true;
                        dtpEnd.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[0]["isEndDate"].Equals(0))
                    {
                        chkEndDate.Checked = false;
                        dtpEnd.Visible = false;
                    }

                    if (ds.Tables[0].Rows[0]["isDoApp"].Equals(1))
                    {
                        chkAppDate.Checked = true;
                        dtpAppDate.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[0]["isDoApp"].Equals(0))
                    {
                        chkAppDate.Checked = false;
                        dtpAppDate.Visible = false;
                    }

                    if (ds.Tables[0].Rows[0]["isDOB"].Equals(1))
                    {
                        chkDOB.Checked = true;
                        dtpDOB.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[0]["isDOB"].Equals(0))
                    {
                        chkDOB.Checked = false;
                        dtpDOB.Visible = false;
                    }

                    if (ds.Tables[0].Rows[0]["isRTU"].Equals(1))
                    {
                        chkRTU.Checked = true;
                    }
                    else if (ds.Tables[0].Rows[0]["isRTU"].Equals(0))
                    {
                        chkRTU.Checked = false;
                    }

                    // Sir Shoaib Code for Memory Streaming

                    pictureBox1.Image = imageList1.Images[0];
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Refresh();


                    if (ds.Tables[0].Rows[0]["Picture"] != DBNull.Value)
                    {
                        Byte[] byteBLOBData = new Byte[0];
                        byteBLOBData = (Byte[])ds.Tables[0].Rows[0]["Picture"];

                        MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                        pictureBox1.Image = Image.FromStream(stmBLOBData);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Refresh();

                        byteBLOBData = null;
                        stmBLOBData.Close();
                        stmBLOBData.Dispose();
                    }
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Clear();
                }

                btnInsert.Enabled = true;
                btnRemove.Enabled = true;
            }


            catch
            {
                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }

        private void txtCapNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.ShowDialog();

            SqlConnection con = new SqlConnection(clsGVar.ConString1);
            con.Open();

            frmInsertBulkImages frmImage = new frmInsertBulkImages();


            string[] fileName = frmImage.imageFileName;

            int[] convertedNames = new int[fileName.Length];

            for (int k = 0; k < frmImage.imageFileName.Length; k++)
            {
                convertedNames[k] += Convert.ToInt32(Path.GetFileNameWithoutExtension(fileName[k]));
            }

            Array.Sort(convertedNames);

            //string directory = Path.GetDirectoryName(fileName[0]);
            //string extension = Path.GetExtension(fileName[0]);


            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            DataRow dRow;
            string tSQL = string.Empty;
            int capNo = 0;

            tSQL = "select ID,CAST(CapNo AS INT) AS CapNo from RecruitCourse WHERE CourseId = " + cboCourseSelection.SelectedValue.ToString() + " AND BatchID = " + cboBatchName.SelectedValue.ToString() + "ORDER BY CapNo";
            ds1 = clsDbManager.GetData_Set(tSQL, "RecruitCourse");

            //if (ds1.Tables[0].Rows.Count > 0)
            //{
            //   capNo = Convert.ToInt32(ds1.Tables[0].Rows[0]["CapNo"] == DBNull.Value ? "1" : ds1.Tables[0].Rows[0]["CapNo"].ToString());
            //}

            int j = 0;

            //for (int i = 0; i <= frmImage.imageFileName.Length; i++)
            for (int i = 0; i < convertedNames.Length; i++)
            {
                capNo = Convert.ToInt32(ds1.Tables[0].Rows[j]["CapNo"] == DBNull.Value ? "1" : ds1.Tables[0].Rows[j]["CapNo"].ToString());

                //if (Path.GetFileNameWithoutExtension(frmImage.imageFileName[i]) == ds.Tables[0].Rows[0]["CapNo"].ToString())
                //if (Path.GetFileNameWithoutExtension(frmImage.imageFileName[i]) == capNo.ToString())
                if (convertedNames[j] == capNo)
                {
                    //MessageBox.Show("Matched");
                    SqlConnection imageCon = new SqlConnection(clsGVar.ConString1);

                    string[] imgData = new string[convertedNames.Length];

                    //for(int l = 0; l<= frmImage.imageFileName.Length; l++)
                    //{
                    string directory = Path.GetDirectoryName(fileName[i]);
                    string extension = Path.GetExtension(fileName[0]);
                    imgData[i] = directory + "\\" + convertedNames[i] + extension;
                    //}

                    tSQL = "";
                    tSQL += "UPDATE RecruitCourse SET Picture =  (SELECT BulkColumn FROM OPENROWSET(BULK  N'" + imgData[i] + "', SINGLE_BLOB) AS x) WHERE CapNo = " + capNo.ToString() + " AND BatchID = " + cboBatchName.SelectedValue.ToString() + " AND CourseID = " + cboCourseSelection.SelectedValue.ToString();

                    clsDbManager.ExeOne(tSQL);


                    //SqlCommand imageCmd = new SqlCommand("UPDATE RecruitCourse SET Picture =  (SELECT BulkColumn FROM OPENROWSET(BULK  N'" + imgData + "', SINGLE_BLOB) AS x) WHERE CapNo = " + ds1.Tables[0].Rows[j]["CapNo"].ToString() + " AND BatchID = " + cboBatchName.SelectedValue.ToString() + " AND CourseID = " + cboCourseSelection.SelectedValue.ToString(), con);
                    //imageCmd.Parameters.Add("@DATA", imgData);
                    //imageCmd.ExecuteNonQuery();
                    j++;

                    tSQL = "";

                    tSQL += " select l.ID, l.Name, l.FatherName AS FName, g.cgdDesc AS GenderName, r.cgdDesc AS RankName, ";
                    tSQL += " l.BeltNo, CAST(l.CapNo AS INT) AS CapNo, d.cgdDesc AS DistrictName, l.DOB, l.Education, l.CNICNo, ";
                    tSQL += " l.MobileNo AS MobNo,l.DOApp, b.cgdDesc AS Blood, m.cgdDesc AS MartialName, ";
                    tSQL += " l.Illness, l.Address,  l.EmergencyContact , c.cgdDesc AS CourseName, ";
                    tSQL += " l.CourseDuration AS CourseDur, ";
                    tSQL += " l.FromDate AS StartDate, l.ToDate AS EndDate, l.CoursePeriod AS TotalPeriod, ";
                    tSQL += " l.Absence, l.Leave, l.ShortLeave AS SLeave, l.CourtApperance AS CourtAppear, ";
                    tSQL += " l.OutDoor, l.Indoor, l.LongWeekend AS LWeek, l.ShortWeekend AS SWeek, ";
                    tSQL += " l.PunishReward, l.SpecialAss, l.MedicalRest AS MRest, l.PreviousOR, l.Picture, ba.BatchName, ";
                    tSQL += " l.isEdu, l.isStartDate, l.isEndDate, l.isDoApp, l.isDOB ";
                    tSQL += " from RecruitCourse l INNER JOIN CatDtl g ON l.GenderId = g.cgdCode AND g.cgCode = 1 ";
                    tSQL += " INNER JOIN CatDtl r ON l.RankId = r.cgdCode AND r.cgCode = 4 INNER JOIN CatDtl d ON l.DistrictId = d.cgdCode AND d.cgCode = 2 ";
                    tSQL += " INNER JOIN CatDtl b ON l.BloodGroupId = b.cgdCode AND b.cgCode = 6 ";
                    tSQL += " INNER JOIN CatDtl m ON l.MartialStatusId = m.cgdCode AND m.cgCode = 7";
                    tSQL += " INNER JOIN CatDtl c ON l.CourseId = c.cgdCode AND c.cgCode = 8 INNER JOIN Batches ba ON l.BatchID = ba.BatchID ";

                    tSQL += " WHERE l.CapNo = " + capNo + " AND l.BatchID = " + cboBatchName.SelectedValue.ToString() + " AND l.CourseID = " + cboCourseSelection.SelectedValue.ToString();
                    try
                    {
                        ds = clsDbManager.GetData_Set(tSQL, "RecruitCourse");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            dRow = ds.Tables[0].Rows[0];
                            txtID.Text = (ds.Tables[0].Rows[0]["ID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ID"].ToString());
                            txtName.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());
                            txtFName.Text = (ds.Tables[0].Rows[0]["FName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["FName"].ToString());
                            cboGender.Text = (ds.Tables[0].Rows[0]["GenderName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["GenderName"].ToString());
                            cboRank.Text = (ds.Tables[0].Rows[0]["RankName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["RankName"].ToString());
                            txtBeltNo.Text = (ds.Tables[0].Rows[0]["BeltNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BeltNo"].ToString());
                            txtCapNo.Text = (ds.Tables[0].Rows[0]["CapNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CapNo"].ToString());
                            cboDistrict.Text = (ds.Tables[0].Rows[0]["DistrictName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DistrictName"].ToString());
                            dtpDOB.Text = (ds.Tables[0].Rows[0]["DOB"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DOB"].ToString());
                            cboEducation.Text = (ds.Tables[0].Rows[0]["Education"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Education"].ToString());
                            txtCNIC.Text = (ds.Tables[0].Rows[0]["CNICNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CNICNo"].ToString());
                            txtMobileNo.Text = (ds.Tables[0].Rows[0]["MobNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["MobNo"].ToString());
                            dtpAppDate.Text = (ds.Tables[0].Rows[0]["DOApp"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DOApp"].ToString());
                            cboBloodGrp.Text = (ds.Tables[0].Rows[0]["Blood"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Blood"].ToString());
                            cboMartialStat.Text = (ds.Tables[0].Rows[0]["MartialName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["MartialName"].ToString());
                            txtIllness.Text = (ds.Tables[0].Rows[0]["Illness"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Illness"].ToString());
                            txtAddress.Text = (ds.Tables[0].Rows[0]["Address"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Address"].ToString());
                            txtEmergency.Text = (ds.Tables[0].Rows[0]["EmergencyContact"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["EmergencyContact"].ToString());
                            cboBatchName.Text = (ds.Tables[0].Rows[0]["CourseName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CourseName"].ToString());
                            txtCourseDuration.Text = (ds.Tables[0].Rows[0]["CourseDur"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CourseDur"].ToString());
                            dtpStart.Text = (ds.Tables[0].Rows[0]["StartDate"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["StartDate"].ToString());
                            dtpEnd.Text = (ds.Tables[0].Rows[0]["EndDate"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["EndDate"].ToString());
                            txtCoursePeriod.Text = (ds.Tables[0].Rows[0]["TotalPeriod"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["TotalPeriod"].ToString());
                            txtAbsence.Text = (ds.Tables[0].Rows[0]["Absence"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Absence"].ToString());
                            txtLeave.Text = (ds.Tables[0].Rows[0]["Leave"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Leave"].ToString());
                            txtShortLeave.Text = (ds.Tables[0].Rows[0]["SLeave"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["SLeave"].ToString());
                            txtCourtAppear.Text = (ds.Tables[0].Rows[0]["CourtAppear"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CourtAppear"].ToString());
                            txtOutdoor.Text = (ds.Tables[0].Rows[0]["OutDoor"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["OutDoor"].ToString());
                            txtIndoor.Text = (ds.Tables[0].Rows[0]["Indoor"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Indoor"].ToString());
                            txtLWeek.Text = (ds.Tables[0].Rows[0]["LWeek"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["LWeek"].ToString());
                            txtSWeek.Text = (ds.Tables[0].Rows[0]["SWeek"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["SWeek"].ToString());
                            txtPunishReward.Text = (ds.Tables[0].Rows[0]["PunishReward"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["PunishReward"].ToString());
                            txtSpecialAss.Text = (ds.Tables[0].Rows[0]["SpecialAss"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["SpecialAss"].ToString());
                            txtMedicalRest.Text = (ds.Tables[0].Rows[0]["MRest"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["MRest"].ToString());
                            txtPreviousOR.Text = (ds.Tables[0].Rows[0]["PreviousOR"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["PreviousOR"].ToString());
                            cboBatchName.Text = (ds.Tables[0].Rows[0]["BatchName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BatchName"].ToString());

                            if (ds.Tables[0].Rows[0]["isEdu"].Equals(1))
                            {
                                chkEducation.Checked = true;
                                cboEducation.Visible = true;
                            }
                            else if (ds.Tables[0].Rows[0]["isEdu"].Equals(0))
                            {
                                chkEducation.Checked = false;
                                cboEducation.Visible = false;
                            }

                            if (ds.Tables[0].Rows[0]["isStartDate"].Equals(1))
                            {
                                chkStartDate.Checked = true;
                                dtpStart.Visible = true;
                            }
                            else if (ds.Tables[0].Rows[0]["isStartDate"].Equals(0))
                            {
                                chkStartDate.Checked = false;
                                dtpStart.Visible = false;
                            }

                            if (ds.Tables[0].Rows[0]["isEndDate"].Equals(1))
                            {
                                chkEndDate.Checked = true;
                                dtpEnd.Visible = true;
                            }
                            else if (ds.Tables[0].Rows[0]["isEndDate"].Equals(0))
                            {
                                chkEndDate.Checked = false;
                                dtpEnd.Visible = false;
                            }

                            if (ds.Tables[0].Rows[0]["isDoApp"].Equals(1))
                            {
                                chkAppDate.Checked = true;
                                dtpAppDate.Visible = true;
                            }
                            else if (ds.Tables[0].Rows[0]["isDoApp"].Equals(0))
                            {
                                chkAppDate.Checked = false;
                                dtpAppDate.Visible = false;
                            }

                            if (ds.Tables[0].Rows[0]["isDOB"].Equals(1))
                            {
                                chkDOB.Checked = true;
                                dtpDOB.Visible = true;
                            }
                            else if (ds.Tables[0].Rows[0]["isDOB"].Equals(0))
                            {
                                chkDOB.Checked = false;
                                dtpDOB.Visible = false;
                            }

                            // Sir Shoaib Code for Memory Streaming

                            pictureBox1.Image = imageList1.Images[0];
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBox1.Refresh();


                            if (ds.Tables[0].Rows[0]["Picture"] != DBNull.Value)
                            {
                                Byte[] byteBLOBData = new Byte[0];
                                byteBLOBData = (Byte[])ds.Tables[0].Rows[0]["Picture"];
                                //  byteBLOBData = (Byte[])(ds.Tables["LadyRecruitCourse"].Rows[c - 1]["Picture"]);

                                MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                                pictureBox1.Image = Image.FromStream(stmBLOBData);
                                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                                pictureBox1.Refresh();

                                byteBLOBData = null;
                                stmBLOBData.Close();
                                stmBLOBData.Dispose();
                                //lblMsg.Text = "File read from the database successfully.";
                            }
                        }
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ds.Clear();
                        }

                        btnInsert.Enabled = true;
                        btnRemove.Enabled = true;
                    }


                    catch
                    {
                        MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
                    }

                }

                else
                {
                    j++;
                }
            }
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            Action<Control.ControlCollection> func1 = null;

            func1 = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Enabled = true;
                    else if (control is CheckBox)
                        (control as CheckBox).Enabled = true;
                    else if (control is ComboBox)
                        (control as ComboBox).Enabled = true;
                    else if (control is DateTimePicker)
                        (control as DateTimePicker).Enabled = true;
                    else
                        func1(control.Controls);
            };

            func1(Controls);

            btnNextRec.Enabled = false;
            btnPrevRec.Enabled = false;
            btnSave.Enabled = true;
        }

        private void txtCapNo_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        private void txtCapNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
        }
    }
}