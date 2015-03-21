using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI_Task
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            dt.GetDateTimeFormats();
        }

        private void ladyRecruitCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLadyRecCourse frm = new frmLadyRecCourse();
            frm.MdiParent = this;
            frm.Show();
        }

        private void addNewCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddBatch frm = new frmAddBatch();
            frm.MdiParent = this;
            frm.Show();
        }

        private void addNewRankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddRank frm = new frmAddRank();
            frm.MdiParent = this;
            frm.Show();
        }

        private void addNewEducationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEducation frm = new frmAddEducation();
            frm.MdiParent = this;
            frm.Show();
        }

        private void addNewBloodGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddBloodGroup frm = new frmAddBloodGroup();
            frm.MdiParent = this;
            frm.Show();
        }

        private void printReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrintRpt frm = new frmPrintRpt();
            frm.MdiParent = this;
            frm.Show();
        }

        private void addNewDistrictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddDistrict frm = new frmAddDistrict();
            frm.MdiParent = this;
            frm.Show();
        }

        private void addNewCourseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddCourse frm = new frmAddCourse();
            frm.MdiParent = this;
            frm.Show();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUser frm = new frmAddUser();
            frm.MdiParent = this;
            frm.Show();
        }

        public ToolStripMenuItem AddNewUserToolStrip
        {
            //get { return txtTest.Text; }
            //set { txtTest.Text = value; }

            get { return addNewUserToolStripMenuItem; }
            set { addNewUserToolStripMenuItem = value; }
        }

        private void addNewAppRankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddAppRank frm = new frmAddAppRank();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.N))
            {
                frmLadyRecCourse frm = new frmLadyRecCourse();
                frm.MdiParent = this;
                frm.Show();
            }

            else if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.P))
            {
                frmPrintRpt frm = new frmPrintRpt();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLadyRecCourse frm = new frmLadyRecCourse();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reportPrintingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrintRpt frm = new frmPrintRpt();
            frm.MdiParent = this;
            frm.Show();
        }

    }
}
