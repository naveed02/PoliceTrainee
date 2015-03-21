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
using GUI_Task.StringFun01;
using GUI_Task.PrintDataSets;

namespace GUI_Task
{
    public partial class frmRptIssue : Form
    {
        int fcboDefaultValue = 0;
        public frmRptIssue()
        {
            InitializeComponent();
        }

        private void issue_Report_Load(object sender, EventArgs e)
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

            //Employee Combo Fill
            lSQL = " SELECT employeeid, first_name + ' ' + last_name AS EmpName FROM PR_Employee";
            lSQL += " order by EmpName";

            clsFillCombo.FillCombo(cboEmp, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboEmp.SelectedValue);


            //Department Combo Fill
            lSQL = "SELECT departmentid,department_name FROM PR_Department ";
            lSQL += " order by department_name";

            clsFillCombo.FillCombo(cboDept, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboDept.SelectedValue);

            //Item Group Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmItemGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGrp, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGrp.SelectedValue);

            //Machine No Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmMachineNo);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboMachineNo, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboMachineNo.SelectedValue);

            //Contractor Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmContractor);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboCont, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboCont.SelectedValue);

            //Godown Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmGodown);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboGodown, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboGodown.SelectedValue);
        }

        private void frmRptIssue_KeyDown(object sender, KeyEventArgs e)
        {
             
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (optIssueWithoutDept.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@EmployeeId,@DepartmentId,@ItemGroupID,@Machine,@Contract,@GodownId";
                string plstType = "18,18,8,8,8,8,8,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," +
                    this.cboEmp.SelectedValue.ToString() + "," +
                    this.cboDept.SelectedValue.ToString() + "," +
                    this.cboItemGrp.SelectedValue.ToString() + "," +
                    this.cboMachineNo.SelectedValue.ToString() + "," +
                    this.cboCont.SelectedValue.ToString() + "," +
                    this.cboGodown.SelectedValue.ToString();


                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrIssueDate rpt1 = new CrIssueDate();

                frmPrintVw6 rptIssueDate = new frmPrintVw6(
                   fRptTitle,
                   StrF01.D2Str(this.dtpFromDate.Value),
                   StrF01.D2Str(this.dtpToDate.Value),
                   "sp_IssueTotal",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptIssueDate.Show();
            }
            else if (optIssueWithDept.Checked == true)
            {
                string fRptTitle = this.Text;
                string plstField = "@FromDate,@ToDate,@EmployeeId,@DepartmentId,@ItemGroupID,@Machine,@Contract,@GodownId";
                string plstType = "18,18,8,8,8,8,8,8"; // {"8, 8, 8, 8, 8, 8"};
                string plstValue = StrF01.D2Str(this.dtpFromDate.Value) + "," +
                    StrF01.D2Str(this.dtpToDate.Value) + "," +
                    this.cboEmp.SelectedValue.ToString() + "," +
                    this.cboDept.SelectedValue.ToString() + "," +
                    this.cboItemGrp.SelectedValue.ToString() + "," +
                    this.cboMachineNo.SelectedValue.ToString() + "," +
                    this.cboCont.SelectedValue.ToString() + "," +
                    this.cboGodown.SelectedValue.ToString();


                //dsLedgerNew pDs = new dsLedgerNew();

                DataSet pDs = new DataSet();
                CrIssueDateDept rpt1 = new CrIssueDateDept();

                frmPrintVw6 rptIssueDateRate = new frmPrintVw6(
                   fRptTitle,
                   StrF01.D2Str(this.dtpFromDate.Value),
                   StrF01.D2Str(this.dtpToDate.Value),
                   "sp_IssueTotalDept",
                   plstField,
                   plstType,
                   plstValue,
                   pDs,
                   rpt1,
                   "SP"
                   );

                //rptLedger2.ShowDialog();
                rptIssueDateRate.Show();
            }
        }
    }

    
}