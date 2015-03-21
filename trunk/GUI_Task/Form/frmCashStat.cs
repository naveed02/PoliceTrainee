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
    public partial class frmCashStat : Form
    {
        public frmCashStat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cash_Statement_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void frmCashStat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (optCashStat.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@Code,@FromDate,@ToDate";
                string plstType = "18,18,18"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = "1-2-01-01-0000" + "," + StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value);

                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrCashStat rpt1 = new CrCashStat();

                frmPrintVw6 rptCashStat = new frmPrintVw6(
                   fRptTitle,
                   StrF01.D2Str(this.dtpFromDate.Value),
                   StrF01.D2Str(this.dtpToDate.Value),
                   "sp_CashStat",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptCashStat.Show();
            }
            else if (optCashRok.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@Code,@FromDate,@ToDate";
                string plstType = "18,18,18"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = "1-2-01-01-0000" + "," + StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value);

                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrCashStat rpt1 = new CrCashStat();

                frmPrintVw6 rptCashStat = new frmPrintVw6(
                   fRptTitle,
                   StrF01.D2Str(this.dtpFromDate.Value),
                   StrF01.D2Str(this.dtpToDate.Value),
                   "sp_CashStat",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptCashStat.Show();
            }
            else if (optBankStat.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@Cash_Code,@Bank_Code";
                string plstType = "18,18"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = "" + "," + "1-2-01-01-0002";

                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrCashBankStat  rpt1 = new CrCashBankStat();

                frmPrintVw6 rptCashBank= new frmPrintVw6(
                   fRptTitle,
                   StrF01.D2Str(this.dtpFromDate.Value),
                   StrF01.D2Str(this.dtpToDate.Value),
                   "sp_CashBank",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptCashBank.Show();
            }
        }
    }
}
