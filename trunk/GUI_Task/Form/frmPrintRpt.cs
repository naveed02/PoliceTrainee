using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI_Task.PrintReport;
using GUI_Task.PrintVw6;

namespace GUI_Task
{
    public partial class frmPrintRpt : Form
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

        public frmPrintRpt()
        {
            InitializeComponent();
        }

        private void AtFormLoad()
        {
            string lSQL = string.Empty;

            this.KeyPreview = true;

            //Course Selection Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode= 8";
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboCourseSelection, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboCourseSelection.SelectedValue);

            //Batch Name Combo Fill
            lSQL = " select BatchID ,BatchName from Batches Where CourseID = " + cboCourseSelection.SelectedValue.ToString() + " AND Status = 1 ";
            lSQL += " order by BatchName ";

            clsFillCombo.FillCombo(cboBatchName, clsGVar.ConString1, "Batches" + "," + "BatchID" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboBatchName.SelectedValue);
        }

        private void frmPrintRpt_Load(object sender, EventArgs e)
        {
            AtFormLoad();
            this.MaximizeBox = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LookUp_Voc();

            string fRptTitle = this.Text;
            string plstField = "@ID";
            string plstType = "8"; // {"8, 8, 8, 8, 8, 8"};
            string plstValue = this.txtID.Text;
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

        private void frmPrintRpt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
            tSQL += " l.PunishReward, l.SpecialAss, l.MedicalRest AS MRest, l.Picture ";
            tSQL += " from RecruitCourse l INNER JOIN CatDtl g ON l.GenderId = g.cgdCode AND g.cgCode = 1 ";
            tSQL += " INNER JOIN CatDtl r ON l.RankId = r.cgdCode AND r.cgCode = 4 INNER JOIN CatDtl d ON l.DistrictId = d.cgdCode AND d.cgCode = 2 ";
            tSQL += " INNER JOIN CatDtl b ON l.BloodGroupId = b.cgdCode AND b.cgCode = 6 ";
            tSQL += " INNER JOIN CatDtl m ON l.MartialStatusId = m.cgdCode AND m.cgCode = 7";
            tSQL += " INNER JOIN CatDtl c ON l.CourseId = c.cgdCode AND c.cgCode = 3 ";
            tSQL += " WHERE l.ID = " + txtID.Text.ToString() + "";
            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "RecruitCourse");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    txtID.Text = (ds.Tables[0].Rows[0]["ID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ID"].ToString());
                }
            }


            catch (Exception e)
            {

                MessageBox.Show("Unable to Get Account Code...", this.Text.ToString());
            }
        }


        private void btnDetailedReport_Click(object sender, EventArgs e)
        {
                string fRptTitle = this.Text;
                string plstField = "@ID,@CourseID,@BatchID";
                string plstType = "8,8,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = "1," + cboCourseSelection.SelectedValue.ToString() + "," + cboBatchName.SelectedValue.ToString();
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

        private void cboCourseSelection_DropDownClosed(object sender, EventArgs e)
        {
            string lSQL = string.Empty;

            cboBatchName.Text = "";
            lSQL = " select BatchID ,BatchName from Batches Where CourseID = " + cboCourseSelection.SelectedValue.ToString() + " AND Status = 1 ";
            lSQL += " order by BatchName ";

            clsFillCombo.FillCombo(cboBatchName, clsGVar.ConString1, "Batches" + "," + "BatchID" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboBatchName.SelectedValue);
        }
    }
}