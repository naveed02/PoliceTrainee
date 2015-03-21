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
    public partial class frmRptMachineProd : Form
    {
        int fcboDefaultValue = 0;
        public frmRptMachineProd()
        {
            InitializeComponent();
        }

        private void machine_Production_Report_Load(object sender, EventArgs e)
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

            //Contractor Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmMachineNo);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboMachineNo, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboMachineNo.SelectedValue);
        }

        private void frmRptMachineProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (optDetail.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@Machine";
                string plstType = "18,18,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," + this.cboMachineNo.SelectedValue;

                
                DataSet pDs = new DataSet();
                CrMachProd rpt1 = new CrMachProd();

                frmPrintVw6 rptLedger2 = new frmPrintVw6(
                   fRptTitle,
                   StrF01.D2Str(this.dtpFromDate.Value),
                   StrF01.D2Str(this.dtpToDate.Value),
                   "sp_Mach_ProdDetail",
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
            else if (optItemWise.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@Machine";
                string plstType = "18,18,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," + this.cboMachineNo.SelectedValue;


                DataSet pDs = new DataSet();
                CrMachProdItem rpt1 = new CrMachProdItem();

                frmPrintVw6 rptLedger2 = new frmPrintVw6(
                   fRptTitle,
                   StrF01.D2Str(this.dtpFromDate.Value),
                   StrF01.D2Str(this.dtpToDate.Value),
                   "sp_Mach_Prod",
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
}
