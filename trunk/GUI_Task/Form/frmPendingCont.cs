using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI_Task
{
    public partial class frmPendingCont : Form
    {
        int fcboDefaultValue=0;
        public frmPendingCont()

        {
            InitializeComponent();
        }

        private void frm_pending_Contracts_Load(object sender, EventArgs e)
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
            //dtpOrder.Value = now.;
            //msk_VocDate.Text = now.Date.ToString();

            this.KeyPreview = true;
            //SetMaxLen();
            //SetToolTips();
            //LoadInitialControls();
            ////btn_EnableDisable(false);
            //sSMaster.Visible = false;
            //msk_VocDate.Text = DateTime.Now.ToString();

            //ButtonImageSetting();
            //fFirstTableName = "cmn_Transport";
            //fFirstKeyField = "Transport_ID";

            //lSQL = "select * from " + fFirstTableName;
            //lSQL += " order by ordering";

            //clsFillCombo.FillCombo(cboTransport, clsGVar.ConString1, fFirstTableName + "," + fFirstKeyField + "," + "False", lSQL);
            //fcboDefaultValue = Convert.ToInt16(cboTransport.SelectedValue);

            ////UOM Combo Fill
            //lSQL = "select * from " + "Gds_UOM";
            //lSQL += " order by ordering";

            //clsFillCombo.FillCombo(cbo_UOM, clsGVar.ConString1, "Gds_UOM" + "," + "GoodsUOM_ID" + "," + "False", lSQL);
            //fcboDefaultValue = Convert.ToInt16(cbo_UOM.SelectedValue);

            //Main Group Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=15";
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboMainGrp, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboMainGrp.SelectedValue);

            //Item Combo Fill
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=6";
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGrp, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGrp.SelectedValue);
        }

        private void frmPendingCont_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
