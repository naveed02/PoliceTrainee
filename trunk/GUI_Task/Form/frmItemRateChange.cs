
﻿using System;
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
    public partial class frmItemRateChange : Form
    {
        int fcboDefaultValue = 0;
        public frmItemRateChange()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmItemrateChangeopt_Load(object sender, EventArgs e)
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
            //Category Combo Fill
            lSQL = "SELECT DISTINCT 1,RIGHT(Itemcode,1) FROM Item ";
            //lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboCategory, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboCategory.SelectedValue);

        }
    }
}
﻿