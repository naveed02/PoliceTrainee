using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI_Task.StringFun01;
using GUI_Task.PrintReport;
using GUI_Task.PrintVw6;

namespace GUI_Task
{
    public partial class frmTrialBal : Form
    {
        public frmTrialBal()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trail_Balance_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void frmTrailBal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string fRptTitle = this.Text;
            string plstField = "@ParaFrom_Date,@ParaTo_Date";
            string plstType = "18,18"; // {"8, 8, 8, 8, 8, 8"};
            string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," + StrF01.D2Str(this.dtpToDate.Value);

            //dsLedgerNew pDs = new dsLedgerNew();

            DataSet pDs = new DataSet();
            CrTrial rpt1 = new CrTrial();

            frmPrintVw6 rptLedger2 = new frmPrintVw6(
               fRptTitle,
               this.dtpFromDate.Value.ToString("dd-MM-yyyy"),
               this.dtpToDate.Value.ToString("dd-MM-yyyy"),
               "Trial",
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
    }
}
