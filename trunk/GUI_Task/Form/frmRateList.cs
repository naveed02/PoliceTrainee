using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI_Task.Class;
using GUI_Task.PrintReport;
using GUI_Task.PrintVw6;

namespace GUI_Task
{
    public partial class frmRateList : Form
    {
        int fcboDefaultValue = 0;
        public frmRateList()
        {
            InitializeComponent();
        }

        private void frm_items_Rate_List_Load(object sender, EventArgs e)
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

            this.KeyPreview = true;

            //Item Group Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmItemGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGrp, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGrp.SelectedValue);
        }

        private void frmRateList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (optRateDozen.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@ItemGroupID";
                string plstType = "8"; // {"8, 8, 8, 8, 8, 8"};

                //string plstValue = cboItemGrp.ValueMember.ToString();
                string plstValue = cboItemGrp.SelectedValue.ToString();
                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();

                CrItemSize rpt1 = new CrItemSize();



                frmPrintVw6 rptItemSize = new frmPrintVw6(
                   fRptTitle,
                   "0", "0",
                   "sp_ItemSize",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //     rptLedger2.ShowDialog();
                rptItemSize.Show();
            }
            else if (optRatePair.Checked == true)
            {

                string fRptTitle = this.Text;
                string plstField = "@ItemGroupID";
                string plstType = "8"; // {"8, 8, 8, 8, 8, 8"};

                //string plstValue = cboItemGrp.ValueMember.ToString();
                string plstValue = cboItemGrp.SelectedValue.ToString();
                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();

                CrItemPairs rpt1 = new CrItemPairs();



                frmPrintVw6 rptItemPair = new frmPrintVw6(
                   fRptTitle,
                   "0", "0",
                   "sp_ItemSize",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //     rptLedger2.ShowDialog();
                rptItemPair.Show();
            }
            else if (optItemChargesRate.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@ItemGroupID";
                string plstType = "8"; // {"8, 8, 8, 8, 8, 8"};

                //string plstValue = cboItemGrp.ValueMember.ToString();
                string plstValue = cboItemGrp.SelectedValue.ToString();
                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();

                CrItemCharges rpt1 = new CrItemCharges();



                frmPrintVw6 rptItemCharges = new frmPrintVw6(
                   fRptTitle,
                   "0", "0",
                   "sp_ItemCharges",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //     rptLedger2.ShowDialog();
                rptItemCharges.Show();
            }

        }
    }
}
