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
    public partial class frmSupplierList : Form
    {
        public frmSupplierList()
        {
            InitializeComponent();
        }

        private void supplier_List_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSupplierList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
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
            CrVendList rpt1 = new CrVendList();

            frmPrintVw6 rptLedger2 = new frmPrintVw6(
               fRptTitle,
               "",
               "",
                //StrF01.D2Str(this.dtpFromDate.Value),
                //StrF01.D2Str(this.dtpToDate.Value),
               "sp_VendList",
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