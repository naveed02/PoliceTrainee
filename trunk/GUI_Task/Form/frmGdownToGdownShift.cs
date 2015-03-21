using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI_Task.Class;

namespace GUI_Task
{
    public partial class frmGdownToGdownShift : Form
    {
        //******* Grid Variable Setting -- Begin ******
        string fHDR = string.Empty;                       // Column Header
        string fColWidth = string.Empty;                  // Column Width (Input)
        string fColMinWidth = string.Empty;               // Column Minimum Width
        string fColMaxInputLen = string.Empty;            // Column Visible Length/Width 
        string fColFormat = string.Empty;                 // Column Format  
        string fColReadOnly = string.Empty;               // Column ReadOnly 1 = ReadOnly, 0 = Read-Write  
        string fFieldList = string.Empty;

        string fColType = string.Empty;
        string fFieldName = string.Empty;
        //******* Grid Variable Setting -- End ******

        string[] a_Color = new string[0];
        int[] a_ColorInt = new int[0];

        string[] a_Size = new string[0];
        int[] a_SizeInt = new int[0];
        int fcboDefaultValue = 0;
        public frmGdownToGdownShift()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGdownToGdownShift_Load(object sender, EventArgs e)
       {
            AtFormLoad();
           // blnFormLoad = false;
            this.MaximizeBox = false;

        }

        private void AtFormLoad()
        {
            string lSQL = string.Empty;
            //dtpOrder.Value = now.;
            //msk_VocDate.Text = now.Date.ToString();

            this.KeyPreview = true;

            //Item group cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmItemGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGroup, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGroup.SelectedValue);


          

            //FromGodown cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmGodown);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboFromGodown, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboFromGodown.SelectedValue);

            //ToGodown cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmGodown);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboToGodown, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboToGodown.SelectedValue);

        }

        private void frmGdownToGdownShift_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
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
            //select doc_id, doc_strid, doc_date, doc_remarks, doc_amt 
            //from gl_tran
            //where doc_vt_id=1 and doc_fiscal_id=1

            //SELECT d.Ord_No, d.Cont_No, d.Ord_Date, h.Name AS CustName, d.Qty, d.Amount, d.Category
            //FROM Ord_Det d INNER JOIN Heads h ON d.Customer=h.Code
            //WHERE d.Category = 1
            //                    "d.DNId",
            //                    "d.Date, ig.cgdDesc AS ItemGroupName, pd.department_name, " 
            //                    + "pe.first_name + ' ' + pe.last_name AS EmpName, d.Note ",
            //                    "DN d INNER JOIN CatDtl ig ON d.ItemGroupId=ig.cgdCode AND ig.cgCode=6 "
            //                    + "INNER JOIN PR_Department pd ON d.DepartmentId=pd.departmentid " 
            //                    + "INNER JOIN PR_Employee pe ON d.EmployeeId=pe.employeeid",
            //                    this.Text.ToString(),
            //                    1,
            //                    "DN#,Date,Item Group Name,Department Name,Employee Name,Note ",
            //                    "10,8,12,12,12,15",
            //                    " T, T, T, T, T, T",
            //                    true,
            //                    "",

            //"sl.StockLevelId",
            //   " sl.Date, cd.cgdDesc AS ItemGroupName, sl.Note ",
            //   "  StockLevel sl inner join StockLevelDetail sld on sl.StockLevelId=sld.StockLevelId "
            //   + " inner join CatDtl cd on sl.ItemGroupID=cd.cgdCode AND cd.cgCode=6",
            //       this.Text.ToString(),
            //       1,
            //       "Stock #,Date,Item Group Name,Note",
            //       "12,8,15,20",
            //       " T, T, T, T",
            //       true,
            //       "",
            //   //"d.Category = " + cboMainGroup.SelectedValue.ToString(), 
            //       "",
            //       "TextBox"
            //       );

            // select g.GtoGId, g.Date, g.FromGodownId AS FromGodownName, g.ToGodownId AS ToGodownName,
            // g.Note, g.ItemGroup
            //from GtoG g
            //inner join GtoGDetail gd on g.GtoGId=gd.GtoGId

            frmLookUp sForm = new frmLookUp(
                    "g.GtoGId",
                " g.Date, G.FromGodownId AS FromGodownName,  g.ToGodownId AS ToGodownName, g.Note, g.ItemGroup ",
                "GtoG g inner join GtoGDetail gd on g.GtoGId=gd.GtoGId ",
                //" Inv_CashDet d inner join Heads h on d.Customer = h.Code ",
                    this.Text.ToString(),
                    1,
                    "G to G ID ,G to G Date, From Godown, To Godown, Note, Item Group",
                   "8,8,15,15,20,15",
                    " T, T, T, T, T, T",
                    true,
                    "",
                //"d.Category = " + cboMainGroup.SelectedValue.ToString(), 
                    "",
                    "TextBox"
                    );
            txtFinishReceNo.Text = string.Empty;
            sForm.lupassControl = new frmLookUp.LUPassControl(PassDataVocID);
            sForm.ShowDialog();

            if (txtFinishReceNo.Text != null)
            {
                if (txtFinishReceNo.Text != null)
                {
                    if (txtFinishReceNo.Text.ToString() == "" || txtFinishReceNo.Text.ToString() == string.Empty)
                    {
                        return;
                    }
                    if (txtFinishReceNo.Text.ToString().Trim().Length > 0)
                    {
                        PopulateRecords();
                        //LoadSampleData();
                        //SumVoc();
                    }

                    //txtOrderNo.Text = txtPassDataVocID.Text.ToString();
                    //grdVoucher[pCol, pRow].Value = tmtext.Text.ToString();
                    //System.Windows.Forms.SendKeys.Send("{TAB}");
                }

                //if (msk_AccountID.Text.ToString() == "" || msk_AccountID.Text.ToString() == string.Empty)
                //{
                //    return;
                //}
                //msk_AccountID.Text = sForm.lupassControl.ToString();
                ////grdVoucher[pCol, pRow].Value = msk_AccountID.Text.ToString();
                //System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }
        #endregion

        private void PassDataVocID(object sender)
        {
            //txtPassDataVocID.Text = ((TextBox)sender).Text;
            txtFinishReceNo.Text = ((TextBox)sender).Text;
            //msk_VocCode.Text = ((MaskedTextBox)sender).Text;
        }

        #region PopulateRecords
        //Populate Recordset 
        private void PopulateRecords()
        {
            DataSet ds = new DataSet();
            DataRow dRow;
            string tSQL = string.Empty;

            // Fields 0,1,2,3 are Begin  

            //tSQL = "select sl.StockLevelId, sl.Date, cd.cgdDesc AS ItemGroupName, sl.Note ";
            //tSQL += "from StockLevel sl inner join StockLevelDetail sld on sl.StockLevelId=sld.StockLevelId";
            //tSQL += "inner join CatDtl cd on sl.ItemGroupID=cd.cgdCode AND cd.cgCode=6";
            //tSQL += " where sl.StockLevelId='" + txtStockLevelNo.Text.ToString() + "';";
            
            //select g.GtoGId, g.Date, g.FromGodownId AS FromGodownName, g.ToGodownId AS ToGodownName,
            // g.Note, g.ItemGroup
            //from GtoG g
            //inner join GtoGDetail gd on g.GtoGId=gd.GtoGId


            tSQL = "select g.GtoGId, g.Date, g.FromGodownId AS FromGodownName, g.ToGodownId AS ToGodownName, g.Note, g.ItemGroup";
            tSQL += " from GtoG g ";
            tSQL += " inner join GtoGDetail gd on g.GtoGId=gd.GtoGId  ";
            tSQL += " where g.GtoGId ='" + txtFinishReceNo.Text.ToString() + "';";

            try
            {
                ds = clsDbManager.GetData_Set(tSQL, "GtoG");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //fAlreadyExists = true;
                    dRow = ds.Tables[0].Rows[0];
                    // Starting title as 0
                    txtFinishReceNo.Text = (ds.Tables[0].Rows[0]["GtoGId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Inv_No"].ToString());
                    //dtpDate.Value = (ds.Tables[0].Rows[0]["Inv_Date"] == DBNull.Value ? DateTime.Now.ToString("T") : Convert.ToDateTime(ds.Tables[0].Rows[0]["Inv_Date"]));
                    dtpDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["Date"]);
                    //txtDebitCode.Text = (ds.Tables[0].Rows[0]["Customer"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Customer"].ToString());
                    //lblDescription.Text = (ds.Tables[0].Rows[0]["CustomerName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["CustomerName"].ToString());
                    // txtStockLevelNo.Text = (ds.Tables[0].Rows[0]["StockLevel"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["StockLevel"].ToString());
                    //txtBillNo.Text = (ds.Tables[0].Rows[0]["BillNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BillNo"].ToString());
                    //txtOrderStatus.Text = (ds.Tables[0].Rows[0]["Status"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Status"].ToString());
                    //txtSaleType.Text = (ds.Tables[0].Rows[0]["Type"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Type"].ToString());
                    //txtDetail.Text = (ds.Tables[0].Rows[0]["Detail"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Detail"].ToString());

                    //cboTransport.Text = (ds.Tables[0].Rows[0]["AddaId"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["AddaId"].ToString());
                    //clsSetCombo.Set_ComboBox(cboAdda, Convert.ToInt32(ds.Tables[0].Rows[0]["AddaId"]));
                    //clsSetCombo.Set_ComboBox(cboItemGroup, Convert.ToInt32(ds.Tables[0].Rows[0]["ItemGroupID"]));


                    //msk_AccountID.Tag = (ds.Tables[0].Rows[0]["GLID"] == DBNull.Value ? "0" : ds.Tables[0].Rows[0]["GLID"].ToString());
                    //if (ds.Tables[0].Rows[0]["Doc_Status"] != DBNull.Value)
                    //{
                    //    chkComplete.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Doc_Status"]);
                    //    //chkIsDisabled.Checked = Convert.ToBoolean(dRow.ItemArray.GetValue(3).ToString());
                    //}
                    //else
                    //{
                    //    chkComplete.Checked = false;
                    //}

                    //fEditMod = true;

                    //chkComplete.Checked = (ds.Tables[0].Rows[0]["Doc_Status"]==DBNull.Value ? "0" : ds.Tables[0].Rows[0]["Doc_Status"].ToString());
                    //txtContract.Text = (ds.Tables[0].Rows[0]["ContractNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["ContractNo"].ToString());

                    //txtBiltyNo.Text = (ds.Tables[0].Rows[0]["BiltyNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BiltyNo"].ToString());
                    //txtBiltyDate.Text = (ds.Tables[0].Rows[0]["BiltyDate"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["BiltyDate"].ToString());
                    //txtVehicleNo.Text = (ds.Tables[0].Rows[0]["VehicleNo"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["VehicleNo"].ToString());
                    //txtDriverName.Text = (ds.Tables[0].Rows[0]["DriverName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["DriverName"].ToString());

                    //int tcboTransportID = 0;
                    //tcboTransportID = Convert.ToInt16(ds.Tables[0].Rows[0]["TransportID"].ToString());
                    //cboTransport.SelectedIndex = ClassSetCombo.Set_ComboBox(cboTransport, tcboTransportID);

                    //tFirstID = Convert.ToInt16(dRow.ItemArray.GetValue(3).ToString());
                    //cboFirstID.SelectedIndex = ClassSetCombo.Set_ComboBox(cboFirstID, tFirstID);

                    //cboTransport.Text = (ds.Tables[0].Rows[0]["TransportID"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["TransportID"].ToString());

                    //grdVoucher.DataSource = ds.Tables[1];
                    //grdVoucher.Visible = true;
                    //lblAccountName.Text = dRow.ItemArray.GetValue(0).ToString();
                    //lblAcID.Text = dRow.ItemArray.GetValue(1).ToString();

                    //if (grdVoucher.RowCount > 1)
                    //{
                    //    grdVoucher.Rows.Clear();
                    //    grdVoucher.Columns.Clear();
                    //}
                    //grdVoucher.Visible = false;
                    //grdVoucher.Rows.Clear();
                    //grdVoucher.Columns.Clear();

                    //grdVoucher.DataSource = ds.Tables[1];
                    //grdVoucher.Visible = true;

                    //grdVoucher.Rows.Clear();
                    //grdVoucher.Columns.Clear();
                    ////
                    //for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    //{
                    //    dRow = ds.Tables[1].Rows[i];
                    //    // **** Following Two Rows may get data one time *****
                    //    //         dGvDetail.DataSource = Zdtset.Tables[0];
                    //    //         dGvDetail.Visible = true;
                    //    // **** Following Two Rows may get data one time *****
                    //    //grdVoucher.Columns = 17;

                    //    grdVoucher.Rows.Add(
                    //        (dRow.ItemArray.GetValue((int)GColInv.ItemID) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColInv.ItemID).ToString()),                       // 0-
                    //        (dRow.ItemArray.GetValue((int)GColInv.ItemName) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColInv.ItemName).ToString()),                           // 1-
                    //        (dRow.ItemArray.GetValue((int)GColInv.UOMID) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColInv.UOMID).ToString()),                           // 1-
                    //        (dRow.ItemArray.GetValue((int)GColInv.UOMName) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColInv.UOMName).ToString()),                             // 3-
                    //        (dRow.ItemArray.GetValue((int)GColInv.GodownID) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColInv.GodownID).ToString()),                          // 4-
                    //        (dRow.ItemArray.GetValue((int)GColInv.GodownName) == DBNull.Value ? "" : dRow.ItemArray.GetValue((int)GColInv.GodownName).ToString()),                          // 5-
                    //        (dRow.ItemArray.GetValue((int)GColInv.Qty) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.Qty).ToString()),                            // 6-
                    //        (dRow.ItemArray.GetValue((int)GColInv.Rate) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.Rate).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColInv.Bundle) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.Bundle).ToString()),                           // 10-
                    //        (dRow.ItemArray.GetValue((int)GColInv.MeshTotal) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.MeshTotal).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColInv.Amount) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.Amount).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColInv.isBundle) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.isBundle).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColInv.isMesh) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.isMesh).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColInv.Length) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.Length).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColInv.LenDec) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.LenDec).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColInv.Width) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.Width).ToString()),                            // 9-
                    //        (dRow.ItemArray.GetValue((int)GColInv.WidDec) == DBNull.Value ? "0" : dRow.ItemArray.GetValue((int)GColInv.WidDec).ToString())                            // 9-
                    //        );
                    //    //dGvDetail.Columns[1].ReadOnly = true;  // working
                    //}
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Clear();
                        //btn_EnableDisable(true);
                    }
                    //PopulateGridData();
                    //LoadGridData();
                    //txtManualDoc.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Unable to Get Order No...", this.Text.ToString());
            }
        }
        #endregion


        #region Color ForeGround/Background

        //private class CellBackColorAlternate : SourceGrid.Cells.Views.Cell
        //{
        //    public CellBackColorAlternate(Color firstColor, Color secondColor)
        //    {
        //        FirstBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(firstColor);
        //        SecondBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(secondColor);
        //    }

        //    private DevAge.Drawing.VisualElements.IVisualElement mFirstBackground;
        //    public DevAge.Drawing.VisualElements.IVisualElement FirstBackground
        //    {
        //        get { return mFirstBackground; }
        //        set { mFirstBackground = value; }
        //    }

        //    private DevAge.Drawing.VisualElements.IVisualElement mSecondBackground;
        //    public DevAge.Drawing.VisualElements.IVisualElement SecondBackground
        //    {
        //        get { return mSecondBackground; }
        //        set { mSecondBackground = value; }
        //    }

        //    protected override void PrepareView(SourceGrid.CellContext context)
        //    {
        //        base.PrepareView(context);

        //        if (Math.IEEERemainder(context.Position.Row, 2) == 0)
        //            Background = FirstBackground;
        //        else
        //            Background = SecondBackground;
        //    }
        //}

        //private class CheckBoxBackColorAlternate : SourceGrid.Cells.Views.CheckBox
        //{
        //    public CheckBoxBackColorAlternate(Color firstColor, Color secondColor)
        //    {
        //        FirstBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(firstColor);
        //        SecondBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(secondColor);
        //    }

        //    private DevAge.Drawing.VisualElements.IVisualElement mFirstBackground;
        //    public DevAge.Drawing.VisualElements.IVisualElement FirstBackground
        //    {
        //        get { return mFirstBackground; }
        //        set { mFirstBackground = value; }
        //    }

        //    private DevAge.Drawing.VisualElements.IVisualElement mSecondBackground;
        //    public DevAge.Drawing.VisualElements.IVisualElement SecondBackground
        //    {
        //        get { return mSecondBackground; }
        //        set { mSecondBackground = value; }
        //    }

        //    protected override void PrepareView(SourceGrid.CellContext context)
        //    {
        //        base.PrepareView(context);

        //        if (Math.IEEERemainder(context.Position.Row, 2) == 0)
        //            Background = FirstBackground;
        //        else
        //            Background = SecondBackground;
        //    }

        //}
        #endregion

        private void chkReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            //DataSet ds = new DataSet();
            //string tSQL = string.Empty;
            //tSQL = "SELECT cgdDesc FROM CatDtl WHERE cgCode=" + Convert.ToString((int)Category.enmColor);
            //ds = clsDbManager.GetData_Set(tSQL, "CatDtl");
            //int count = ds.Tables[0].Rows.Count;
            //string[] a_Color = new string[count];

            //for (int i = 0; i < count; i++)
            //{
            //    a_Color[i] = ds.Tables[0].Rows[i]["cgdDesc"].ToString();
            //}
            //ds.Dispose();
            //ds.Clear();

            //SourceGrid.Cells.Editors.EditorBase mEditor_Color;
            //mEditor_Color = new SourceGrid.Cells.Editors.ComboBox(typeof(string), a_Color, false);
            //mEditor_Color.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.AnyKey | SourceGrid.EditableMode.SingleClick;

            //for (int r = 1; r < grid1.RowsCount - 1; r++)
            //    for (int c = 0; c < grid1.ColumnsCount; c++)
            //    {
            //        if (grid1[2, 3].Editor != null)
            //            grid1[2, 4].Editor.EnableEdit = true;
            //        //grid1[r, c].Editor.EnableEdit = !chkReadOnly.Checked;
            //    }
        }


        private void SettingGridVariable()
        {
            string lHDR = "";                       // Column Header
            string lColWidth = "";                  // Column Width (Input)
            string lColMinWidth = "";               // Column Minimum Width
            string lColMaxInputLen = "";            // Column Visible Length/Width 
            string lColFormat = "";                 // Column Format  
            string lColReadOnly = "";               // Column ReadOnly 1 = ReadOnly, 0 = Read-Write  
            string lFieldList = "";
            string tColType = "";
            string tFieldName = "";


            //
            lFieldList = "Code";                    // 0-    ItemID";       
            lFieldList += ",ItemCode";                // 1-    ItemCode";     
            lFieldList += ",Name";                  // 2-    ItemName";     
            lFieldList += ",SizeName";              // 3-    SizeID";       
            lFieldList += ",ColorName";             // 5-    ColorID";      
            lFieldList += ",UOMID";               // 6-    UOMID";        
            lFieldList += ",Description";           // 7-    Discount";     
            //lFieldList += ",ContQty";             // 8-    ContQty";      
            //lFieldList += ",OrdQty";              // 9-    OrdQty";       
            lFieldList += ",ContRemQty";          // 10    ContRemQty";   
            lFieldList += ",Del_Qty";             // 11    Del_Qty";      
            //lFieldList += ",OrdUnDelQty";         // 12    OrdUnDelQty";  
            //lFieldList += ",Rate";                // 13    Rate";         
            //lFieldList += ",Amount";              // 14    Amount";       
            //lFieldList += ",AvailBal";            // 15    AvailBal";     


            lHDR += "Item ID";            // 0-    ItemID";       
            lHDR += ",Item Code";         // 1-    ItemCode";     
            lHDR += ",Item Name";         // 2-    ItemName";     
            lHDR += ",Size";              // 3-    SizeID";       
            lHDR += ",Color";             // 5-    ColorID";      
            lHDR += ",UOM ID";            // 6-    UOMID";        
            lHDR += ",Discount";          // 7-    Discount";     
            //lHDR += ",Cont.Qty";          // 8-    ContQty";      
            //lHDR += ",Ord.Qty";           // 9-    OrdQty";       
            lHDR += ",Cont.Rem.Qty";      // 10    ContRemQty";   
            lHDR += ",Del.Qty";           // 11    Del_Qty";      
            //lHDR += ",Ord.UnDel.Qty";     // 12    OrdUnDelQty";  
            //lHDR += ",Rate";              // 13    Rate";         
            //lHDR += ",Amount";            // 14    Amount";       
            //lHDR += ",AvailBal";          // 15    AvailBal";     

            // Col Visible Width
            lColWidth = "   5";                // 0-    ItemID";       
            lColWidth += ",12";                // 1-    ItemCode";     
            lColWidth += ", 20";                // 2-    ItemName";     
            lColWidth += ", 7";                // 3-    SizeID";       
            lColWidth += ", 7";                // 5-    ColorID";      
            lColWidth += ", 7";                // 6-    UOMID";        
            lColWidth += ", 7";                // 7-    Discount";     
            //lColWidth += ", 7";                // 8-    ContQty";      
            //lColWidth += ", 7";                // 9-    OrdQty";       
            lColWidth += ", 7";                // 10    ContRemQty";   
            lColWidth += ", 7";                // 11    Del_Qty";      
            //lColWidth += ", 7";                // 12    OrdUnDelQty";  
            //lColWidth += ", 7";                // 13    Rate";         
            //lColWidth += ", 10";               // 14    Amount";       
            //lColWidth += ", 7";                // 15    AvailBal";     

            // Column Input Length/Width
            lColMaxInputLen = "  0";                // 0-    ItemID";       
            lColMaxInputLen += ", 0";               // 1-    ItemCode";     
            lColMaxInputLen += ", 0";               // 2-    ItemName";     
            lColMaxInputLen += ", 0";               // 3-    SizeID";       
            lColMaxInputLen += ", 0";               // 5-    ColorID";      
            lColMaxInputLen += ", 0";               // 6-    UOMID";        
            lColMaxInputLen += ", 0";               // 7-    Discount";     
            //lColMaxInputLen += ", 0";               // 8-    ContQty";      
            //lColMaxInputLen += ", 0";               // 9-    OrdQty";       
            lColMaxInputLen += ", 0";               // 10    ContRemQty";   
            lColMaxInputLen += ", 0";               // 11    Del_Qty";      
            //lColMaxInputLen += ", 0";               // 12    OrdUnDelQty";  
            //lColMaxInputLen += ", 0";               // 13    Rate";         
            //lColMaxInputLen += ", 0";               // 14    Amount";       
            //lColMaxInputLen += ", 0";               // 15    AvailBal";     

            // Column Min Width
            lColMinWidth = "   0";                      // 0-    ItemID";       
            lColMinWidth += ", 0";                      // 1-    ItemCode";     
            lColMinWidth += ", 0";                      // 2-    ItemName";     
            lColMinWidth += ", 0";                      // 3-    SizeID";       
            lColMinWidth += ", 0";                      // 5-    ColorID";      
            lColMinWidth += ", 0";                      // 6-    UOMID";        
            lColMinWidth += ", 0";                      // 7-    Discount";     
            //lColMinWidth += ", 0";                      // 8-    ContQty";      
            //lColMinWidth += ", 0";                      // 9-    OrdQty";       
            lColMinWidth += ", 0";                      // 10    ContRemQty";   
            lColMinWidth += ", 0";                      // 11    Del_Qty";      
            //lColMinWidth += ", 0";                      // 12    OrdUnDelQty";  
            //lColMinWidth += ", 0";                      // 13    Rate";         
            //lColMinWidth += ", 0";                      // 14    Amount";       
            //lColMinWidth += ", 0";                      // 15    AvailBal";     

            // Column Format
            lColFormat = "  T";                        // 0-    ItemID";       
            lColFormat += ", T";                       // 1-    ItemCode";     
            lColFormat += ", T";                       // 2-    ItemName";     
            lColFormat += ", T";                       // 3-    SizeID";       
            lColFormat += ", T";                       // 5-    ColorID";      
            lColFormat += ", T";                       // 6-    UOMID";        
            lColFormat += ",N2";                       // 7-    Discount";     
            //lColFormat += ",N2";                       // 8-    ContQty";      
            //lColFormat += ",N2";                       // 9-    OrdQty";       
            lColFormat += ",N2";                       // 10    ContRemQty";   
            lColFormat += ",N2";                       // 11    Del_Qty";      
            //lColFormat += ",N2";                       // 12    OrdUnDelQty";  
            //lColFormat += ",N2";                       // 13    Rate";         
            //lColFormat += ",N2";                       // 14    Amount";       
            //lColFormat += ",N2";                       // 15    AvailBal";     

            // Column ReadOnly 1= readonly, 0 = read-write
            lColReadOnly = "  0";                       // 0-    ItemID";       
            lColReadOnly += ",1";                       // 1-    ItemCode";     
            lColReadOnly += ",1";                       // 2-    ItemName";     
            lColReadOnly += ",0";                       // 3-    SizeID";       
            lColReadOnly += ",0";                       // 5-    ColorID";      
            lColReadOnly += ",0";                       // 6-    UOMID";        
            lColReadOnly += ",0";                       // 7-    Discount";     
            //lColReadOnly += ",1";                       // 8-    ContQty";      
            //lColReadOnly += ",0";                       // 9-    OrdQty";       
            lColReadOnly += ",1";                       // 10    ContRemQty";   
            lColReadOnly += ",1";                       // 11    Del_Qty";      
            //lColReadOnly += ",1";                       // 12    OrdUnDelQty";  
            //lColReadOnly += ",0";                       // 13    Rate";         
            //lColReadOnly += ",1";                       // 14    Amount";       
            //lColReadOnly += ",1";                       // 15    AvailBal";     

            // For Saving Time
            tColType += "  N0";             // 0-    ItemID";       
            tColType += ",  T";             // 1-    ItemCode";     
            tColType += ",  T";             // 2-    ItemName";     
            tColType += ",  T";             // 3-    SizeID";       
            tColType += ",  T";             // 5-    ColorID";      
            tColType += ",  T";             // 6-    UOMID";        
            tColType += ", N2";             // 7-    Discount";     
            //tColType += ", N2";             // 8-    ContQty";      
            //tColType += ", N2";             // 9-    OrdQty";       
            tColType += ", N2";             // 10    ContRemQty";   
            tColType += ", N2";             // 11    Del_Qty";      
            //tColType += ", N2";             // 12    OrdUnDelQty";  
            //tColType += ", N2";             // 13    Rate";         
            //tColType += ", N2";             // 14    Amount";       
            //tColType += ", N2";             // 15    AvailBal";     

            tFieldName += "Code";               // 0-    ItemID";       
            tFieldName += ",ItemCode";            // 1-    ItemCode";     
            tFieldName += ",ItemName";            // 2-    ItemName";     
            tFieldName += ",SizeName";              // 3-    SizeID";       
            tFieldName += ",ColorName";             // 5-    ColorID";      
            tFieldName += ",UOMID";               // 6-    UOMID";        
            tFieldName += ",Discount";            // 7-    Discount";     
            //tFieldName += ",ContQty";             // 8-    ContQty";      
            //tFieldName += ",OrdQty";              // 9-    OrdQty";       
            tFieldName += ",ContRemQty";          // 10    ContRemQty";   
            tFieldName += ",Del_Qty";             // 11    Del_Qty";      
            //tFieldName += ",OrdUnDelQty";         // 12    OrdUnDelQty";  
            //tFieldName += ",Rate";                // 13    Rate";         
            //tFieldName += ",Amount";              // 14    Amount";       
            //tFieldName += ",AvailBal";            // 15    AvailBal";     


            fHDR = lHDR;
            fColWidth = lColWidth;
            fColMaxInputLen = lColMaxInputLen;
            fColMinWidth = lColMinWidth;
            fColFormat = lColFormat;
            fColReadOnly = lColReadOnly;
            fFieldList = lFieldList;

            fColType = tColType;
            fFieldName = tFieldName;

            //lMask = null;
            //lCboFillType = null;
            //lCboTableKeyField = null;
            //lCboQry = null;         
        }

        private void txtFinishReceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                LookUp_Voc();
            }
        }

        private void txtFinishReceNo_DoubleClick(object sender, EventArgs e)
        {
            LookUp_Voc();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            {
                DataTable SizeSource;
                DataTable SizeGrid;

                DataTable ColorSource;
                DataTable ColorGrid;

                grdGtoG.AutoGenerateColumns = false;

                //tableSource = new DataTable("tableSource");
                //tableSource.Columns.AddRange(new DataColumn[] { new DataColumn("id"), new DataColumn("job") });

                //tableSource.Rows.Add(1, "Manager");
                //tableSource.Rows.Add(2, "Supervisor");
                //tableSource.Rows.Add(3, "Cashier");
                //tableSource.Rows.Add(4, "Officer");
                //tableSource.Rows.Add(5, "Peon");

                //tableGrid = new DataTable("tableGrid");
                //tableGrid.Columns.Add("jobid");
                //tableGrid.Rows.Add(2);

                SizeSource = new DataTable("tableSource");
                SizeSource.Columns.AddRange(new DataColumn[] { new DataColumn("SizeId"), new DataColumn("SizeName") });

                ColorSource = new DataTable("ColorSource");
                ColorSource.Columns.AddRange(new DataColumn[] { new DataColumn("ColorId"), new DataColumn("ColorName") });

                DataSet ds = new DataSet();
                string tSQL = string.Empty;

                tSQL = "SELECT cgdCode, cgdDesc FROM CatDtl WHERE cgCode=" + Convert.ToString((int)Category.enmSize) + ";";
                tSQL += "SELECT cgdCode, cgdDesc FROM CatDtl WHERE cgCode=" + Convert.ToString((int)Category.enmColor) + ";";

                ds = clsDbManager.GetData_Set(tSQL, "CatDtl");

                int count = ds.Tables[0].Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    SizeSource.Rows.Add((int)ds.Tables[0].Rows[i]["cgdCode"], ds.Tables[0].Rows[i]["cgdDesc"].ToString());
                }

                count = ds.Tables[1].Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    ColorSource.Rows.Add((int)ds.Tables[1].Rows[i]["cgdCode"], ds.Tables[1].Rows[i]["cgdDesc"].ToString());
                }

                ds.Dispose();
                ds.Clear();

                SizeGrid = new DataTable("tableGrid");
                SizeGrid.Columns.Add("SizeNameSizeId");
                SizeGrid.Rows.Add(2);

                ColorGrid = new DataTable("ColorGrid");
                ColorGrid.Columns.Add("ColorNameColorId");
                ColorGrid.Rows.Add(2);

                // When it is bound. It does not accept row manually. Evan a blank row is not acceptable.

                DataGridViewTextBoxColumn cTBCode = new DataGridViewTextBoxColumn();
                cTBCode.HeaderText = "Code";
                cTBCode.Width = 100;
                grdGtoG.Columns.Add(cTBCode);


                DataGridViewTextBoxColumn cTBItemCode = new DataGridViewTextBoxColumn();
                cTBItemCode.HeaderText = "ItemCode";
                cTBItemCode.Width = 100;
                grdGtoG.Columns.Add(cTBItemCode);

                DataGridViewTextBoxColumn cTBName = new DataGridViewTextBoxColumn();
                cTBName.HeaderText = "Name";
                cTBName.Width = 100;
                grdGtoG.Columns.Add(cTBName);

                // Combo Box Size
                DataGridViewComboBoxColumn SizeCol = new DataGridViewComboBoxColumn();
                SizeCol.HeaderText = "Size";
                SizeCol.Width = 100;
                SizeCol.DataSource = SizeSource;
                SizeCol.DisplayMember = "SizeName";
                SizeCol.ValueMember = "SizeId";
                SizeCol.DataPropertyName = "SizeNameSizeID";
                grdGtoG.Columns.Add(SizeCol);

                // Combo Box Color
                DataGridViewComboBoxColumn ColorCol = new DataGridViewComboBoxColumn();
                ColorCol.HeaderText = "Color";
                ColorCol.Width = 100;
                ColorCol.DataSource = ColorSource;
                ColorCol.DisplayMember = "ColorName";
                ColorCol.ValueMember = "ColorId";
                ColorCol.DataPropertyName = "ColorNameColorID";
                grdGtoG.Columns.Add(ColorCol);

                DataGridViewTextBoxColumn cTBUOM = new DataGridViewTextBoxColumn();
                cTBUOM.HeaderText = "UOM";
                cTBUOM.Width = 100;
                grdGtoG.Columns.Add(cTBUOM);


                DataGridViewTextBoxColumn cTBGodown = new DataGridViewTextBoxColumn();
                cTBGodown.HeaderText = "From Godown Stock";
                cTBGodown.Width = 100;
                grdGtoG.Columns.Add(cTBGodown);

                DataGridViewTextBoxColumn cTBQty = new DataGridViewTextBoxColumn();
                cTBQty.HeaderText = "Qty";
                cTBQty.Width = 100;
                grdGtoG.Columns.Add(cTBQty);

                DataGridViewTextBoxColumn cTBRate = new DataGridViewTextBoxColumn();
                cTBRate.HeaderText = "To Godown Stock";
                cTBRate.Width = 100;
                grdGtoG.Columns.Add(cTBRate);


                //using JThomas.Controls;
                //DataGridViewMaskedTextColumn mcol = new DataGridViewMaskedTextColumn("00000999");
                //mcol.DataPropertyName = "Number";
                //mcol.HeaderText = "Number";
                //mcol.Name = "Column";
                //mcol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                //mcol.Width = 90;
                //dGrd.Columns.Add(mcol);

            }
        }


    }
}


