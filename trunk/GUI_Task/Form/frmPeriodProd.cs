using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI_Task.StringFun01;
using GUI_Task.PrintVw6;
using GUI_Task.PrintReport;

namespace GUI_Task
{
    public partial class frmPeriodProd : Form
    {
        public frmPeriodProd()
        {
            InitializeComponent();
        }

        private void period_Wise_Production_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPeriodProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string fRptTitle = this.Text;
            string plstField = "@FromDate,@ToDate";
            string plstType = "18,18"; // {"8, 8, 8, 8, 8, 8"};
            string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                StrF01.D2Str(this.dtpToDate.Value);

            //string plstValue = txtItemCode.Text.ToString() + "," + cboSize.SelectedValue.ToString() + "," +
            //    cboColor.SelectedValue.ToString() + "," + cboGodown.SelectedValue.ToString() + "," +
            //    StrF01.D2Str(this.dtpFromDate.Value) + "," +
            //    StrF01.D2Str(this.dtpToDate.Value);

            //dsLedgerNew pDs = new dsLedgerNew();

            DataSet pDs = new DataSet();
            CrPerProd rpt1 = new CrPerProd();

            frmPrintVw6 rptPeriodProd = new frmPrintVw6(
               fRptTitle,
               StrF01.D2Str(this.dtpFromDate.Value),
               StrF01.D2Str(this.dtpToDate.Value),
               "Prod_Report",
               plstField,
               plstType,
               plstValue,
               pDs,
               rpt1,
               "SP"
               );

            //rptLedger2.ShowDialog();
            rptPeriodProd.Show();
        }

    }
}
