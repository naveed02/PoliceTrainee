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
using GUI_Task.PrintVw6;
using GUI_Task.PrintReport;

namespace GUI_Task
{
    public partial class frmRptTotalStock : Form
    {
        int fcboDefaultValue=0;
        public frmRptTotalStock()
        {
            InitializeComponent();
        }

        private void total_Stock_Report_Load(object sender, EventArgs e)
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
            
            //Godown Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmGodown);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboGodown, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboGodown.SelectedValue);

            //Category Combo Fill
            lSQL = "SELECT distinct 1, RIGHT(ItemCode,1) FROM Item";

            clsFillCombo.FillCombo(cboCategory, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboCategory.SelectedValue);
        }

        private void frmRptTotalStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (optAllGodown.Checked == true)
            {
                if (optDetail.Checked == true)
                {
                    string fRptTitle = this.Text;
                    string plstField = "@ItemGroup,@ItemCategory,@FromDate,@ToDate,@isZeroBal";
                    string plstType = "8,18,18,18,8"; // {"8, 8, 8, 8, 8, 8"};
                    string plstValue = cboItemGrp.SelectedValue.ToString() + "," +
                        cboCategory.Text.ToString() + "," +
                       StrF01.D2Str(this.dtpFromDate.Value) + "," +
                        StrF01.D2Str(this.dtpToDate.Value) + "," +
                        (chkIsZeroBalance.Checked == true ? 0 : 1);

                    //dsLedgerNew pDs = new dsLedgerNew();

                    DataSet pDs = new DataSet();
                    CrTotalStockRepInOut rpt1 = new CrTotalStockRepInOut();

                    frmPrintVw6 rptCrTotalStockRepInOut = new frmPrintVw6(
                       fRptTitle,
                       StrF01.D2Str(this.dtpFromDate.Value),
                       StrF01.D2Str(this.dtpToDate.Value),
                       "sp_StokGroupInOut",
                       plstField,
                       plstType,
                       plstValue,
                       pDs,
                       rpt1,
                       "SP"
                       );

                    //rptLedger2.ShowDialog();
                    rptCrTotalStockRepInOut.Show();
                }
                else if (optDetailAll.Checked == true)
                {
                    string fRptTitle = this.Text;
                    string plstField = "@ItemGroup,@ItemCategory,@FromDate,@ToDate,@isZeroBal";
                    string plstType = "8,18,18,18,8"; // {"8, 8, 8, 8, 8, 8"};
                    string plstValue = cboItemGrp.SelectedValue.ToString() + "," +
                        cboCategory.Text.ToString() + "," +
                       StrF01.D2Str(this.dtpFromDate.Value) + "," +
                        StrF01.D2Str(this.dtpToDate.Value) + "," +
                        (chkIsZeroBalance.Checked == true ? 0 : 1);

                    //dsLedgerNew pDs = new dsLedgerNew();

                    DataSet pDs = new DataSet();
                    CrTotalStockRepInOutAll rpt1 = new CrTotalStockRepInOutAll();

                    frmPrintVw6 rptCrTotalStockRepInOutAll = new frmPrintVw6(
                       fRptTitle,
                       StrF01.D2Str(this.dtpFromDate.Value),
                       StrF01.D2Str(this.dtpToDate.Value),
                       "sp_StokGroupInOutAll",
                       plstField,
                       plstType,
                       plstValue,
                       pDs,
                       rpt1,
                       "SP"
                       );
                    rptCrTotalStockRepInOutAll.Show();
                }
                else if (optDetailSize.Checked == true)
                {

                    string fRptTitle = this.Text;
                    string plstField = "@ItemGroup,@ItemCategory,@FromDate,@ToDate,@isZeroBal";
                    string plstType = "8,18,18,18,8"; // {"8, 8, 8, 8, 8, 8"};
                    string plstValue = cboItemGrp.SelectedValue.ToString() + "," +
                        cboCategory.Text.ToString() + "," +
                       StrF01.D2Str(this.dtpFromDate.Value) + "," +
                        StrF01.D2Str(this.dtpToDate.Value) + "," +
                        (chkIsZeroBalance.Checked == true ? 0 : 1);

                    //dsLedgerNew pDs = new dsLedgerNew();

                    DataSet pDs = new DataSet();
                    CrTotalStockRepInOutSize rpt1 = new CrTotalStockRepInOutSize();

                    frmPrintVw6 rptCrTotalStockRepInOutSize = new frmPrintVw6(
                       fRptTitle,
                       StrF01.D2Str(this.dtpFromDate.Value),
                       StrF01.D2Str(this.dtpToDate.Value),
                       "sp_StokGroupInOutAll",
                       plstField,
                       plstType,
                       plstValue,
                       pDs,
                       rpt1,
                       "SP"
                       );
                    rptCrTotalStockRepInOutSize.Show();
                }
                else if (optSummary.Checked == true)
                {
                    string fRptTitle = this.Text;
                    string plstField = "@ItemGroup,@ItemCategory,@FromDate,@ToDate,@isZeroBal";
                    string plstType = "8,18,18,18,8"; // {"8, 8, 8, 8, 8, 8"};
                    string plstValue = cboItemGrp.SelectedValue.ToString() + "," +
                        cboCategory.Text.ToString() + "," +
                       StrF01.D2Str(this.dtpFromDate.Value) + "," +
                        StrF01.D2Str(this.dtpToDate.Value) + "," +
                        (chkIsZeroBalance.Checked == true ? 0 : 1);

                    //dsLedgerNew pDs = new dsLedgerNew();

                    DataSet pDs = new DataSet();
                    CrTotalStockRepInOutSumry rpt1 = new CrTotalStockRepInOutSumry();

                    frmPrintVw6 rptCrTotalStockRepInOutSumry = new frmPrintVw6(
                       fRptTitle,
                       StrF01.D2Str(this.dtpFromDate.Value),
                       StrF01.D2Str(this.dtpToDate.Value),
                       "sp_StokGroupInOut",
                       plstField,
                       plstType,
                       plstValue,
                       pDs,
                       rpt1,
                       "SP"
                       );
                    rptCrTotalStockRepInOutSumry.Show();
                }
                else if (optSummaryNegative.Checked == true)
                {
                    string fRptTitle = this.Text;
                    string plstField = "@ItemGroup,@ItemCategory,@FromDate,@ToDate,@isZeroBal";
                    string plstType = "8,18,18,18,8"; // {"8, 8, 8, 8, 8, 8"};
                    string plstValue = cboItemGrp.SelectedValue.ToString() + "," +
                        cboCategory.Text.ToString() + "," +
                       StrF01.D2Str(this.dtpFromDate.Value) + "," +
                        StrF01.D2Str(this.dtpToDate.Value) + "," +
                        (chkIsZeroBalance.Checked == true ? 0 : 1);

                    //dsLedgerNew pDs = new dsLedgerNew();

                    DataSet pDs = new DataSet();
                    CrTotalStockRepInOutSumry rpt1 = new CrTotalStockRepInOutSumry();

                    frmPrintVw6 rptCrTotalStockRepInOutSumry = new frmPrintVw6(
                       fRptTitle,
                       StrF01.D2Str(this.dtpFromDate.Value),
                       StrF01.D2Str(this.dtpToDate.Value),
                       "sp_StokGroupInOut",
                       plstField,
                       plstType,
                       plstValue,
                       pDs,
                       rpt1,
                       "SP"
                       );
                    rptCrTotalStockRepInOutSumry.Show();
                }
                else if (optPUS.Checked == true)
                {

                    string fRptTitle = this.Text;
                    string plstField = "@ItemGroup,@ItemCategory,@Godown,@FromDate,@ToDate,@isZeroBal";
                    string plstType = "8,18,8,18,18,8"; // {"8, 8, 8, 8, 8, 8"};
                    string plstValue = cboItemGrp.SelectedValue.ToString() + "," +
                        cboCategory.Text.ToString() + "," +
                        cboGodown.SelectedValue.ToString() + "," +
                       StrF01.D2Str(this.dtpFromDate.Value) + "," +
                        StrF01.D2Str(this.dtpToDate.Value) + "," +
                        (chkIsZeroBalance.Checked == true ? 0 : 1);

                    //dsLedgerNew pDs = new dsLedgerNew();

                    DataSet pDs = new DataSet();
                    CrTotalStockUpper rpt1 = new CrTotalStockUpper();

                    frmPrintVw6 rptCrTotalStockUpper = new frmPrintVw6(
                       fRptTitle,
                       StrF01.D2Str(this.dtpFromDate.Value),
                       StrF01.D2Str(this.dtpToDate.Value),
                       "sp_StokUpper",
                       plstField,
                       plstType,
                       plstValue,
                       pDs,
                       rpt1,
                       "SP"
                       );
                    rptCrTotalStockUpper.Show();
                }
                else if (optPUSRemainingOrder.Checked == true)
                {
                    MessageBox.Show("No Report Found For Current Selection");
                }
                else if (optDetailCT.Checked == true)
                {

                    string fRptTitle = this.Text;
                    string plstField = "@ItemGroup,@ItemCategory";
                    string plstType = "8,18"; // {"8, 8, 8, 8, 8, 8"};
                    string plstValue = cboItemGrp.SelectedValue.ToString() + "," +
                        cboCategory.Text.ToString() + "," +
                        cboGodown.SelectedValue.ToString() + "," +
                       StrF01.D2Str(this.dtpFromDate.Value) + "," +
                        StrF01.D2Str(this.dtpToDate.Value) + "," +
                        (chkIsZeroBalance.Checked == true ? 0 : 1);

                    //dsLedgerNew pDs = new dsLedgerNew();

                    DataSet pDs = new DataSet();
                    CrTotalStockRep rpt1 = new CrTotalStockRep();

                    frmPrintVw6 rptCrTotalStockRep = new frmPrintVw6(
                       fRptTitle,
                       StrF01.D2Str(this.dtpFromDate.Value),
                       StrF01.D2Str(this.dtpToDate.Value),
                       "sp_StokGroup",
                       plstField,
                       plstType,
                       plstValue,
                       pDs,
                       rpt1,
                       "SP"
                       );
                    rptCrTotalStockRep.Show();
                }
            }
            else if (optGodownWise.Checked == true)
            {
                if (optDetail.Checked == true)
                {

                    string fRptTitle = this.Text;
                    string plstField = "@ItemGroup,@ItemCategory,@Godown,@FromDate,@ToDate,@isZeroBal";
                    string plstType = "8,18,8,18,18,8"; // {"8, 8, 8, 8, 8, 8"};
                    string plstValue = cboItemGrp.SelectedValue.ToString() + "," +
                        cboCategory.SelectedValue.ToString() + "," +
                        cboGodown.SelectedValue.ToString() + "," +
                       StrF01.D2Str(this.dtpFromDate.Value) + "," +
                        StrF01.D2Str(this.dtpToDate.Value) + "," +
                        (chkIsZeroBalance.Checked == true ? 0 : 1);

                    //dsLedgerNew pDs = new dsLedgerNew();

                    DataSet pDs = new DataSet();
                    CrTotalStockRepGod rpt1 = new CrTotalStockRepGod();

                    frmPrintVw6 rptCrTotalStockRepGod = new frmPrintVw6(
                       fRptTitle,
                       StrF01.D2Str(this.dtpFromDate.Value),
                       StrF01.D2Str(this.dtpToDate.Value),
                       "sp_StokGroupGod",
                       plstField,
                       plstType,
                       plstValue,
                       pDs,
                       rpt1,
                       "SP"
                       );
                    rptCrTotalStockRepGod.Show();
                }
                else if (optDetailAll.Checked == true)
                {
                    MessageBox.Show("No Report Found For Current Selection");
                }
                else if (optDetailSize.Checked == true)
                {

                    string fRptTitle = this.Text;
                    string plstField = "@ItemGroup,@ItemCategory,@FromDate,@ToDate,@GodownID,@isZeroBal";
                    string plstType = "8,18,18,18,8,8"; // {"8, 8, 8, 8, 8, 8"};
                    string plstValue = cboItemGrp.SelectedValue.ToString() + "," +
                        cboCategory.SelectedValue.ToString() + "," +
                       StrF01.D2Str(this.dtpFromDate.Value) + "," +
                        StrF01.D2Str(this.dtpToDate.Value) + "," +
                        cboGodown.SelectedValue.ToString() + "," +
                        (chkIsZeroBalance.Checked == true ? 0 : 1);

                    //dsLedgerNew pDs = new dsLedgerNew();

                    DataSet pDs = new DataSet();
                    CrTotalStockRepInOutSize rpt1 = new CrTotalStockRepInOutSize();

                    frmPrintVw6 rptCrTotalSockRepInOutSize = new frmPrintVw6(
                       fRptTitle,
                       StrF01.D2Str(this.dtpFromDate.Value),
                       StrF01.D2Str(this.dtpToDate.Value),
                       "sp_StokGroupInOutSize",
                       plstField,
                       plstType,
                       plstValue,
                       pDs,
                       rpt1,
                       "SP"
                       );
                    rptCrTotalSockRepInOutSize.Show();
                }
                else if (optSummary.Checked == true)
                {
                    string fRptTitle = this.Text;
                    string plstField = "@ItemGroup,@ItemCategory,@Godown,@FromDate,@ToDate,@isZeroBal";
                    string plstType = "8,18,8,18,18,8"; // {"8, 8, 8, 8, 8, 8"};
                    string plstValue = cboItemGrp.SelectedValue.ToString() + "," +
                        cboCategory.SelectedValue.ToString() + "," +
                        cboGodown.SelectedValue.ToString() + "," +
                       StrF01.D2Str(this.dtpFromDate.Value) + "," +
                        StrF01.D2Str(this.dtpToDate.Value) + "," +
                        (chkIsZeroBalance.Checked == true ? 0 : 1);

                    //dsLedgerNew pDs = new dsLedgerNew();

                    DataSet pDs = new DataSet();
                    CrTotalStockRepInOutSumry rpt1 = new CrTotalStockRepInOutSumry();

                    frmPrintVw6 rptCrTotalSockRepInOutSumry = new frmPrintVw6(
                       fRptTitle,
                       StrF01.D2Str(this.dtpFromDate.Value),
                       StrF01.D2Str(this.dtpToDate.Value),
                       "sp_StokGroupGod",
                       plstField,
                       plstType,
                       plstValue,
                       pDs,
                       rpt1,
                       "SP"
                       );
                    rptCrTotalSockRepInOutSumry.Show();
                }
                else if (optSummaryNegative.Checked == true||optPUS.Checked==true||optPUSRemainingOrder.Checked==true||optDetailCT.Checked==true)
                {
                    MessageBox.Show("No Report Found For Current Selection");
                }
            }
        }


       
    }
}
