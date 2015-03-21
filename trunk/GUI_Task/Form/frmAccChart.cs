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
    public partial class frmAccChart : Form
    {
        public frmAccChart()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chart_Of_Accounts_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void frmAccChart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string fRptTitle = this.Text;
            string plstField = "@OrgID";
            string plstType = "8"; // {"8, 8, 8, 8, 8, 8"};
            string plstValue = "" + 1 + "";
            //this.mskAccCode.Text + "," + StrF01.D2Str(this.dtpFromDate.Value) + "," +
            //  StrF01.D2Str(this.dtpToDate.Value);

            //dsLedgerNew pDs = new dsLedgerNew();

            DataSet pDs = new DataSet();
            CrAccChart rpt1 = new CrAccChart();

            frmPrintVw6 rptLedger2 = new frmPrintVw6(
               fRptTitle,
               "",
               "",
                //StrF01.D2Str(this.dtpFromDate.Value),
                //StrF01.D2Str(this.dtpToDate.Value),
               "sp_AccChart",
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
