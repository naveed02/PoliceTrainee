using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using GUI_Task.Class;

namespace GUI_Task
{
    public partial class frmPassword : Form
    {
        public frmPassword()
        {
            InitializeComponent();
        }

        private void Password_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void SaveData()
        {
            string tSQL = string.Empty;
            string strSaveQry = string.Empty;
            // Fields 0,1,2,3 are Begin  

            tSQL = "SELECT * ";
            tSQL += " FROM Users WHERE UserName = 'Usama'";

            try
            {
                if (clsDbManager.IDAlreadyExistQry(tSQL) == true)
                {
                    //fAlreadyExists = true;
                    strSaveQry = " UPDATE Users ";
                    strSaveQry += " SET Password = '" + txtConfirmPassword.Text.ToString() + "'";

                }

                if (!clsDbManager.ExeOne(strSaveQry))
                {
                    MessageBox.Show("Not Saved see log...", this.Text.ToString());
                    return;
                }
                else
                {
                    MessageBox.Show("Password Updated Successfully...", this.Text.ToString());
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Unable to Change Password...", this.Text.ToString());
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNewPassword.Text) | string.IsNullOrEmpty(this.txtOldPassword.Text) | string.IsNullOrEmpty(this.txtConfirmPassword.Text))
            {
               // MessageBox.Show("Invalid Credentials");
                MessageBox.Show("Invalid Credentials",
                    "Change Password Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }

            else if (txtNewPassword.Text == txtConfirmPassword.Text)
            {
                string lSQL = string.Empty;
                lSQL = "SELECT Password FROM Users WHERE UserName = 'Usama'";

                //clsGetTable.GetDataTable(lSQL);
                //string test = Convert.ToString(clsGetTable.cmd.ExecuteScalar());

                DataSet ds = new DataSet();
                ds = clsDbManager.GetData_Set(lSQL, "Users");

                if (txtOldPassword.Text == ds.Tables[0].Rows[0]["Password"].ToString())
                {
                    SaveData();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Old Password Is Incorrect",
                    "Change Password Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("Passwords Does not Match !");
                this.Close();
            }
        }
    }
}
