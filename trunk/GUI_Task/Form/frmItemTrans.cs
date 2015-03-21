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
    public partial class frmItemTrans : Form
    {
        int fcboDefaultValue = 0;
        bool blnFormLoad = true;
        public frmItemTrans()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LookUp_Voc();
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
            lSQL = "SELECT departmentid, department_name FROM PR_Department Order By DepartmentID";

            clsFillCombo.FillCombo(cboDept, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboDept.SelectedValue);

        }

        private void frmItemTrans_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        #region LookUp_Voc

        private void LookUp_Voc()
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
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID);
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
                        PopulateRecords();
                    }
                }
            }
        }
        #endregion

        private void PassDataVocID(object sender)
        {
            txtItemCode.Text = ((TextBox)sender).Text;
        }

        #region PopulateRecords
        //Populate Recordset 
        private void PopulateRecords()
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
                    lblName.Text = (ds.Tables[0].Rows[0]["ItemName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ItemName"].ToString());
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

        private void frmItemTrans_Load(object sender, EventArgs e)
        {
            blnFormLoad = false;
            AtFormLoad();
            this.MaximizeBox = false;
        }

        private void txtItemCode_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                LookUp_Voc();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string fRptTitle = this.Text;
        string plstField = "@ItemCode,@SizeID,@ColorID,@Godown,@Dept,@FromDate,@ToDate";
            string plstType = "8,8,8,8,8,18,18"; // {"8, 8, 8, 8, 8, 8"};
            string plstValue = txtItemCode.Text.ToString() + ",0,0,0,0" + "," +
                StrF01.D2Str(this.dtpFromDate.Value) + "," +
                StrF01.D2Str(this.dtpToDate.Value);

            //dsLedgerNew pDs = new dsLedgerNew();

            DataSet pDs = new DataSet();
            CrItemTrans rpt1 = new CrItemTrans();

            frmPrintVw6 rptItemTrans = new frmPrintVw6(
               fRptTitle,
               StrF01.D2Str(this.dtpFromDate.Value),
               StrF01.D2Str(this.dtpToDate.Value),
               "sp_ItemDetail",
               plstField,
               plstType,
               plstValue,
               pDs,
               rpt1,
               "SP"
               );
            rptItemTrans.Show();
        }

        }


            
    }
