using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI_Task.Class;
using GUI_Task.StringFun01;
using GUI_Task.PrintReport;
using GUI_Task.PrintVw6;

namespace GUI_Task
{
    public partial class frmPendingOrd : Form
    {
        int fcboDefaultValue = 0;
        public frmPendingOrd()
        {
            InitializeComponent();
        }

        private void pending_Orders_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            AtFormLoad();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AtFormLoad()
        {
            string lSQL = string.Empty;
            
            //Main Group Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode="+Convert.ToString((int)Category.enmMainGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboMainGrp, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboMainGrp.SelectedValue);

            //Item Group Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode="+Convert.ToString((int)Category.enmItemGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGrp, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGrp.SelectedValue);
        }

        private void frmPendingOrd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (optOrdDetail.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@ItemMainGroupID, @ItemGroupID, @FromDate, @ToDate";
                string plstType = "8,8,18,18"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = cboMainGrp.SelectedValue.ToString()
                    + "," + cboItemGrp.SelectedValue.ToString() + "," + StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value);

                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrRunOrder rpt1 = new CrRunOrder();

                frmPrintVw6 rptLedger2 = new frmPrintVw6(
                   fRptTitle,
                   StrF01.D2Str(this.dtpFromDate.Value),
                   StrF01.D2Str(this.dtpToDate.Value),
                   "sp_OrderRun",
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

            else if (optOrdSummary.Checked == true)
            {
            }
        }
    }
}
