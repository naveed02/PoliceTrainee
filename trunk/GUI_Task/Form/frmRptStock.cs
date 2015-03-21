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
    public partial class frmRptStock : Form
    {
        int fcboDefaultValue = 0;
        public frmRptStock()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void stock_Report_Item_Wise_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            AtFormLoad();
        }
        private void AtFormLoad()
        {
            string lSQL = string.Empty;

            this.KeyPreview = true;

            //Item Group Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode="+Convert.ToString((int)Category.enmItemGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGrp, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGrp.SelectedValue);

            //Size Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode="+Convert.ToString((int)Category.enmSize);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboSize, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboSize.SelectedValue);

            //Color Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode="+Convert.ToString((int)Category.enmColor);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboColor, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboColor.SelectedValue);

            //Godown Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode="+Convert.ToString((int)Category.enmGodown);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboGodown, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboGodown.SelectedValue);

            //Department Combo Fill
            lSQL = "SELECT departmentid, department_name FROM PR_Department";

            clsFillCombo.FillCombo(cboDept, clsGVar.ConString1, "PR_Department" + "," + "DepartmentID" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboDept.SelectedValue);

            //Category Combo Fill
            lSQL = "SELECT distinct 1, RIGHT(ItemCode,1) FROM Item";

            clsFillCombo.FillCombo(cboCategory, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboCategory.SelectedValue);
        }

        private void frmRptStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (optAllGowdown.Checked == true)
            {
                if (chkDateWise.Checked == true)
                {
                    if (optStockDetail.Checked == true)
                    {
                        string fRptTitle = this.Text;
                        string plstField = "@ItemGroup,@ItemCategory,@FromDate,@ToDate";
                        string plstType = "8,18,18,18"; // {"8, 8, 8, 8, 8, 8"};
                        string plstValue = this.cboItemGrp.SelectedValue.ToString() + "," +
                            cboCategory.Text.ToString() + "," +
                            StrF01.D2Str(this.dtpFromDate.Value) + "," +
                            StrF01.D2Str(this.dtpToDate.Value);

                        //dsLedgerNew pDs = new dsLedgerNew();

                        DataSet pDs = new DataSet();
                        CrTotalStockRepDate rpt1 = new CrTotalStockRepDate();

                        frmPrintVw6 rptTotalStockRepDate = new frmPrintVw6(
                           fRptTitle,
                           StrF01.D2Str(this.dtpFromDate.Value),
                           StrF01.D2Str(this.dtpToDate.Value),
                           "sp_StokGroupDate",
                           plstField,
                           plstType,
                           plstValue,
                           pDs,
                           rpt1,
                           "SP"
                           );

                        //rptLedger2.ShowDialog();
                        rptTotalStockRepDate.Show();
                    }
                    else if (optStockSummary.Checked == true)
                    {
                        string fRptTitle = this.Text;
                        string plstField = "@ItemGroup,@ItemCategory,@FromDate,@ToDate";
                        string plstType = "8,18,18,18"; // {"8, 8, 8, 8, 8, 8"};
                        string plstValue = this.cboItemGrp.SelectedValue.ToString() + "," +
                            cboCategory.Text.ToString() + "," +
                            StrF01.D2Str(this.dtpFromDate.Value) + "," +
                            StrF01.D2Str(this.dtpToDate.Value);

                        //dsLedgerNew pDs = new dsLedgerNew();

                        DataSet pDs = new DataSet();
                        CrTotalStockRepDateSmry rpt1 = new CrTotalStockRepDateSmry();

                        frmPrintVw6 rptTotalStockRepDateSmry = new frmPrintVw6(
                           fRptTitle,
                           StrF01.D2Str(this.dtpFromDate.Value),
                           StrF01.D2Str(this.dtpToDate.Value),
                           "sp_StokGroupDate",
                           plstField,
                           plstType,
                           plstValue,
                           pDs,
                           rpt1,
                           "SP"
                           );

                        //rptLedger2.ShowDialog();
                        rptTotalStockRepDateSmry.Show();
                    }
                    else if (optStockValue.Checked == true)
                    {
                        string fRptTitle = this.Text;
                        string plstField = "@ItemGroup,@ItemCategory,@FromDate,@ToDate";
                        string plstType = "8,18,18,18"; // {"8, 8, 8, 8, 8, 8"};
                        string plstValue = this.cboItemGrp.SelectedValue.ToString() + "," +
                            cboCategory.Text.ToString() + "," +
                            StrF01.D2Str(this.dtpFromDate.Value) + "," +
                            StrF01.D2Str(this.dtpToDate.Value);

                        //dsLedgerNew pDs = new dsLedgerNew();

                        DataSet pDs = new DataSet();
                        CrTotalStockRepDateSmry rpt1 = new CrTotalStockRepDateSmry();

                        frmPrintVw6 rptTotalStockRepDateRate = new frmPrintVw6(
                           fRptTitle,
                           StrF01.D2Str(this.dtpFromDate.Value),
                           StrF01.D2Str(this.dtpToDate.Value),
                           "sp_StokGroupDateRate",
                           plstField,
                           plstType,
                           plstValue,
                           pDs,
                           rpt1,
                           "SP"
                           );
                        rptTotalStockRepDateRate.Show();
                    }
                    else if (optWIPItemGroup.Checked == true)
                    {
                        string fRptTitle = this.Text;
                        string plstField = "@ItemGroup,@DeptID,@FromDate,@ToDate";
                        string plstType = "8,8,18,18"; // {"8, 8, 8, 8, 8, 8"};
                        string plstValue = this.cboItemGrp.SelectedValue.ToString() + "," +
                            cboDept.SelectedValue.ToString() + "," +
                            StrF01.D2Str(this.dtpFromDate.Value) + "," +
                            StrF01.D2Str(this.dtpToDate.Value);

                        //dsLedgerNew pDs = new dsLedgerNew();

                        DataSet pDs = new DataSet();
                        CrWIPWoDept rpt1 = new CrWIPWoDept();

                        frmPrintVw6 rptWIPDept = new frmPrintVw6(
                           fRptTitle,
                           StrF01.D2Str(this.dtpFromDate.Value),
                           StrF01.D2Str(this.dtpToDate.Value),
                           "sp_WIPWoDept",
                           plstField,
                           plstType,
                           plstValue,
                           pDs,
                           rpt1,
                           "SP"
                           );
                        rptWIPDept.Show();
                    }
                    else if (optWIPDeptBalance.Checked == true)
                    {
                        string fRptTitle = this.Text;
                        string plstField = "@ItemGroup,@DeptID,@FromDate,@ToDate";
                        string plstType = "8,8,18,18"; // {"8, 8, 8, 8, 8, 8"};
                        string plstValue = this.cboItemGrp.SelectedValue.ToString() + "," +
                            cboDept.SelectedValue.ToString() + "," +
                            StrF01.D2Str(this.dtpFromDate.Value) + "," +
                            StrF01.D2Str(this.dtpToDate.Value);

                        //dsLedgerNew pDs = new dsLedgerNew();

                        DataSet pDs = new DataSet();
                        CrWIPWoDept rpt1 = new CrWIPWoDept();

                        frmPrintVw6 rptWIPWoDept = new frmPrintVw6(
                           fRptTitle,
                           StrF01.D2Str(this.dtpFromDate.Value),
                           StrF01.D2Str(this.dtpToDate.Value),
                           "sp_WIPDept",
                           plstField,
                           plstType,
                           plstValue,
                           pDs,
                           rpt1,
                           "SP"
                           );
                        rptWIPWoDept.Show();
                    }
                    else if (optWIPAllItemBal.Checked == true)
                    {
                        string fRptTitle = this.Text;
                        string plstField = "@ItemGroup,@DeptID,@FromDate,@ToDate";
                        string plstType = "8,8,18,18"; // {"8, 8, 8, 8, 8, 8"};
                        string plstValue = this.cboItemGrp.SelectedValue.ToString() + "," +
                            cboDept.SelectedValue.ToString() + "," +
                            StrF01.D2Str(this.dtpFromDate.Value) + "," +
                            StrF01.D2Str(this.dtpToDate.Value);

                        //dsLedgerNew pDs = new dsLedgerNew();

                        //DataSet pDs = new DataSet();
                        //CrWIPAllItem rpt1 = new CrWIPAllItem();

                        //frmPrintVw6 rptWIPAllItem = new frmPrintVw6(
                        //   fRptTitle,
                        //   StrF01.D2Str(this.dtpFromDate.Value),
                        //   StrF01.D2Str(this.dtpToDate.Value),
                        //   "sp_WIPDept",
                        //   plstField,
                        //   plstType,
                        //   plstValue,
                        //   pDs,
                        //   rpt1,
                        //   "SP"
                        //   );
                        //rptWIPAllItem.Show();
                    }
                    else if (optWIPAllItemDeptBal.Checked == true)
                    {
                        string fRptTitle = this.Text;
                        string plstField = "@ItemGroup,@DeptID,@FromDate,@ToDate";
                        string plstType = "8,8,18,18"; // {"8, 8, 8, 8, 8, 8"};
                        string plstValue = this.cboItemGrp.SelectedValue.ToString() + "," +
                            cboDept.SelectedValue.ToString() + "," +
                            StrF01.D2Str(this.dtpFromDate.Value) + "," +
                            StrF01.D2Str(this.dtpToDate.Value);

                        //dsLedgerNew pDs = new dsLedgerNew();

                        //DataSet pDs = new DataSet();
                        //CrWIPAllItemDept rpt1 = new CrWIPAllItemDept();

                        //frmPrintVw6 rptWIPAllItemDept = new frmPrintVw6(
                        //   fRptTitle,
                        //   StrF01.D2Str(this.dtpFromDate.Value),
                        //   StrF01.D2Str(this.dtpToDate.Value),
                        //   "sp_WIPDept",
                        //   plstField,
                        //   plstType,
                        //   plstValue,
                        //   pDs,
                        //   rpt1,
                        //   "SP"
                        //   );
                        //rptWIPAllItemDept.Show();
                    }
                }
                else if (chkDateWise.Checked == false)
                {
                    MessageBox.Show("Please Check 'Date Wise' For Viewing Report");
                }
            }
            else if (optGodownWise.Checked == true)
            {
                MessageBox.Show("No Report Found For Current Selection");
            }
        }
        #region PopulateRecords
        //Populate Recordset 
        private void PopulateRecords()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  

            tSQL = "SELECT * ";
            tSQL += " FROM CatDtl WHERE cgCode= " + cboCategory.SelectedValue.ToString();
            tSQL += " AND cgdCode= " + txtItemCode.Text.ToString();

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "CatDtl");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    lblItemName.Text = (ds.Tables[0].Rows[0]["cgdDesc"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["cgdDesc"].ToString());
                    //dtpOrder.Value = (ds.Tables[0].Rows[0]["doc_date"] == DBNull.Value ? DateTime.Now.ToString("T") : ds.Tables[0].Rows[0]["doc_date"]);
                    lblItemName.Text = (ds.Tables[0].Rows[0]["UName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["UName"].ToString());
                    //mskCustomerCode.Text = (ds.Tables[0].Rows[0]["Customer"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Customer"].ToString());
                    //lblName.Text = (ds.Tables[0].Rows[0]["CustName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CustName"].ToString());
                    //txtBillNo.Text = (ds.Tables[0].Rows[0]["BillNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BillNo"].ToString());
                    //txtOrderStatus.Text = (ds.Tables[0].Rows[0]["Status"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Status"].ToString());
                    //txtSaleType.Text = (ds.Tables[0].Rows[0]["Type"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Type"].ToString());
                    //txtDetail.Text = (ds.Tables[0].Rows[0]["Detail"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Detail"].ToString());

                    //cboTransport.Text = (ds.Tables[0].Rows[0]["AddaId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["AddaId"].ToString());
                    //clsSetCombo.Set_ComboBox(cboTransport, Convert.ToInt32(ds.Tables[0].Rows[0]["AddaId"]));
                    //clsSetCombo.Set_ComboBox(cboItemGroup, Convert.ToInt32(ds.Tables[0].Rows[0]["ItemGroupID"]));


                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Item Code...", this.Text.ToString());
            }
        }
        #endregion

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc1();
            }
        }

        private void txtItemCode_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc1();
        }

        #region LookUp_Voc1

        private void LookUp_Voc1()
        {

            //string pSource,
            //int pRow,
            //int pCol

            // MessageBox.Show("Lookup Source: " + pSource);

            // 1- KeyField
            // 2- Field List
            // 3- Table Name
            // 4- Form Title
            // 5- Default Find Field (Int) 0,1,2,3 etc Default = 1 = title field
            // 6- Grid Title List
            // 7- Grid Title Width
            // 8- Grid Title format T = Text, N = Numeric etc
            // 9- Bool One Table = True, More Then One = False
            // 10 Join String Otherwise Empty String.
            // 11 Optional Where
            // 11 Return Control Type TextBox or MaskedTextBox Default mtextBox
            //

            frmLookUp sForm = new frmLookUp(
                    "i.ItemId",
                    "i.ItemCode,i.Name, u.UnitName",
                    "Item i INNER JOIN IMS_UOM u ON i.UOMId = u.UOMID",
                    this.Text.ToString(),
                    1,
                    "Item ID, Item Code, Item Name,Unit Name",
                    "8,12,20,12",
                    " T, T, T, T",
                    true,
                    "",
                    "",
                    "TextBox"
                    );
            txtItemCode.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID1);
            sForm.ShowDialog();

            if (txtItemCode.Text != null)
            {
                if (txtItemCode.Text != null)
                {
                    if (txtItemCode.Text.ToString() == "" || txtItemCode.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtItemCode.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecords1();
                    }
                }
            }
        }
        #endregion

        private void PassDataVocID1(object sender)
        {
            txtItemCode.Text = ((TextBox)sender).Text;
        }

        #region PopulateRecords1
        //Populate Recordset 
        private void PopulateRecords1()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  

            tSQL = "SELECT i.ItemId, i.ItemCode, i.Name AS ItemName, u.UnitName ";
            tSQL += " FROM Item i INNER JOIN IMS_UOM u ON i.UOMId = u.UOMID ";
            tSQL += " where i.ItemCode ='" + txtItemCode.Text.ToString() + "';";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "Item");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    txtItemCode.Text = (ds.Tables[0].Rows[0]["ItemId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemId"].ToString());
                    lblItemName.Text = (ds.Tables[0].Rows[0]["Name"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Name"].ToString());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Item Code...", this.Text.ToString());
            }
        }
        #endregion


    }
}
