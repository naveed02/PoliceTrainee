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
    public partial class frmRptUser : Form
    {
        int fcboDefaultValue = 0;
        public frmRptUser()
        {
            InitializeComponent();
        }

        private void user_Entry_Report_Load(object sender, EventArgs e)
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


            //Status Combo Fill
            lSQL = "Select 1,'Running' Union Select 2,'Complete'";

            clsFillCombo.FillCombo(cboStatus, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboStatus.SelectedValue);

        }
    }
    }

