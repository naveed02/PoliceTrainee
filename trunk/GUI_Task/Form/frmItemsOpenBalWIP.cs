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
    public partial class frmItemsOpenBalWIP : Form
    {
        int fcboDefaultValue = 0;
        public frmItemsOpenBalWIP()
        {
            InitializeComponent();
        }

        private void Items_Opening_Balance_WIP_Load(object sender, EventArgs e)
       
       
        {
            AtFormLoad();
            // blnFormLoad = false;

        }

        private void AtFormLoad()
        {
            string lSQL = string.Empty;
            //dtpOrder.Value = now.;
            //msk_VocDate.Text = now.Date.ToString();

            this.KeyPreview = true;

            //Emp Code Combo Fill
            lSQL = "SELECT employeeid, first_name +' '+ last_name AS EmpName FROM PR_Employee ";
       //     lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboEmployee, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboEmployee.SelectedValue);
            
            //Item group cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmItemGroup);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboItemGroup, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboItemGroup.SelectedValue);

            //Purpose cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmPurpose);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboPurpose, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboPurpose.SelectedValue);

            //Machine cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmMachineNo);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboMachine, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboMachine.SelectedValue);

            //Contractor cOMBO
            lSQL = "select cgdCode, cgdDesc from catdtl where cgcode=" + Convert.ToString((int)Category.enmContractor);
            lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboContractor, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboContractor.SelectedValue);

            //dEPARTMENT Combo Fill
            lSQL = "SELECT departmentid, department_name FROM PR_Department";
            //lSQL += " order by cgdDesc";

            clsFillCombo.FillCombo(cboDepartment, clsGVar.ConString1, "CatDtl" + "," + "cgdCode" + "," + "False", lSQL);
            fcboDefaultValue = Convert.ToInt16(cboDepartment.SelectedValue);

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
